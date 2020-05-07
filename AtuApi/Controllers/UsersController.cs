using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Dtos;
using AtuApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userName, string password)
        {
            var user = _userService.Authenticate(userName, password);

            if (user == null)
                return Unauthorized();

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString()),
            //        new Claim("Roles", user.Roles.Role)
            //    }),
            //    Expires = DateTime.UtcNow.AddYears(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);



            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Token = tokenString
            });
        }
    }
}