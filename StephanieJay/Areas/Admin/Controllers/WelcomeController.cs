using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.Models;
using System.Net;
using RSS;
using System.Web.Configuration;
using StephanieJay.Classes;
using StephanieJay.Classes.Extensions;

namespace StephanieJay.Areas.Admin.Controllers
{
    [Authorize(Users="Stephanie")]
    public class WelcomeController : Controller
    {
        private readonly string _xmlPath;

        public WelcomeController()
        {
            _xmlPath = System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["WelcomeMessage"]);
        }

        //GET: /Admin/Welcome
        public ActionResult Index()
        {
            var welcome = Xml<WelcomeMessage>.Load(_xmlPath);
            return View(welcome);
        }

        //POST: /Admin/Welcome
        [HttpPost]
        public ActionResult Index(WelcomeMessage model)
        {
            //ModelState.DumpErrors();
            Xml<WelcomeMessage>.Save(_xmlPath, model);
            return RedirectToAction("Index", "Admin");
        }
    }
}
