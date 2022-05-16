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
    public class asset_detailsController : Controller
    {
        private glpsContext db = new glpsContext();

        // GET: asset_details
        public ActionResult Index()
        {
            return View(db.asset_Details.ToList());
        }

        // GET: asset_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asset_details asset_details = db.asset_Details.Find(id);
            if (asset_details == null)
            {
                return HttpNotFound();
            }
            return View(asset_details);
        }

        // GET: asset_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asset_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Flight,Departure,Arrival,Terminal,Aircraft,Capacity,Crew")] asset_details asset_details)
        {
            if (ModelState.IsValid)
            {
                db.asset_Details.Add(asset_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asset_details);
        }

        // GET: asset_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asset_details asset_details = db.asset_Details.Find(id);
            if (asset_details == null)
            {
                return HttpNotFound();
            }
            return View(asset_details);
        }

        // POST: asset_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Flight,Departure,Arrival,Terminal,Aircraft,Capacity,Crew")] asset_details asset_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asset_details);
        }

        // GET: asset_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asset_details asset_details = db.asset_Details.Find(id);
            if (asset_details == null)
            {
                return HttpNotFound();
            }
            return View(asset_details);
        }

        // POST: asset_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asset_details asset_details = db.asset_Details.Find(id);
            db.asset_Details.Remove(asset_details);
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
