using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AtuApi.Dtos;
using AtuApi.Interfaces;
using AtuApi.Models;

using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            User user = _mapper.Map<User>(userDto);

            if (User.Identity.Name == null)
            {
                return Unauthorized();
            }
            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));



            Role role = _unitOfWork.RoleRepository.Get(userDto.Role.Id);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.Branch.Id);


            user.Branches = branch;




            try
            {
                // save 
                var userInDb = _unitOfWork.UserRepository.Create(user, userDto.Password);
                return Accepted(user.Id);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
    }
}