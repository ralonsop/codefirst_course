using Es.Pue.Intranet.Model.PersistenceLayer.API.Candidates;
using Es.Pue.Intranet.Model.PersistenceLayer.API.Projects;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Managers;
using Es.Pue.Intranet.UtilityLayer.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer
{
    public abstract class PersistenceManager:IDisposable
    {
        public abstract IProjectDAO GetProjectDAO();

        public abstract ICandidateDAO GetCandidateDAO();

        public abstract void SaveChanges();

        public abstract void Dispose();

        public static PersistenceManager GetPersistenceManager
            (ProjectsUtilities.PersistenceTechnologies persistenceTechnology)
        {
            PersistenceManager persistenceManager=null;

            switch (persistenceTechnology) {
                case ProjectsUtilities.PersistenceTechnologies.SqlServer:
                    persistenceManager = new SQLPersistenceManager();

                    break;                   
            }
            return persistenceManager;

        }
    }
}
