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
    public class TerritoryRepository : Repository<Territory>, ITerritoryRepository
    {
        IDiManager _diManager;
        public TerritoryRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        private DataContext Territory => Context as DataContext;

        public IEnumerable<Territory> GetTerritories()
        {
            return _diManager.GetTerritories();
        }

        public Territory GetTerritory(int TerritoryId)
        {
            return _diManager.GetTerritory(TerritoryId);
        }
    }
}
