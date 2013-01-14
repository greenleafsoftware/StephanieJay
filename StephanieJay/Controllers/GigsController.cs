using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StephanieJay.Classes;
using System.Web.Configuration;

namespace StephanieJay.Controllers
{
    public class GigsController : Controller
    {
        public ActionResult Index()
        {
            var gigs = Xml<Gigs>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Gigs"]));
            return View(gigs);
        }
    }
}
