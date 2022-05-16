using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using glps.DAL;
using glps.Models;

namespace glps.Controllers
{
    public class airport_dataController : Controller
    {
        private glpsContext db = new glpsContext();

        // GET: airport_data
        public ActionResult Index()
        {
            return View(db.airport_Datas.ToList());
        }

        // GET: airport_data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airport_data airport_data = db.airport_Datas.Find(id);
            if (airport_data == null)
            {
                return HttpNotFound();
            }
            return View(airport_data);
        }

        // GET: airport_data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: airport_data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IATA_code,ISO_Alpha_Code,Long_Name,Location")] airport_data airport_data)
        {
            if (ModelState.IsValid)
            {
                db.airport_Datas.Add(airport_data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airport_data);
        }

        // GET: airport_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airport_data airport_data = db.airport_Datas.Find(id);
            if (airport_data == null)
            {
                return HttpNotFound();
            }
            return View(airport_data);
        }

        // POST: airport_data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IATA_code,ISO_Alpha_Code,Long_Name,Location")] airport_data airport_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airport_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airport_data);
        }

        // GET: airport_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airport_data airport_data = db.airport_Datas.Find(id);
            if (airport_data == null)
            {
                return HttpNotFound();
            }
            return View(airport_data);
        }

        // POST: airport_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            airport_data airport_data = db.airport_Datas.Find(id);
            db.airport_Datas.Remove(airport_data);
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
