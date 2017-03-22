using Es.Pue.Intranet.Model.BusinessLayer.Entities.Base;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Candidates;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.Mappers.Projects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts
{
   public class CandidatesDBContext:DbContext
    {
        static CandidatesDBContext() {

            Database.SetInitializer<CandidatesDBContext>(null);

        }

        public CandidatesDBContext() : base("Name=Candidates") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations
                .Add(new CandidateMAP());
            //    .Add(new PersonMAP())
            //    .Add(new ProjectMAP())
            //    ;
        }


        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

        public void EntryDisconectedObject(object entity) {
          
            foreach (var property in entity.GetType().GetProperties()){
                if (property.GetValue(entity) is IList) {
                    foreach (var listEntity in (IList)property.GetValue(entity)) {
                        EntryDisconectedObject(listEntity);
                    }                 
                }
           
                else if (property.GetValue(entity) != null
                      && property.GetValue(entity) is EntityBase){
                    EntryDisconectedObject(property.GetValue(entity));                
                }               
            }
            if (entity is EntityBase) {
                ((EntityBase)entity).UpdateFKs(true);

                if (!this.ChangeTracker.Entries().Any(
                      e => ((EntityBase)e.Entity).Id ==
                      ((EntityBase)entity).Id
                      &&
                      e.Entity.GetType() == entity.GetType()
                      )){
                    this.Entry(entity).State =
                  ((EntityBase)entity).DBInsertedDate == null ?
                  System.Data.Entity.EntityState.Added :
                  System.Data.Entity.EntityState.Modified;
                    if (((EntityBase)entity).DBInsertedDate == null){
                        ((EntityBase)entity).DBInsertedDate = DateTime.Now;
                    }



                }
            }
        }

    }
}
