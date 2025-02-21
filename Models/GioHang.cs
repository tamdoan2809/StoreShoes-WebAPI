using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom_10_QuanLyShopGiayTheThaoSneaker.Models
{
    public class GioHang
    {
        DbQLSGDataContext db = new DbQLSGDataContext();
        public int iMaSP { set; get; }
        public string sTenSP { set; get; }
        public string Anh { set; get; }
        public int iSoLuong { set; get; }
        public double dDonGia { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int maSP)
        {
            iMaSP = maSP;
            SanPham sp = db.SanPhams.Single(s => s.MaSP == iMaSP);
            sTenSP = sp.TenSP;
            Anh = sp.Anh;
            dDonGia = double.Parse(sp.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}