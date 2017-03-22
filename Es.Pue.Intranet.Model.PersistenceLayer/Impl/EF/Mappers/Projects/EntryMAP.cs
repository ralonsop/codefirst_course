using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Projects
{
    class EntryMAP:EntityTypeConfiguration<Entry>
    {
        public EntryMAP() {

            this.ToTable("Entries", schemaName: "Projects");

        }

    }
}
