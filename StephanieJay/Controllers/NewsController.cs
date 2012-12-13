using System;
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
            WebRequest request = WebRequest.CreateDefault(new Uri(System.Web.Configuration.WebConfigurationManager.AppSettings["urlRSS"]));
            WebResponse response = request.GetResponse();
            _newsRss = Rss.Load(response.GetResponseStream());
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
                _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Item news = _newsRss.channel.items[id];
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
                //_dataFactory.News.Entry(news).State = EntityState.Modified;
                //_newsRss.Save(Server.MapPath("..//rss.xml"));
                _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: /News/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Item news = _newsRss.channel.items[id];
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _newsRss.channel.items.RemoveAt(id);
            _newsRss.Save(Server.MapPath(System.Web.Configuration.WebConfigurationManager.AppSettings["LocalRSS"]));
            return RedirectToAction("Index");
        }
    }
}
