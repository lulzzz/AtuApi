using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetProject(string projectCode);
        IEnumerable<Project> GetProjects();
    }
}
