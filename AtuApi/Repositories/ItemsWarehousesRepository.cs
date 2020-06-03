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
    public class ItemsWarehousesRepository : Repository<ItemsWarehouses>, IItemsWarehousesRepository
    {
        IDiManager _diManager;
        public ItemsWarehousesRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        private DataContext ItemsWarehousesContext => Context as DataContext;

        public ItemsWarehouses GetItemQuantityInWarehouse(string itemCode, string wareHouseCode)
        {
            return _diManager.GetItemQuantityInWareHouse(itemCode, wareHouseCode);
        }

        public ItemsWarehouses GetItemQuantityWarehouses(string itemCode)
        {
            return _diManager.GetItemTotalQuantity(itemCode);
        }
    }
}
