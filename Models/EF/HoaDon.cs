namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        public string GhiChu { get; set; }

        public DateTime? NgayLap { get; set; }

        public bool? IsDelete { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaKhachHang { get; set; }

        public int MaDMHD { get; set; }

        public int? VAT { get; set; }

        public virtual CTHD CTHD { get; set; }

        public virtual DanhMucHoaDon DanhMucHoaDon { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
