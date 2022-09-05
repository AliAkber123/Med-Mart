using Amar_Pharmacy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Amar_Pharmacy1.Controllers
{
    public class AdminController : Controller
    {
        OnlinepharmacyEntities dbo = new OnlinepharmacyEntities();
        medMart1Entities1 db = new  medMart1Entities1();

        // GET: Admin
        [HttpGet]

        
        public ActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1( Login1 log)

        {
            Login1 lo = db.Login1.Where(x => x.Email == log.Email && x.UserPassword == log.UserPassword).SingleOrDefault();
            if (lo != null)
            {
                return RedirectToAction("Medicine", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Email or password not found or matched";
                return View();
            }

            

        }
        [HttpGet]
        public ActionResult SellerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellerLogin(Seller sel)

        {
            Seller se = db.Sellers.Where(x => x.SellerEmail == sel.SellerEmail && x.SellerPassword == sel.SellerPassword).SingleOrDefault();
            if (se != null)
            {
                return RedirectToAction("Billing", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Email or password not found or matched";
                return View();
            }



        }
        public ActionResult Category()

        { 

            var sql = "select * from Category";
            List<Category> Category = db.Categories.SqlQuery(sql).ToList();
            ViewBag.Category = db.Categories.ToList();
            return View(Category);

 
        }
        public ActionResult Medicine()

        {

            var sql = "select * from Medicine";
            List<Medicine> Medicine = db.Medicines.SqlQuery(sql).ToList();
            ViewBag.Medicine = db.Medicines.ToList();
            return View(Medicine);


        }
        public ActionResult Seller()

        {

            var sql = "select * from Seller";
            List<Seller> Seller = db.Sellers.SqlQuery(sql).ToList();
            ViewBag.Seller = db.Sellers.ToList();
            return View(Seller);


        }
        public ActionResult Billing()

        {

            var sql = "select * from Billing";
            List<Billing> Billing = db.Billings.SqlQuery(sql).ToList();
            ViewBag.Billing = db.Billings.ToList();
            return View(Billing);


        }
        public ActionResult CreateBilling()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateBilling([Bind(Include = "MedName, MedQuantity, Price, BillingDate")] Billing Billing)
        {
            if (ModelState.IsValid)
            {
                db.Billings.Add(Billing);
                db.SaveChanges();
                return RedirectToAction("Billing", "Admin");

            }
            return RedirectToAction("Billing", "Admin");
        }

        public ActionResult CreateMedicine()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateMedicine([Bind(Include = "MedName, MedStock, Price, MedExpDate, MedCategory")] Medicine Medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(Medicine);
                db.SaveChanges();
                return RedirectToAction("Medicine", "Admin");

            }
            return RedirectToAction("Medicine", "Admin");
        }
        public ActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory([Bind(Include = "CategoryID, CategoryName")] Category Category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(Category);
                db.SaveChanges();
                return RedirectToAction("CreateCategory", "Admin");

            }
            return View();
        }
        public ActionResult CreateSeller()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateSeller([Bind(Include = "SellerAddress, SellerName, SellerEmail, SellerPassword, SellerDOB,SellerGender")] Seller Seller)
        {    
            if (ModelState.IsValid)
            {
                db.Sellers.Add(Seller);
                db.SaveChanges();
                return RedirectToAction("Seller", "Admin");


            }
            return RedirectToAction("Seller", "Admin");
        }

        public ActionResult MedicineSearch(string search)
        {

            List<Medicine> meds = db.Medicines.Where(temp => temp.MedName.Contains(search)).ToList();
            return View(meds);
        }

        public ActionResult NewLogIn()
        {
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View();
        }
        [HttpPost]
        public ActionResult NewLogIn(Login1 log )

        {
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            var lo = db.Login1.Where(x => x.Email == log.Email && x.UserPassword == log.UserPassword).SingleOrDefault();
                
                if (lo != null)
                {
                Session["Email"] =lo.Email.ToString() ;
                return RedirectToAction("Medicine", "Admin");
                   // Session["Admin"] = "AliRudra";
                }
                else
                {
                    ViewBag.ErrorMessage = "Email or password not found or matched";
                    return View();

                }
               

        }
        public ActionResult UpdateBilling()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateBilling(Billing bill)
        {


            Billing existingBilling = db.Billings.Where(temp => temp.MedName == bill.MedName).FirstOrDefault();

            existingBilling.MedName = bill.MedName;

            existingBilling.MedQuantity = bill.MedQuantity;


            existingBilling.Price = bill.Price;



            existingBilling.BillingDate = bill.BillingDate;


           


            db.SaveChanges();
            return RedirectToAction("Billing", "Admin");


        }
        public ActionResult UpdateMedicine()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateMedicine(Medicine med)
        {    
            
               
            Medicine existingMedicine = db.Medicines.Where(temp => temp.MedName == med.MedName).FirstOrDefault();

             existingMedicine.MedName = med.MedName;
            
             existingMedicine.MedStock  = med.MedStock;
            
            
                existingMedicine.Price = med.Price;
            
             
           
                existingMedicine.MedExpDate= med.MedExpDate;
             
            
                existingMedicine.MedCategory = med.MedCategory;
            


            db.SaveChanges(); 
            return RedirectToAction("Medicine", "Admin");
            

        }
        public ActionResult DeleteBilling()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteBilling(String MedName)
        {


            Billing Billing = db.Billings.Where(temp => temp.MedName == MedName).FirstOrDefault();
            db.Billings.Remove(Billing);
            db.SaveChanges();
            ViewBag.Billing = db.Billings.ToList();
            return RedirectToAction("Billing", "Admin");


        }
        public ActionResult DeleteMedicine()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteMedicine(String MedName)
        {


            Medicine Medicine = db.Medicines.Where(temp => temp.MedName == MedName).FirstOrDefault();
            db.Medicines.Remove(Medicine);
            db.SaveChanges();
            ViewBag.Medicine = db.Medicines.ToList();
            return RedirectToAction("Medicine", "Admin");


        }
        public ActionResult UpdateSeller()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateSeller(Seller sel)
        {


            Seller existingSeller = db.Sellers.Where(temp => temp.SellerName == sel.SellerName).FirstOrDefault();

            existingSeller.SellerAddress = sel.SellerAddress;

            existingSeller.SellerName = sel.SellerName;


            existingSeller.SellerEmail = sel.SellerEmail;



            existingSeller.SellerPassword = sel.SellerPassword;


            existingSeller.SellerDOB = sel.SellerDOB;
            existingSeller.SellerGender = sel.SellerGender;



            db.SaveChanges();
            return RedirectToAction("Seller", "Admin");


        }
        public ActionResult DeleteSeller()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteSeller(String SellerName)
        {


            Seller Seller = db.Sellers.Where(temp => temp.SellerName == SellerName).FirstOrDefault();
            db.Sellers.Remove(Seller);
            db.SaveChanges();
            ViewBag.Seller = db.Sellers.ToList();
            return RedirectToAction("Seller", "Admin");


        }

    }
}
 
 
