using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.FactoryMethod.Factory;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
namespace WebApplication1.FactoryMethod.ConcreteFactory
{
    public class LoaiThuongFactory : Factory1
    {
        public LoaiThuong CreateModel(LoaiThuongViewModel loaiThuongViewModel)
        {
            LoaiThuong loaiThuong = loaiThuongViewModel;
            return loaiThuong;
        }
    }
}