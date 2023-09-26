namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTHDs = new HashSet<CTHD>();
            CTPNs = new HashSet<CTPN>();
        }

        [Key]
        [StringLength(50)]
        public string MASP { get; set; }

        [Required]
        [StringLength(50)]
        public string TENSP { get; set; }

        public int GIA { get; set; }

        public string MOTA { get; set; }

        public string HINHSP { get; set; }

        public int SL { get; set; }

        [StringLength(50)]
        public string LOAISP { get; set; }

        [StringLength(50)]
        public string SIZE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }
    }
}
