using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicDb;

namespace ClinicWeb.Controllers
{
    public class TreatmantsController : Controller
    {
        private DoctorAppointmenEntities1 db = new DoctorAppointmenEntities1();

        // GET: Treatmants
        public ActionResult Index()
        {
            var treatmants = db.Treatmants.Include(t => t.Patient);
            return View(treatmants.ToList());
        }

        // GET: Treatmants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatmant treatmant = db.Treatmants.Find(id);
            if (treatmant == null)
            {
                return HttpNotFound();
            }
            return View(treatmant);
        }

        // GET: Treatmants/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name");
            return View();
        }

        // POST: Treatmants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,Treatment,Note")] Treatmant treatmant)
        {
            if (ModelState.IsValid)
            {
                db.Treatmants.Add(treatmant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", treatmant.PatientId);
            return View(treatmant);
        }

        // GET: Treatmants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatmant treatmant = db.Treatmants.Find(id);
            if (treatmant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", treatmant.PatientId);
            return View(treatmant);
        }

        // POST: Treatmants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,Treatment,Note")] Treatmant treatmant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Name", treatmant.PatientId);
            return View(treatmant);
        }

        // GET: Treatmants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatmant treatmant = db.Treatmants.Find(id);
            if (treatmant == null)
            {
                return HttpNotFound();
            }
            return View(treatmant);
        }

        // POST: Treatmants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatmant treatmant = db.Treatmants.Find(id);
            db.Treatmants.Remove(treatmant);
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
