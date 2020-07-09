﻿
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
                        src => src.Role.PermissionRoles.Select(x => x.Permissions)));
            CreateMap<UserDtoResponse, User>();



            CreateMap<PurchaseRequest, PurchaseRequestDto>();
                //.ForMember(des => des.Rows, opts => opts.MapFrom(src=>src.Rows));

            CreateMap<PurchaseRequestDto, PurchaseRequest>()
                .ForMember(des => des.Employee, opts => opts.Ignore());

            CreateMap<PurchaseRequestRowDto, PurchaseRequestRow>();
            CreateMap<PurchaseRequestRow, PurchaseRequestRowDto>();


            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();

            CreateMap<Role, RoleDto>().ForMember(
                des => des.Permissions,
                opt => opt.MapFrom(
                    src => src.PermissionRoles.Select(x => x.Permissions)));

            CreateMap<RoleDto, Role>();



            CreateMap<ApprovalTemplateRequestDto, ApprovalTemplate>()
                 .ForMember(
                      dest => dest.ApprovalsEmployees,
                      opts => opts.MapFrom(
                          src => src.ApprovalEmployees.Select(pr => new ApprovalsEmployees
                          {
                              UserId = pr,
                          }
                          )))
                 .ForMember(dest => dest.TemplateCode, opts => opts.Ignore())
                 .ForMember(dest => dest.UsersAppovalTemplates, opts => opts.MapFrom(
                       src => src.Users.Select(ua => new UsersAppovalTemplate { UserId = ua })))
                 .ForMember(src => src.ApprovalsDocumentTypes, opts => opts.MapFrom(
                       src => src.DocumentTypes.Select(appD => new ApprovalsDocumentType { DocumentTypeId = appD })));



            CreateMap<ApprovalTemplate, ApprovalTemplateResponseDto>()
                .ForMember(
                    des => des.ApprovalEmployees,
                    opts => opts.MapFrom(
                        src => src.ApprovalsEmployees.Select(appr => appr.User).ToList()))
                .ForMember(
                  des => des.Users,
                  opts => opts.MapFrom(
                      src => src.UsersAppovalTemplates.Select(usr => usr.User)))
                .ForMember(
                  des => des.DocumentTypes,
                  opts => opts.MapFrom(
                      src => src.ApprovalsDocumentTypes.Select(usr => usr.DocumentType)));

            CreateMap<DocumentType, DocumentTypeResponseDto>();

        }
    }
}
