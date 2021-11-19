namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhapxuatton")]
    public partial class nhapxuatton
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        [Display(Name ="Hàng hóa")]
        public string mahanghoa { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Nhập")]
        public int nhap { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Xuất")]
        public int xuat { get; set; }

        [Key]
        [Column(Order = 3)]
        [Display(Name = "Tồn")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ton { get; set; }

        public virtual hanghoa hanghoa { get; set; }
    }
}
