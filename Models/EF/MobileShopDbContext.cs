using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class MobileShopDbContext : DbContext
    {
        public MobileShopDbContext()
            : base("name=MobileShopDbContext")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DanhMucHoaDon> DanhMucHoaDons { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanHieu> NhanHieux { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucHoaDon>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.DanhMucHoaDon)
                .HasForeignKey(e => e.MaDMHD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMucSanPham)
                .HasForeignKey(e => e.MaDMSP);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .HasOptional(e => e.CTHD)
                .WithRequired(e => e.HoaDon);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.MaKhachHang);

            modelBuilder.Entity<NhanHieu>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.NhanHieu)
                .HasForeignKey(e => e.MaNhanHieu);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.MaNhanVien);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaKhuyenMai)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHDs)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.MaSanPham);
        }
    }
}
