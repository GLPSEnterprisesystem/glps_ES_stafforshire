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
    public class appin_dataController : Controller
    {
        private glpsContext db = new glpsContext();

        // GET: appin_data
        public ActionResult Index()
        {
            return View(db.appin_Datas.ToList());
        }

        // GET: appin_data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appin_data appin_data = db.appin_Datas.Find(id);
            if (appin_data == null)
            {
                return HttpNotFound();
            }
            return View(appin_data);
        }

        // GET: appin_data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: appin_data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Flight,Seat_Number,Fore_Name,Family_Name,Passport_Number,Country_of_Issue")] appin_data appin_data)
        {
            if (ModelState.IsValid)
            {
                db.appin_Datas.Add(appin_data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appin_data);
        }

        // GET: appin_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appin_data appin_data = db.appin_Datas.Find(id);
            if (appin_data == null)
            {
                return HttpNotFound();
            }
            return View(appin_data);
        }

        // POST: appin_data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Flight,Seat_Number,Fore_Name,Family_Name,Passport_Number,Country_of_Issue")] appin_data appin_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appin_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appin_data);
        }

        // GET: appin_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appin_data appin_data = db.appin_Datas.Find(id);
            if (appin_data == null)
            {
                return HttpNotFound();
            }
            return View(appin_data);
        }

        // POST: appin_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appin_data appin_data = db.appin_Datas.Find(id);
            db.appin_Datas.Remove(appin_data);
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
