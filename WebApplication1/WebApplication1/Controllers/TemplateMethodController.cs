using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public abstract class TemplateMethodController : Controller
    {

        protected abstract void PrintNotification();
        protected abstract void PrintNotification2();
        public void Print()
        {
            PrintNotification();
            PrintNotification2();
        }
    }
}