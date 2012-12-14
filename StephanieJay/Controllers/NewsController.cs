﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.Models;
using System.Net;
using RSS;
using System.Web.Configuration;

namespace StephanieJay.Controllers
{
    public class NewsController : Controller
    {
        private Rss _newsRss;

        public NewsController()
        {
            /*WebRequest request = WebRequest.CreateDefault(new Uri(WebConfigurationManager.AppSettings["urlRSS"]));
            WebResponse response = request.GetResponse();
            _newsRss = Rss.Load(response.GetResponseStream());*/

            _newsRss = Rss.Load(Server.MapPath(WebConfigurationManager.AppSettings["LocalRSS"]));
        }

        //GET: /News
        public ActionResult Index()
        {
            var news = _newsRss.channel.items;
            return View(news);
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
                _newsRss.Save(Server.MapPath(WebConfigurationManager.AppSettings["LocalRSS"]));
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
                _newsRss.Save(Server.MapPath(WebConfigurationManager.AppSettings["LocalRSS"]));
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Delete/5
        public ActionResult Delete(string id)
        {
            _newsRss.channel.items.RemoveAll(x => x.guid == id);
            _newsRss.Save(Server.MapPath(WebConfigurationManager.AppSettings["LocalRSS"]));
            return RedirectToAction("Index");
        }
    }
}
