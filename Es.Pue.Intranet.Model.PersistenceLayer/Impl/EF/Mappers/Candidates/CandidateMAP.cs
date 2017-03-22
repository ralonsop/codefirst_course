using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Candidates
{
    class CandidateMAP:EntityTypeConfiguration<Candidate>
    {
        public CandidateMAP() {

//            this.ToTable("Candidate", schemaName: "Projects");
            
            this.HasMany(c => c.Recruiters)
                .WithMany()
                .Map(p => 
                {
                    p.ToTable("Candidate_Recruiters", schemaName: "dbo");
                });

            //this.HasMany(c => c.CandidateData)
            //  .WithMany()
            //  .Map(p =>
            //  {
            //      p.ToTable("Candidate_Recruiters", schemaName: "dbo");
            //  });

        }

    }
}
