using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates
{
   public class Recruiter:Entities.Base.EntityBase
    {
        public String Name { get; set; }
        public virtual Login Login { get; set; }
        public Guid? LoginId { get; set; }

    }
}
