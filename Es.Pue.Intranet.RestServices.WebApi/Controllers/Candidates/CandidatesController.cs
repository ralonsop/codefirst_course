using Es.Pue.Intranet.Model.BusinessLayer.Entities.Candidates;
using Es.Pue.Intranet.RestServices.WebApi.ApiExtends;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Es.Pue.Intranet.RestServices.WebApi.Controllers.Candidates
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class CandidatesController : IntranetApiController
    {
        [Route("CandidatesApi/Candidate/{id}")]
        [HttpGet]
        public IHttpActionResult GetCandidateById(Guid id)
        {
            var candidate = ServiceManager.CandidateService.GetCandidateById(id);
            candidate.CandidateData.FirstOrDefault();

            if (candidate != null)
            {
                return Ok(candidate);
            }
            else {
                return NotFound();
            }

        }

        [Route("CandidatesApi/Candidate/Name/{name}")]
        [HttpGet]
        public IHttpActionResult GetCandidatesByName(string name)
        {
            var candidate = ServiceManager.CandidateService.GetCandidatesByName(name);

            if (candidate != null)
            {
                return Ok(candidate);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("CandidatesApi/Candidate/ExamName/{examName}")]
        [HttpGet]
        public IHttpActionResult GetCandidatesByExamName(string examName)
        {
            var candidate = ServiceManager.CandidateService.GetCandidatesByExamName(examName);

            if (candidate != null)
            {
                return Ok(candidate);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("CandidatesApi/Candidate/Login")]
        [HttpPost]
        public IHttpActionResult GetCandidateLogin()
        {


            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            JObject jobject =JObject.Parse(jsonContent);
            var user=   jobject["user"].Value<String>();
            var pass=   jobject["pass"].Value<String>();

            var candidates=ServiceManager.CandidateService.GetCandidatesByUserAndPass(user, pass);
            

            return Ok(candidates);

        }



        [Route("CandidatesApi/Candidate")]
        [HttpPost]
        public IHttpActionResult CandidateSave(Candidate candidate)
        {
            ServiceManager.CandidateService.CandidateSave(candidate);
           ServiceManager.SaveChanges();

            if (candidate != null)
            {
                return Ok(candidate);
            }
            else
            {
                return NotFound();
            }

        }
        [Route("CandidatesApi/Candidates")]
        [HttpGet]
        public IHttpActionResult GetCandidates()
        {
            return Ok(ServiceManager.CandidateService.GetCandidates());
        }

        [Route("CandidatesApi/Candidates")]
        [HttpPost]
        public IHttpActionResult CandidatesSave(List<Candidate> candidates)
        {
            foreach (var candidate in candidates)
            {
                ServiceManager.CandidateService.CandidateSave(candidate);
            }
            ServiceManager.SaveChanges();
              return Ok(candidates);   
        }
    }
}
