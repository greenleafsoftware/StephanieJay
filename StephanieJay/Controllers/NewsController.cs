﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.Models;
using System.Net;
using RSS;

namespace StephanieJay.Controllers
{
    public class NewsController : Controller
    {
        private Rss _newsRss;

        public NewsController()
        {
<<<<<<< HEAD
            /*WebRequest request = WebRequest.CreateDefault(new Uri("http://www.greenleafsoftware.co.uk/XML/News.xml"));
=======
            WebRequest request = WebRequest.CreateDefault(new Uri(System.Web.Configuration.WebConfigurationManager.AppSettings["urlRSS"]));
>>>>>>> 6fe9a243b7b865cf78e8732e106082aa84470119
            WebResponse response = request.GetResponse();
            _newsRss = Rss.Load(response.GetResponseStream());*/
            _newsRss = Rss.Load("C:\\Users\\Al\\Desktop\\test.xml");
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
<<<<<<< HEAD
                //_newsRss.Save(Server.MapPath("..//rss.xml"));
                _newsRss.Save("C:\\Users\\Al\\Desktop\\test.xml");
=======
                _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
>>>>>>> 6fe9a243b7b865cf78e8732e106082aa84470119
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
<<<<<<< HEAD
                _newsRss.channel.items.RemoveAll(x => x.guid == news.guid);
                _newsRss.channel.items.Add(news);
                _newsRss.Save("C:\\Users\\Al\\Desktop\\test.xml");
=======
                //_dataFactory.News.Entry(news).State = EntityState.Modified;
                //_newsRss.Save(Server.MapPath("..//rss.xml"));
                _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
>>>>>>> 6fe9a243b7b865cf78e8732e106082aa84470119
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Delete/5
        public ActionResult Delete(string id)
        {
<<<<<<< HEAD
            _newsRss.channel.items.RemoveAll(x => x.guid == id);
            _newsRss.Save("C:\\Users\\Al\\Desktop\\test.xml");
=======
            _newsRss.channel.items.RemoveAt(id);
            _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
>>>>>>> 6fe9a243b7b865cf78e8732e106082aa84470119
            return RedirectToAction("Index");
        }
    }
}
