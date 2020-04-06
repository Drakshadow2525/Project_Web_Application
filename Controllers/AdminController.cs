using FinalProjectPetey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    public class AdminController : Controller
    {
        ProjectPeteyEntities Ad = new ProjectPeteyEntities();
        //PeteyEntities1 Ad = new PeteyEntities1();
        //PeteyEntities Ad = new PeteyEntities();
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Shop()
        {
            ViewBag.listProduct = Ad.customers.Where(c => c.Shop_name != null).ToList();
            Session["ShowDataUser"] = "0";
            return View();
        }

        public ActionResult ManagUser()
        {
            return View();
        }

        public ActionResult User()
        {
            ViewBag.listProduct = Ad.customers.ToList();
            Session["ShowDataUser"] = "0";
            return View();
        }


        public ActionResult ShowDataUser(int id)
        {
            ViewBag.listProduct = Ad.customers.ToList();
            ViewData["ShowDataUser"] = Ad.customers.Where(c => c.Customer_Id == id).Single();
            Session["ShowDataUser"] = "1";
            return View("User");
        }

        public ActionResult ShowDataShop(int id)
        {
            ViewBag.listProduct = Ad.customers.Where(c => c.Shop_name != null).ToList();
            ViewData["ShowDataUser"] = Ad.customers.Where(c => c.Customer_Id == id).Single();
            Session["ShowDataUser"] = "1";
            return View("Shop");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserdata(int id, FormCollection fc)
        {
            int a = 0;
            try
            {
                customer cus = Ad.customers.Where(c => c.Customer_Id == id).Single();

                if (cus.Shop_name == null)
                {
                    a = 1;
                    ViewBag.listProduct = Ad.customers.ToList();
                    cus.E_mail = fc["Email"];
                    cus.Username = fc["Username"];
                    cus.Fullname = fc["Fullname"];
                    cus.Phone_No = fc["Tel"];
                    cus.Address = fc["Address"];
                    Ad.SaveChanges();
                }
                else
                {
                    ViewBag.listProduct = Ad.customers.Where(c => c.Shop_name != null).ToList();
                    cus.E_mail = fc["Email"];
                    cus.Username = fc["Username"];
                    cus.Fullname = fc["Fullname"];
                    cus.Phone_No = fc["Tel"];
                    cus.Address = fc["Address"];
                    cus.Shop_name = fc["Shop_name"];
                    cus.Name_Bank = fc["Bank_Name"];
                    cus.Name_Owner = fc["Bank_NameOwner"];
                    cus.Id_Bank = fc["Bank_No"];
                    cus.Card_No = fc["Credit_No"];
                    Ad.SaveChanges();
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }



            ViewData["ShowDataUser"] = Ad.customers.Where(c => c.Customer_Id == id).Single();
            Session["ShowDataUser"] = "1";

            if (a == 1)
                return View("User");
            else
                return View("Shop");
        }

        public ActionResult AddtoSumCargo(int id)
        {
            if (Session["sum"] == null)
            {
                List<item> cart = new List<item>();
                cart.Add(new item(Ad.Pets.Find(id), 1));
                Session["sum"] = cart;
            }
            else
            {

            }
            return Redirect("Sumcargo");
        }

        public ActionResult SumCargo()
        {
            ViewBag.listProduct = Ad.Pets.ToList();
            return View();
        }

        public ActionResult SumCargoa(int id)
        {
            SumCargo su = new SumCargo();
            su.Product_Id = id;
            Ad.SumCargoes.Add(su);
            Ad.SaveChanges();

            ViewBag.SumCargoes = Ad.SumCargoes.ToList();
            ViewBag.listProduct = Ad.Pets.ToList();
            return View("SumCargo");

        }

        public ActionResult SumCargoPro()
        {
            ViewBag.listProduct = Ad.Products.ToList();
            return View();
        }


        public ActionResult Orders()
        {
            var order = Ad.Orders.ToList();
            return View(order);
        }


        public ActionResult Orders_Details(int id)
        {
            var order = Ad.Orders_Details.Where(i => i.Order_Id == id).ToList();
            //var order = Ad.Orders_Details.ToList();
            return View(order);
        }


        public ActionResult SumCargoPro(int id)
        {
            SumCargo su = new SumCargo();
            su.Product_Id = id;
            Ad.SumCargoes.Add(su);
            Ad.SaveChanges();

            ViewBag.listProduct = Ad.Products.ToList();
            return View("SumCargoPro");

        }

        public ActionResult SumCargoTrainer()
        {
            ViewBag.listProduct = Ad.Trainers.ToList();
            return View();
        }

        public ActionResult SumCargoTrainer(int id)
        {
            SumCargo su = new SumCargo();
            su.Product_Id = id;
            Ad.SumCargoes.Add(su);
            Ad.SaveChanges();

            ViewBag.listProduct = Ad.Trainers.ToList();
            return View("SumCargoTrainer");

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FilterPet(int id, FormCollection fc)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FilterPro(int id, FormCollection fc)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FilterTrainer(int id, FormCollection fc)
        {
            return View();
        }
    }
}