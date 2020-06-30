using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using AtuApi.Interfaces;
using AtuApi.Models;
using AutoMapper;
using DataModels.Dtos;
using DataModels.Models;
using DataModels.RequestDtos;
using DataModels.ResponseDtos;
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

            var userDto = _mapper.Map<UserDtoResponse>(user);

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
                userDto,
                Token = tokenString
            });
        }

        [HttpPost("Register")]
        [Authorize(Policy = "CanCreateUsers")]
        public IActionResult Register([FromBody]UserDtoRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creatorRole = userCreator.Role.RoleName;

            Role role = _unitOfWork.RoleRepository.Get(userDto.RoleId);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);
            ApprovalTemplate approvalTemplate = _unitOfWork.ApprovalTemplateRepository.Get(userDto.ApprovalTemplateCode);

            if (role == null)
            {
                return UnprocessableEntity("ასეთი როლი არ არსებობს");
            }
            if (branch == null)
            {
                branch = _unitOfWork.BranchesRepository.Get(-1);
            }
            if (approvalTemplate == null)
            {
                user.ApprovalTemplateCode = -1;
            }

            user.Role = role;
            user.Branch = branch;
            user.ApprovalTemplate = approvalTemplate;

            var creatingRole = user.Role.RoleName;

            if (creatingRole == "Admin" && creatorRole != "Admin")
            {
                return BadRequest("არავალიდური ქმედება (Creating Admin From Non Admin User)");
            }

            try
            {
                var userInDb = _unitOfWork.UserRepository.Create(user, userDto.Password);
                return CreatedAtAction(nameof(GetById), new { id = userInDb.Id }, userInDb.Id);
                 
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
            var user = _unitOfWork.UserRepository.GetById(id);
            var userDto = _mapper.Map<UserDtoResponse>(user);
            return Ok(userDto);
        }

        [Authorize(Policy = "CanReadUsers")]
        [HttpGet]
        public IActionResult GetByAll()
        {
            var xz = User.Identity;
            var users = _unitOfWork.UserRepository.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDtoResponse>>(users);
            Request.HttpContext.Response.Headers.Add("Total-Count", users.Count().ToString());

            return Ok(usersDto);
        }

        [Authorize(Policy = "CanModifyUsers")]
        [HttpPut]
        public IActionResult Update([FromBody]UserDtoRequest userDto)
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
            ApprovalTemplate temlate = _unitOfWork.ApprovalTemplateRepository.Get(userDto.ApprovalTemplateCode);
            if (role == null)
            {
                return UnprocessableEntity("ასეთი როლი არ არსებობს");
            }
            if (branch == null)
            {
                branch = _unitOfWork.BranchesRepository.Get(-1);
            }
            

            userToBeUpdated.Branch = branch;
            userToBeUpdated.Role = role;
            userToBeUpdated.ApprovalTemplate = temlate;

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