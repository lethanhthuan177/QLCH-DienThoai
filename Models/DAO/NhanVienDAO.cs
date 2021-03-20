using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    class NhanVienDAO
    {
        private readonly MobileShopDbContext _context = null;

        public NhanVienDAO()
        {
            _context = new MobileShopDbContext();
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiNhanVien(NhanVien nv)
        {
            _context.NhanViens.Add(nv);
            _context.SaveChanges();
            return nv.MaNhanVien;
        }

        // Phương thức trả về nhân viên theo mã
        public NhanVien LayNhanVienTheoMaNhanVien(string mnv)
        {
            return _context.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == mnv);
        }

        public NhanVien LayNhanVienTheoTen(string ten)
        {
            return _context.NhanViens.SingleOrDefault(nv => nv.TenNhanVien == ten);
        }

        public NhanVien XemChiTietNhanVien(int id)
        {
            return _context.NhanViens.SingleOrDefault(nv => nv.ID == id);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaNhanVien(int id)
        {
            try
            {
                var _nhanVien = _context.NhanViens.Find(id);
                _nhanVien.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
