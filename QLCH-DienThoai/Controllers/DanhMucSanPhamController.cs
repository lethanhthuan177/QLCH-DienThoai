using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var danhMucSanPham = new DanhMucSanPhamDAO();
            var modelDanhMuc = danhMucSanPham.PhanTrang(searchString, page, pageSize);

            return View(modelDanhMuc);
        }

        // GET: DanhMucSanPham/Details/5
        public ActionResult Details(string id)
        {
            var danhMucSanPham = new DanhMucSanPhamDAO().XemChiTietDanhMucSanPham(id);

            return View(danhMucSanPham);
        }

        // GET: DanhMucSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucSanPham/Create
        [HttpPost]
        public ActionResult Create(DanhMucSanPham dmsp)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var danhMucSanPhamDao = new DanhMucSanPhamDAO();

                string maDanhMucSanPham = danhMucSanPhamDao.ThemMoiDanhMucSanPham(dmsp);

                if (!string.IsNullOrEmpty(maDanhMucSanPham))
                {
                    return RedirectToAction("Index", "DanhMucSanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View(dmsp);

        }

        // GET: DanhMucSanPham/Edit/5
        // mdm : mã danh mục;
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var danhMucSanPham = new DanhMucSanPhamDAO().ViewDetails(id);

            return View(danhMucSanPham);
        }

        // POST: DanhMucSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(DanhMucSanPham danhMucSanPham)
        {
            var _danhMucKhoaHocDao = new DanhMucSanPhamDAO();

            var kq = _danhMucKhoaHocDao.CapNhat(danhMucSanPham);
            if (kq)
            {
                return RedirectToAction("Index", "DanhMucSanPham");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật danh mục sản phẩm lỗi");
            }
            return View(danhMucSanPham);
        }

        // GET: DanhMucSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMucSanPham/Delete/5
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                new DanhMucSanPhamDAO().XoaDanhMucSanPham(id);

                return RedirectToAction("Index", "DanhMucSanPham");
            }
            catch
            {
                return View();
            }
        }
    }
}
