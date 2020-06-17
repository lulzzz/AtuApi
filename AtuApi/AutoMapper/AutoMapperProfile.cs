using AtuApi.Dtos;
using AtuApi.Interfaces;
using AtuApi.Models;
using AutoMapper;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

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
                        src => src.ApprovalsEmployees.Select(appr => appr.EmployeeCode).ToList())); ;
        }
    }
}
