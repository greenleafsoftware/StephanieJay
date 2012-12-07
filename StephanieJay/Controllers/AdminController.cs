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
    public class NewsController : Controller
    {
        private DataFactory _dataFactory = new DataFactory();

        //GET: /News
        public ActionResult Index()
        {
            var news = _dataFactory.News.Get();
            return View(news);
        }

        //GET: /News/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: /News/Create
        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                _dataFactory.News.Add(news);
                _dataFactory.News.Save();
                return RedirectToAction("Index");
            }
            return View(news);
        }


        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id = 0)
        {
            News news = _dataFactory.News.Get(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                //_dataFactory.News.Entry(news).State = EntityState.Modified;
                _dataFactory.News.Save();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id = 0)
        {
            News news = _dataFactory.News.Get(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _dataFactory.News.Get(id);
            _dataFactory.News.Remove(news);
            _dataFactory.News.Save();
            return RedirectToAction("Index");
        }
    }
}
