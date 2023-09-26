namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOHD { get; set; }

        [StringLength(50)]
        public string MAND { get; set; }

        [StringLength(50)]
        public string MAKH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NGHD { get; set; }

        public int TRIGIA { get; set; }

        public int? KHUYENMAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
