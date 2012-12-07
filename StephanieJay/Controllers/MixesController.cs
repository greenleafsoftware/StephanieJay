using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSS;
using System.Net;

namespace StephanieJay.Controllers
{
    public class MixesController : Controller
    {
        //
        // GET: /Mixes/

        Rss feed = null;

        public ActionResult Index()
        {
            WebRequest request = WebRequest.CreateDefault(new Uri("http://www.greenleafsoftware.co.uk/XML/News.xml"));
            WebResponse response = request.GetResponse();
            feed = Rss.Load(response.GetResponseStream());

            foreach (Item itm in feed.channel.items)
            {
                Response.Write(itm.title);
                Response.Write(itm.description);
            }

            // Edit
            feed.channel.items[0].description = "This is a new test to check that it works ok...";

            // Save
            feed.Save(Server.MapPath("rss.xml"));

            return View();
        }

    }
}
