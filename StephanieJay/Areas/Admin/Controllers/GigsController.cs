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
<<<<<<< HEAD
                _gigs.gigs.Add(gig);
||||||| merged common ancestors
                //Check if group exists for gig
                Predicate<Group> search = gr => gr.date.Month == gig.date.Month && gr.date.Year == gig.date.Year;

                if (_gigs.groups.Exists(search))
                {
                    //Add the gig to the existing group.
                    _gigs.groups.Find(search).gigs.Add(gig);
                }
                else
                {
                    //Create a new group and add the gig.
                    var dateInfo = new DateTimeFormatInfo();
                    var group = new Group
                    {
                        date = new DateTime(gig.date.Year, gig.date.Month, 1),
                        name = dateInfo.GetMonthName(gig.date.Month) + " " + gig.date.Year,
                        gigs = new List<Gig> { gig }
                    };
                    _gigs.groups.Add(group);
                }

=======
                ////Give it a new guid
                //if (gig.guid == null)
                //{
                //    gig.guid = Guid.NewGuid().ToString();
                //}

                ////Check if group exists for gig
                //Predicate<Group> search = gr => gr.date.Month == gig.date.Month && gr.date.Year == gig.date.Year;

                //if (_gigs.groups.Exists(search))
                //{
                //    //Add the gig to the existing group.
                //    _gigs.groups.Find(search).gigs.Add(gig);
                //}
                //else
                //{
                //    //Create a new group and add the gig.
                //    var dateInfo = new DateTimeFormatInfo();
                //    var group = new Group
                //    {
                //        date = new DateTime(gig.date.Year, gig.date.Month, 1),
                //        name = dateInfo.GetMonthName(gig.date.Month) + " " + gig.date.Year,
                //        gigs = new List<Gig> { gig }
                //    };
                //    _gigs.groups.Add(group);
                //}

                gig.guid = Guid.NewGuid().ToString();
                _gigs.gigs.Add(gig);
                _gigs.gigs.Sort((a, b) => a.date.CompareTo(b.date));
>>>>>>> c7fd00a9faa6d0653e67aff3003e4611da0052f2
                Xml<Gigs>.Save(_xmlPath, _gigs);
                return RedirectToAction("Index");
            }
            return View(gig);
        }

        // GET: /Admin/Gigs/Edit/5
        public ActionResult Edit(string id)
        {
<<<<<<< HEAD
            Gig gig = _gigs.gigs.SingleOrDefault(g => g.guid == id);
||||||| merged common ancestors
            Gig gig = _gigs.groups.SelectMany(gp => gp.gigs).SingleOrDefault(g => g.guid == id);
=======
            //Gig gig = _gigs.groups.SelectMany(gp => gp.gigs).SingleOrDefault(g => g.guid == id);
            Gig gig = _gigs.gigs.FirstOrDefault(x => x.guid == id);
>>>>>>> c7fd00a9faa6d0653e67aff3003e4611da0052f2
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
<<<<<<< HEAD
                _gigs.gigs.Remove(gig);
                _gigs.gigs.Add(gig);
                //Xml<Rss>.Save(_xmlPath, _gigs);
||||||| merged common ancestors
                _gigs.xxxx.RemoveAll(x => x.guid == model.guid);
                _gigs.xxxx.gigs.Add(model);
                Xml<Rss>.Save(_xmlPath, _gigs);
=======
                //_gigs.groups.SelectMany(g => g.gigs).ToList().RemoveAll(g => g.guid == gig.guid);
                _gigs.gigs.RemoveAll(x => x.guid == model.guid);
                _gigs.gigs.Add(model);
                _gigs.gigs.Sort((a, b) => a.date.CompareTo(b.date));
                Xml<Gigs>.Save(_xmlPath, _gigs);
>>>>>>> c7fd00a9faa6d0653e67aff3003e4611da0052f2
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: /News/Delete/5
        public ActionResult Delete(string id)
        {
            /*_newsRss.channel.items.RemoveAll(x => x.guid == id);
            Xml<Rss>.Save(_xmlPath, _newsRss);*/
            //_gigs.groups.SelectMany(g => g.gigs).ToList().RemoveAll(g => g.guid == id);
            _gigs.gigs.RemoveAll(x => x.guid == id);
            Xml<Gigs>.Save(_xmlPath, _gigs);
            return RedirectToAction("Index");
        }
    }
}
