namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietxuat")]
    public partial class chitietxuat
    {
        [Key]
        public int stt { get; set; }

        [Required]
        [StringLength(20)]
        public string maphieuxuat { get; set; }

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

        public virtual phieuxuat phieuxuat { get; set; }
    }
}
