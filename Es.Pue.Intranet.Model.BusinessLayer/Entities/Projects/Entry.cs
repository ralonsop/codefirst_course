using Es.Pue.Intranet.Model.BusinessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects
{
    public class Entry:EntityBase
    {
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public DateTime Date { get; set; }
        public float Duration { get; set; }

        public Entry() {

        }

    }
}
