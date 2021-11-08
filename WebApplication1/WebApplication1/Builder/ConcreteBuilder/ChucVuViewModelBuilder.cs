using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Builder.IBuilder;
using WebApplication1.Models.ViewModel;
namespace WebApplication1.Builder.ConcreteBuilder
{
    public class ChucVuViewModelBuilder : IChucVuViewModelBuilder
    {
        ChucVuViewModel chucVuViewModel = new ChucVuViewModel();
        public IChucVuViewModelBuilder AddTenChucVu(string tenChucVu)
        {
            chucVuViewModel.TenChucVu = tenChucVu;
            return this;
        }

        public IChucVuViewModelBuilder AddHeSoChucVu(double heSoChucVu)
        {
            chucVuViewModel.HeSoChucVu = heSoChucVu;
            return this;
        }
        public IChucVuViewModelBuilder AddPhuCap(int? phuCap)
        {
            chucVuViewModel.PhuCap = phuCap;
            return this;
        }
        public IChucVuViewModelBuilder AddTrangThai(bool trangThai)
        {
            chucVuViewModel.TrangThai = trangThai;
            return this;
        }
        public IChucVuViewModelBuilder AddNguoiSua(string nguoiSua)
        {
            chucVuViewModel.NguoiSua = nguoiSua;
            return this;
        }

        public IChucVuViewModelBuilder AddNgaySua(DateTime ngaySua)
        {
            chucVuViewModel.NgaySua = ngaySua;
            return this;
        }

        public ChucVuViewModel Build()
        {
            return chucVuViewModel;
        }
    }
}