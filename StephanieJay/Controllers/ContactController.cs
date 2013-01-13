using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StephanieJay.Models;

namespace StephanieJay.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel contactVM)
        {
            if (!ModelState.IsValid)
            {
                return View(contactVM);
            }

            var contact = new Contact
            {
                From = contactVM.From,
                ContactVia = contactVM.ContactVia,
                Message = contactVM.Message
            };

            new Email().Send(contact);

            return RedirectToAction("ContactConfirm");
        }

        public ActionResult ContactConfirm()
        {
            return View();
        }
    }
}
