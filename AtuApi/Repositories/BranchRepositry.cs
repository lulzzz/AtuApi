using AtuApi.Interfaces;
using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContextHelper;

namespace AtuApi.Repositories
{
    public class BranchRepositry : Repository<Branch>, IBranchRepository
    {
        public BranchRepositry(DataContext context) : base(context)
        {

        }

        private DataContext BranchContext => Context as DataContext;



    }
}
