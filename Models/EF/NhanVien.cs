namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string TenNhanVien { get; set; }

        public int? GioiTinh { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? SDT { get; set; }

        [StringLength(10)]
        public string MaNhanVien { get; set; }

        public DateTime? NgayVaoLam { get; set; }

        public string HinhAnh { get; set; }

        public string GhiChu { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        public DateTime? NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
