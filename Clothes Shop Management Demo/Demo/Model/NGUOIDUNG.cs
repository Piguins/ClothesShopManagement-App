namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            HOADONs = new HashSet<HOADON>();
            PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }

        [Key]
        [StringLength(50)]
        public string MAND { get; set; }

        [Required]
        [StringLength(50)]
        public string TENND { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGSINH { get; set; }

        [StringLength(5)]
        public string GIOITINH { get; set; }

        [Required]
        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(50)]
        public string USERNAME { get; set; }

        public string PASS { get; set; }

        public bool QTV { get; set; }

        public bool TTND { get; set; }

        public string AVA { get; set; }

        [StringLength(100)]
        public string MAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
