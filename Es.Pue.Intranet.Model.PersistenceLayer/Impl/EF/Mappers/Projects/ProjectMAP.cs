using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Projects
{
    class ProjectMAP:EntityTypeConfiguration<Project>
    {
        public ProjectMAP() {

            this.ToTable("Projects", schemaName: "Projects");
            
            this.HasMany(p => p.Team)
                .WithMany()
                .Map(p => 
                {
                    p.ToTable("Project_Persons", schemaName: "Projects");
                });

        }

    }
}
