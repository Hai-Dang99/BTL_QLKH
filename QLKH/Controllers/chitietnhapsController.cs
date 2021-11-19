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
    public class chitietnhapsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: chitietnhaps
        public ActionResult Index()
        {
            var chitietnhaps = db.chitietnhaps.Include(c => c.hanghoa).Include(c => c.Khachhang).Include(c => c.phieunhap);
            return View(chitietnhaps.ToList());
        }

        // GET: chitietnhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietnhap chitietnhap = db.chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietnhap);
        }

        // GET: chitietnhaps/Create
        public ActionResult Create()
        {
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa");
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang");
            ViewBag.maphieunhap = new SelectList(db.phieunhaps, "maphieunhap", "mancc");
            return View();
        }

        // POST: chitietnhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,maphieunhap,mahanghoa,soluong,ngayxuat,makhachhang")] chitietnhap chitietnhap)
        {
            if (ModelState.IsValid)
            {
                db.chitietnhaps.Add(chitietnhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietnhap.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietnhap.makhachhang);
            ViewBag.maphieunhap = new SelectList(db.phieunhaps, "maphieunhap", "mancc", chitietnhap.maphieunhap);
            return View(chitietnhap);
        }

        // GET: chitietnhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietnhap chitietnhap = db.chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietnhap.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietnhap.makhachhang);
            ViewBag.maphieunhap = new SelectList(db.phieunhaps, "maphieunhap", "mancc", chitietnhap.maphieunhap);
            return View(chitietnhap);
        }

        // POST: chitietnhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stt,maphieunhap,mahanghoa,soluong,ngayxuat,makhachhang")] chitietnhap chitietnhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietnhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mahanghoa = new SelectList(db.hanghoas, "mahanghoa", "tenhanghoa", chitietnhap.mahanghoa);
            ViewBag.makhachhang = new SelectList(db.Khachhangs, "makhachhang", "tenkhachhang", chitietnhap.makhachhang);
            ViewBag.maphieunhap = new SelectList(db.phieunhaps, "maphieunhap", "mancc", chitietnhap.maphieunhap);
            return View(chitietnhap);
        }

        // GET: chitietnhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietnhap chitietnhap = db.chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietnhap);
        }

        // POST: chitietnhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietnhap chitietnhap = db.chitietnhaps.Find(id);
            db.chitietnhaps.Remove(chitietnhap);
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
