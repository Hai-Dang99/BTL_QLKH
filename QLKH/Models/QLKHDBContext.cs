using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLKH.Models
{
    public partial class QLKHDBContext : DbContext
    {
        public QLKHDBContext()
            : base("name=QLKHDBContext")
        {
        }

        public virtual DbSet<chitietnhap> chitietnhaps { get; set; }
        public virtual DbSet<chitietxuat> chitietxuats { get; set; }
        public virtual DbSet<hanghoa> hanghoas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<nhacc> nhaccs { get; set; }
        public virtual DbSet<phieunhap> phieunhaps { get; set; }
        public virtual DbSet<phieuxuat> phieuxuats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<nhapxuatton> nhapxuattons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chitietnhap>()
                .Property(e => e.maphieunhap)
                .IsUnicode(false);

            modelBuilder.Entity<chitietnhap>()
                .Property(e => e.mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<chitietnhap>()
                .Property(e => e.makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<chitietxuat>()
                .Property(e => e.maphieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<chitietxuat>()
                .Property(e => e.mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<chitietxuat>()
                .Property(e => e.makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .Property(e => e.mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .Property(e => e.tenhanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .Property(e => e.dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<hanghoa>()
                .Property(e => e.mancc)
                .IsUnicode(false);

            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.chitietnhaps)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.chitietxuats)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hanghoa>()
                .HasMany(e => e.nhapxuattons)
                .WithRequired(e => e.hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.mahoadon)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.chitietnhaps)
                .WithRequired(e => e.Khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.chitietxuats)
                .WithRequired(e => e.Khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.phieuxuats)
                .WithRequired(e => e.Khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.mancc)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.tenncc)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<nhacc>()
                .HasMany(e => e.hanghoas)
                .WithRequired(e => e.nhacc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhacc>()
                .HasMany(e => e.phieunhaps)
                .WithRequired(e => e.nhacc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieunhap>()
                .Property(e => e.maphieunhap)
                .IsUnicode(false);

            modelBuilder.Entity<phieunhap>()
                .Property(e => e.mancc)
                .IsUnicode(false);

            modelBuilder.Entity<phieunhap>()
                .HasMany(e => e.chitietnhaps)
                .WithRequired(e => e.phieunhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieuxuat>()
                .Property(e => e.maphieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<phieuxuat>()
                .Property(e => e.makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<phieuxuat>()
                .HasMany(e => e.chitietxuats)
                .WithRequired(e => e.phieuxuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taikhoan>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<taikhoan>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<nhapxuatton>()
                .Property(e => e.mahanghoa)
                .IsUnicode(false);
        }
    }
}
