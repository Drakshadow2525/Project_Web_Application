using Antlr.Runtime;
using FinalProjectPetey.Models;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using static FinalProjectPetey.Models.RegistershopViewModel;

namespace FinalProjectPetey.Controllers
{
    public class AccountController : Controller
    {

        ProjectPeteyEntities Re = new ProjectPeteyEntities();
        //PeteyEntities3 Re = new PeteyEntities3();
        //PeteyEntities1 Re = new PeteyEntities1();

        //PeteysEntities Re = new PeteysEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registers()
        {
            return View();
        }

        public ActionResult resetpassword1()
        {
            return View();
        }

        public ActionResult resetpassword2()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult accept()
        {
            return View();
        }

        public ActionResult accepts()
        {
            return View();
        }

        public ActionResult Condition()
        {
            return View();
        }

        public ActionResult Conditiontwo()
        {
            return View();
        }
        public ActionResult Rsellproduct()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registers(RegisterViewModel model, FormCollection fc)
        {
            try
            {
                string date = fc["Birthdate"];
                customer cus = new customer();
                cus.Username = fc["Username"];
                cus.Password = fc["Password"];
                cus.ConfirmPassword = fc["ConfirmPassword"];
                cus.E_mail = fc["E_mail"];
                cus.Fullname = fc["Fullname"];
                cus.Sex = fc["Sex"];
                cus.Birthdate = Convert.ToDateTime(date);
                cus.Phone_No = fc["Phone_No"];
                cus.Address = fc["Address"];
                cus.UserType = "User";
                Re.customers.Add(cus);
                Re.SaveChanges();
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
            return View("Conditiontwo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rsellproduct(int id ,FormCollection fc)
        {
            try
            {
                //string iframe = fc["iframe"];
               // var cus2 = (customer)Session["UserID"];
                customer cus = Re.customers.Where(a => a.Customer_Id == id).Single(); ;

                if (ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null & file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/images_Shop"), fileName);
                        file.SaveAs(path);
                        cus.Images = fileName;
                    }
                }
                cus.Shop_name = fc["Shop_name"];
                cus.Name_Bank = fc["Name_Bank"];
                cus.Name_Owner = fc["Name_Owner"];
                cus.Card_No = fc["Card_No"];
                cus.Id_Bank = fc["Id_Bank"];
                cus.UserType = "Shop";
                Re.Entry(cus).State = EntityState.Modified;
                //Re.customers.Add(cus);
                Re.SaveChanges();
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
            Session["Shop_name"] = "0";
            Session["UserName"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Conditiontwo", "Account", new { area = "" });
            //return View("Conditiontwo");
        }

        //private void ConfigureViewModel(RegistershopViewModel model)
        //{
        //    IEnumerable<Productss> products = Repository.FetchProducts();
        //    model.ProductList = new SelectList(products, "ID", "Name");
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(customer objUser)
        {
            if (ModelState.IsValid)
                {
                    using (ProjectPeteyEntities db = new ProjectPeteyEntities())
                    {
                        var obj = db.customers.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["UserID"] = obj.Customer_Id;
                            Session["UserName"] = obj.Username;
                            Session["UserType"] = obj.UserType;
                            if (obj.Shop_name == null && obj.Username != "admin")
                            {
                                Session["Shop_name"] = "1";
                                Session["CheckLogin"] = "0";
                            if (Session["CheckAlert"] == "1")
                            {
                                Session["CheckAlert"] = "0";
                                return RedirectToAction("Pet", "Sell", new { area = "" });
                            }
                            else
                            {
                                return RedirectToAction("Condition", "Account", new { area = "" });
                            }
                            }
                            else if (obj.Username == "admin")
                            {
                                Session["Shop_name"] = "2";
                                Session["CheckLogin"] = "0";
                                Session["CheckAlert"] = "0";
                                return RedirectToAction("Admin", "Admin", new { area = "" });
                            }
                            else if (obj.Shop_name != null)
                            {
                                Session["Shop_name"] = "3";
                                Session["CheckLogin"] = "0";
                            if (Session["CheckAlert"] == "1")
                            {
                                Session["CheckAlert"] = "0";
                                return RedirectToAction("Pet", "Sell", new { area = "" });
                            }
                            else
                            {
                                return RedirectToAction("Condition", "Account", new { area = "" });
                            }
                            }
                            else
                            {

                            }
                    }else
                    {
                        Session["CheckLogin"] = "1";
                        return RedirectToAction("Login", "Account", new { area = "" });
                    }
                    }
                }
            
            return View(objUser);
        }

        public ActionResult Logout()
        {
            Session["Shop_name"] = "0";
            Session["UserName"] = null;
            Session["UserType"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind (Include = "Customer_id,Username,Password,ConfirmPassword,Fullname,Sex,Birthdate,Phone_No,E_mail,Address,Shop_name,Name_Bank,Name_Owner,Card_No,Id_Bank,UserType" )] customer cus)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult resetpassword1(FormCollection fc)
        {
            ViewBag.cuslist = Re.customers.ToList();
            int a = 1;

            foreach (customer c in ViewBag.cuslist)
            {
                if (c.Username.Equals(fc["Username"]) && c.Birthdate.Equals(Convert.ToDateTime(fc["Birtdate"])) && c.Phone_No.Equals(fc["Tel"]))
                {
                    a = 2;
                    Session["UserId"] = c.Customer_Id;
                }
            }

            if (a == 2)
            {
                return View("resetpassword2");
            }
            else
            {
                Session["Check1"] = "1";
                return View("resetpassword1");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult resetpassword2(FormCollection fc)
        {
            int a = Convert.ToInt32(Session["UserId"]);

            if (fc["Password"] == fc["RePassword"])
            {
                try
                {
                    customer cus = Re.customers.Where(c => c.Customer_Id == a).Single();
                    cus.Password = fc["Password"];
                    Re.SaveChanges();
                    return View("Login");
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
            }
            else
            {
                Session["Check2"] = "1";
                return View("resetpassword2");
            }


        }


        public ActionResult EditUser(int id)
        {

            ViewData["Userdata"] = Re.customers.Where(i => i.Customer_Id == id).Single();
            return View();
        }

        public ActionResult EditShop(int id)
        {

            ViewData["Userdata"] = Re.customers.Where(i => i.Customer_Id == id).Single();
            return View();
        }


        public ActionResult EditUser1(FormCollection fc, int id)
        {
            int a = 0;
            try
            {
                customer customer = Re.customers.Where(i => i.Customer_Id == id).Single();

                if (customer.Shop_name == null)
                {
                    a = 1;
                    customer.Fullname = fc["Name"];
                    customer.Phone_No = fc["Phone"];
                    customer.E_mail = fc["Email"];
                    customer.Address = fc["Address"];
                    Re.SaveChanges();
                }
                else
                {
                    a = 2;      
                    customer.Fullname = fc["Name"];
                    customer.Phone_No = fc["Phone"];
                    customer.E_mail = fc["Email"];
                    customer.Shop_name = fc["Shop_name"];
                    customer.Name_Bank = fc["Name_Bank"];
                    customer.Name_Owner = fc["Name_Owner"];
                    customer.Card_No = fc["Card_No"];
                    customer.Id_Bank = fc["Id_Bank"];
                    Re.SaveChanges();
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

            ViewData["Userdata"] = Re.customers.Where(i => i.Customer_Id == id).Single();
            Session["CheckInsert"] = "1";
            if (a == 1)
            {
                return View("EditUser", new { id = id });
            }else
            {
                return View("EditShop", new { id = id });
            }
        }

        public ActionResult Myorder(int id)
        {
            using (ProjectPeteyEntities ent = new ProjectPeteyEntities())
            {

               // var query =
               //    from post in database.Posts
               //    join meta in database.Post_Metas on post.ID equals meta.Post_ID
               //    where post.ID == id
               //    select new { Post = post, Meta = meta };

               // var query = database.Posts    // your starting point - table in the "from" statement
               //.Join(database.Post_Metas, // the source table of the inner join
               //   post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
               //   meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
               //   (post, meta) => new { Post = post, Meta = meta }) // selection
               //.Where(postAndMeta => postAndMeta.Post.ID == id);

                IEnumerable<ViewModel> Myorder_order = null;
                dynamic dmodel = new ExpandoObject();
                dmodel.Myorder_order = (from od in ent.Orders_Details
                                join oo in ent.Orders on od.Order_Id equals oo.Order_Id
                                join p in ent.Pets on od.Product_Id equals p.Pet_Id
                                join pr in ent.Products on od.Product_Id2 equals pr.Product_Id
                                join t in ent.Trainers on od.Product_Id3 equals t.Trainer_Id
                                where oo.Customer_Id == id
                                select new 
                {
                    Pid = p.Pet_Id,
                    Pname = p.Gene,
                    Pimages = p.Images,
                    Pprice = (decimal)p.Price,
                    Prid = pr.Product_Id,
                    Prname = pr.Name,
                    Primages = p.Images,
                    Prprice = (decimal)p.Price,

                    Tid = t.Trainer_Id,
                    Tname = t.Name,
                    Timages = t.Images,
                    Tprice = (decimal)t.Price,

                    order_id = oo.Order_Id,
                    time = oo.Order_date
                });
                //var viewModel = new MyViewModel { SemesterFaculties = Myorder_order.ToList() };
                ViewBag.Myorder_order = Myorder_order.ToList();

                return View(Myorder_order.ToList());

                //              var Myorder_order = 
                //                                from od in ent.Orders_Details
                //                                join oo in ent.Orders on od.Order_Id equals oo.Order_Id
                //                                join p in ent.Pets on od.Product_Id equals p.Pet_Id
                //                                join pr in ent.Products on od.Product_Id2 equals pr.Product_Id
                //                                join t in ent.Trainers on od.Product_Id3 equals t.Trainer_Id
                //                                select new {
                //                                    oo.Order_date, p.Pet_Id, p.Gene, p.Price, pr.Product_Id, pr.Name, pr.Images, t.Trainer_Id
                //                                };
                //var orderd = new List<Orders_Details>();
                //        foreach (var t in Myorder_order)
                //        {
                //            orderd.Add(new Orders_Details()
                //            {
                //                Pet_Id = t.Pet_Id,
                //                Gene = t.Gene,
                //                Images = t.Images,

                //                Pprice = (decimal)t.Price,
                //                Prid = t.Product_Id,
                //                Prname = t.Name,
                //                Primages = t.Images,

                //                Prprice = (decimal)t.Price,
                //                Tid = t.Trainer_Id,
                //                Tname = t.Name,
                //                Timages = t.Images,
                //                Tprice = (decimal)t.Price,

                //                time = t.Order_date


                //        });
                //        }
                //        return View(orderd);
            }
        }
    }
}