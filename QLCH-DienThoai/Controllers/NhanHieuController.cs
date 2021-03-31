using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class NhanHieuController : Controller
    {
        // GET: NhanHieu
        public ActionResult Index(string searchString,int page = 1,int pageSize = 10)
        {
            var nhDao = new NhanHieuDAO();
            var dsNH = nhDao.PhanTrang(searchString, page, pageSize);
            return View();
        }

        // GET: NhanHieu/Details/5
        public ActionResult Details(string id)
        {
            var ctNH = new NhanHieuDAO().XemChiTietNhanHieu(id);
            return View();
        }

        // GET: NhanHieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanHieu/Create
        [HttpPost]
        public ActionResult Create(NhanHieu nh)
        {
            if (ModelState.IsValid)
            {
                var nhDao = new NhanHieuDAO();

                string maNH = nhDao.ThemMoiNhanHieu(nh);

                if(!string.IsNullOrEmpty(maNH))
                {
                    return RedirectToAction("Index", "NhanHieu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhãn hiệu thất bai");
                }
            }
            return View(nh);
        }

        // GET: NhanHieu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NhanHieu/Edit/5
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

        // GET: NhanHieu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanHieu/Delete/5
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
