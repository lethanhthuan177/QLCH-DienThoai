using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QLCH_DienThoai.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index(string searchString,int page = 1,int pageSize = 10)
        {
            var khDao = new KhachHangDAO();
            var dsKH = khDao.PhanTrang(searchString,page,pageSize);

            return View(dsKH);
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(string id)
        {
            var ctKH = new KhachHangDAO().XemChiTietKhachHang(id);
            return View(ctKH);
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        public ActionResult Create(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                var khDao = new KhachHangDAO();

                string maKH = khDao.ThemMoiKhachHang(kh);

                if (!string.IsNullOrEmpty(maKH))
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
            }
            return View(kh);
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit(string mkh)
        {
            var kh = new KhachHangDAO().XemChiTietKhachHang(mkh);
            return View(kh);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                var khDao = new KhachHangDAO();

                Task<bool> kq = khDao.CapNhat(kh);

                if(await kq)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View(kh);
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                new KhachHangDAO().XoaKhachHang(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
