//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonNghiPhep
    {
        public int MaDonNghiPhep { get; set; }
        public int MaNhanVien { get; set; }
        public System.DateTime NgayNghi { get; set; }
        public string CaNghi { get; set; }
        public string LyDo { get; set; }
        public bool TrangThai { get; set; }
        public string NguoiDuyet { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
