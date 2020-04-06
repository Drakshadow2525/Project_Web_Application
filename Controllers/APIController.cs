using FinalProjectPetey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult OrderbyModelPet()
        {
            var orderModel = new OrderDetailsDataModel();
            var data = orderModel.GetOrderbyModelPet();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrderbyModelProduct()
        {
            var orderModel = new OrderDetailsDataModel();
            var data = orderModel.GetOrderbyModelProduct();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrderbyModelTrainer()
        {
            var orderModel = new OrderDetailsDataModel();
            var data = orderModel.GetOrderbyModelTrainer();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}