using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectPetey.Models;

namespace FinalProjectPetey.Controllers
{
    public class ShoppingCartController : Controller
    {
        //PeteyEntities3 pe = new PeteyEntities3();
        ProjectPeteyEntities pe = new ProjectPeteyEntities();
        //PeteyEntities1 pe = new PeteyEntities1();
        //PeteyEntities pe = new PeteyEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        private int isExisting(int id)
        {
            if (id >= 1 && id <= 39999)
            {
                List<item> cart = (List<item>)Session["cart"];
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Pet.Pet_Id == id)
                    {
                        return i;
                    }
                }
            }
            else if (id >= 40000 && id < 99500)
            {
                List<item> cart1 = (List<item>)Session["cart"];
                for (int i = 0; i < cart1.Count; i++)
                {
                    if (cart1[i].Product.Product_Id == id)
                    {
                        return i;
                    }
                }
            }
            else if (id >= 99500 && id < 110000)
            {
                List<item> cart2 = (List<item>)Session["cart"];
                for (int i = 0; i < cart2.Count; i++)
                {
                    if (cart2[i].Trainer.Trainer_Id == id)
                    {
                        return i;
                    }
                }
            }
            else
            {

            }
            return -1;
        }

        public ActionResult AddtoCart(int id)
        {
            if (id >= 1 && id <= 39999 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Pets.Where(a => a.Pet_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }
            else if (id >= 40000 && id < 99500 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Products.Where(a => a.Product_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }
            else if (id >= 99500 && id < 110000 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Trainers.Where(a => a.Trainer_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }
            else
            {
                if (Session["cart"] == null)
                {
                    if (id >= 1 && id <= 39999)
                    {
                        Session["id"] = "1";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Pets.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else if (id >= 40000 && id < 99500)
                    {
                        Session["id"] = "2";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Products.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else if (id >= 99500 && id < 110000)
                    {
                        Session["id"] = "3";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Trainers.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (id >= 1 && id <= 39999)
                    {
                        Session["id"] = "1";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Pets.Find(id), 1));
                        }
                        else
                        {
                            cart[index].Quantity++;
                        }
                        Session["cart"] = cart;

                    }
                    else if (id >= 40000 && id < 99500)
                    {
                        Session["id"] = "2";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Products.Find(id), 1));
                        }
                        else
                        {
                            cart[index].QuantityProduct++;
                        }
                        Session["cart"] = cart;
                    }
                    else if (id >= 99500 && id < 110000)
                    {
                        Session["id"] = "3";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Trainers.Find(id), 1));
                        }
                        else
                        {
                            cart[index].QuantityTrainer++;
                        }
                        Session["cart"] = cart;
                    }
                    else
                    {

                    }
                }
            }
            return View("ShoppingCart");
        }




        public ActionResult ViewDetails(int id)
        {

            //var Name = pe.customers
            //        .Where(x => x.Customer_Id == id)
            //        .Select(x => x.Fullname);

            //var Phone = pe.customers
            //        .Where(x => x.Customer_Id == id)
            //        .Select(x => x.Phone_No);

            //var Email = pe.customers
            //        .Where(x => x.Customer_Id == id)
            //        .Select(x => x.E_mail);

            //var Add = pe.customers
            //        .Where(x => x.Customer_Id == id)
            //        .Select(x => x.E_mail);

            //var avg = pe.PeviewStars
            //    .Where(x => x.Customer_id == id)
            //    .Select(x => x.Score)
            //    .Average();

            //Session["avg"] = avg;
            //Session["Name"] = Name;
            //Session["Phone"] = Phone;
            //Session["Email"] = Email;
            //Session["Address"] = Add;
            ViewData["AniDetails"] = pe.Pets.Where(a => a.Pet_Id == id).Single();

            return View();
        }


        public ActionResult ViewDetailsProduct(int id)
        {
            ViewData["ProDetails"] = pe.Products.Where(a => a.Product_Id == id).Single();
            return View();
        }


        public ActionResult Comment()
        {
            return View();
        }


        public ActionResult ViewDetailsTrainer(int id)
        {
            ViewData["TrainDetails"] = pe.Trainers.Where(a => a.Trainer_Id == id).Single();
            return View();
        }

        public ActionResult InputDetailsBuy(int id)
        {
            if (Session["cart"] == null)
            {
                List<item> cart = new List<item>();
                cart.Add(new item(pe.Pets.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<item> cart = (List<item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    cart.Add(new item(pe.Pets.Find(id), 1));
                }
                else
                {
                    cart[index].Quantity++;
                }
                Session["cart"] = cart;
            }

            return View("InputDetailsBuy");
        }


        public ActionResult Cart()
        {
            List<item> cart = (List<item>)Session["cart"];
            Session["cart"] = cart;
            return View("ShoppingCart");
        }

        public ActionResult Buy(int id)
        {
            if (id >= 1 && id <= 39999 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Pets.Where(a => a.Pet_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }
            else if (id >= 40000 && id < 99500 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Products.Where(a => a.Product_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }
            else if (id >= 99500 && id < 110000 && Session["UserID"] == null)
            {

                    Session["CheckAlert"] = "1";
                    ViewData["AniDetails"] = pe.Trainers.Where(a => a.Trainer_Id == id).Single();
                    return RedirectToAction("Login", "Account", new { area = "" });

            }

            else
            {
                if (Session["cart"] == null)
                {
                    if (id >= 1 && id <= 39999)
                    {
                        Session["id"] = "1";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Pets.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else if (id >= 40000 && id < 99500)
                    {
                        Session["id"] = "2";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Products.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else if (id >= 99500 && id < 110000)
                    {
                        Session["id"] = "3";
                        List<item> cart = new List<item>();
                        cart.Add(new item(pe.Trainers.Find(id), 1));
                        Session["cart"] = cart;
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (id >= 1 && id <= 39999)
                    {
                        Session["id"] = "1";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Pets.Find(id), 1));
                        }
                        else
                        {
                            cart[index].Quantity++;
                        }
                        Session["cart"] = cart;

                    }
                    else if (id >= 40000 && id < 99500)
                    {
                        Session["id"] = "2";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Products.Find(id), 1));
                        }
                        else
                        {
                            cart[index].QuantityProduct++;
                        }
                        Session["cart"] = cart;
                    }
                    else if (id >= 99500 && id < 110000)
                    {
                        Session["id"] = "3";
                        List<item> cart = (List<item>)Session["cart"];
                        int index = isExisting(id);
                        if (index == -1)
                        {
                            cart.Add(new item(pe.Trainers.Find(id), 1));
                        }
                        else
                        {
                            cart[index].QuantityTrainer++;
                        }
                        Session["cart"] = cart;
                    }
                    else
                    {

                    }
                }
            }

            return View();
        }

        public ActionResult DeleteRe(int id)
        {
            int index = isExisting(id);
            Session["Send"] = "1";
            if (id >= 1 && id <= 39999)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity += 0;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }
            else if (id >= 40000 && id < 99500)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].QuantityProduct > 1)
                {
                    cart[index].QuantityProduct += 0;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }
            else if (id >= 99500 && id < 110000)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].QuantityTrainer > 1)
                {
                    cart[index].QuantityTrainer += 0;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }else
            {

            }

            return View("ShoppingCart");
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);

            if (id >= 1 && id <= 39999)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }
            else if (id >= 40000 && id < 99500)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].QuantityProduct > 1)
                {
                    cart[index].QuantityProduct--;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }
            else if (id >= 99500 && id < 110000)
            {
                List<item> cart = (List<item>)Session["cart"];
                if (cart[index].QuantityTrainer > 1)
                {
                    cart[index].QuantityTrainer--;
                }
                else
                {
                    cart.RemoveAt(index);
                }

                Session["cart"] = cart;
            }else
            {

            }

            return View("ShoppingCart");
        }


        
        public ActionResult Save_Order(FormCollection fc)
        {
            int id = 0;
            decimal a = 2500, b = 3000, c = 2000, d = 3500, e = 6000;
            if (fc["Delivery"] == "2")
            {
                Session["price_send"] = a;
            }
            else if (fc["Delivery"] == "3")
            {
                Session["price_send"] = b;
            }
            else if (fc["Delivery"] == "4")
            {
                Session["price_send"] = c;
            }
            else if (fc["Delivery"] == "5")
            {
                Session["price_send"] = c;
            }
            else if (fc["Delivery"] == "6")
            {
                Session["price_send"] = d;
            }
            else
            {
                Session["price_send"] = e;
            }

            List<item> items = (List<item>)Session["cart"];
            decimal summary = 0;
            try
            {
                Order orders = new Order();
                orders.Grand_total = Convert.ToDecimal(Session["Grand_Total"]);
                orders.Customer_Id = Convert.ToInt32(Session["UserID"]);
                orders.Card_No = fc["Pay"];
                orders.Card_Name = fc["Delivery"];
                orders.Order_date = DateTime.Now;
                orders.Order_status = "New";
                pe.Orders.Add(orders);
                pe.SaveChanges();
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

            try
            {
                foreach (item it in items)
                {

                    if (it.Pet.Pet_Id != null || it.Product.Product_Id != null || it.Trainer.Trainer_Id != null)
                    {
                        if (it.Pet.Pet_Id >= 1 && it.Pet.Pet_Id <= 39999)
                        {
                            id = it.Pet.Pet_Id;
                        }
                        else if (it.Product.Product_Id >= 40000 && it.Product.Product_Id <= 99500)
                        {
                            id = it.Product.Product_Id;
                        }
                        else if (it.Trainer.Trainer_Id >= 99500 && it.Trainer.Trainer_Id <= 110000)
                        {
                            id = it.Trainer.Trainer_Id;
                        }else
                        {

                        }
                    }
                    if (id >= 1 && id <= 39999)
                    {
                        Orders_Details od = new Orders_Details();
                        od.Order_Id = pe.Orders.Max(item => item.Order_Id);
                        od.Product_Id = it.Pet.Pet_Id;
                        od.Amount = it.Quantity;
                        od.Sub_total = (it.Pet.Price * it.Quantity);
                        pe.Orders_Details.Add(od);
                        pe.SaveChanges();
                    }
                    else if (id >= 40000 && id < 99500)
                    {
                        Orders_Details od = new Orders_Details();
                        od.Order_Id = pe.Orders.Max(item => item.Order_Id);
                        od.Product_Id2 = it.Product.Product_Id;
                        od.Amount = it.QuantityProduct;
                        od.Sub_total = (it.Product.Price * it.QuantityProduct);
                        pe.Orders_Details.Add(od);
                        pe.SaveChanges();
                    }
                    else if (id >= 99500 && id < 110000)
                    {
                        Orders_Details od = new Orders_Details();
                        od.Order_Id = pe.Orders.Max(item => item.Order_Id);
                        od.Product_Id3 = it.Trainer.Trainer_Id;
                        od.Amount = it.QuantityTrainer;
                        od.Sub_total = (it.Trainer.Price * it.QuantityTrainer);
                        pe.Orders_Details.Add(od);
                        pe.SaveChanges();
                    }else
                    {

                    }
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

            if (fc["Pay"] == "30")
            {
                Session["Checkdiv"] = "1";
                return View("AddressInput");
            }
            else
            {
                return View("AddressInput");
            }
        }

        public ActionResult Save_Order2(FormCollection fc)
        {
            int a = pe.Orders.Max(i => i.Order_Id);
            Session["Max"] = a;
            try
            {
                Order order = pe.Orders.Where(x => x.Order_Id == a).Single();
                order.Name = fc["Name"];
                order.Adress = fc["Address"];
                order.Tel = fc["Tel"];
                order.Email = fc["Email"];
                order.Card_No = fc["Card_No"];
                order.Card_Name = fc["Card_Name"];
                pe.SaveChanges();
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
            ViewData["orderD"] = pe.Orders.Where(i => i.Order_Id == a).Single();
            return View("Confirm");
        }

        public ActionResult Address()
        {
            return View();
        }

        public ActionResult AddressInput()
        {
            return View();
        }

        public ActionResult Confirm()
        {
            int a = pe.Orders.Max(i => i.Order_Id);
            ViewData["orderD"] = pe.Orders.Where(i => i.Order_Id == a).Single();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(int id, FormCollection fc)
        {
            int checkreturn = 0;

            Comment com = new Comment();

            if (id >= 1 && id <= 39999)
            {
                checkreturn = 1;
                com.Customer_id = 2;
                com.Distance = fc["comment"];
                com.ID_Pet = id;
                pe.Comments.Add(com);
                pe.SaveChanges();

            }
            else if (id >= 40000 && id < 99500)
            {
                checkreturn = 2;
                com.Customer_id = 2;
                com.Distance = fc["comment"];
                com.ID_Product = id;
                pe.Comments.Add(com);
                pe.SaveChanges();

            }
            else if (id >= 99500 && id < 110000)
            {
                checkreturn = 3;
                com.Customer_id = 2;
                com.Distance = fc["comment"];
                com.ID_Trainer = id;
                pe.Comments.Add(com);
                pe.SaveChanges();
            }
            else
            {
                checkreturn = 1;
                com.Customer_id = 2;
                com.Distance = fc["comment"];
                com.ID_Pet = id;
                pe.Comments.Add(com);
                pe.SaveChanges();
            }

            if (checkreturn == 1)
            {
                ViewData["AniDetails"] = pe.Pets.Where(a => a.Pet_Id == id).Single();
                return View("ViewDetails", new { id = id });
               
            }
            else if (checkreturn == 2)
            {
                ViewData["ProDetails"] = pe.Products.Where(a => a.Product_Id == id).Single();
                return View("ViewDetailsProduct", new { id = id });
                
            }
            else
            {
                ViewData["TrainDetails"] = pe.Trainers.Where(a => a.Trainer_Id == id).Single();
                return View("ViewDetailsTrainer", new { id = id });
            }

        }
    }
}
