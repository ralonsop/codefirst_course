using Es.Pue.Intranet.Model.PersistenceLayer.API.Candidates;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DAOS.Candidates
{
   public class CandidateDAO:ICandidateDAO
    {
        private CandidatesDBContext ctx;

        public CandidateDAO(CandidatesDBContext ctx)
        {
            this.ctx = ctx;
        }

        public Candidate GetCandidateById(Guid id)
        {
            return this.ctx.Candidates.
                AsNoTracking().
                Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void CandidateSave(Candidate candidate)
        {
            this.ctx.EntryDisconectedObject(candidate);
        }

        public Candidate GetCandidateByExam(Exam exam)
        {
          return  this.ctx.Candidates.Where(
                c => c.Exams.Any(e => e.Id == exam.Id)).FirstOrDefault();
        }

        public List<Candidate> GetCandidatesByName(string name)
        {
            return ctx.Candidates.AsNoTracking()
                .Where(c => c.CandidateData.Any(ca => ca.Name.Contains(name))).ToList();
        }

        public List<Candidate> GetCandidatesByExamName(string name)
        {
            return ctx.Candidates.AsNoTracking()
                .Where(c => c.Exams.Any(e => e.Name.Contains(name))).ToList();
        }

        public List<Candidate> GetCandidatesByUserAndPass(string user, string pass)
        {
            return ctx.Candidates.AsNoTracking()
                .Where(c => c.Login.LoginUser == user && c.Login.Password == pass).ToList();
        }

        public List<Recruiter> GetRecruiters()
        {
           return this.ctx.Recruiters.AsNoTracking().ToList();
        }

        public List<Candidate> GetCandidates()
        {
            return this.ctx.Candidates.AsNoTracking().ToList();
        }
    }
}
