using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Dtos;
using DataModels.Models;
using DataModels.RequestDtos;
using DataModels.ResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalTemplatesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApprovalTemplatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateApprovalTemplate(ApprovalTemplateRequestDto approvalTemplateDto)
        {
            var templateInDb = _unitOfWork.ApprovalTemplateRepository.Find(x => x.TemplateName == approvalTemplateDto.TemplateName);
            if (templateInDb != null)
            {
                return Conflict($"დადასტურების შაბლონის სახელით : {approvalTemplateDto.TemplateName} უკვე არსებობს");
            }
            var approvalTemplate = _mapper.Map<ApprovalTemplate>(approvalTemplateDto);
            var result = _unitOfWork.ApprovalTemplateRepository.Add(approvalTemplate);
            _unitOfWork.SaveChanges();
            return Ok(result.TemplateCode);
        }

        [HttpGet]
        public IActionResult GetApprovalTemplates()
        {
            var approvalTemplates = _unitOfWork.ApprovalTemplateRepository.GetAll();
            var approvalTemplateDtos = _mapper.Map<IEnumerable<ApprovalTemplateResponseDto>>(approvalTemplates);
            Request.HttpContext.Response.Headers.Add("Total-Count", approvalTemplates.Count().ToString());
            return Ok(approvalTemplateDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetApprovalTemplates(int id)
        {
            ApprovalTemplate approvalTemplate = _unitOfWork.ApprovalTemplateRepository.Get(id);
            var approvalTemplateDto = _mapper.Map<ApprovalTemplateResponseDto>(approvalTemplate);
            return Ok(approvalTemplateDto);
        }


        [HttpPut]
        public IActionResult UpdateApprovalTemplate(ApprovalTemplateRequestDto approvalTemplateDto)
        {
            var approvalTemplate = _mapper.Map<ApprovalTemplate>(approvalTemplateDto);
            var template = _unitOfWork.ApprovalTemplateRepository.Get(approvalTemplateDto.TemplateCode);
            template.IsActive = approvalTemplate.IsActive;
            template.TemplateName = approvalTemplate.TemplateName;
            template.ApprovalsEmployees = approvalTemplate.ApprovalsEmployees;
            template.UsersAppovalTemplates = approvalTemplate.UsersAppovalTemplates;
            template.ApprovalsDocumentTypes = approvalTemplate.ApprovalsDocumentTypes;
            _unitOfWork.ApprovalTemplateRepository.Update(template);

            _unitOfWork.SaveChanges();
            return Ok();
        }

    }
}