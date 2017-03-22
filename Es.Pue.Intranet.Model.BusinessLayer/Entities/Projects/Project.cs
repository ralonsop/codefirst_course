using Es.Pue.Intranet.Model.BusinessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects
{
   public class Project:EntityBase
    {
        public String Name { get; set; }
        public virtual List<Person> Team { get; set; }
        public virtual List<Entry> Entries { get; set; }
        public Project() {
            Team = new List<Person>();
            Entries = new List<Entry>();
        }

    }
}
