namespace QLKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhacc")]
    public partial class nhacc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhacc()
        {
            hanghoas = new HashSet<hanghoa>();
            phieunhaps = new HashSet<phieunhap>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name ="Mã nhà cung cấp")]
        public string mancc { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Tên nhà cung cấp")]
        public string tenncc { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string sdt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hanghoa> hanghoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieunhap> phieunhaps { get; set; }
    }
}
