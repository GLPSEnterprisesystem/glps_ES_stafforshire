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
    public class airline_detailsController : Controller
    {
        private glpsContext db = new glpsContext();

        // GET: airline_details
        public ActionResult Index()
        {
            return View(db.airline_Details.ToList());
        }

        // GET: airline_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airline_details airline_details = db.airline_Details.Find(id);
            if (airline_details == null)
            {
                return HttpNotFound();
            }
            return View(airline_details);
        }

        // GET: airline_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: airline_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company_name,letter_code,Country")] airline_details airline_details)
        {
            if (ModelState.IsValid)
            {
                db.airline_Details.Add(airline_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airline_details);
        }

        // GET: airline_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airline_details airline_details = db.airline_Details.Find(id);
            if (airline_details == null)
            {
                return HttpNotFound();
            }
            return View(airline_details);
        }

        // POST: airline_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company_name,letter_code,Country")] airline_details airline_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airline_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airline_details);
        }

        // GET: airline_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airline_details airline_details = db.airline_Details.Find(id);
            if (airline_details == null)
            {
                return HttpNotFound();
            }
            return View(airline_details);
        }

        // POST: airline_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            airline_details airline_details = db.airline_Details.Find(id);
            db.airline_Details.Remove(airline_details);
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
