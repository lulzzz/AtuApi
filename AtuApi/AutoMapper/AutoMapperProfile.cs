 
using AtuApi.Models;
using AutoMapper;
using DataModels.Dtos;
using DataModels.Models;
using DataModels.RequestDtos;
using DataModels.ResponseDtos;
using System.Collections.Generic;
using System.Linq;


namespace AtuApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDtoRequest>();
            CreateMap<UserDtoRequest, User>();

            CreateMap<User, UserDtoResponse>().ForMember(
                    des => des.Permissions,
                    opts => opts.MapFrom(
                        src => src.Role.PermissionRoles.Select(x=>x.Permissions)));
            CreateMap<UserDtoResponse, User>();



            CreateMap<PurchaseRequest, PurchaseRequestDto>();

            CreateMap<PurchaseRequestDto, PurchaseRequest>()
                .ForMember(des => des.Employee, opts => opts.Ignore());

            CreateMap<PurchaseRequestRowDto, PurchaseRequestRow>();
            CreateMap<PurchaseRequestRow, PurchaseRequestRowDto>();

            CreateMap<ApprovalTemplateDto, ApprovalTemplate>()
                .ForMember(
                     dest => dest.ApprovalsEmployees,
                     opts => opts.MapFrom(
                         src => src.ApprovalEmployees.Select(pr => new ApprovalsEmployees
                         {
                             EmployeeCode = pr,
                         }
                         )))
                .ForMember(dest => dest.TemplateCode, opts => opts.Ignore());
            CreateMap<ApprovalTemplate, ApprovalTemplateDto>()
                .ForMember(
                    des => des.ApprovalEmployees,
                    opts => opts.MapFrom(
                        src => src.ApprovalsEmployees.Select(appr => appr.EmployeeCode).ToList()));

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();

            CreateMap<Role, RoleDto>().ForMember(
                des => des.Permissions,
                opt => opt.MapFrom(
                    src => src.PermissionRoles.Select(x => x.Permissions)));

            CreateMap<RoleDto, Role>();





        }
    }
}
