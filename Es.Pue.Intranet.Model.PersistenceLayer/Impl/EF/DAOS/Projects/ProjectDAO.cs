using Es.Pue.Intranet.Model.PersistenceLayer.API.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DBContexts;

namespace Es.Pue.Intranet.Model.PersistenceLayer.Impl.EF.DAOS
{
    class ProjectDAO : IProjectDAO
    {
        private IntranetDBContext ctx;

        public ProjectDAO(IntranetDBContext ctx)
        {
            this.ctx = ctx;
        }


        public Project GetProjectById(Guid id)
        {     
            return ctx.Projects.AsNoTracking()
                .Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Project> GetProjects()
        {
            return ctx.Projects.AsNoTracking().ToList();
        }

        public void ProjectSave(Project project)
        {
            ctx.Entry(project).State =
                project.DBInsertedDate!=null ?
                System.Data.Entity.EntityState.Modified :
                System.Data.Entity.EntityState.Added;
        
            if(project.DBInsertedDate == null)
            {
                project.DBInsertedDate = DateTime.Now;
            }
            
            foreach (var person in project.Team) {

                ctx.Entry(person).State =
                        person.DBInsertedDate != null ?
                        System.Data.Entity.EntityState.Modified :
                        System.Data.Entity.EntityState.Added;

                if (person.DBInsertedDate == null)
                {
                    person.DBInsertedDate = DateTime.Now;
                }
            }

            foreach (var entry in project.Entries)
            {

                ctx.Entry(entry).State =
                        entry.DBInsertedDate != null ?
                        System.Data.Entity.EntityState.Modified :
                        System.Data.Entity.EntityState.Added;

                if (entry.DBInsertedDate == null)
                {
                    entry.DBInsertedDate = DateTime.Now;
                }           
                entry.UpdateFKs(true);             
            }

        }
    }
}
