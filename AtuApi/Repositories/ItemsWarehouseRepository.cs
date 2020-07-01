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
    public class ItemsWarehouseRepository : Repository<ItemsWarehouses>, IItemsWarehousesRepository
    {
        IDiManager _diManager;
        public ItemsWarehouseRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        private DataContext ItemsWarehousesContext => Context as DataContext;

        public ItemsWarehouses GetItemInfoInWareHouse(string itemCode, string wareHouseCode)
        {
            return _diManager.GetItemInfoInWareHouse(itemCode, wareHouseCode);
        }

        public ItemsWarehouses GetItemInfoWarehouses(string itemCode)
        {
            return _diManager.GetItemTotalInfo(itemCode);
        }
    }
}
