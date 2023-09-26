namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            CTPNs = new HashSet<CTPN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPN { get; set; }

        [StringLength(50)]
        public string MAND { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NGAYNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
