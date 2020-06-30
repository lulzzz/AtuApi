using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
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

            var role = user.Role;
            var permissionsRoles = role.PermissionRoles;

            var Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role.Id.ToString())
            });


            foreach (var permissionsRole in permissionsRoles.Select(x => x.Permissions).Distinct())
            {
                Claim claim = new Claim(permissionsRole.PermissionName, "xuevoznaet");
                Subject.AddClaim(claim);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Subject,
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
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
        [Authorize(Policy = "CanCreateUsers")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creatorRole = userCreator.Role.RoleName;

            Role role = _unitOfWork.RoleRepository.Get(userDto.RoleId);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);

            if (role == null)
            {
                return UnprocessableEntity("ასეთი როლი არ არსებობს");
            }
            if (branch == null)
            {
                branch = _unitOfWork.BranchesRepository.Get(-1);
            }

            user.Role = role;
            user.Branch = branch;

            var creatingRole = user.Role.RoleName;

            if (creatingRole == "Admin" && creatorRole != "Admin")
            {
                return BadRequest("არავალიდური ქმედება (Creating Admin From Non Admin User)");
            }

            try
            {
                var userInDb = _unitOfWork.UserRepository.Create(user, userDto.Password);
                return Accepted(userInDb.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadUsers")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [Authorize(Policy = "CanReadUsers")]
        [HttpGet]
        public IActionResult GetByAll()
        {
            var xz = User.Identity;
            var users = _unitOfWork.UserRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            Request.HttpContext.Response.Headers.Add("Total-Count", users.Count().ToString());

            return Ok(usersDto);
        }

        [Authorize(Policy = "CanModifyUsers")]
        [HttpPut]
        public IActionResult Update([FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var userToBeUpdatedInDb = _unitOfWork.UserRepository.GetById(userDto.Id);
            if (userToBeUpdatedInDb == null)
            {
                return BadRequest("მომხმარებელი ვერ მოიძებნა");
            }
            var userToBeUpdated = _mapper.Map<User>(userDto);

            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creatorRole = userCreator.Role.RoleName;
            Role role = _unitOfWork.RoleRepository.Get(userDto.RoleId);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);
            if (role == null)
            {
                return UnprocessableEntity("ასეთი როლი არ არსებობს");
            }
            if (branch == null)
            {
                branch = _unitOfWork.BranchesRepository.Get(-1);
            }

            userToBeUpdated.Branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);
            userToBeUpdated.Role = _unitOfWork.RoleRepository.Get(userDto.RoleId);

            var creatingRole = userToBeUpdated.Role.RoleName;
            bool isHimself = userCreator.Id == userToBeUpdated.Id;

            if (creatingRole == "Admin" && creatorRole != "Admin")
            {
                return BadRequest("არავალიდური ქმედება (Updating Admin From Non Admin User)");
            }



            try
            {
                // save
                _unitOfWork.UserRepository.Update(userToBeUpdated, userDto.Password);
                return Accepted();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}