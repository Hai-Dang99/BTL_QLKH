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
    public class taikhoansController : BaseController
    {
        private QLKHDBContext db = new QLKHDBContext();

        // GET: taikhoans
        public ActionResult Index()
        {
            return View(db.taikhoans.Where(u => u.fullcontrol == false).ToList());
        }

        // GET: taikhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taikhoan taikhoan = db.taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // GET: taikhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(taikhoanConfirm model)
        {
            if (checkUsername(model.username) == true)//kiểm tra xem mã hàng hóa đã tồn tại trong csdl hay chưa
            {
                ViewBag.flag = 2;//thông báo lỗi
                return View(model);
            }
            if (ModelState.IsValid)
            {
                if (model.matkhau.Equals(model.matkhauConfirm))
                {
                    taikhoan taikhoan = new taikhoan();
                    taikhoan.username = model.username;
                    taikhoan.matkhau = model.matkhau;
                    taikhoan.fullcontrol = false;
                    db.taikhoans.Add(taikhoan);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Flag = 1;
                    return View(model);
                }
            }

            return View(model);
        }

        // GET: taikhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taikhoan taikhoan = db.taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            taikhoanConfirm model = new taikhoanConfirm();
            model.id = taikhoan.id;
            model.username = taikhoan.username;
            model.matkhau = taikhoan.matkhau;
            model.matkhauConfirm = taikhoan.matkhau;
            return View(model);
        }

        // POST: taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(taikhoanConfirm model)
        {
            //if (checkUsername(model.username) == true)//kiểm tra xem mã hàng hóa đã tồn tại trong csdl hay chưa
            //{
            //    ViewBag.flag = 2;//thông báo lỗi
            //    return View(model);
            //}
            if (ModelState.IsValid)
            {
                if (model.matkhau.Equals(model.matkhauConfirm))
                {
                    taikhoan taikhoan = new taikhoan();
                    taikhoan.id = model.id;
                    taikhoan.username = model.username;
                    taikhoan.matkhau = model.matkhau;
                    taikhoan.fullcontrol = false;
                    db.Entry(taikhoan).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.flag = 1;//thông báo lỗi
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: taikhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            taikhoan taikhoan = db.taikhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taikhoan taikhoan = db.taikhoans.Find(id);
            db.taikhoans.Remove(taikhoan);
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

        private bool checkUsername(String username)//bool là đúng hoặc sai
        {
            return db.taikhoans.Count(u => u.username == username) > 0;
        }
    }
}
