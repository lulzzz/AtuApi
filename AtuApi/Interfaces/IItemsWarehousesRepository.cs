using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IItemsWarehousesRepository : IRepository<ItemsWarehouses>
    {
        ItemsWarehouses GetItemQuantityWarehouses(string itemCode);
        ItemsWarehouses GetItemQuantityInWarehouse(string itemCode, string wareHouseCode);
    }
}
