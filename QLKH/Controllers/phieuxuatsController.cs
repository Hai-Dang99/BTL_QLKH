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
    public class phieuxuatsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: phieuxuats
        public ActionResult Index()
        {
            var phieuxuats = db.phieuxuats.Include(p => p.Khachhang);
            return View(phieuxuats.ToList());
        }

        // GET: phieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuxuat phieuxuat = db.phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // GET: phieuxuats/Create
        public ActionResult Create()
        {
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang");
            return View();
        }

        // POST: phieuxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maphieuxuat,ngaytao,makhachhang")] phieuxuat phieuxuat)
        {
            if (checkKey(phieuxuat.maphieuxuat) == true)
            {
                ViewBag.Flag = 1;
                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", phieuxuat.makhachhang);
                return View(phieuxuat);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.phieuxuats.Add(phieuxuat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", phieuxuat.makhachhang);
                return View(phieuxuat);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", phieuxuat.makhachhang);
                return View(phieuxuat);
            }
        }

        // GET: phieuxuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuxuat phieuxuat = db.phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", phieuxuat.makhachhang);
            return View(phieuxuat);
        }

        // POST: phieuxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maphieuxuat,ngaytao,makhachhang")] phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", phieuxuat.makhachhang);
            return View(phieuxuat);
        }

        // GET: phieuxuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuxuat phieuxuat = db.phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // POST: phieuxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            phieuxuat phieuxuat = db.phieuxuats.Find(id);
            db.phieuxuats.Remove(phieuxuat);
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

        private bool checkKey(string key)
        {
            return db.phieuxuats.Count(u => u.maphieuxuat == key) > 0;
        }
    }
}
