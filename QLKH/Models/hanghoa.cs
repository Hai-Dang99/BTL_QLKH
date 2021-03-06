namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hanghoa")]
    public partial class hanghoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hanghoa()
        {
            chitietnhaps = new HashSet<chitietnhap>();
            chitietxuats = new HashSet<chitietxuat>();
            nhapxuattons = new HashSet<nhapxuatton>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name ="Mã hoàng hóa")]
        public string mahanghoa { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Tên hoàng hóa")]
        public string tenhanghoa { get; set; }

        [Display(Name = "Giá")]
        public decimal dongia { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Đơn vị tính")]
        public string donvitinh { get; set; }

        [Required]
        [StringLength(20)]
        public string mancc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietnhap> chitietnhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietxuat> chitietxuats { get; set; }

        public virtual nhacc nhacc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhapxuatton> nhapxuattons { get; set; }
    }
}
