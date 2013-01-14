using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.ViewModels;
using System.Web.Configuration;
using StephanieJay.Classes;

namespace StephanieJay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.WelcomeMessage = Xml<WelcomeMessage>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["WelcomeMessage"]));
            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
