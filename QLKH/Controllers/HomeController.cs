using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKH.Models;

namespace QLKH.Controllers
{
    public class HomeController : Controller
    {
        private QLKHDBContext db = new QLKHDBContext();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(taikhoan model)
        {
            if (ModelState.IsValid)
            {
                var user = db.taikhoans.Where(u => u.username.Equals(model.username) && u.matkhau.Equals(model.matkhau)).ToList();
                if (user.Count > 0)
                {
                    Session["Username"] = user.FirstOrDefault().username;
                    var check = user.FirstOrDefault().fullcontrol;
                    if (check == true)
                    {
                        Session["role"] = "SUPER_ADMIN";
                    }
                    else
                    {
                        Session["role"] = "ADMIN";
                    }
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

        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["role"] = null;
            return Redirect("/Home/Login");
        }
    }
}