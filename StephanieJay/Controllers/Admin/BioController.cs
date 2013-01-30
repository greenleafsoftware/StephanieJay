using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using StephanieJay.Classes;

namespace StephanieJay.Controllers.Admin
{
    public class BioController : Controller
    {
        private readonly string _xmlPath;

        public BioController()
        {
            _xmlPath = System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Bio"]);
        }

        //GET: /Admin/Welcome
        public ActionResult Index()
        {
            var bio = Xml<Bio>.Load(_xmlPath);
            return View("/Views/Admin/Bio/Index.cshtml", bio);
        }

        //POST: /Admin/Welcome
        [HttpPost]
        public ActionResult Index(Bio bio)
        {
            Xml<Bio>.Save(_xmlPath, bio);
            return View("/Views/Admin/Bio/Index.cshtml", bio);
        }
    }
}
