using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Builder.IBuilder
{
    public interface IPhongBanBuilder
    {
        IPhongBanBuilder AddTenPhongBan(string tenPB);
        IPhongBanBuilder AddSoDT(string soDT);
        IPhongBanBuilder AddNguoiSua(string nguoiSua);
        IPhongBanBuilder AddNgaySua(DateTime ngaySua);
        PhongBan Build();
    }
}
