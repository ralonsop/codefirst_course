using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.API.Projects
{
   public interface IProjectDAO
    {
        void ProjectSave(Project project);

        Project GetProjectById(Guid id);

        List<Project> GetProjects();

    }
}
