using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class NghiViewModel
    {
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Ngày nghỉ")]
        public System.DateTime NgayNghi { get; set; }
        [DisplayName("Phép")]
        public bool Phep { get; set; }
        [DisplayName("Người duyệt")]
        public string NguoiDuyet { get; set; }
        [DisplayName("Ngày sửa")]
        public Nullable<System.DateTime> NgaySua { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator NghiViewModel(Nghi nghi)
        {
            return new NghiViewModel
            {
               MaNhanVien = nghi.MaNhanVien,
               NgayNghi = nghi.NgayNghi,
               Phep = nghi.Phep,
               NguoiDuyet = nghi.NguoiDuyet,
               NgaySua = nghi.NgaySua,
               GhiChu = nghi.GhiChu,
               NhanVien = nghi.NhanVien,
            };
        }

        public static implicit operator Nghi(NghiViewModel nghiViewModel)
        {
            return new Nghi
            {
                MaNhanVien = nghiViewModel.MaNhanVien,
                NgayNghi = nghiViewModel.NgayNghi,
                Phep = nghiViewModel.Phep,
                NguoiDuyet = nghiViewModel.NguoiDuyet,
                NgaySua = nghiViewModel.NgaySua,
                GhiChu = nghiViewModel.GhiChu,
                NhanVien = nghiViewModel.NhanVien,
            };
        }

        public virtual NhanVien NhanVien { get; set; }
        public virtual NhanVienViewModel NhanVienViewModel { get; set; }
    }
}