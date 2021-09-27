using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class QuyDinhTGViewModel
    {
        [DisplayName("Mã quy định")]
        public int MaQuyDinh { get; set; }
        [DisplayName("Tên quy định")]
        public string TenQuyDinh { get; set; }
        [DisplayName("Giá trị")]
        [Required(ErrorMessage = "Giá trị không được trống...")]
        //[RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Thời gian không hợp lệ. Vui lòng nhập lại, ví dụ: 1:00 PM")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public System.TimeSpan GiaTri { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public static implicit operator QuyDinhTGViewModel(QuyDinhThoiGian quyDinhTG)
        {
            return new QuyDinhTGViewModel
            {
                MaQuyDinh = quyDinhTG.MaQuyDinh,
                TenQuyDinh = quyDinhTG.TenQuyDinh,
                GiaTri = quyDinhTG.GiaTri,
                GhiChu = quyDinhTG.GhiChu
            };
        }

        public static implicit operator QuyDinhThoiGian(QuyDinhTGViewModel quyDinhTGViewModel)
        {
            return new QuyDinhThoiGian
            {
                MaQuyDinh = quyDinhTGViewModel.MaQuyDinh,
                TenQuyDinh = quyDinhTGViewModel.TenQuyDinh,
                GiaTri = quyDinhTGViewModel.GiaTri,
                GhiChu = quyDinhTGViewModel.GhiChu
            };
        }
    }
}