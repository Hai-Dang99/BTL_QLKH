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
        public int stt { get; set; }

        [Required]
        [StringLength(20)]
        public string maphieunhap { get; set; }

        [Required]
        [StringLength(20)]
        public string mahanghoa { get; set; }

        public int soluong { get; set; }

        public DateTime? ngayxuat { get; set; }

        [Required]
        [StringLength(20)]
        public string makhachhang { get; set; }

        public virtual hanghoa hanghoa { get; set; }

        public virtual Khachhang Khachhang { get; set; }

        public virtual phieunhap phieunhap { get; set; }
    }
}
