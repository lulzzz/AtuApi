using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using AtuApi.Interfaces;
using AtuApi.Models;
using AutoMapper;
using DataModels.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RolesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetRoles()
        {
            IEnumerable<Role> Roles = _unitOfWork.RoleRepository.GetAll();

            IList<RoleDto> RolesDto = _mapper.Map<IList<RoleDto>>(Roles);

            Request.HttpContext.Response.Headers.Add("Total-Count", Roles.Count().ToString());

            return Ok(RolesDto);

        }


        [HttpGet("{id}")]
        public IActionResult GetRoles(int id)
        {
            Role Roles = _unitOfWork.RoleRepository.Get(id);

            RoleDto RolesDto = _mapper.Map<RoleDto>(Roles);

            if (RolesDto == null)
            {
                return NotFound();
            }

            return new ObjectResult(RolesDto)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }


        [HttpPost]
        public IActionResult CreateRoles(RoleDto roleDto)
        {
            Role roleInDb = _unitOfWork.RoleRepository.Find(r => r.RoleName == roleDto.RoleName);
            if (roleInDb != null)
            {
                return Conflict();
            }

            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creartorRoleId = userCreator.RoleId;
            var creartorRole = _unitOfWork.RoleRepository.Get(creartorRoleId);
            var role = _mapper.Map<Role>(roleDto);

            var creartorRoleDto = _mapper.Map<RoleDto>(creartorRole);
            var creartorPermissions = creartorRoleDto.Permissions;
            var RoleToaddedPermissions = roleDto.Permissions;

            var RoleToaddedPermissionsIds = RoleToaddedPermissions.Select(i => i.Id);
            var creartorPermissionsIds = creartorPermissions.Select(i => i.Id);
            bool isSubset = !RoleToaddedPermissionsIds.Except(creartorPermissionsIds).Any();

            if (!isSubset)
            {
                return Forbid();
            }



            List<PermissionRoles> permissionRoles = new List<PermissionRoles>();
            foreach (var permission in roleDto.Permissions)
            {
                var permissionRole = new PermissionRoles { PermissionId = permission.Id, RoleId = roleDto.Id };
                permissionRoles.Add(permissionRole);
            }

            role.PermissionRoles = permissionRoles;

            var addedRole = _unitOfWork.RoleRepository.Add(role);
            var action = CreatedAtAction(nameof(GetRoles), new { id = addedRole.Id }, addedRole.Id);
            return action;

        }

        [HttpPut]
        public IActionResult UpdateRoles(RoleDto roleDto)
        {
            bool hasPermissions = roleDto.Permissions != null;

            var userCreator = _unitOfWork.UserRepository.GetById(int.Parse(User.Identity.Name));
            var creartorRole = _unitOfWork.RoleRepository.Get(userCreator.RoleId);
            var UpdateRole = _mapper.Map<Role>(roleDto);
            var roleInDb = _unitOfWork.RoleRepository.Get(UpdateRole.Id);
            var creartorRoleDto = _mapper.Map<RoleDto>(creartorRole);
            var creartorPermissions = creartorRoleDto.Permissions;
            var RoleToaddedPermissions = roleDto.Permissions;

            var RoleToaddedPermissionsIds = RoleToaddedPermissions?.Select(i => i.Id);
            var creartorPermissionsIds = creartorPermissions?.Select(i => i.Id);
            bool isSubset;

            if (!hasPermissions)
            {
                isSubset = true;
            }
            else
            {
                isSubset = !RoleToaddedPermissionsIds.Except(creartorPermissionsIds).Any();
                List<PermissionRoles> permissionRoles = new List<PermissionRoles>();
                foreach (var permission in roleDto.Permissions)
                {
                    var permissionRole = new PermissionRoles { PermissionId = permission.Id, RoleId = roleInDb.Id };
                    permissionRoles.Add(permissionRole);
                }
                roleInDb.PermissionRoles = permissionRoles;
            }

            if (!isSubset)
            {
                return Forbid();
            }
            if (roleInDb.RoleName == "Admin")
            {
                return Forbid();
            }
            roleInDb.RoleName = roleDto.RoleName;
            _unitOfWork.RoleRepository.Update(roleInDb);
            RoleDto RolesDto = _mapper.Map<RoleDto>(roleInDb);
            return Accepted(RolesDto);

        }


        [HttpDelete]
        public IActionResult DeleteRoles(int id)
        {
            var RolesInDb = _unitOfWork.RoleRepository.Get(id);
            if (RolesInDb == null)
            {
                return NotFound();
            }

            _unitOfWork.RoleRepository.Remove(RolesInDb);

            return new ObjectResult(RolesInDb)
            {
                StatusCode = (int)HttpStatusCode.Accepted
            };
        }
    }
}