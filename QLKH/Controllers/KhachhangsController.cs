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
    public class KhachhangsController : BaseController
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
            if (id == null)//nếu id = null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//báo lỗi
            }
            Khachhang khachhang = db.Khachhangs.Find(id);//tìm khách hàng trong csdl
            if (khachhang == null)//nếu không tìm thấy khách hàng trong csdl
            {
                return HttpNotFound();
            }
            return View(khachhang);//trả về view details
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
                if (ModelState.IsValid)//nếu nhập thông tin không đúng luật (VD: để trống 1 ô nào đấy)
                {
                    db.Khachhangs.Add(khachhang);//thêm vào csdl
                    db.SaveChanges();//lưu
                    return RedirectToAction("Index");//trả về view index
                }
                return View(khachhang);//trả về view Create 
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(khachhang);//trả về view Create
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
                db.Entry(khachhang).State = EntityState.Modified; //sửa
                db.SaveChanges();//lưu
                return RedirectToAction("Index");//trả về view index
            }
            return View(khachhang);//trả về view Edit + thông tin khách hàng 
        }

        // GET: Khachhangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)//nếu mã khách hàng là null thì trả về thông báo lỗi
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);//tìm trong csdl xem có khách hàng nào trùng id vs id đc nhận k?
            if (khachhang == null)//nếu không tìm thấy khách hàng
            {
                return HttpNotFound();
            }
            return View(khachhang);//nếu tìm thấy khách hàng
        }

        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khachhang khachhang = db.Khachhangs.Find(id);//tìm khách hàng trong csdl có mã khách hàng trùng id vs id nhận đc
            if (checkctn(khachhang.makhachhang) == true)
            {
                ViewBag.Flag = 1;
                return View(khachhang);
            }
            else
            {
                db.Khachhangs.Remove(khachhang);//xóa 
                db.SaveChanges();//lưu
                return RedirectToAction("Index");//trả về view Index
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
            return db.Khachhangs.Count(u => u.makhachhang == key) > 0;//tìm trong cơ sở dữ liệu có khách hàng nào có id trùng vs id đc nhập k
        }

        private bool checkctn(String key)
        {
            return db.chitietnhaps.Count(u => u.makhachhang == key) > 0;
        }
    }
}
