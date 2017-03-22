using Es.Pue.Intranet.Model.BusinessLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects
{
   
    public class Person:EntityBase
    {
        public String Nif { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        public Person() {

        }


    }
}
