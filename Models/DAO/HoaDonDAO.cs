using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class HoaDonDAO
    {
        private MobileShopDbContext _context = null;

        public HoaDonDAO()
        {
            _context = new MobileShopDbContext();
        }

        // Phương thức này để phân trang
        public IEnumerable<HoaDon> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<HoaDon> model = _context.HoaDons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.MaHoaDon.Contains(searchString));
            }
            return model.OrderBy(sp => sp.ID).ToPagedList(page, pageSize);
        }


        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiHoaDon(HoaDon hd)
        {
            _context.HoaDons.Add(hd);
            _context.SaveChanges();
            return hd.MaHoaDon;
        }

        // Phương thức trả về nhân viên theo mã
        public HoaDon LayHoaDonTheoMaHoaDon(string mhd)
        {
            return _context.HoaDons.SingleOrDefault(sp => sp.MaHoaDon == mhd);
        }

        public HoaDon LayHoaDonTheoMa(string maHD)
        {
            return _context.HoaDons.SingleOrDefault(sp => sp.MaHoaDon == maHD);
        }

        public HoaDon XemChiTietHoaDon(int id)
        {
            return _context.HoaDons.SingleOrDefault(sp => sp.ID == id);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaHoaDon(int id)
        {
            try
            {
                var _hoaDon = _context.HoaDons.Find(id);
                _hoaDon.IsDelete = true;
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
