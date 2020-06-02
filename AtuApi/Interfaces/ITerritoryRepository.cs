using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface ITerritoryRepository : IRepository<Territory>
    {
        Territory GetTerritory(int TerritoryId);
        IEnumerable<Territory> GetTerritories();

    }
}
