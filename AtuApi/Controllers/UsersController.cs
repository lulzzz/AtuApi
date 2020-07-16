﻿using System;
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
    [Route("api/[controller]/[action]")]
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
        [HttpPost]
        public IActionResult AuthenticateFacebook()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
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

        [HttpPost]
        [Authorize(Policy = "CanCreateUsers")]
        public IActionResult Register([FromBody]UserDtoRequest userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creatorRole = userCreator.Role.RoleName;

            Role role = _unitOfWork.RoleRepository.Get(userDto.RoleId);
            Branch branch = _unitOfWork.BranchesRepository.Get(userDto.BranchId);
            Employee employee = _unitOfWork.EmployeeRepository.GetEmployee(userDto.SapEmployeeId);
            if (employee == null)
            {
                return UnprocessableEntity("ასეთი Employee არ არსებობს");
            }

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
        public IActionResult GetAll()
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
            Employee employee = _unitOfWork.EmployeeRepository.GetEmployee(userDto.SapEmployeeId);
            if (employee == null)
            {
                return UnprocessableEntity("ასეთი Employee არ არსებობს");
            }

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
            userToBeUpdated.SapEmployeeId = employee.EmpId;
            //userToBeUpdated.ApprovalTemplate = temlate;

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

        [HttpGet]
        public IActionResult GetDocsStatus()
        {
            List<DocumentStatusesResponse> res = new List<DocumentStatusesResponse>();
            var user = _unitOfWork.UserRepository.GetById(2);
            var NotificationsHistoryGrouped = _unitOfWork.NotificationHistoryRepository.FindAll(x => x.OrignatorId == user.Id).GroupBy(x => x.DocId);

            foreach (var NotificationsHistoryDoc in NotificationsHistoryGrouped)
            {

                List<DocumentStatusesResponse> resTemp = new List<DocumentStatusesResponse>();
                DocumentTypeResponseDto ObjetType = _mapper.Map<DocumentTypeResponseDto>(NotificationsHistoryDoc.First().ObjectType);
                foreach (var notification in NotificationsHistoryDoc)
                {
           
                    if (notification.ApproverStatus == "Rejected")
                    {
                        resTemp.Add(new DocumentStatusesResponse
                        {
                            DocId = NotificationsHistoryDoc.Key,
                            Status = "Rejected",
                            ObjetType = ObjetType
                        });
                        break;
                    }
                    if (notification.ApproverStatus == "NoAction")
                    {
                        resTemp.Add(new DocumentStatusesResponse
                        {
                            DocId = NotificationsHistoryDoc.Key,
                            Status = "Pending",
                            ObjetType = ObjetType
                        });
                        break;
                    }
                }
                if (resTemp.Count < 1)
                {
                    resTemp.Add(new DocumentStatusesResponse
                    {
                        DocId = NotificationsHistoryDoc.Key,
                        Status = "Approved",
                        ObjetType = ObjetType
                    });
                }
                res.AddRange(resTemp);
            }
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetPendingNotifications()
        {
            List<NotificationsHistory> userNotifications = new List<NotificationsHistory>();
            var user = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            List<NotificationsHistory> NotificationsList = _unitOfWork.NotificationHistoryRepository.FindAll(x => x.ApproverId == user.Id).ToList();
            foreach (var notification in NotificationsList)
            {
                var notificationsByDoc = _unitOfWork.NotificationHistoryRepository.FindAll(x => x.DocId == notification.DocId).ToList();
                var orderedNotificationsByDoc = notificationsByDoc.OrderBy(x => x.Level);
                foreach (var n in orderedNotificationsByDoc)
                {
                    if (n.ApproverId == user.Id)
                    {
                        if (n.ApproverStatus == "NoAction")
                        {
                            userNotifications.Add(n);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (n.ApproverStatus == "NoAction" || n.ApproverStatus == "Rejected")
                    {
                        break;
                    }

                }
            }
            var userNotificationsDto = _mapper.Map<IList<NotificationsHistoryDto>>(userNotifications);
            return Ok(userNotificationsDto);
        }

        [HttpPost]
        public IActionResult ApprovePendingNotification(int NotificationId)
        {
            var notiication = _unitOfWork.NotificationHistoryRepository.Get(NotificationId);
            notiication.ApproverStatus = "Approved";
            notiication.WatchStatus = "Opend";
            _unitOfWork.NotificationHistoryRepository.Update(notiication);
            return Accepted();
        }

        [HttpPost]
        public IActionResult RejectPendingNotification(int NotificationId, string Comment)
        {
            var notification = _unitOfWork.NotificationHistoryRepository.Get(NotificationId);
            notification.ApproverStatus = "Rejected";
            notification.Comment = Comment;
            notification.WatchStatus = "Opend";
            _unitOfWork.NotificationHistoryRepository.Update(notification);
            if (notification.ObjectType.DocDescription == "PurchaseRequest")
            {
                var pr = _unitOfWork.PurchaseRequestRepository.Get(notification.DocId);
                pr.Status = "Rejected";
                _unitOfWork.PurchaseRequestRepository.Update(pr);
            }
            return Accepted();
        }
    }
}