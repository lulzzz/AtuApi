using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Dtos;
using AtuApi.Interfaces;
using AutoMapper;
using DataModels.Models;
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
        public IActionResult CreateApprovalTemplate(ApprovalTemplateDto approvalTemplateDto)
        {
            var approvalTemplate = _mapper.Map<ApprovalTemplate>(approvalTemplateDto);
            var result = _unitOfWork.ApprovalTemplateRepository.Add(approvalTemplate);
            return Ok(result.TemplateCode);
        }

        [HttpGet]
        public IActionResult GetApprovalTemplates()
        {
            var approvalTemplates = _unitOfWork.ApprovalTemplateRepository.GetAll();
            var approvalTemplateDtos = _mapper.Map<IEnumerable<ApprovalTemplateDto>>(approvalTemplates);
            return Ok(approvalTemplateDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetApprovalTemplates(int id)
        {
            var approvalTemplate = _unitOfWork.ApprovalTemplateRepository.Get(id);
            var approvalTemplateDto = _mapper.Map<ApprovalTemplateDto>(approvalTemplate);
            return Ok(approvalTemplateDto);
        }

        
        [HttpPut]
        public IActionResult UpdateApprovalTemplate(ApprovalTemplateDto approvalTemplateDto)
        {
            var approvalTemplate = _mapper.Map<ApprovalTemplate>(approvalTemplateDto);
            var template = _unitOfWork.ApprovalTemplateRepository.Get(approvalTemplateDto.TemplateCode);
            template.IsActive = approvalTemplate.IsActive;
            template.TemplateName = approvalTemplate.TemplateName;
            template.ApprovalsEmployees = approvalTemplate.ApprovalsEmployees;
            _unitOfWork.ApprovalTemplateRepository.Update(template);
            return Ok();
        }

    }
}