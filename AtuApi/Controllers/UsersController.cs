using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AtuApi.Dtos;
using AtuApi.Interfaces;
using AtuApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Authenticate(userName, password);

            if (user == null)
                return Unauthorized();

            List<Claim> claims = new List<Claim>();
            Claim claim = new Claim("tepe", "value") { };

            var keyBytes = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var key = new SymmetricSecurityKey(keyBytes);
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var signInCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken("", "", claims, DateTime.Now, DateTime.Now.AddHours(1), signInCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            var userPrincipal = new ClaimsPrincipal(new[] { new ClaimsIdentity(claims) });
            HttpContext.SignInAsync(userPrincipal);
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);
            var userCreator = _unitOfWork.UserRepository.Get(int.Parse(User.Identity.Name));
            var creatorRole = userCreator.Role.RoleName;


            Role role = _unitOfWork.RoleRepository.Get(userDto.RoleId);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);

            user.Role = role;
            user.Branch = branch;

            var creatingRole = user.Role.RoleName;

            if (creatingRole == "Admin" && creatorRole != "Admin")
            { 
                return BadRequest("არავალიდური ქმედება");
            }

            try
            {
                // save 
                var userInDb = _unitOfWork.UserRepository.Create(user, userDto.Password);
                return Accepted(userInDb.Id);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }

        }
    }
}