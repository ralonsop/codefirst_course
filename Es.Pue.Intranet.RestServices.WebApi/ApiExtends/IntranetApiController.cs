using Es.Pue.Intranet.Model.ServiceLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Es.Pue.Intranet.RestServices.WebApi.ApiExtends
{
    public class IntranetApiController:ApiController
    {
        private readonly ServiceManager serviceManager;

        public IntranetApiController() {
            serviceManager = new ServiceManager();
        }

        protected ServiceManager ServiceManager {
            get {
                return serviceManager;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                this.serviceManager.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}