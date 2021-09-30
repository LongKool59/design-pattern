using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public class LoaiPhatViewModel
    {
        public LoaiPhatViewModel()
        {
            this.Ct_Phat = new HashSet<Ct_Phat>();
        }

        [DisplayName("Mã loại phạt")]
        public int MaLoaiPhat { get; set; }
        [DisplayName("Tên loại phạt")]
        [Required(ErrorMessage = "Tên loại phạt không được trống...")]
        public string TenLoaiPhat { get; set; }
        [DisplayName("Giá trị")]
        public int GiaTri { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }
        public bool IsChecked { get; set; }

        public static implicit operator LoaiPhatViewModel(LoaiPhat loaiPhat)
        {
            return new LoaiPhatViewModel
            {
                MaLoaiPhat = loaiPhat.MaLoaiPhat,
                TenLoaiPhat = loaiPhat.TenLoaiPhat,
                GiaTri = loaiPhat.GiaTri,
                TrangThai = loaiPhat.TrangThai,
                NguoiSua = loaiPhat.NguoiSua,
                NgaySua = loaiPhat.NgaySua 
            };
        }
        public static implicit operator LoaiPhat(LoaiPhatViewModel loaiPhatViewModel)
        {
            return new LoaiPhat
            {
                MaLoaiPhat = loaiPhatViewModel.MaLoaiPhat,
                TenLoaiPhat = loaiPhatViewModel.TenLoaiPhat,
                GiaTri = loaiPhatViewModel.GiaTri,
                TrangThai = loaiPhatViewModel.TrangThai,
                NguoiSua = loaiPhatViewModel.NguoiSua,
                NgaySua = loaiPhatViewModel.NgaySua
            };
        }
        public virtual ICollection<Ct_Phat> Ct_Phat { get; set; }
    }
}