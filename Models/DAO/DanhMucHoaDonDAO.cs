using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhMucHoaDonDAO
    {
        private MobileShopDbContext _context = null;

        public DanhMucHoaDonDAO()
        {
            _context = new MobileShopDbContext();
        }

        // Phân trang 
        public IEnumerable<DanhMucHoaDon> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<DanhMucHoaDon> model = _context.DanhMucHoaDons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.TenDMHD.Contains(searchString));
            }
            return model.OrderBy(sp => sp.ID).ToPagedList(page, pageSize);
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiDanhMucSanPham(DanhMucHoaDon dmhd)
        {
            _context.DanhMucHoaDons.Add(dmhd);
            _context.SaveChanges();
            return dmhd.MaDMHD;
        }

        // Phương thức trả về nhân viên theo mã
        public DanhMucHoaDon LayDanhMucHoaDonTheoMaDanhMucHoaDon(string mdm)
        {
            return _context.DanhMucHoaDons.SingleOrDefault(dmhd => dmhd.MaDMHD == mdm);
        }

        public DanhMucHoaDon LayDanhMucHoaDonTheoTen(string ten)
        {
            return _context.DanhMucHoaDons.SingleOrDefault(dmhd => dmhd.TenDMHD == ten);
        }

        public DanhMucHoaDon XemChiTietDanhMucHoaDon(string maDMHD)
        {
            return _context.DanhMucHoaDons.SingleOrDefault(dmhd => dmhd.TenDMHD == maDMHD);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaDanhMucHoaDon(string id)
        {
            try
            {
                var _khachHang = _context.DanhMucHoaDons.SingleOrDefault(x=>x.MaDMHD == id);
                _khachHang.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CapNhat(DanhMucHoaDon dmhd)
        {
            try
            {
                var _danhMucHoaDon = _context.DanhMucHoaDons.Find(dmhd.ID);
                _danhMucHoaDon.MaDMHD = dmhd.MaDMHD;
                _danhMucHoaDon.TenDMHD = dmhd.TenDMHD;

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
