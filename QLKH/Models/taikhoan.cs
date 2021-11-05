namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taikhoan")]
    public partial class taikhoan
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string matkhau { get; set; }

        public bool? fullcontrol { get; set; }
    }
}
