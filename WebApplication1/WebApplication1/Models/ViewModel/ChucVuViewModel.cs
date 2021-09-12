using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModel
{
    public partial class ChucVuViewModel
    {
        private QLNhanSuEntities db = new QLNhanSuEntities();
        /* [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]*/
        public ChucVuViewModel()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }

        [DisplayName("Mã chức vụ")]

        public int MaChucVu { get; set; }
        [DisplayName("Tên chức vụ")]
        [Required(ErrorMessage = "Tên chức vụ không được trống...")]
        public string TenChucVu { get; set; }
        [DisplayName("Hệ số chức vụ")]
        [Required(ErrorMessage = "Hệ số chức vụ không được trống...")]
        public double HeSoChucVu { get; set; }
        [DisplayName("Phụ cấp")]
        [Required(ErrorMessage = "Phụ cấp không được trống...")]
        public Nullable<int> PhuCap { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        public bool IsChecked { get; set; }
        [DisplayName("Người sửa")]
        public string NguoiSua { get; set; }
        [DisplayName("Ngày sửa")]
        public System.DateTime NgaySua { get; set; }

        public static implicit operator ChucVuViewModel(ChucVu chucVu)
        {
            return new ChucVuViewModel
            {
                MaChucVu = chucVu.MaChucVu,
                TenChucVu = chucVu.TenChucVu,
                HeSoChucVu = chucVu.HeSoChucVu,
                PhuCap = chucVu.PhuCap,
                NguoiSua = chucVu.NguoiSua,
                NgaySua = chucVu.NgaySua,
                TrangThai = chucVu.TrangThai,

            };
        }

        public static implicit operator ChucVu(ChucVuViewModel chucVuViewModel)
        {
            return new ChucVu
            {
                MaChucVu = chucVuViewModel.MaChucVu,
                TenChucVu = chucVuViewModel.TenChucVu,
                HeSoChucVu = chucVuViewModel.HeSoChucVu,
                PhuCap = chucVuViewModel.PhuCap,
                NguoiSua = chucVuViewModel.NguoiSua,
                NgaySua = chucVuViewModel.NgaySua,
                TrangThai = chucVuViewModel.TrangThai,

            };
        }
        public List<ChucVu> chucVus
        {
            get; set;
        }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}