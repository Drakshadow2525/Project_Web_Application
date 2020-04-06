using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectPetey.Models;
using System.Threading.Tasks;

namespace FinalProjectPetey.Controllers
{
   // public int id;
    public class SellController : Controller
    {
        ProjectPeteyEntities pe = new ProjectPeteyEntities();
        //PeteyEntities1 pe = new PeteyEntities1();
        //PeteyEntities pe = new PeteyEntities();
        // GET: Sell

        public ActionResult Index()
        {
            ViewBag.listProduct = pe.Pets.ToList();
            //ViewBag.listProduct = pe.Products.ToList();
            //ViewBag.listProduct = pe.Trainers.ToList();
            return View();
        }

        public ActionResult Pet(string sortOrder, string searchString)
        {

            ViewBag.PriceSort = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "";
            var pet = from p in pe.Pets select p;
            ViewBag.listProduct = pe.Pets.ToList();

            if (sortOrder == "dog")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "สุนัข");
            }
            else if (sortOrder == "cat")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "แมว");
            }
            else if (sortOrder == "bird")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "นก");
            }
            else if (sortOrder == "rabbit")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "กระต่าย");
            }
            else if (sortOrder == "rat")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "หนู");
            }
            else if(sortOrder == "snake")
            {
                ViewBag.listProduct = pe.Pets.Where(p => p.Typess == "งู");
            }else
            {
                ViewBag.listProduct = pe.Pets.ToList();
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                pet = pet.Where(p => p.Gene.ToUpper().Contains(searchString.ToUpper()) || p.Sex.ToUpper().Contains(searchString.ToUpper()));
                ViewBag.listProduct = pet.ToList();
            }

            return View(pet);
        }

        public ActionResult Product(string sortOrder, string searchString)
        {
            ViewBag.PriceSort = String.IsNullOrEmpty(sortOrder) ? "Price_desc" : "";
            var product = from p in pe.Products select p;
            ViewBag.listProduct = pe.Products.ToList();

            if (sortOrder == "toy")
            {
                ViewBag.listProduct = pe.Products.Where(p => p.Typess== "ของเล่น");
            }
            else if (sortOrder == "food")
            {
                ViewBag.listProduct = pe.Products.Where(p => p.Typess == "อาหาร");
            }
            else if(sortOrder == "other")
            {
                ViewBag.listProduct = pe.Products.Where(p => p.Typess == "อุปกรณ์");
            }else
            {
                ViewBag.listProduct = pe.Products.ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()) || p.Brand.ToUpper().Contains(searchString.ToUpper()));
                ViewBag.listProduct = product.ToList();
            }
            return View(product);
        }

        public ActionResult Trainer(string searchString)
        {
            var trainer = from p in pe.Trainers select p;
            ViewBag.listProduct = pe.Trainers.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                trainer = trainer.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper()));
                ViewBag.listProduct = trainer.ToList();
            }
            return View(trainer);
        }



        public ActionResult Shop(int id)
        {
            var avg = pe.PeviewStars
                    .Where(x => x.Customer_id == id)
                    .Select(x => x.Score)
                    .Average();

            Session["avg"] = avg;
            ViewData["Shop"] = pe.customers.Where(a => a.Customer_Id == id).Single();
            return View();
        }

        public ActionResult RateVote(int id,FormCollection fc)
        {

            int ss = Convert.ToInt16(fc["rate"]);
            PeviewStar PeviewStar = new PeviewStar();
            PeviewStar.Customer_id = id;
            PeviewStar.Score = ss;
            pe.PeviewStars.Add(PeviewStar);
            pe.SaveChanges();


            ViewData["Shop"] = pe.customers.Where(a => a.Customer_Id == id).Single();
            return View("Shop", new { id = id });
        }


      
    }
}