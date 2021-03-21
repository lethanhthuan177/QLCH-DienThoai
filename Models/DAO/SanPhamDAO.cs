using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SanPhamDAO
    {
        private MobileShopDbContext _context = null;

        public SanPhamDAO()
        {
            _context = new MobileShopDbContext();
        }

        public IEnumerable<SanPham> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<SanPham> model = _context.SanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.TenSanPham.Contains(searchString));
            }
            return model.OrderBy(sp => sp.ID).ToPagedList(page, pageSize);
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiSanPham(SanPham sp)
        {
            _context.SanPhams.Add(sp);
            _context.SaveChanges();
            return sp.MaSanPham;
        }

        // Phương thức trả về nhân viên theo mã
        public SanPham LaySanPhamTheoMaSanPham(string msp)
        {
            return _context.SanPhams.SingleOrDefault(sp => sp.MaSanPham == msp);
        }

        public SanPham LaySanPhamTheoMa(string maSP)
        {
            return _context.SanPhams.SingleOrDefault(sp => sp.MaSanPham == maSP);
        }

        public SanPham XemChiTietSanPham(int id)
        {
            return _context.SanPhams.SingleOrDefault(sp => sp.ID == id);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaSanPham(int id)
        {
            try
            {
                var _sanPham = _context.SanPhams.Find(id);
                _sanPham.IsDelete = true;
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
