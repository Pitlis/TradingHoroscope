using DataBaseAccess;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository = new Repository();

        public ActionResult Index()
        {
            ViewBag.Message = "Trading Horoscopes";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("{info/{zodiac}")]
        public ActionResult Info(string zodiac)
        {
            DailyHoroscopeRecord horoscope = null;
            try
            {
                Zodiac z = (Zodiac)Enum.Parse(typeof(Zodiac), zodiac);
                horoscope = repository.GetTodayHoroscope(z);
                ViewBag.Zodiac = z;
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }

            return View(horoscope);
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}