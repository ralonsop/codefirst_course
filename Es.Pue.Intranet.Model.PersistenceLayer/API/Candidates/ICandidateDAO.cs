using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.API.Candidates
{
   public interface ICandidateDAO
    {
        Candidate GetCandidateById(Guid id);
        Candidate GetCandidateByExam(Exam exam);
        List<Candidate> GetCandidatesByName(string name);
        List<Candidate> GetCandidatesByExamName(string name);
        List<Candidate> GetCandidatesByUserAndPass(string user, string pass);
        List<Recruiter> GetRecruiters();
        List<Candidate> GetCandidates();

        void CandidateSave(Candidate candidate);
        
    }
}
