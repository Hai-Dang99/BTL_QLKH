namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khachhang")]
    public partial class Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khachhang()
        {
            chitietnhaps = new HashSet<chitietnhap>();
            chitietxuats = new HashSet<chitietxuat>();
            Hoadons = new HashSet<Hoadon>();
            phieuxuats = new HashSet<phieuxuat>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name ="Mã khách hàng")]
        public string makhachhang { get; set; }

        [Required]//bắt buộc phải có
        [StringLength(50)]//độ dài tối da của dữ liệu
        [Display(Name = "Tên khách hàng")]
        public string tenkhachhang { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string sodienthoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietnhap> chitietnhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietxuat> chitietxuats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadon> Hoadons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieuxuat> phieuxuats { get; set; }
    }
}
