using Es.Pue.Intranet.Model.PersistenceLayer;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Managers;
using Es.Pue.Intranet.Model.ServiceLayer.API.Candidates;
using Es.Pue.Intranet.Model.ServiceLayer.API.Projects;
using Es.Pue.Intranet.Model.ServiceLayer.Impl.Candidates;
using Es.Pue.Intranet.Model.ServiceLayer.Impl.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.ServiceLayer.Managers
{
  public class ServiceManager:IDisposable
    {
        private readonly SQLPersistenceManager sqlPersistenceManager;
        IProjectService projectService;
        ICandidateService candidateService;

        public ServiceManager()
        {
            sqlPersistenceManager = 
                (SQLPersistenceManager)
                PersistenceManager.
                GetPersistenceManager(
                    UtilityLayer.Projects.
                    ProjectsUtilities.PersistenceTechnologies.SqlServer);

        }

        public IProjectService ProjectService {
            get {
                return projectService ?? (projectService = new ProjectService(sqlPersistenceManager));
            }
        }

        public ICandidateService CandidateService
        {
            get
            {
                return candidateService ?? (
                    candidateService = new CandidateService(sqlPersistenceManager));
            }
        }
        public void Dispose()
        {
            sqlPersistenceManager.Dispose();
        }

        public void SaveChanges() {
            sqlPersistenceManager.SaveChanges();
        }
    }
}
