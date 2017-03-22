using Es.Pue.Intranet.Model.BusinessLayer.Entities.Projects;
using Es.Pue.Intranet.RestServices.WebApi.ApiExtends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Es.Pue.Intranet.RestServices.WebApi.Controllers.Projects
{

    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ProjectController : IntranetApiController
    {
        [HttpGet]
        [Route("api/projects")]
        public IHttpActionResult GetProjects() {

            
          var projects=  ServiceManager.ProjectService.GetProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("api/project/{id}")]
        public IHttpActionResult GetProjectById(Guid id)
        {
            var project = ServiceManager.ProjectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost]
        [Route("api/project")]
        public IHttpActionResult ProjectSave(Project project)
        {
            ServiceManager.ProjectService.ProjectSave(project);
            ServiceManager.SaveChanges();
            return Ok(project);
        }

        [HttpPost]
        [Route("api/projects")]
        public IHttpActionResult ProjectsSave(List<Project> projects)
        {
            foreach(var project in projects)
            {
                ServiceManager.ProjectService.ProjectSave(project);         
            }
            ServiceManager.SaveChanges();
            return Ok(projects);
        }


    }
}
