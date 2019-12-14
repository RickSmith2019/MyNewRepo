using EventBrightApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EventBrightApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DailyDeal()
        {
            var eventname = GetDailyDeal();
            return PartialView("_DailyDeal", eventname);
        }
        private EventBrightApplicationDB db = new EventBrightApplicationDB();
        private object GetDailyDeal()
        {           
            DateTime cutOffDate = DateTime.Now.AddDays(2);
            
            return db.Events
                .Where(e => e.StartDate <= cutOffDate
                && e.EndDate > DateTime.Now)
                .OrderBy(e => e.StartDate)
                .Take(2)
                .ToList();            
        }
    }
}

