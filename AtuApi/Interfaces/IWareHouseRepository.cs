using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IWareHouseRepository : IRepository<WareHouse>
    {
        WareHouse GetWareHouse(string wareHouseCode);
        IEnumerable<WareHouse> GetWareHouses();
    }
}
