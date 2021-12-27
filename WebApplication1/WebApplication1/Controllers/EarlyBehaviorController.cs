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
    public class EarlyBehaviorController : ChamCongBehaviorControllers
    {
        public override void PrintMessage()
        {
            this.AddNotification("Không được check out. Vì bạn vừa mới check in trong giờ nghỉ.", NotificationType.WARNING);
        }
    }
}