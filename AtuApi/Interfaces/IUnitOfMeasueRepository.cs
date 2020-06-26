using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IUnitOfMeasueRepository : IRepository<UnitOfMeasure>
    {
        UnitOfMeasure GetUnitOfMeasure(int absEntry);
    }
}
