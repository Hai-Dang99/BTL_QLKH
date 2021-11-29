using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKH.Models
{
    public class taikhoanConfirm
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(30)]
        [Display(Name ="Tên đăng nhập")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(30)]
        [Display(Name = "Mật khẩu")]
        public string matkhau { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30)]
        [Display(Name = "Xác nhận mật khẩu")]
        public string matkhauConfirm { get; set; }
    }
}