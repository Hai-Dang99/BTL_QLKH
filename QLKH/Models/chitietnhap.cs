namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietnhap")]
    public partial class chitietnhap
    {
        [Key]
        [Display(Name ="STT")]
        public int stt { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phiếu nhập")]
        public string maphieunhap { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Hàng hóa")]
        public string mahanghoa { get; set; }

        [Display(Name = "Số lượng")]
        public int soluong { get; set; }

        [Display(Name = "Ngày xuất")]
        public DateTime? ngayxuat { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Khách hàng")]
        public string makhachhang { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual Khachhang Khachhang { get; set; }

        public virtual phieunhap phieunhap { get; set; }
    }
}
