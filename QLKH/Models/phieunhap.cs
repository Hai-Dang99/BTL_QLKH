namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieunhap")]
    public partial class phieunhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieunhap()
        {
            chitietnhaps = new HashSet<chitietnhap>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name = "Mã phiếu nhập")]
        public string maphieunhap { get; set; }

        [Display(Name ="Ngày tạo")]
        public DateTime ngaytao { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nhà cung cấp")]
        public string mancc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietnhap> chitietnhaps { get; set; }

        public virtual nhacc nhacc { get; set; }
    }
}
