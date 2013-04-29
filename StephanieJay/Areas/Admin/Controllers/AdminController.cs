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

namespace StephanieJay.Areas.Admin.Controllers
{
    [Authorize(Users="Stephanie")]
    public class AdminController : Controller
    {
        //GET: /Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}
