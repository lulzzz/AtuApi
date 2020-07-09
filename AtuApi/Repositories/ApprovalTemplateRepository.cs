 
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
            return ApprovalTemplateContext.ApprovalTemplates.Include(x => x.UsersAppovalTemplates).ThenInclude(x => x.User).Include(x => x.ApprovalsEmployees).ThenInclude(x => x.User).Include(x => x.ApprovalsDocumentTypes).ThenInclude(x => x.DocumentType).ToList();
        }

        public new ApprovalTemplate Get(int id)
        {
            return ApprovalTemplateContext.ApprovalTemplates.Include(x => x.UsersAppovalTemplates).ThenInclude(x=>x.User).Include(x => x.ApprovalsEmployees).ThenInclude(x=>x.User).Include(x => x.ApprovalsDocumentTypes).ThenInclude(x=>x.DocumentType).FirstOrDefault(x=>x.TemplateCode == id);
        }

        private DataContext ApprovalTemplateContext => Context as DataContext;


    }
}
