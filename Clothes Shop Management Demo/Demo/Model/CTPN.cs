namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPN")]
    public partial class CTPN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MASP { get; set; }

        public int SL { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
