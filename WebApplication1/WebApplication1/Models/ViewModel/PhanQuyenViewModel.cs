using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class PhanQuyenViewModel
    {
        public PhanQuyenViewModel()
        {
            this.TaiKhoans = new HashSet<TaiKhoan>();
        }

        [DisplayName("Mã quyền")]
        public int MaQuyen { get; set; }
        [DisplayName("Tên quyền")]
        public string TenQuyen { get; set; }
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator PhanQuyenViewModel(PhanQuyen phanQuyen)
        {
            return new PhanQuyenViewModel
            {
                MaQuyen = phanQuyen.MaQuyen,
                TenQuyen = phanQuyen.TenQuyen,
                GhiChu = phanQuyen.GhiChu,
            };
        }
        public static implicit operator PhanQuyen(PhanQuyenViewModel phanQuyenViewModel)
        {
            return new PhanQuyen
            {
                MaQuyen = phanQuyenViewModel.MaQuyen,
                TenQuyen = phanQuyenViewModel.TenQuyen,
                GhiChu = phanQuyenViewModel.GhiChu,
            };
        }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}