using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;

using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Projects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts
{
   public class IntranetDBContext:DbContext
    {
        static IntranetDBContext() {

            Database.SetInitializer<IntranetDBContext>(null);

        }

        public IntranetDBContext() : base("Name=Intranet") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations
                .Add(new EntryMAP())
                .Add(new PersonMAP())
                .Add(new ProjectMAP())
                ;
        }

        public DbSet<Project> Projects { get; set; }

    }
}
