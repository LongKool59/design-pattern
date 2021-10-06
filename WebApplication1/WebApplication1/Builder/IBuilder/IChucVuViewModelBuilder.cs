using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.ViewModel;
namespace WebApplication1.Builder.IBuilder
{
    public interface IChucVuViewModelBuilder
    {
        IChucVuViewModelBuilder AddTenChucVu(string tenChucVu);

        IChucVuViewModelBuilder AddHeSoChucVu(double heSoChucVu);
        IChucVuViewModelBuilder AddPhuCap(int? phuCap);
        IChucVuViewModelBuilder AddTrangThai(bool trangThai);
        IChucVuViewModelBuilder AddNguoiSua(string nguoiSua);
        IChucVuViewModelBuilder AddNgaySua(DateTime ngaySua);
        ChucVuViewModel Build();
    }
}
