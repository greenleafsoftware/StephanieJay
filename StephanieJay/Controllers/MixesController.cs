using System.Web.Mvc;
using StephanieJay.Classes;

namespace StephanieJay.Controllers
{
    public class MixesController : Controller
    {
        public ActionResult Index()
        {
            var gigs = Xml<Gigs>.Load(Server.MapPath("Gigs.xml"));
            return View(gigs);
        }
    }
}
