using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom_10_QuanLyShopGiayTheThaoSneaker.Models;

namespace Nhom_10_QuanLyShopGiayTheThaoSneaker.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        DbQLSGDataContext db = new DbQLSGDataContext();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoten = f["HoTenKH"];
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];
            var rematkhau = f["Rematkhau"];
            var dienthoai = f["DienThoai"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var diachi = f["DiaChi"];
            var email = f["Email"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Mật khẩu không được bỏ trống";
            }
            if (String.IsNullOrEmpty(rematkhau))
            {
                ViewData["Loi4"] = "Mật khẩu không được bỏ trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi5"] = "Số điện thoại không được bỏ trống";
            }
            if (!String.IsNullOrEmpty(hoten) && !String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau) && !String.IsNullOrEmpty(rematkhau) && !String.IsNullOrEmpty(dienthoai))
            {
                kh.HoTen = hoten;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.DiaChi = diachi;
                kh.Email = email;
                KhachHang cus = db.KhachHangs.SingleOrDefault(c => c.TaiKhoan == tendn);
                if (cus == null)
                {
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    return RedirectToAction("DangNhap", "User");
                }
                else
                    ViewBag.TB = "Trùng tên đăng nhập!";
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap", "User");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];
            //var loaiTaiKhoan = f["LoaiTaiKhoan"]; // Thêm dòng này để lấy giá trị loại tài khoản từ form

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Tên đăng nhập không được bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Mật khẩu không được bỏ trống";
            }

            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                {
                    KhachHang kh = db.KhachHangs.SingleOrDefault(c => c.TaiKhoan == tendn && c.MatKhau == matkhau);
                    if (kh != null)
                    {
                        ViewBag.TB = "Đăng nhập thành công!";
                        Session["taikhoan"] = kh;
                    }
                    else
                        ViewBag.TB = "Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!";
                }
                //KhachHang kh = db.KhachHangs.SingleOrDefault(c => c.TaiKhoan == tendn && c.MatKhau == matkhau);
                //if (kh != null)
                //{
                //    Session["taikhoan"] = kh;

                //    if (kh.LoaiTK != null && kh.LoaiTK.ToLower() == "admin") // Kiểm tra loại tài khoản
                //    {
                //        ViewBag.TB = "Bạn đã đăng nhập với tài khoản admin!";
                //    }
                //    else
                //    {
                //        ViewBag.TB = "Bạn đã đăng nhập với tài khoản người dùng!";
                //    }
                //}
                //else
                //{
                //    ViewBag.TB = "Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!";
                //}
            }

            return View();
        }

    }
}