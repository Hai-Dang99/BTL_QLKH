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
    public class nhaccsController : Controller
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: nhaccs
        public ActionResult Index()
        {
            return View(db.nhaccs.ToList());
        }

        // GET: nhaccs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhacc nhacc = db.nhaccs.Find(id);
            if (nhacc == null)
            {
                return HttpNotFound();
            }
            return View(nhacc);
        }

        // GET: nhaccs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nhaccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mancc,tenncc,sdt")] nhacc nhacc)
        {
            if (checkKey(nhacc.mancc) == true)
            {
                ViewBag.Flag = 1;
                return View(nhacc);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.nhaccs.Add(nhacc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(nhacc);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(nhacc);
            }
        }

        // GET: nhaccs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhacc nhacc = db.nhaccs.Find(id);
            if (nhacc == null)
            {
                return HttpNotFound();
            }
            return View(nhacc);
        }

        // POST: nhaccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mancc,tenncc,sdt")] nhacc nhacc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhacc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhacc);
        }

        // GET: nhaccs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhacc nhacc = db.nhaccs.Find(id);
            if (nhacc == null)
            {
                return HttpNotFound();
            }
            return View(nhacc);
        }

        // POST: nhaccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            nhacc nhacc = db.nhaccs.Find(id);
            if (checkhh(nhacc.mancc) == true)
            {
                ViewBag.Flag = 1;
                return View(nhacc);
            }
            else
            {
                db.nhaccs.Remove(nhacc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }  
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
            return db.nhaccs.Count(u => u.mancc == key) > 0;
        }

        private bool checkhh(String key)
        {
            return db.hanghoas.Count(u => u.mancc == key) > 0;
        }
    }
}
