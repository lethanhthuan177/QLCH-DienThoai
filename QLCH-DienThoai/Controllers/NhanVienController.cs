using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var nvDao = new NhanHieuDAO();
            var dsNV = nvDao.PhanTrang(searchString, page, pageSize);
            return View(dsNV);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(string id)
        {
            var ctSP = new SanPhamDAO().XemChiTietSanPham(id);
            return View(ctSP);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var spDao = new SanPhamDAO();

                string maSP = spDao.ThemMoiSanPham(sp);

                if (!string.IsNullOrEmpty(maSP))
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

        // GET: NhanVien/Edit/5
        public ActionResult Edit(string msp)
        {
            var sp = new SanPhamDAO().XemChiTietSanPham(msp);
            return View(sp);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var _spDao = new SanPhamDAO();

                    var kq = _spDao.CapNhat(sp);
                    if (kq)
                    {
                        return RedirectToAction("Index", "SanPham");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại");
                    }
                }

                return View(sp);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanVien/Delete/5
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
