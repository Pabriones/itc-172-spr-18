using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Using_Data_Entities_and_Wizards.Models;

namespace Using_Data_Entities_and_Wizards.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["PersonKey"] ==null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be login";
                return RedirectToAction("Index","Login", msg);

            }
            ViewBag.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="DonateDate","DonationAmount","DonationConfirmation")]Donation d)
        {
            d.PersonKey = (int)Session["PersonKey"];
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            db.Donations.Add(d);
            db.SaveChanges();
            Message m = new Message("Donation has been added");
            return View("Result", m);
    
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}