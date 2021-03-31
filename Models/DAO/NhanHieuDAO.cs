using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class NhanHieuDAO
    {
        private MobileShopDbContext _context = null;

        public NhanHieuDAO()
        {
            _context = new MobileShopDbContext();
        }

        public IEnumerable<NhanHieu> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<NhanHieu> model = _context.NhanHieux;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.TenNhanHien.Contains(searchString));
            }
            return model.OrderBy(sp => sp.ID).ToPagedList(page, pageSize);
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiNhanHieu(NhanHieu nh)
        {
            _context.NhanHieux.Add(nh);
            _context.SaveChanges();
            return nh.MaNhanHien;
        }

        // Phương thức trả về nhân viên theo mã
        public NhanHieu LaySanPhamTheoMaSanPham(string mnv)
        {
            return _context.NhanHieux.SingleOrDefault(nh => nh.MaNhanHien == mnv);
        }

        public NhanHieu LaySanPhamTheoMa(string maHD)
        {
            return _context.NhanHieux.SingleOrDefault(nh => nh.MaNhanHien == maHD);
        }

        public NhanHieu XemChiTietNhanHieu(string id)
        {
            return _context.NhanHieux.SingleOrDefault(nh => nh.MaNhanHien == id);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaSanPham(int id)
        {
            try
            {
                var _sanPham = _context.NhanHieux.Find(id);
                _sanPham.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CapNhat(NhanHieu nh)
        {
            try
            {
                var _nh = _context.NhanHieux.SingleOrDefault(x => x.MaNhanHien == nh.MaNhanHien);
                _nh.TenNhanHien = nh.TenNhanHien;
                _nh.MaNhanHien = nh.MaNhanHien;
                _nh.GhiChu = nh.GhiChu;

                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
