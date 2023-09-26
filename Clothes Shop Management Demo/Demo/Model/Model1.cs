using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Demo.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLBHEntities")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<CTPN> CTPNs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTHD>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CTPN>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.USERNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.AVA)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.MAND)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CTPNs)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTPNs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
