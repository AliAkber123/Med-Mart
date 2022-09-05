using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amar_Pharmacy1.Controllers
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

        public ActionResult Categories()
        {
            
            ViewBag.Message = "Your contact page.";
            

            return View();
             

        }
        public ActionResult Login()
        {
            ViewBag.Message = "Hi";

            return View();
        }
        public ActionResult Loginse()
        {
            ViewBag.Message = "Hi";

            return View();
        }
        
        public ActionResult Billing()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult Category()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult Medicine()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult Seller()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult CreateMedicine()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult CreateCategory()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult CreateSeller()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult Login1()
        {
            ViewBag.Message = " Hi";

            return View();
        }
        public ActionResult MedSearch()
        {
            return View();
        }


    }
}