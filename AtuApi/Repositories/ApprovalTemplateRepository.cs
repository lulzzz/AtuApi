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



        private DataContext ApprovalTemplateContext => Context as DataContext;

  
    }
}
