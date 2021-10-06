using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class LoaiThuongViewModel
    {
        public LoaiThuongViewModel()
        {
            this.Ct_Thuong = new HashSet<Ct_Thuong>();
        }

        [DisplayName("Mã loại thưởng")]
        public int MaLoaiThuong { get; set; }
        [DisplayName("Tên loại thưởng")]
        [Required(ErrorMessage = "Tên loại thưởng không được trống...")]
        public string TenLoaiThuong { get; set; }
        [DisplayName("Giá trị")]
        [Required(ErrorMessage = "Giá trị không được trống...")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số nguyên dương...")]
        public int GiaTri { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }
        public bool IsChecked { get; set; }

        public static implicit operator LoaiThuongViewModel(LoaiThuong loaiThuong)
        {
            return new LoaiThuongViewModel
            {
                MaLoaiThuong = loaiThuong.MaLoaiThuong,
                TenLoaiThuong = loaiThuong.TenLoaiThuong,
                GiaTri = loaiThuong.GiaTri,
                TrangThai = loaiThuong.TrangThai,
                NguoiSua = loaiThuong.NguoiSua,
                NgaySua = loaiThuong.NgaySua
            };
        }
        public static implicit operator LoaiThuong(LoaiThuongViewModel loaiThuongViewModel)
        {
            return new LoaiThuong
            {
                MaLoaiThuong = loaiThuongViewModel.MaLoaiThuong,
                TenLoaiThuong = loaiThuongViewModel.TenLoaiThuong,
                GiaTri = loaiThuongViewModel.GiaTri,
                TrangThai = loaiThuongViewModel.TrangThai,
                NguoiSua = loaiThuongViewModel.NguoiSua,
                NgaySua = loaiThuongViewModel.NgaySua
            };
        }
        public virtual ICollection<Ct_Thuong> Ct_Thuong { get; set; }
    }
}