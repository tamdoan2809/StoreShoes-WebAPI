using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom_10_QuanLyShopGiayTheThaoSneaker.Models;

namespace Nhom_10_QuanLyShopGiayTheThaoSneaker.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        DbQLSGDataContext db = new DbQLSGDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tsl += listGioHang.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                ttt += listGioHang.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("SanPhamAll", "SanPham");
            }
            List<GioHang> listGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(listGioHang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return View();
        }
        public ActionResult ThemGioHang(int msp, string strURL)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang SanPham = listGioHang.Find(sp => sp.iMaSP == msp);
            if (SanPham == null)
            {
                SanPham = new GioHang(msp);
                listGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang sp = listGioHang.Single(s => s.iMaSP == MaSP);
            if (sp != null)
            {
                listGioHang.RemoveAll(s => s.iMaSP == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (listGioHang.Count == 0)
            {
                return RedirectToAction("SanPhamAll", "SanPham");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult CapNhatGioHang(int MaSP, int SoLuong)
        {
            List<GioHang> listGioHang = LayGioHang();
            GioHang sp = listGioHang.Single(s => s.iMaSP == MaSP);
            if (sp != null)
            {
                sp.iSoLuong = SoLuong;
            }
            return RedirectToAction("GioHang", "GioHang");
        }

    }
}