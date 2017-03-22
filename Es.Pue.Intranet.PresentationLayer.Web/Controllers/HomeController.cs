using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Es.Pue.Intranet.PresentationLayer.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("Candidats")]
        [Route("Candidates")]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}