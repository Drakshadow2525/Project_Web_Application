using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectPetey.Controllers
{
    public class ProductReportController : Controller
    {
        // GET: ProductReport
        public ActionResult Index()
        {
            //ViewBag.ListPhones = rptEntities.Phones.ToList();
            return View();
        }

        //public ActionResult PhoneExportPDF()
        //{
        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Report/PReport.rpt")));
        //    rd.SetDataSource(rptEntities.Phones.Select(p => new
        //    {
        //        product_id = p.product_id,
        //        brand = p.brand,
        //        model = p.model,
        //        price = p.price.Value,
        //        cost = p.cost.Value
        //    }).ToList());

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();

        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    return File(stream, "application/pdf", "PhoneReport.pdf");
        //}
    }
}