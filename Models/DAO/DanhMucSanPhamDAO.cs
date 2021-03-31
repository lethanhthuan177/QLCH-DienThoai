using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhMucSanPhamDAO
    {
        private MobileShopDbContext _context = null;

        public DanhMucSanPhamDAO()
        {
            _context = new MobileShopDbContext();
        }

        public IEnumerable<DanhMucSanPham> PhanTrang(string searchString, int page, int pageSize)
        {
            IQueryable<DanhMucSanPham> model = _context.DanhMucSanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(sp => sp.TenDanhMuc.Contains(searchString) && (sp.IsDelete == false));
            }
            return model.OrderBy(sp=>sp.ID).ToPagedList(page,pageSize);
        }

        // Phương thức thêm mới nhân viên vào database 
        public string ThemMoiDanhMucSanPham(DanhMucSanPham dmhd)
        {
            _context.DanhMucSanPhams.Add(dmhd);
            _context.SaveChanges();
            return dmhd.MaDMSP;
        }

        // Phương thức trả về nhân viên theo mã
        public DanhMucSanPham LayDanhMucSanPhamTheoMaDanhMucSP(string mdm)
        {
            return _context.DanhMucSanPhams.SingleOrDefault(dmhd => dmhd.MaDMSP == mdm);
        }

        public DanhMucSanPham LayDanhMucSanPhamTheoTen(string ten)
        {
            return _context.DanhMucSanPhams.SingleOrDefault(dmhd => dmhd.TenDanhMuc == ten);
        }

        public DanhMucSanPham XemChiTietDanhMucSanPham(string id)
        {
            return _context.DanhMucSanPhams.SingleOrDefault(dmhd => dmhd.TenDanhMuc == id);
        }

        public DanhMucSanPham ViewDetails(string maDMHD)
        {
            return _context.DanhMucSanPhams.SingleOrDefault(dmhd => dmhd.MaDMSP == maDMHD);
        }

        // Hàm xóa nhân viên
        // Nếu xóa nhân viên thì set IsDelete = 1;
        public bool XoaDanhMucSanPham(string id)
        {
            try
            {
                var _khachHang = _context.DanhMucSanPhams.Find(id);
                _khachHang.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CapNhat(DanhMucSanPham dmsp)
        {
            try
            {
                var _danhMucSanPham = _context.DanhMucSanPhams.Find(dmsp.MaDMSP);
                //_danhMucSanPham.MaDMSP = dmsp.MaDMSP;
                _danhMucSanPham.TenDanhMuc = dmsp.TenDanhMuc;
                _danhMucSanPham.GhiChu = dmsp.GhiChu;
                
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
