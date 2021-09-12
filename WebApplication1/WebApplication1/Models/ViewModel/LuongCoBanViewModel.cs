using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class LuongCoBanViewModel
    {
        public LuongCoBanViewModel()
        {
            this.LuongThangs = new HashSet<LuongThang>();
        }

        [DisplayName("Mã lương cơ bản")]
        public int MaLuongCoBan { get; set; }
        [DisplayName("Tiền lương cơ bản")]
        [Required(ErrorMessage = "Tiền lương không được trống...")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int TienLuongCoBan { get; set; }
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }

        public static implicit operator LuongCoBanViewModel(LuongCoBan luongCoBan)
        {
            return new LuongCoBanViewModel
            {
                MaLuongCoBan = luongCoBan.MaLuongCoBan,
                TienLuongCoBan = luongCoBan.TienLuongCoBan,
                MaNhanVien = luongCoBan.MaNhanVien,
                TrangThai = luongCoBan.TrangThai,
                NguoiSua = luongCoBan.NguoiSua,
                NgaySua = luongCoBan.NgaySua,
                NhanVien = luongCoBan.NhanVien,
            };
        }

        public static implicit operator LuongCoBan(LuongCoBanViewModel luongCoBanViewModel)
        {
            return new LuongCoBan
            {
                MaLuongCoBan = luongCoBanViewModel.MaLuongCoBan,
                TienLuongCoBan = luongCoBanViewModel.TienLuongCoBan,
                MaNhanVien = luongCoBanViewModel.MaNhanVien,
                TrangThai = luongCoBanViewModel.TrangThai,
                NguoiSua = luongCoBanViewModel.NguoiSua,
                NgaySua = luongCoBanViewModel.NgaySua,
                NhanVien = luongCoBanViewModel.NhanVien,
            };
        }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<LuongThang> LuongThangs { get; set; }
    }
}