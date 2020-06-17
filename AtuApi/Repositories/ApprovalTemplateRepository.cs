using AtuApi.Dtos;
using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class ApprovalTemplateRepository : Repository<ApprovalTemplate>, IApprovalTemplateRepository
    {

        public ApprovalTemplateRepository(DataContext context) : base(context)
        {

        }

        public new IEnumerable<ApprovalTemplate> GetAll()
        {
            return ApprovalTemplateContext.ApprovalTemplates.Include(x => x.ApprovalsEmployees).ToList();
        }

        public new ApprovalTemplate Get(int id)
        {
            return ApprovalTemplateContext.ApprovalTemplates.Include(x => x.ApprovalsEmployees).FirstOrDefault(x=>x.TemplateCode == id);
        }

        private DataContext ApprovalTemplateContext => Context as DataContext;


    }
}
