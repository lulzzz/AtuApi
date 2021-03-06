﻿using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class PurchaseRequestRepository : Repository<PurchaseRequest>, IPurchaseRequestRepository
    {
        public PurchaseRequestRepository(DataContext context) : base(context)
        {

        }

        IEnumerable<PurchaseRequest> IRepository<PurchaseRequest>.GetAll()
        {
            return PurchaseRequestContext.PurchaseRequests.Include(x => x.Rows).ToList();
        }

        public new IEnumerable<PurchaseRequest> FindAll(Expression<Func<PurchaseRequest, bool>> predicate)
        {
            return PurchaseRequestContext.PurchaseRequests.Include(x => x.Rows).Where(predicate).Include(x => x.ObjctType).ToList();
        }

        public new PurchaseRequest Get(int id)
        {
            return PurchaseRequestContext.PurchaseRequests.Include(x => x.Rows).Include(x => x.Creator).FirstOrDefault(y => y.DocNum == id);
        }

        private DataContext PurchaseRequestContext => Context as DataContext;

    }
}
