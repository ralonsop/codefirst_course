using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Projects
{
    class PersonMAP:EntityTypeConfiguration<Person>
    {
        public PersonMAP() {

            this.ToTable("Persons", schemaName: "Projects");

        }

    }
}
