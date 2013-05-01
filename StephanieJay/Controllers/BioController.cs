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
    public class BioController : Controller
    {
        //
        // GET: /Bio/

        public ActionResult Index()
        {
            {
                var viewModel = new BioViewModel();
                viewModel.Bio = Xml<Bio>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Bio"]));
                return View(viewModel);
            }
        }

    }
}
