using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var spDao = new SanPhamDAO();
            var dsSanpham = spDao.PhanTrang(searchString, page, pageSize);

            return View(dsSanpham);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(string id)
        {
            var ctSanPham = new SanPhamDAO().XemChiTietSanPham(id);
            return View(ctSanPham);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var spDao = new SanPhamDAO();

                string maSanPham = spDao.ThemMoiSanPham(sp);

                if (!string.IsNullOrEmpty(maSanPham))
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View(sp);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var sanPham = new SanPhamDAO().XemChiTietSanPham(id);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                var _sanPhamDao = new SanPhamDAO();

                var kq = _sanPhamDao.CapNhat(sp);
                if (kq)
                    return RedirectToAction("Index", "SanPham");
                else
                    ModelState.AddModelError("", "Cập nhật sản phẩm lỗi");
            }
            return View(sp);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                new SanPhamDAO().XoaSanPham(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
