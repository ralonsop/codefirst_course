using Es.Pue.Intranet.Model.BusinessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates
{
    public class Candidate:EntityBase
    {
        public virtual List<Recruiter> Recruiters { get; set; }
     
        public virtual Login Login { get; set; }       
        public Guid? LoginId { get; set; }

     

        public virtual List<CandidateData> CandidateData { get; set; }
        public virtual List<Exam> Exams { get; set; }


    }
}
