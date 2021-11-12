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
    public class hanghoasController : Controller
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: hanghoas
        public ActionResult Index()
        {
            var hanghoas = db.hanghoas.Include(h => h.nhacc);
            return View(hanghoas.ToList());
        }

        // GET: hanghoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hanghoa hanghoa = db.hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // GET: hanghoas/Create
        public ActionResult Create()
        {
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc");
            return View();
        }

        // POST: hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahanghoa,tenhanghoa,dongia,donvitinh,mancc")] hanghoa hanghoa)
        {
            if (checkKey(hanghoa.mahanghoa) == true)
            {
                ViewBag.Flag = 1;
                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", hanghoa.mancc);
                return View(hanghoa);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.hanghoas.Add(hanghoa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", hanghoa.mancc);
                return View(hanghoa);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", hanghoa.mancc);
                return View(hanghoa);
            }
        }

        // GET: hanghoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hanghoa hanghoa = db.hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", hanghoa.mancc);
            return View(hanghoa);
        }

        // POST: hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahanghoa,tenhanghoa,dongia,donvitinh,mancc")] hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanghoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mancc = new SelectList(db.nhaccs, "mancc", "tenncc", hanghoa.mancc);
            return View(hanghoa);
        }

        // GET: hanghoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hanghoa hanghoa = db.hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // POST: hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            hanghoa hanghoa = db.hanghoas.Find(id);
            db.hanghoas.Remove(hanghoa);
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
            return db.hanghoas.Count(u => u.mahanghoa == key) > 0;
        }
    }
}
