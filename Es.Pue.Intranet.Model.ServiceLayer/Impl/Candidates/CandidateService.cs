using Es.Pue.Intranet.Model.ServiceLayer.API.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using Es.Pue.Intranet.Model.PersistenceLayer;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Managers;

namespace Es.Pue.Intranet.Model.ServiceLayer.Impl.Candidates
{
    class CandidateService : ICandidateService
    {
        PersistenceManager sqlPersistenceManager = null;


        public CandidateService(SQLPersistenceManager sqlPersistenceManager)
        {
            this.sqlPersistenceManager = sqlPersistenceManager;
        }

        public Candidate GetCandidateById(Guid id)
        {
           return this.sqlPersistenceManager.GetCandidateDAO().GetCandidateById(id);
        }

        public void CandidateSave(Candidate candidate)
        {
            this.sqlPersistenceManager.GetCandidateDAO().CandidateSave(candidate);
        }

        public List<Candidate> GetCandidatesByName(string name)
        {
           return this.sqlPersistenceManager.GetCandidateDAO().GetCandidatesByName(name);
        }

        public List<Candidate> GetCandidatesByExamName(string name)
        {
            return this.sqlPersistenceManager.GetCandidateDAO().GetCandidatesByExamName(name);
        }

        public List<Candidate> GetCandidatesByUserAndPass(string user, string pass)
        {
            return this.sqlPersistenceManager.GetCandidateDAO().GetCandidatesByUserAndPass(user,pass);
        }

        public List<Recruiter> GetRecruiters()
        {
            return this.sqlPersistenceManager.GetCandidateDAO().GetRecruiters();
        }

        public List<Candidate> GetCandidates()
        {
            return this.sqlPersistenceManager.GetCandidateDAO().GetCandidates();
        }
    }
}
