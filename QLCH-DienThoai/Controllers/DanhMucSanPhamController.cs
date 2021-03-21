using Models.DAO;
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
        public ActionResult Index(string searchString,int page = 1,int pageSize = 10)
        {
            var danhMucSanPham = new DanhMucSanPhamDAO();
            var modelDanhMuc = danhMucSanPham.PhanTrang(searchString, page, pageSize);

            return View(modelDanhMuc);
        }

        // GET: DanhMucSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DanhMucSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucSanPham/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMucSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DanhMucSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMucSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMucSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
