using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Using_Data_Entities_and_Wizards.Models;

namespace Using_Data_Entities_and_Wizards.Controllers
{
    public class Application_For_Assistance_Controller : Controller
    {
        // GET: Application_For_Assistance_
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            if (Session["PersonKey"]== null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in to apply for Grants";
                return RedirectToAction("Result", msg);
            }
            ViewBag.GrantList = new SelectList(db.GrantApplications, "PersonKey", "GrantTypeKey");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="PersonKey, GrantApplicationDate, GranTypeKey, GrantApplicationRequestAmount, " +
            "GrantApplicationReason, GrantApplicationStatusKey, GrantApplicationAllocationAmount")] GrantApplication ga)
        {
            try
            {
                ga.GrantApplicationKey = (int)Session["PersonKey"];
                ga.GrantAppicationDate = DateTime.Now;
                ga.GrantApplicationReviews.Add(ga);
                db.SaveChanges();
                Message m = new Message();
                m.MessageText = "Thank you for your submitting your application";
                return RedirectToAction("Result",m);
            }
            catch (Exception e)
            {
                Message m = new Message();
                m.MessageText = e.Message;
                return RedirectToAction("Result",m);
            }
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);   
        }
    }
}