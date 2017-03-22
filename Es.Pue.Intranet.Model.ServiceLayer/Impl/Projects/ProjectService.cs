using Es.Pue.Intranet.Model.ServiceLayer.API.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Managers;
using Es.Pue.Intranet.Model.PersistenceLayer;
using Es.Pue.Intranet.UtilityLayer.Projects;
using static Es.Pue.Intranet.UtilityLayer.Projects.ProjectsUtilities;

namespace Es.Pue.Intranet.Model.ServiceLayer.Impl.Projects
{
    class ProjectService : IProjectService
    {
        PersistenceManager sqlPersistenceManager = null;
      

        public ProjectService(SQLPersistenceManager sqlPersistenceManager) {
            this.sqlPersistenceManager = sqlPersistenceManager;
        }

        public Project GetProjectById(Guid id)
        {
         return  this.sqlPersistenceManager.GetProjectDAO().GetProjectById(id);
        }

        public List<Project> GetProjects()
        {
            return this.sqlPersistenceManager.GetProjectDAO().GetProjects();
        }

        public void ProjectSave(Project project)
        {
             this.sqlPersistenceManager.GetProjectDAO().ProjectSave(project);
        }
    }
}
