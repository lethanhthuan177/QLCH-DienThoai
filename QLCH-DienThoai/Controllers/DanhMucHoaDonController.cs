using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class DanhMucHoaDonController : Controller
    {
        // GET: DanhMucHoaDon
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var danhMucHoaDon = new DanhMucHoaDonDAO();
            var modelDanhMuc = danhMucHoaDon.PhanTrang(searchString, page, pageSize);

            return View(modelDanhMuc);
        }

        // GET: DanhMucHoaDon/Details/5
        public ActionResult Details(string id)
        {
            var danhMucHoaDon = new DanhMucHoaDonDAO().XemChiTietDanhMucHoaDon(id);

            return View(danhMucHoaDon);
        }

        // GET: DanhMucHoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucHoaDon/Create
        [HttpPost]
        public ActionResult Create(DanhMucHoaDon dmhd)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                var danhMucHoaDonDao = new DanhMucHoaDonDAO();
                string maDanhMucHoaDon = danhMucHoaDonDao.ThemMoiDanhMucSanPham(dmhd);

                if (!string.IsNullOrEmpty(maDanhMucHoaDon))
                {
                    return RedirectToAction("Index", "DanhMucHoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View(dmhd);
        }

        // GET: DanhMucHoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            var danhMucHoaDon = new DanhMucHoaDonDAO().XemChiTietDanhMucHoaDon(id);

            return View(danhMucHoaDon);
        }

        // POST: DanhMucHoaDon/Edit/5
        [HttpPost]
        public ActionResult Edit(DanhMucHoaDon danhMucHoaDon)
        {
            if (ModelState.IsValid)
            {
                var _danhMucHoaDonDao = new DanhMucHoaDonDAO();
                var kq = _danhMucHoaDonDao.CapNhat(danhMucHoaDon);
                if (kq)
                {
                    return RedirectToAction("Index", "DanhMucHoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục hóa đơn thất bại");
                }
            }
            return View(danhMucHoaDon);
        }

        // GET: DanhMucHoaDon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMucHoaDon/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                new DanhMucHoaDonDAO().XoaDanhMucHoaDon(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
