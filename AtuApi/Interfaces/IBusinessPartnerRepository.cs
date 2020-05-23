using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IBusinessPartnerRepository : IRepository<BusinessPartner>
    {
        BusinessPartner GetBusinessPartner(string cardCode);
        IEnumerable<BusinessPartner> GetBusinessPartners();
    }
}
