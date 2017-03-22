using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Pue.Intranet.Model.PersistenceLayer.API.Projects;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DAOS;
using Es.Pue.Intranet.Model.PersistenceLayer.API.Candidates;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DAOS.Candidates;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Managers
{
   public class SQLPersistenceManager : PersistenceManager
    {
        IntranetDBContext intranetCtx;
        CandidatesDBContext candidateDBContext;

        IProjectDAO projectDAO;
        ICandidateDAO candidateDAO;

        public SQLPersistenceManager()
        {
            intranetCtx = new IntranetDBContext();
            candidateDBContext = new CandidatesDBContext();
        }

        public override IProjectDAO GetProjectDAO()
        {
            return projectDAO ?? (projectDAO = new ProjectDAO(intranetCtx));
        }

        public override ICandidateDAO GetCandidateDAO()
        {
            return candidateDAO ?? (candidateDAO = new CandidateDAO(candidateDBContext));
        }


        public override void Dispose()
        {
            intranetCtx.Dispose();
            candidateDBContext.Dispose();
        }

       

        public override void SaveChanges()
        {
            intranetCtx.SaveChanges();
            candidateDBContext.SaveChanges();
        }

       
    }
}
