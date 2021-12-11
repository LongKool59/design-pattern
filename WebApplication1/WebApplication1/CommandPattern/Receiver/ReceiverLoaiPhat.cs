using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.CommandPattern.Interface;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.CommandPattern.Receiver
{
    public class ReceiverLoaiPhat
    {
        private LoaiPhat loaiPhat { get; set; }
        public LoaiPhatViewModel loaiPhatViewModel { get; set; }
        public QLNhanSuEntities db { get; set; }
        public void ConvertToModel()
        {
            loaiPhat = loaiPhatViewModel;
        }
        public void AddModel()
        {
            db = db;
            db.LoaiPhats.Add(loaiPhat);
        }

    }
}