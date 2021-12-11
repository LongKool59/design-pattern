using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
namespace WebApplication1.FactoryMethod.Factory
{
    public interface Factory1
    {
        LoaiThuong CreateModel(LoaiThuongViewModel loaiThuongViewModel);
    }
}
