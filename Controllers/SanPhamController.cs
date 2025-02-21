using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom_10_QuanLyShopGiayTheThaoSneaker.Models;

namespace Nhom_10_QuanLyShopGiayTheThaoSneaker.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        DbQLSGDataContext db = new DbQLSGDataContext();
        public ActionResult SanPhamAll()
        {
            var ListSP = db.SanPhams.ToList();
            return View(ListSP);
        }
        public ActionResult XemChiTiet(int msp)
        {
            SanPham sp = db.SanPhams.Single(s => s.MaSP == msp);
            if (sp == null)
            {
                return HttpNotFound();
            }

            return View(sp);

        }
        public ActionResult LoaiPartial()
        {

            var ListLoai = db.Loais.ToList();
            return PartialView(ListLoai);
        }
        public ActionResult GiayTheoLoai(int maLoai)
        {
            var listGTL = db.SanPhams.Where(s => s.MaLoai == maLoai).ToList();
            Loai loai = db.Loais.Single(x => x.MaLoai == maLoai);
            ViewBag.TenLoai = loai.TenLoai;
            return View(listGTL);
        }
        public ActionResult TimSanPham(string txt_Search)
        {
            var ListSP = db.SanPhams.Where(s => s.TenSP.Contains(txt_Search)).ToList();
            return View(ListSP);
        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.InsertOnSubmit(sanPham);
                db.SubmitChanges();
                ViewBag.SuccessMessage = "Thêm sản phẩm thành công!";
                return RedirectToAction("SanPhamAll", "SanPham");
            }
            return View("ThemSanPham", "SanPham");
        }
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {

            SanPham sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSP == id);
            if (sanPham != null)
            {
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
                ViewBag.SuccessMessage = "Xóa sản phẩm thành công!";
            }
            return RedirectToAction("SanPhamAll", "SanPham");
        }
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSP == id);
            if (sanPham != null)
            {
                return View(sanPham);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult CapNhatSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                SanPham sp = db.SanPhams.SingleOrDefault(s => s.MaSP == sanPham.MaSP);
                if (sp != null)
                {
                    sp.TenSP = sanPham.TenSP;
                    sp.GiaBan = sanPham.GiaBan;
                    sp.MoTa = sanPham.MoTa;
                    sp.NgayCapNhat = sanPham.NgayCapNhat;
                    sp.Anh = sanPham.Anh;
                    sp.SLTon = sanPham.SLTon;
                    sp.MaLoai = sanPham.MaLoai;

                    db.SubmitChanges();
                    return RedirectToAction("SanPhamAll", "SanPham");
                }
            }
            return View(sanPham);
        }
	}
}