using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class ChamCongViewModel
    {
        public int MaNhanVien { get; set; }
        public System.DateTime Ngay { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm\:ss}")]
        public TimeSpan? ThoiGianVao { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm\:ss}")]
        public TimeSpan? ThoiGianRa { get; set; }
        public int? ThoiGianLamViec { get; set; }
        public int? ThoiGianTangCa { get; set; }
        public string TrangThai { get; set; }

        public static implicit operator ChamCongViewModel(ChamCong chamCong)
        {
            return new ChamCongViewModel
            {
                MaNhanVien = chamCong.MaNhanVien,
                Ngay = chamCong.Ngay,
                ThoiGianVao = chamCong.ThoiGianVao,
                ThoiGianRa = chamCong.ThoiGianRa,
                ThoiGianLamViec = chamCong.ThoiGianLamViec,
                ThoiGianTangCa = chamCong.ThoiGianTangCa,
                TrangThai = chamCong.TrangThai,
                NhanVien = chamCong.NhanVien
            };
        }
        public static implicit operator ChamCong(ChamCongViewModel chamCongViewModel)
        {
            return new ChamCong
            {
                MaNhanVien = chamCongViewModel.MaNhanVien,
                Ngay = chamCongViewModel.Ngay,
                ThoiGianVao = chamCongViewModel.ThoiGianVao,
                ThoiGianRa = chamCongViewModel.ThoiGianRa,
                ThoiGianLamViec = chamCongViewModel.ThoiGianLamViec,
                ThoiGianTangCa = chamCongViewModel.ThoiGianTangCa,
                TrangThai = chamCongViewModel.TrangThai,
                NhanVien = chamCongViewModel.NhanVien
            };
        }

        public virtual NhanVien NhanVien { get; set; }
        public virtual NhanVienViewModel NhanVienViewModel { get; set; }
    }
}