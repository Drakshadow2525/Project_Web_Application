using FinalProjectPetey.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    // [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class DataSellController : Controller
    {
        //PeteyEntities3 Cp = new PeteyEntities3();
        ProjectPeteyEntities Cp = new ProjectPeteyEntities();
        //PeteyEntities1 Cp = new PeteyEntities1();
        //PeteyEntities Cp = new PeteyEntities();
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePet()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePet(int id, FormCollection fc)
        {

            try
            {
                string date = fc["Birthdate"];
                string Price = fc["Price"];
                Pet pet = new Pet();
                if (ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/images_pet"), fileName);
                        file.SaveAs(path);
                        pet.Images = fileName;
                    }
                }
                pet.Name = fc["Name"];
                pet.Customer_id = id;
                pet.Price = Convert.ToDecimal(Price);
                pet.Sex = fc["Sex"];
                pet.Birthdate = Convert.ToDateTime(date);
                pet.Gene = fc["Gene"];
                pet.History = fc["History"];
                pet.Typess = fc["Type"];
                Cp.Pets.Add(pet);
                Cp.SaveChanges();
                Session["id"] = pet.Pet_Id;
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
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return View("Addpic");
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreaterProduct(FormCollection fc, int id)
        {
            try
            {
                var Sesion = Session["User_id"];
                string date = fc["Birthdate"];
                string Price = fc["Price"];
                string date2 = fc["Exp_date"];
                Product pro = new Product();
                pro.Name = fc["Name"];
                pro.Customer_id = id;
                pro.Price = Convert.ToDecimal(Price);
                pro.Pro_date = Convert.ToDateTime(date);
                pro.Exp_date = Convert.ToDateTime(date2);
                pro.Brand = fc["Brand"];
                pro.Detalis = fc["Detalis"];
                pro.Typess = fc["Type"];
                if (ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/images_product"), fileName);
                        file.SaveAs(path);
                        pro.Images = fileName;
                    }
                }
                Cp.Products.Add(pro);
                Cp.SaveChanges();
                Session["id"] = pro.Product_Id;
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
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return View("Addpic");
        }
        public ActionResult CreateTrainer()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTrainer(RegisterViewModel model, FormCollection fc, int id)
        {
            try
            {
                var Sesion = Session["User_id"];
                string date = fc["Birthdate"];
                string Price = fc["Price"];
                Trainer T = new Trainer();
                T.Name = fc["Name"];
                T.Customer_id = id;
                T.Price = Convert.ToDecimal(Price);
                T.Details = fc["Details"];
                if (ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/images_trainer"), fileName);
                        file.SaveAs(path);
                        T.Images = fileName;
                    }
                }
                Cp.Trainers.Add(T);
                Cp.SaveChanges();
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
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return View("Addpic");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Updatepic(int id, FormCollection fc)
        {
            Trainer T = new Trainer();
            Product pro = new Product();
            Pet pet = new Pet();
            if (id != null)
            {
                if (id <= 1 || id >= 39999)
                {
                    if (ModelState.IsValid)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/images_pet"), fileName);
                            file.SaveAs(path);
                            pet.Images2 = fileName;
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/images_pet"), fileName);
                            file.SaveAs(path);
                            pet.Images3 = fileName;
                        }
                    }


                    if (ModelState.IsValid)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/images_pet"), fileName);
                            file.SaveAs(path);
                            pet.Images4 = fileName;
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/images_pet"), fileName);
                            file.SaveAs(path);
                            pet.Images5 = fileName;
                        }
                    }
                    Cp.Entry(pet).State = EntityState.Modified;
                    //Cp.Pets.Add(pet);
                    Cp.SaveChanges();
                }
             
            }
            return View();
        }

        public ActionResult MenuAdd()
        {
            return View("MenuAdd");
        }

        public ActionResult Addpic()
        {
            return View();
        }



        // GET: EditShop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditShop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EditShop/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            return View();
        }

        // POST: EditShop/Delete/5
        [HttpPost]
        public ActionResult DeleteProduct(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EditShop/Delete/5
        public ActionResult DeleteTrainer(int id)
        {
            return View();
        }

        // POST: EditShop/Delete/5
        [HttpPost]
        public ActionResult DeleteTrainer(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var databyid = Cp.Pets.Single(x => x.Pet_Id == id);
            return View(databyid);
        }

        // POST: EditShop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pet col)
        {
            try
            {
                Pet Petobj = Cp.Pets.Single(x => x.Pet_Id == id);
                Petobj.Pet_Id = col.Pet_Id;
                Petobj.Name = col.Name;
                Petobj.Price = col.Price;
                Petobj.Gene = col.Gene;
                Petobj.History = col.History;

                Cp.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");             
            }

            ViewBag.petlist = Cp.Pets.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.productlist = Cp.Products.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.trainerlist = Cp.Trainers.Where(i => i.Customer_id == col.Customer_id).ToList();

            return View("Listmyshoporder");
        }

        public ActionResult EditProduct(int id)
        {
            var databyid = Cp.Products.Single(x => x.Product_Id == id);
            return View(databyid);
        }

        // POST: EditShop/Edit/5
        [HttpPost]
        public ActionResult EditProduct(int id, Product col)
        {
            try
            {
                Product pr = Cp.Products.Single(x => x.Product_Id == id);
                pr.Product_Id = col.Product_Id;
                pr.Name = col.Name;
                pr.Price = col.Price;               
                pr.Detalis = col.Detalis;
                pr.Exp_date = col.Exp_date;
                pr.Pro_date = col.Pro_date;
                pr.Brand = col.Brand;
                Cp.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }

            ViewBag.petlist = Cp.Pets.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.productlist = Cp.Products.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.trainerlist = Cp.Trainers.Where(i => i.Customer_id == col.Customer_id).ToList();

            return View("Listmyshoporder");
        }

        public ActionResult EditTrainer(int id)
        {
            var databyid = Cp.Trainers.Single(x => x.Trainer_Id == id);
            return View(databyid);
        }

        // POST: EditShop/Edit/5
        [HttpPost]
        public ActionResult EditTrainer(int id, Trainer col)
        {
            try
            {
                Trainer pr = Cp.Trainers.Single(x => x.Trainer_Id == id);
                pr.Trainer_Id = col.Trainer_Id;
                pr.Name = col.Name;
                pr.Price = col.Price;
                pr.Details = col.Details;
                Cp.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }

            ViewBag.petlist = Cp.Pets.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.productlist = Cp.Products.Where(i => i.Customer_id == col.Customer_id).ToList();
            ViewBag.trainerlist = Cp.Trainers.Where(i => i.Customer_id == col.Customer_id).ToList();

            return View("Listmyshoporder");
        }




        public ActionResult Listmyshoporder(int id)
        {

            ViewBag.petlist = Cp.Pets.Where(i => i.Customer_id == id).ToList();
            ViewBag.productlist = Cp.Products.Where(i => i.Customer_id == id).ToList();
            ViewBag.trainerlist = Cp.Trainers.Where(i => i.Customer_id == id).ToList();

            return View();
        }
    }
}
