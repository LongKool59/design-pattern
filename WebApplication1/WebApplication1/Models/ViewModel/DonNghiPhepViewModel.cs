using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class DonNghiPhepViewModel
    {
        [DisplayName("Mã đơn nghỉ phép")]
        public int MaDonNghiPhep { get; set; }
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Ngày nghỉ")]
        [Required(ErrorMessage = "Ngày nghỉ không được trống...")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime NgayNghi { get; set; }
        [DisplayName("Ca nghỉ")]
        public string CaNghi { get; set; }
        [DisplayName("Lý do")]
        [Required(ErrorMessage = "Lý do không được trống...")]
        public string LyDo { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người duyệt")]
        public string NguoiDuyet { get; set; }
        public bool IsChecked { get; set; }

        public static implicit operator DonNghiPhepViewModel(DonNghiPhep donNghiPhep)
        {
            return new DonNghiPhepViewModel
            {
                MaDonNghiPhep = donNghiPhep.MaDonNghiPhep,
                MaNhanVien = donNghiPhep.MaNhanVien,
                NgayNghi = donNghiPhep.NgayNghi,
                CaNghi = donNghiPhep.CaNghi,
                LyDo = donNghiPhep.LyDo,
                TrangThai = donNghiPhep.TrangThai,
                NguoiDuyet = donNghiPhep.NguoiDuyet,
                NhanVien = donNghiPhep.NhanVien
            };
        }
        public static implicit operator DonNghiPhep(DonNghiPhepViewModel donNghiPhepViewModel)
        {
            return new DonNghiPhep
            {
                MaDonNghiPhep = donNghiPhepViewModel.MaDonNghiPhep,
                MaNhanVien = donNghiPhepViewModel.MaNhanVien,
                NgayNghi = donNghiPhepViewModel.NgayNghi,
                CaNghi = donNghiPhepViewModel.CaNghi,
                LyDo = donNghiPhepViewModel.LyDo,
                TrangThai = donNghiPhepViewModel.TrangThai,
                NguoiDuyet = donNghiPhepViewModel.NguoiDuyet,
                NhanVien = donNghiPhepViewModel.NhanVien
            };
        }
        public virtual NhanVien NhanVien { get; set; }
        public virtual NhanVienViewModel NhanVienViewModel { get; set; }

    }
}