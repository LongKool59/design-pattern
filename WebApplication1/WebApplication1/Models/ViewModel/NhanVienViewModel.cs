using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class NhanVienViewModel
    {
        public NhanVienViewModel()
        {
            this.ChamCongs = new HashSet<ChamCong>();
            this.Ct_Phat = new HashSet<Ct_Phat>();
            this.Ct_Thuong = new HashSet<Ct_Thuong>();
            this.LuongCoBans = new HashSet<LuongCoBan>();
            this.Nghis = new HashSet<Nghi>();
        }


        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Họ tên không được trống...")]
        public string HoTen { get; set; }
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được trống...")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public System.DateTime NgaySinh { get; set; }
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Quê quán")]
        [Required(ErrorMessage = "Quê quán không được trống...")]
        public string QueQuan { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được trống...")]
        public string DiaChi { get; set; }
        [DisplayName("Chứng minh nhân dân")]
        [Required(ErrorMessage = "Số chứng minh nhân dân không được trống...")]
        public string CMND { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được trống...")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng. Ví dụ: example@gmail.com")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được trống...")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại bắt đầu là 0, không bao gồm chữ, gồm 10 số. ")]
        public string SDT { get; set; }
        [DisplayName("Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh không được trống...")]
        [Url(ErrorMessage = "Vui lòng đưa đường link hình ảnh chính xác!")]
        public string HinhAnh { get; set; }
        [DisplayName("Mã chức vụ")]
        public int MaChucVu { get; set; }
        [DisplayName("Mã phòng ban")]
        public Nullable<int> MaPB { get; set; }
        [DisplayName("Người tạo")]
        public string NguoiTao { get; set; }
        [DisplayName("Ngày tạo")]
        public System.DateTime NgayTao { get; set; }

        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator NhanVienViewModel(NhanVien nhanVien)
        {
            return new NhanVienViewModel
            {
                MaNhanVien = nhanVien.MaNhanVien,
                HoTen = nhanVien.HoTen,
                NgaySinh = nhanVien.NgaySinh,
                GioiTinh = nhanVien.GioiTinh,
                QueQuan = nhanVien.QueQuan,
                DiaChi = nhanVien.DiaChi,
                CMND = nhanVien.CMND,
                Email = nhanVien.Email,
                SDT = nhanVien.SDT,
                HinhAnh = nhanVien.HinhAnh,
                MaChucVu = nhanVien.MaChucVu,
                MaPB = nhanVien.MaPB,
                NguoiTao = nhanVien.NguoiTao,
                NgayTao = nhanVien.NgayTao,
                TrangThai = nhanVien.TrangThai,
                NguoiSua = nhanVien.NguoiSua,
                NgaySua = nhanVien.NgaySua,
                ChucVu = nhanVien.ChucVu,
                PhongBan = nhanVien.PhongBan,
                TaiKhoan = nhanVien.TaiKhoan,
            };
        }

        public static implicit operator NhanVien(NhanVienViewModel nhanVienViewModel)
        {
            return new NhanVien
            {
                MaNhanVien = nhanVienViewModel.MaNhanVien,
                HoTen = nhanVienViewModel.HoTen,
                NgaySinh = nhanVienViewModel.NgaySinh,
                GioiTinh = nhanVienViewModel.GioiTinh,
                QueQuan = nhanVienViewModel.QueQuan,
                DiaChi = nhanVienViewModel.DiaChi,
                CMND = nhanVienViewModel.CMND,
                Email = nhanVienViewModel.Email,
                SDT = nhanVienViewModel.SDT,
                HinhAnh = nhanVienViewModel.HinhAnh,
                MaChucVu = nhanVienViewModel.MaChucVu,
                MaPB = nhanVienViewModel.MaPB,
                NguoiTao = nhanVienViewModel.NguoiTao,
                NgayTao = nhanVienViewModel.NgayTao,
                TrangThai = nhanVienViewModel.TrangThai,
                NguoiSua = nhanVienViewModel.NguoiSua,
                NgaySua = nhanVienViewModel.NgaySua,
                ChucVu = nhanVienViewModel.ChucVu,
                PhongBan = nhanVienViewModel.PhongBan,
                TaiKhoan = nhanVienViewModel.TaiKhoan,
            };
        }

        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual ICollection<Ct_Phat> Ct_Phat { get; set; }
        public virtual ICollection<Ct_Thuong> Ct_Thuong { get; set; }
        public virtual ICollection<LuongCoBan> LuongCoBans { get; set; }
        public virtual ICollection<Nghi> Nghis { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual ChucVuViewModel ChucVuViewModel { get; set; }
        public virtual PhongBanViewModel PhongBanViewModel { get; set; }
        public virtual TaiKhoanViewModel TaiKhoanViewModel { get; set; }
    }
}