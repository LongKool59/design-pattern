using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class Ct_PhatViewModel
    {
        [DisplayName("Mã chi tiết phạt")]
        public int MaCTPhat { get; set; }
        [DisplayName("Mã NV")]
        public int MaNhanVien { get; set; }
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }
        [DisplayName("Mã loại phạt")]
        public int MaLoaiPhat { get; set; }

        [DisplayName("Người phạt")]
        public string NguoiPhat { get; set; }
        [DisplayName("Ngày phạt")]
        public System.DateTime NgayPhat { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }
        public bool IsChecked { get; set; }

        public static implicit operator Ct_PhatViewModel(Ct_Phat ct_Phat)
        {
            return new Ct_PhatViewModel
            {
                MaCTPhat = ct_Phat.MaCTPhat,
                MaNhanVien = ct_Phat.MaNhanVien,
                MaLoaiPhat = ct_Phat.MaLoaiPhat,
                NguoiPhat = ct_Phat.NguoiPhat,
                NgayPhat = ct_Phat.NgayPhat,
                TrangThai = ct_Phat.TrangThai,
                NguoiSua = ct_Phat.NguoiSua,
                NgaySua = ct_Phat.NgaySua,
                NhanVien = ct_Phat.NhanVien,
                LoaiPhat = ct_Phat.LoaiPhat,
                PhongBan = ct_Phat.NhanVien.PhongBan,
            };
        }

        public static implicit operator Ct_Phat(Ct_PhatViewModel ct_PhatViewModel)
        {
            return new Ct_Phat
            {
                MaCTPhat = ct_PhatViewModel.MaCTPhat,
                MaNhanVien = ct_PhatViewModel.MaNhanVien,
                MaLoaiPhat = ct_PhatViewModel.MaLoaiPhat,
                NguoiPhat = ct_PhatViewModel.NguoiPhat,
                NgayPhat = ct_PhatViewModel.NgayPhat,
                TrangThai = ct_PhatViewModel.TrangThai,
                NguoiSua = ct_PhatViewModel.NguoiSua,
                NgaySua = ct_PhatViewModel.NgaySua,
                NhanVien = ct_PhatViewModel.NhanVien,
                LoaiPhat = ct_PhatViewModel.LoaiPhat,
            };
        }

        public virtual NhanVienViewModel NhanVienViewModel { get; set; }
        public virtual LoaiPhatViewModel LoaiPhatViewModel{ get; set; }
        public virtual PhongBanViewModel PhongBanViewModel { get; set; }

        public virtual LoaiPhat LoaiPhat { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual PhongBan PhongBan{ get; set; }
    }
}