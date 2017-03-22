using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates
{
    public class Login:Entities.Base.EntityBase
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
    }
}
