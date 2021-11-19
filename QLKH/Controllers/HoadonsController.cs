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
    public class HoadonsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: Hoadons
        public ActionResult Index()
        {
            var hoadons = db.Hoadons.Include(h => h.Khachhang);
            return View(hoadons.ToList());
        }

        // GET: Hoadons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // GET: Hoadons/Create
        public ActionResult Create()
        {
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang");
            return View();
        }

        // POST: Hoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahoadon,ngaytao,makhachhang")] Hoadon hoadon)
        {
            if (checkKey(hoadon.mahoadon) == true)
            {
                ViewBag.Flag = 1;
                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", hoadon.makhachhang);
                return View(hoadon);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Hoadons.Add(hoadon);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", hoadon.makhachhang);
                return View(hoadon);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", hoadon.makhachhang);
                return View(hoadon);
            }
        }

        // GET: Hoadons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", hoadon.makhachhang);
            return View(hoadon);
        }

        // POST: Hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahoadon,ngaytao,makhachhang")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", hoadon.makhachhang);
            return View(hoadon);
        }

        // GET: Hoadons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: Hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hoadon hoadon = db.Hoadons.Find(id);
            db.Hoadons.Remove(hoadon);
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
            return db.Hoadons.Count(u => u.mahoadon == key) > 0;
        }
    }
}
