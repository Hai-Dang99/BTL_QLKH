using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLKH.Models;

namespace QLKH.Controllers
{
    public class nhapxuattonsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: nhapxuattons
        public ActionResult Index()
        {
            var nhapxuattons = db.nhapxuattons.Include(n => n.hanghoa);
            return View(nhapxuattons.ToList());
        }

        // GET: nhapxuattons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhapxuatton nhapxuatton = db.nhapxuattons.Find(id);
            if (nhapxuatton == null)
            {
                return HttpNotFound();
            }
            return View(nhapxuatton);
        }

        // GET: nhapxuattons/Create
        public ActionResult Create()
        {
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa");
            return View();
        }

        // POST: nhapxuattons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahanghoa,nhap,xuat,ton")] nhapxuatton nhapxuatton)
        {
            if (ModelState.IsValid)
            {
                db.nhapxuattons.Add(nhapxuatton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", nhapxuatton.mahanghoa);
            return View(nhapxuatton);
        }

        // GET: nhapxuattons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhapxuatton nhapxuatton = db.nhapxuattons.Find(id);
            if (nhapxuatton == null)
            {
                return HttpNotFound();
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", nhapxuatton.mahanghoa);
            return View(nhapxuatton);
        }

        // POST: nhapxuattons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahanghoa,nhap,xuat,ton")] nhapxuatton nhapxuatton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapxuatton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", nhapxuatton.mahanghoa);
            return View(nhapxuatton);
        }

        // GET: nhapxuattons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhapxuatton nhapxuatton = db.nhapxuattons.Find(id);
            if (nhapxuatton == null)
            {
                return HttpNotFound();
            }
            return View(nhapxuatton);
        }

        // POST: nhapxuattons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            nhapxuatton nhapxuatton = db.nhapxuattons.Find(id);
            db.nhapxuattons.Remove(nhapxuatton);
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
