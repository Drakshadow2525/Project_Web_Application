using FinalProjectPetey.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    public class ProductCartController : Controller
    {
        // GET: ProductCart
        public ActionResult Index()
        {
            return View();
        }
  public ActionResult PhoneChart()
        {
            //var context = new ReportEntities();

            ArrayList xValue = new ArrayList();
            ArrayList yValuePrice = new ArrayList();
            ArrayList yValueCost = new ArrayList();

            //var result = (from c in context.Pets select c);

            //result.ToList().ForEach(rs => xValue.Add(rs.Gene));
            //result.ToList().ForEach(rs => yValuePrice.Add(rs.Price));

            ////var result2 = (from c in context.Products select c);

            //result2.ToList().ForEach(rs => xValue.Add(rs.Name));
            //result2.ToList().ForEach(rs => yValuePrice.Add(rs.Price));

            ////var result3 = (from c in context.Trainers select c);

            //result3.ToList().ForEach(rs => xValue.Add(rs.Name));
            //result3.ToList().ForEach(rs => yValuePrice.Add(rs.Price));

            //new Chart(width: 800, height: 500, theme: ChartTheme.Green)
            //.AddTitle("Chart for price and cost of products comparison")
            //.AddSeries("Price", chartType: "bar", xValue: xValue, yValues: yValuePrice)
            //.AddSeries("Cost", chartType: "bar", xValue: xValue, yValues: yValueCost)
            //.AddLegend()
            //.Write("png");

            return null;
        }
    }
    
}
