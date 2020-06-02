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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private IDiManager _diManager;

        public ProjectRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }

        public Project GetProject(string projectCode)
        {
            return _diManager.GetProject(projectCode);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _diManager.GetProjects();
        }
    }
}
