namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MASP { get; set; }

        public int SL { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
