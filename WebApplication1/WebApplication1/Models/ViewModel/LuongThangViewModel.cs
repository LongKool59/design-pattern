using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class LuongThangViewModel
    {
        public int MaLuong_Thang { get; set; }
        public System.DateTime ThangNam { get; set; }
        public int TongGioLamViec { get; set; }
        public int TongGioTangCa { get; set; }
        public int TongThuong { get; set; }
        public int TongPhat { get; set; }
        public int MaLuongCoBan { get; set; }
        public double? HeSoLuong { get; set; }
        public int? PhuCap { get; set; }

        public static implicit operator LuongThangViewModel(LuongThang luongThang)
        {
            return new LuongThangViewModel
            {
                MaLuong_Thang = luongThang.MaLuong_Thang,
                ThangNam = luongThang.ThangNam,
                TongGioLamViec = luongThang.TongGioLamViec,
                TongGioTangCa = luongThang.TongGioTangCa,
                TongThuong = luongThang.TongThuong,
                TongPhat = luongThang.TongPhat,
                MaLuongCoBan = luongThang.MaLuongCoBan,
                HeSoLuong = luongThang.HeSoLuong,
                PhuCap = luongThang.PhuCap,
                LuongCoBan = luongThang.LuongCoBan,
            };
        }
        public static implicit operator LuongThang(LuongThangViewModel luongThangViewModel)
        {
            return new LuongThang
            {
                MaLuong_Thang = luongThangViewModel.MaLuong_Thang,
                ThangNam = luongThangViewModel.ThangNam,
                TongGioLamViec = luongThangViewModel.TongGioLamViec,
                TongGioTangCa = luongThangViewModel.TongGioTangCa,
                TongThuong = luongThangViewModel.TongThuong,
                TongPhat = luongThangViewModel.TongPhat,
                MaLuongCoBan = luongThangViewModel.MaLuongCoBan,
                HeSoLuong = luongThangViewModel.HeSoLuong,
                PhuCap = luongThangViewModel.PhuCap,
                LuongCoBan = luongThangViewModel.LuongCoBan,
            };
        }

        public virtual LuongCoBan LuongCoBan { get; set; }
    }
}