namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadon")]
    public partial class Hoadon
    {
        [Key]
        [StringLength(20)]
        public string mahoadon { get; set; }

        public DateTime ngaytao { get; set; }

        [StringLength(20)]
        public string makhachhang { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
