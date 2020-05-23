using AtuApi.Interfaces;
using DataContextHelper;
using DataModels;
using DataModels.Iterfaces;
using System;
using System.Collections.Generic;

namespace AtuApi.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        IDiManager _diManager;
        public ItemRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }
        public Item GetItem(string itemCode)
        {
            return _diManager.GetItem(itemCode);
        }

        public IEnumerable<Item> GetItems()
        {
            return _diManager.GetItems();
        }

        private DataContext ItemContext => Context as DataContext;
    }
}
