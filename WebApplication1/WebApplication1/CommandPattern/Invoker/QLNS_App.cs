using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.CommandPattern.Interface;
namespace WebApplication1.CommandPattern.Invoker
{
    public class QLNS_App
    {
        public Command convertToModelCommand { get; set; }
        public Command addModelCommand { get; set; }

        public void ConvertToModel()
        {
            convertToModelCommand.Execute();
        }
        public void AddModel()
        {
            addModelCommand.Execute();
        }
    }
}