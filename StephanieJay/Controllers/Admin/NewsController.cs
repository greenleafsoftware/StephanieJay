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

namespace StephanieJay.Controllers.Admin
{
    [Authorize(Users="Stephanie")]
    public class NewsController : Controller
    {
        private Rss _newsRss;
        private readonly string _xmlPath;

        public NewsController()
        {
            _newsRss = Xml<Rss>.Load(System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["News"]));
            _xmlPath = System.Web.HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["News"]);
        }

        //GET: /News
        public ActionResult Index()
        {
            var news = _newsRss.channel.items;
            return View("/Views/Admin/News/Index.cshtml", news);
        }

        //GET: /News/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: /News/Create
        [HttpPost]
        public ActionResult Create(Item news)
        {
            if (ModelState.IsValid)
            {
                _newsRss.channel.items.Add(news);
                Xml<Rss>.Save(_xmlPath, _newsRss);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Edit/5
        public ActionResult Edit(string id)
        {
            Item news = _newsRss.channel.items.FirstOrDefault(x => x.guid == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /News/Edit/5
        [HttpPost]
        public ActionResult Edit(Item news)
        {
            if (ModelState.IsValid)
            {
                _newsRss.channel.items.RemoveAll(x => x.guid == news.guid);
                _newsRss.channel.items.Add(news);
                Xml<Rss>.Save(_xmlPath, _newsRss);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Delete/5
        public ActionResult Delete(string id)
        {
            _newsRss.channel.items.RemoveAll(x => x.guid == id);
            Xml<Rss>.Save(_xmlPath, _newsRss);
            return RedirectToAction("Index");
        }
    }
}
