using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstLook.Models;

namespace FirstLook.Controllers
{
    public class MailingController : Controller
    {
        // GET: Mailing
        public ActionResult Index()
        {
            Mailing m1 = new Mailing();
            m1.FirstName = "Allen";
            m1.LastName = "Iverson";
            m1.Email = "the.answer.seattlecolleges.edu";

            Mailing m2 = new Mailing();
            m1.FirstName = "Dikembe";
            m1.LastName = "Mutombo";
            m1.Email = "Mt.Mutombo.seattlecolleges.edu";

            Mailing m3 = new Mailing();
            m1.FirstName = "Karl";
            m1.LastName = "Malone";
            m1.Email = "the.mailman.seattlecolleges.edu";

            List<Mailing> mailings = new List<Mailing>();
            mailings.Add(m1);
            mailings.Add(m2);
            mailings.Add(m3);

            return View(mailings);
        }
    }
}