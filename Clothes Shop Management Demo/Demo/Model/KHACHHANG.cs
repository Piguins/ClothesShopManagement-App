namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(50)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(50)]
        public string HOTEN { get; set; }

        [StringLength(5)]
        public string GIOITINH { get; set; }

        [StringLength(50)]
        public string DCHI { get; set; }

        [Required]
        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
