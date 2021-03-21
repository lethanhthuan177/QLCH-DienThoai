using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class KhachHangDAO
    {
        private MobileShopDbContext _context = null;

        public KhachHangDAO()
        {
            _context = new MobileShopDbContext();
        }

        public IEnumerable<KhachHang> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<KhachHang> model = _context.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.TenKH.Contains(searchString));
            }
            return model.OrderBy(sp => sp.ID).ToPagedList(page, pageSize);
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiKhachHang(KhachHang kh)
        {
            _context.KhachHangs.Add(kh);
            _context.SaveChanges();
            return kh.MaKhachHang;
        }

        // Phương thức trả về nhân viên theo mã
        public KhachHang LayKhachHangTheoMaKhachHang(string mkh)
        {
            return _context.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == mkh);
        }

        public KhachHang LayKhachHangTheoTen(string ten)
        {
            return _context.KhachHangs.SingleOrDefault(kh => kh.TenKH == ten);
        }

        public KhachHang XemChiTietKhachHang(int id)
        {
            return _context.KhachHangs.SingleOrDefault(kh => kh.ID == id);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaKhachHang(int id)
        {
            try
            {
                var _khachHang = _context.KhachHangs.Find(id);
                _khachHang.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
