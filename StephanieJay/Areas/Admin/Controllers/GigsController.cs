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
using System.Globalization;

namespace StephanieJay.Areas.Admin.Controllers
{
    [Authorize(Users="Stephanie")]
    public class GigsController : Controller
    {
        private Gigs _gigs;
        private readonly string _xmlPath;

        public GigsController()
        {
            _gigs = Xml<Gigs>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Gigs"]));
            _xmlPath = System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["Gigs"]);
        }

        //GET: /Admin/Gigs
        public ActionResult Index()
        {
            return View(_gigs);
        }

        //GET: /Admin/Gigs/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: /Admin/Gigs/Create
        [HttpPost]
        public ActionResult Create(Gig gig)
        {
            if (ModelState.IsValid)
            {
                _gigs.gigs.Add(gig);
                Xml<Gigs>.Save(_xmlPath, _gigs);
                return RedirectToAction("Index");
            }
            return View(gig);
        }

        // GET: /Admin/Gigs/Edit/5
        public ActionResult Edit(string id)
        {
            Gig gig = _gigs.gigs.SingleOrDefault(g => g.guid == id);
            if (gig == null)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // POST: /News/Edit/5
        [HttpPost]
        public ActionResult Edit(Gig gig)
        {
            if (ModelState.IsValid)
            {
                _gigs.gigs.Remove(gig);
                _gigs.gigs.Add(gig);
                //Xml<Rss>.Save(_xmlPath, _gigs);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Admin");
        }

        // GET: /News/Delete/5
        public ActionResult Delete(string id)
        {
            /*_newsRss.channel.items.RemoveAll(x => x.guid == id);
            Xml<Rss>.Save(_xmlPath, _newsRss);*/
            return RedirectToAction("Index", "Admin");
        }
    }
}
