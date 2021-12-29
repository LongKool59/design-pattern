using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using PagedList;
using PagedList.Mvc;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class LateBehaviorController: ChamCongBehaviorControllers
    {
        public override string PrintMessage()
        {
            return "Không được check in vì đã quá giờ quy định.";
        }      
    }
}