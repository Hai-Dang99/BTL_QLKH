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
    public class chitietxuatsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: chitietxuats
        public ActionResult Index()
        {
            var chitietxuats = db.chitietxuats.Include(c => c.hanghoa).Include(c => c.Khachhang).Include(c => c.phieuxuat);
            return View(chitietxuats.ToList());
        }

        // GET: chitietxuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietxuat chitietxuat = db.chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietxuat);
        }

        // GET: chitietxuats/Create
        public ActionResult Create()
        {
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa");
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang");
            ViewBag.maphieuxuat = new SelectList(db.phieuxuats, "maphieuxuat", "makhachhang");
            return View();
        }

        // POST: chitietxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,maphieuxuat,mahanghoa,soluong,ngayxuat,makhachhang")] chitietxuat chitietxuat)
        {
            if (ModelState.IsValid)
            {
                db.chitietxuats.Add(chitietxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietxuat.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietxuat.makhachhang);
            ViewBag.maphieuxuat = new SelectList(db.phieuxuats, "maphieuxuat", "makhachhang", chitietxuat.maphieuxuat);
            return View(chitietxuat);
        }

        // GET: chitietxuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietxuat chitietxuat = db.chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietxuat.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietxuat.makhachhang);
            ViewBag.maphieuxuat = new SelectList(db.phieuxuats, "maphieuxuat", "makhachhang", chitietxuat.maphieuxuat);
            return View(chitietxuat);
        }

        // POST: chitietxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stt,maphieuxuat,mahanghoa,soluong,ngayxuat,makhachhang")] chitietxuat chitietxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietxuat.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietxuat.makhachhang);
            ViewBag.maphieuxuat = new SelectList(db.phieuxuats, "maphieuxuat", "makhachhang", chitietxuat.maphieuxuat);
            return View(chitietxuat);
        }

        // GET: chitietxuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietxuat chitietxuat = db.chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietxuat);
        }

        // POST: chitietxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietxuat chitietxuat = db.chitietxuats.Find(id);
            db.chitietxuats.Remove(chitietxuat);
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
