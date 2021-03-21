namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTHDs = new HashSet<CTHD>();
            HoaDons = new HashSet<HoaDon>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(50)]
        public string MaSanPham { get; set; }

        [StringLength(200)]
        public string TenSanPham { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        public int? SoLuong { get; set; }

        public bool? IsDelete { get; set; }

        [StringLength(50)]
        public string MaDMSP { get; set; }

        public string HinhAnh { get; set; }

        public DateTime? NgayNhap { get; set; }

        public DateTime? NgayBan { get; set; }

        [StringLength(50)]
        public string MaNhanHieu { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaKhuyenMai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual NhanHieu NhanHieu { get; set; }
    }
}
