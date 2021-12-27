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
    public class StrategyPatternController
    {
            ChamCongBehaviorControllers behavior;
 
            public void SetChamCongBehavior(ChamCongBehaviorControllers behavior)
            {
                this.behavior = behavior;
            }
            public void PrintNotification()
            {
                this.behavior.PrintMessage();
            }
    }
}