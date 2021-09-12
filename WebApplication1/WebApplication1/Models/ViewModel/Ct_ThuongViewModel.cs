using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class Ct_ThuongViewModel
    {
        [DisplayName("Mã chi tiết thưởng")]
        public int MaCTThuong { get; set; }
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Mã loại thưởng")]
        public int MaLoaiThuong { get; set; }


        [DisplayName("Người thưởng")]
        public string NguoiThuong { get; set; }
        [DisplayName("Ngày thưởng")]
        public System.DateTime NgayThuong { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }
        public bool IsChecked { get; set; }

        public static implicit operator Ct_ThuongViewModel(Ct_Thuong ct_Thuong)
        {
            return new Ct_ThuongViewModel
            {
                MaCTThuong = ct_Thuong.MaCTThuong,
                MaNhanVien = ct_Thuong.MaNhanVien,
                MaLoaiThuong = ct_Thuong.MaLoaiThuong,
                NguoiThuong = ct_Thuong.NguoiThuong,
                NgayThuong = ct_Thuong.NgayThuong,
                TrangThai = ct_Thuong.TrangThai,
                NguoiSua = ct_Thuong.NguoiSua,
                NgaySua = ct_Thuong.NgaySua,
                NhanVien = ct_Thuong.NhanVien,
                LoaiThuong = ct_Thuong.LoaiThuong,
            };
        }

        public static implicit operator Ct_Thuong(Ct_ThuongViewModel ct_ThuongViewModel)
        {
            return new Ct_Thuong
            {
                MaCTThuong = ct_ThuongViewModel.MaCTThuong,
                MaNhanVien = ct_ThuongViewModel.MaNhanVien,
                MaLoaiThuong = ct_ThuongViewModel.MaLoaiThuong,
                NguoiThuong = ct_ThuongViewModel.NguoiThuong,
                NgayThuong = ct_ThuongViewModel.NgayThuong,
                TrangThai = ct_ThuongViewModel.TrangThai,
                NguoiSua = ct_ThuongViewModel.NguoiSua,
                NgaySua = ct_ThuongViewModel.NgaySua
            };
        }

        public virtual NhanVien NhanVien { get; set; }
        public virtual LoaiThuong LoaiThuong { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}