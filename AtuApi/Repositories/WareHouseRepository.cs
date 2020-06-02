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
    public class WareHouseRepository : Repository<WareHouse>, IWareHouseRepository
    {
        private IDiManager _diManager;
        public WareHouseRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        public WareHouse GetWareHouse(string wareHouseCode)
        {
            return _diManager.GetWareHouse(wareHouseCode);
        }

        public IEnumerable<WareHouse> GetWareHouses()
        {
            return _diManager.GetWareHouses();
        }
    }
}
