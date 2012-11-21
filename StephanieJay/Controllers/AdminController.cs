using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.Classes;
using StephanieJay.Models;

namespace StephanieJay.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditNews()
        {
            NewsItemModel news = DataFactory.GetNews();
            return View(news);
        }
    }
}
