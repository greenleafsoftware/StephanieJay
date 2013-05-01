using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.ViewModels;
using System.Web.Configuration;
using StephanieJay.Classes;
using RSS;

namespace StephanieJay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var news = Xml<Rss>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["News"]));
            var viewModel = new HomeViewModel();
            viewModel.WelcomeMessage = Xml<WelcomeMessage>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["WelcomeMessage"]));
            viewModel.News = news.channel.items;
            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
