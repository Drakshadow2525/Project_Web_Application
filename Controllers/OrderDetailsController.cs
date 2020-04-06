using FinalProjectPetey.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    public class OrderDetailsController : Controller
    {
        ProjectPeteyEntities db = new ProjectPeteyEntities();

        //PeteyEntities3 db = new PeteyEntities3();
        // GET: OrderDetailspr
        //public ActionResult Index()
        //{
        //    var orderDetailsP = db.Orders_Details.Include(o => o.Pet);
        //    var orderDetailsPe = db.Orders_Details.Include(Pro => Pro.Product);
        //    var orderDetailsTr = db.Orders_Details.Include( Tra => Tra.Trainer);

        //    return View(orderDetailsP.ToList());
        //    return View(orderDetailsPe.ToList());
        //    return View(orderDetailsTr.ToList());
        //}

        //public ViewResult ViewOrderDetails()
        //{
        //    IEnumerable <OrderDetailsViewModel> model = null;
        //    model = (from prod in db.Orders_Details
        //             join o in db.Pets on prod.Product_Id equals o.Pet_Id
        //             join Pro in db.Products on prod.Product_Id2 equals Pro.Product_Id
        //             join Tra in db.Trainers on prod.Product_Id3 equals Tra.Trainer_Id
        //             select new OrderDetailsViewModel
        //             {
        //                 Gene = o.Gene,
        //                 Name = o.Name,
        //                 BrandProduct = Pro.Name,
        //                 NameProduct = Pro.Brand,
        //                 NameTrainer = Tra.Name,
        //                 PricePet = (decimal)o.Price,
        //                 PriceProduct =(decimal)Pro.Price,
        //                 PriceTrainer= (decimal)Tra.Price,
        //                 Amount = (int)prod.Amount,
        //                 AmountProduct = (int)prod.Amount,
        //                 AmountTrainer = (int)prod.Amount,
        //                 Total = (decimal)prod.Sub_total,
        //                 TotalProduct = (decimal)prod.Sub_total,
        //                 TotalTrainer = (decimal)prod.Sub_total

        //             });
        //    return View(model);
        //}



        public ActionResult IndexPet()
        {
            var orderDetailsP = db.Orders_Details.Include(o => o.Pet);
            return View(orderDetailsP.ToList());
        }

        public ViewResult ViewOrderDetailspet()
        {
            IEnumerable<OrderDetailsViewModelPet> model = null;
            model = (from prod in db.Pets
                     join o in db.Orders_Details on prod.Pet_Id equals o.Product_Id
                     select new OrderDetailsViewModelPet
                     {
                         Gene = prod.Gene,
                         Name = prod.Name,
                         PricePet = (decimal)prod.Price,
                         Amount = (int)o.Amount,
                         Total = (decimal)o.Sub_total,
                     });
            return View(model);
        }


        public ActionResult IndexProduct()
        {
            var orderDetailsTr = db.Orders_Details.Include(Tra => Tra.Trainer);
            return View(orderDetailsTr.ToList());
        }

        public ViewResult ViewOrderDetailsProduct()
        {
            IEnumerable<OrderDetailsViewModelProduct> model = null;
            model = (from prod in db.Products
                     join Tra in db.Orders_Details on prod.Product_Id equals Tra.Product_Id2
                     select new OrderDetailsViewModelProduct
                     {
                         NameProduct = prod.Name,
                         BrandProduct = prod.Brand,
                         PriceProduct = (decimal)prod.Price,
                         AmountProduct = (int)Tra.Amount,
                         TotalProduct = (decimal)Tra.Sub_total,
                     });
            return View(model);
        }


        public ActionResult IndexTrainer()
        {
            var orderDetailsP = db.Orders_Details.Include(o => o.Pet);
            return View(orderDetailsP.ToList());
        }

        public ViewResult ViewOrderDetailsTrainer()
        {
            IEnumerable<OrderDetailsViewModelTrainer> model = null;
            model = (from prod in db.Trainers
                     join Tra in db.Orders_Details on prod.Trainer_Id equals Tra.Product_Id3
                     select new OrderDetailsViewModelTrainer
                     {
                         NameTrainer= prod.Name,
                         PriceTrainer = (decimal)prod.Price,
                         AmountTrainer = (int)Tra.Amount,
                         TotalTrainer = (decimal)Tra.Sub_total,
                     });
            return View(model);
        }

        //ExcelExport
        public HttpResponseBase ExcelExportPet()
        {
            var api = new APIController();
            var jsonDataExport = JsonConvert.SerializeObject(api.OrderbyModelPet().Data);
            string filename = "OrderPetSummary";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonDataExport, (typeof(DataTable)));
            string fullDetail = string.Empty;

            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                fullDetail = fullDetail + tab + dc.ColumnName;
                tab = ",";
            }
            fullDetail = fullDetail + "\n";
            int ii;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (ii = 0; ii < dt.Columns.Count; ii++)
                {
                    fullDetail = fullDetail + tab + dr[ii].ToString().Replace(',', '‚');
                    tab = ",";
                }
                fullDetail = fullDetail + "\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("contentdisposition", string.Format("attachment;filename={0}.csv", filename));
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.UTF32;
            byte[] BOX = new byte[] { 0xef, 0xbb, 0xbf };
            Response.BinaryWrite(BOX);
            Response.BinaryWrite(Encoding.UTF8.GetBytes(fullDetail));
            Response.Flush();
            Response.End();
            return null;
        }

        public HttpResponseBase ExcelExportProduct()
        {
            var api = new APIController();
            var jsonDataExport = JsonConvert.SerializeObject(api.OrderbyModelProduct().Data);
            string filename = "OrderProductSummary";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonDataExport, (typeof(DataTable)));
            string fullDetail = string.Empty;

            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                fullDetail = fullDetail + tab + dc.ColumnName;
                tab = ",";
            }
            fullDetail = fullDetail + "\n";
            int ii;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (ii = 0; ii < dt.Columns.Count; ii++)
                {
                    fullDetail = fullDetail + tab + dr[ii].ToString().Replace(',', '‚');
                    tab = ",";
                }
                fullDetail = fullDetail + "\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("contentdisposition", string.Format("attachment;filename={0}.csv", filename));
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.UTF32;
            byte[] BOX = new byte[] { 0xef, 0xbb, 0xbf };
            Response.BinaryWrite(BOX);
            Response.BinaryWrite(Encoding.UTF8.GetBytes(fullDetail));
            Response.Flush();
            Response.End();
            return null;
        }

        public HttpResponseBase ExcelExportTrainer()
        {
            var api = new APIController();
            var jsonDataExport = JsonConvert.SerializeObject(api.OrderbyModelTrainer().Data);
            string filename = "OrderTrainerSummary";
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonDataExport, (typeof(DataTable)));
            string fullDetail = string.Empty;

            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                fullDetail = fullDetail + tab + dc.ColumnName;
                tab = ",";
            }
            fullDetail = fullDetail + "\n";
            int ii;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (ii = 0; ii < dt.Columns.Count; ii++)
                {
                    fullDetail = fullDetail + tab + dr[ii].ToString().Replace(',', '‚');
                    tab = ",";
                }
                fullDetail = fullDetail + "\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("contentdisposition", string.Format("attachment;filename={0}.csv", filename));
            Response.ContentType = "text/csv";
            Response.ContentEncoding = Encoding.UTF32;
            byte[] BOX = new byte[] { 0xef, 0xbb, 0xbf };
            Response.BinaryWrite(BOX);
            Response.BinaryWrite(Encoding.UTF8.GetBytes(fullDetail));
            Response.Flush();
            Response.End();
            return null;
        }
    }
}