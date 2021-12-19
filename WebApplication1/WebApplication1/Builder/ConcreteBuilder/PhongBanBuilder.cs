using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Builder.IBuilder;
using WebApplication1.Models;
namespace WebApplication1.Builder.ConcreteBuilder
{
    public class PhongBanBuilder : IPhongBanBuilder
    {
        PhongBan phongBan = new PhongBan();
        public IPhongBanBuilder AddTenPhongBan(string tenPB)
        {
            phongBan.TenPB = tenPB;
            return this;
        }

        public IPhongBanBuilder AddSoDT(string soDT)
        {
            phongBan.SoDT = soDT;
            return this;    
        }

        public IPhongBanBuilder AddNguoiSua(string nguoiSua)
        {
            phongBan.NguoiSua = nguoiSua;
            return this;
        }
        public IPhongBanBuilder AddNgaySua(DateTime ngaySua)
        {
            phongBan.NgaySua = ngaySua;
            return this;
        }

        public PhongBan Build()
        {
            return phongBan;
        }
    }
}