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
    public class KhachhangsController : Controller
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: Khachhangs
        public ActionResult Index()
        {
            return View(db.Khachhangs.ToList());
        }

        // GET: Khachhangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: Khachhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makhachhang,tenkhachhang,sodienthoai")] Khachhang khachhang)
        {
            if(checkKey(khachhang.makhachhang) == true)
            {
                ViewBag.Flag = 1;
                return View(khachhang);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Khachhangs.Add(khachhang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(khachhang);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(khachhang);
            }
        }

        // GET: Khachhangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makhachhang,tenkhachhang,sodienthoai")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        // GET: Khachhangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khachhang khachhang = db.Khachhangs.Find(id);
            db.Khachhangs.Remove(khachhang);
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
            return db.Khachhangs.Count(u => u.makhachhang == key) > 0;
        }
    }
}
