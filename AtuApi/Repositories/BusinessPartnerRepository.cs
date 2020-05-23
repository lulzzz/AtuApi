using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Iterfaces;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class BusinessPartnerRepository : Repository<BusinessPartner>, IBusinessPartnerRepository
    {
        IDiManager _diManager;

        public BusinessPartnerRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }
        public BusinessPartner GetBusinessPartner(string cardCode)
        {
           return _diManager.GetBusinessPartner(cardCode);
        }

        public IEnumerable<BusinessPartner> GetBusinessPartners()
        {
            return _diManager.GetBusinessPartners();
        }
        private DataContext BusinessPartnerContext => Context as DataContext;
    }
}
