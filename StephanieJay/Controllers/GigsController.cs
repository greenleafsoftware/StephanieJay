using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StephanieJay.Classes;

namespace StephanieJay.Controllers
{
    public class GigsController : Controller
    {
        //
        // GET: /Gigs/
        Gigs gigs = null;

        public ActionResult Index()
        {
            gigs = Gigs.Load(Server.MapPath("Gigs.xml"));
            return View(gigs);
        }

    }
}
