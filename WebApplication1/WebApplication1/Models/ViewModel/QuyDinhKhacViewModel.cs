using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class QuyDinhKhacViewModel
    {
        [DisplayName("Mã quy định")]
        public int MaQuyDinh { get; set; }
        [DisplayName("Tên quy định")]
        public string TenQuyDinh { get; set; }
        [DisplayName("Giá trị")]
        [Required(ErrorMessage = "Giá trị không được trống...")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số nguyên dương...")]
        public int GiaTri { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public static implicit operator QuyDinhKhacViewModel(QuyDinhKhac quyDinhKhac)
        {
            return new QuyDinhKhacViewModel
            {
                MaQuyDinh = quyDinhKhac.MaQuyDinh,
                TenQuyDinh = quyDinhKhac.TenQuyDinh,
                GiaTri = quyDinhKhac.GiaTri,
                GhiChu = quyDinhKhac.GhiChu
            };
        }

        public static implicit operator QuyDinhKhac(QuyDinhKhacViewModel quyDinhKhacViewModel)
        {
            return new QuyDinhKhac
            {
                MaQuyDinh = quyDinhKhacViewModel.MaQuyDinh,
                TenQuyDinh = quyDinhKhacViewModel.TenQuyDinh,
                GiaTri = quyDinhKhacViewModel.GiaTri,
                GhiChu = quyDinhKhacViewModel.GhiChu
            };
        }
    }
}