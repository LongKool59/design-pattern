using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class PhongBanViewModel
    {
        public PhongBanViewModel()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }

        [DisplayName("Mã phòng ban")]
        public int MaPB { get; set; }
        [DisplayName("Tên phòng ban")]
        [Required(ErrorMessage = "Tên phòng ban không được trống...")]
        public string TenPB { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được trống...")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại bắt đầu là 0 và không bao gồm chữ. Gồm 10 số")]
        public string SoDT { get; set; }

        public bool IsChecked { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }

        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }

        public static implicit operator PhongBanViewModel(PhongBan phongBan)
        {
            return new PhongBanViewModel
            {
                MaPB = phongBan.MaPB,
                TenPB = phongBan.TenPB,
                SoDT = phongBan.SoDT,
                NguoiSua = phongBan.NguoiSua,
                NgaySua = phongBan.NgaySua,
            };
        }

        public static implicit operator PhongBan(PhongBanViewModel phongBanViewModel)
        {
            return new PhongBan
            {
                MaPB = phongBanViewModel.MaPB,
                TenPB = phongBanViewModel.TenPB,
                SoDT = phongBanViewModel.SoDT,
                NguoiSua = phongBanViewModel.NguoiSua,
                NgaySua = phongBanViewModel.NgaySua,
            };
        }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}