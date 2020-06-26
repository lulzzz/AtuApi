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
    public class UnitOfMeasueRepository : Repository<UnitOfMeasure>, IUnitOfMeasueRepository
    {

        IDiManager _diManager;
        public UnitOfMeasueRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        private DataContext UnitOfMeasureContext => Context as DataContext;
        public UnitOfMeasure GetUnitOfMeasure(int absEntry)
        {
            return _diManager.GetUnitOfMeasure(absEntry);
        }
    }
}
