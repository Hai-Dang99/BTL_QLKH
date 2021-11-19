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
    public class phieunhapsController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: phieunhaps
        public ActionResult Index()
        {
            var phieunhaps = db.phieunhaps.Include(p => p.nhacc);
            return View(phieunhaps.ToList());
        }

        // GET: phieunhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // GET: phieunhaps/Create
        public ActionResult Create()
        {
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc");
            return View();
        }

        // POST: phieunhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maphieunhap,ngaytao,mancc")] phieunhap phieunhap)
        {
            if (checkKey(phieunhap.maphieunhap) == true)
            {
                ViewBag.Flag = 1;
                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", phieunhap.mancc);
                return View(phieunhap);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.phieunhaps.Add(phieunhap);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", phieunhap.mancc);
                return View(phieunhap);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", phieunhap.mancc);
                return View(phieunhap);
            }
        }

        // GET: phieunhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", phieunhap.mancc);
            return View(phieunhap);
        }

        // POST: phieunhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maphieunhap,ngaytao,mancc")] phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", phieunhap.mancc);
            return View(phieunhap);
        }

        // GET: phieunhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // POST: phieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            phieunhap phieunhap = db.phieunhaps.Find(id);
            db.phieunhaps.Remove(phieunhap);
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
            return db.phieunhaps.Count(u => u.maphieunhap == key) > 0;
        }
    }
}
