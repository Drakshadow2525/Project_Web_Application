using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectPetey.Models;

namespace FinalProjectPetey.Controllers
{
    public class SumCargoesController : Controller
    {
        ProjectPeteyEntities db = new ProjectPeteyEntities();
        //PeteyEntities1 db = new PeteyEntities1();
        //private PeteyEntities db = new PeteyEntities();

        // GET: SumCargoes
        public ActionResult Index()
        {
            var sumCargoes = db.SumCargoes.Include(s => s.Pet).Include(s => s.Product).Include(s => s.Trainer);
            return View(sumCargoes.ToList());
        }

        // GET: SumCargoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumCargo sumCargo = db.SumCargoes.Find(id);
            if (sumCargo == null)
            {
                return HttpNotFound();
            }
            return View(sumCargo);
        }

        // GET: SumCargoes/Create
        public ActionResult Create()
        {
            ViewBag.Product_Id = new SelectList(db.Pets, "Pet_Id", "Name");
            ViewBag.Product_Id2 = new SelectList(db.Products, "Product_Id", "Name");
            ViewBag.Product_Id3 = new SelectList(db.Trainers, "Trainer_Id", "Name");
            return View();
        }

        // POST: SumCargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sum_Id,Product_Id,Product_Id2,Product_Id3")] SumCargo sumCargo)
        {
            if (ModelState.IsValid)
            {
                db.SumCargoes.Add(sumCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_Id = new SelectList(db.Pets, "Pet_Id", "Name", sumCargo.Product_Id);
            ViewBag.Product_Id2 = new SelectList(db.Products, "Product_Id", "Name", sumCargo.Product_Id2);
            ViewBag.Product_Id3 = new SelectList(db.Trainers, "Trainer_Id", "Name", sumCargo.Product_Id3);
            return View(sumCargo);
        }

        // GET: SumCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumCargo sumCargo = db.SumCargoes.Find(id);
            if (sumCargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_Id = new SelectList(db.Pets, "Pet_Id", "Name", sumCargo.Product_Id);
            ViewBag.Product_Id2 = new SelectList(db.Products, "Product_Id", "Name", sumCargo.Product_Id2);
            ViewBag.Product_Id3 = new SelectList(db.Trainers, "Trainer_Id", "Name", sumCargo.Product_Id3);
            return View(sumCargo);
        }

        // POST: SumCargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sum_Id,Product_Id,Product_Id2,Product_Id3")] SumCargo sumCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sumCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_Id = new SelectList(db.Pets, "Pet_Id", "Name", sumCargo.Product_Id);
            ViewBag.Product_Id2 = new SelectList(db.Products, "Product_Id", "Name", sumCargo.Product_Id2);
            ViewBag.Product_Id3 = new SelectList(db.Trainers, "Trainer_Id", "Name", sumCargo.Product_Id3);
            return View(sumCargo);
        }

        // GET: SumCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumCargo sumCargo = db.SumCargoes.Find(id);
            if (sumCargo == null)
            {
                return HttpNotFound();
            }
            return View(sumCargo);
        }

        // POST: SumCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SumCargo sumCargo = db.SumCargoes.Find(id);
            db.SumCargoes.Remove(sumCargo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
