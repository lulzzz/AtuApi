using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IUnitOfMeasueGroupRepository : IRepository<UnitOfMeasureGroup>
    {
        IEnumerable<UnitOfMeasureGroup> GetUnitOfMeasurGroups();
        UnitOfMeasureGroup GetUnitOfMeasurGroup(int grpEntry);
    }
}
