namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieuxuat")]
    public partial class phieuxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieuxuat()
        {
            chitietxuats = new HashSet<chitietxuat>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name ="Mã phiếu xuất")]
        public string maphieuxuat { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime ngaytao { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Khách hàng")]
        public string makhachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietxuat> chitietxuats { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
