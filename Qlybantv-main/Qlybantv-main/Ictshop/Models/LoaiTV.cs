namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTV")]
    public partial class LoaiTV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTV()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        [Key]
        public int MaLoai { get; set; }

        [StringLength(10)]
        [Display(Name = "Tên hệ điều hành")]

        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
