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
    public class UnitOfMeasueGroupsRepository : Repository<UnitOfMeasureGroup>, IUnitOfMeasueGroupRepository
    {
        IDiManager _diManager;
        public UnitOfMeasueGroupsRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        private DataContext UnitOfMeasureGroupContext => Context as DataContext;

        public UnitOfMeasureGroup GetUnitOfMeasurGroup(int grpEntry)
        {
            return _diManager.GetUnitOfMeasurGroup(grpEntry);
        }

        public IEnumerable<UnitOfMeasureGroup> GetUnitOfMeasurGroups()
        {
            return _diManager.GetUnitOfMeasurGroups();
        }
    }
}
