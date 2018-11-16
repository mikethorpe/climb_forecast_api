using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using climb_forecast_api.DAL;
using climb_forecast_api.Models;

namespace climb_forecast_api.Controllers
{
    public class CragsController : Controller
    {
        private WeatherContext db = new WeatherContext();

        // GET: Crags
        public ActionResult Index()
        {
            return View(db.Crags.ToList());
        }

        // GET: Crags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crag crag = db.Crags.Find(id);
            if (crag == null)
            {
                return HttpNotFound();
            }
            return View(crag);
        }

        // GET: Crags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CragName,WeatherStationName")] Crag crag)
        {
            if (ModelState.IsValid)
            {
                db.Crags.Add(crag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crag);
        }

        // GET: Crags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crag crag = db.Crags.Find(id);
            if (crag == null)
            {
                return HttpNotFound();
            }
            return View(crag);
        }

        // POST: Crags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CragName,WeatherStationName")] Crag crag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crag);
        }

        // GET: Crags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crag crag = db.Crags.Find(id);
            if (crag == null)
            {
                return HttpNotFound();
            }
            return View(crag);
        }

        // POST: Crags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crag crag = db.Crags.Find(id);
            db.Crags.Remove(crag);
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
