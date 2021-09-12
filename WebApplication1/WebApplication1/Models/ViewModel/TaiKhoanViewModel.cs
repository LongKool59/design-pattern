using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public partial class TaiKhoanViewModel
    {
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được trống...")]
        public string TenTK { get; set; }
        [DisplayName("Mật khẩu")]

        [Required(ErrorMessage = "Mật khẩu không được trống...")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d).{5,25}$", ErrorMessage = "Mật khẩu bao gồm chữ và số, từ 5 đến 25 kí tự")]
        public string MatKhau { get; set; }
        [DisplayName("Mã quyền")]
        public int MaQuyen { get; set; }
        public string ResetPasswordCode { get; set; }

        public static implicit operator TaiKhoanViewModel(TaiKhoan taiKhoan)
        {
            return new TaiKhoanViewModel
            {
               MaNhanVien = taiKhoan.MaNhanVien,
               TenTK = taiKhoan.TenTK,
               MatKhau = taiKhoan.MatKhau,
               MaQuyen = taiKhoan.MaQuyen,
               NhanVien = taiKhoan.NhanVien,
               PhanQuyen = taiKhoan.PhanQuyen,
            };
        }

        public static implicit operator TaiKhoan(TaiKhoanViewModel taiKhoanViewModel)
        {
            return new TaiKhoan
            {
                MaNhanVien = taiKhoanViewModel.MaNhanVien,
                TenTK = taiKhoanViewModel.TenTK,
                MatKhau = taiKhoanViewModel.MatKhau,
                MaQuyen = taiKhoanViewModel.MaQuyen,
                NhanVien = taiKhoanViewModel.NhanVien,
                PhanQuyen = taiKhoanViewModel.PhanQuyen,
            };
        }

        public virtual NhanVien NhanVien { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}