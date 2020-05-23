using AtuApi.Controllers;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{

    public interface IItemRepository : IRepository<Item>
    {
        Item GetItem(string itemCode);
        IEnumerable<Item> GetItems();
    }
}
