using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.CommandPattern.Receiver;
using WebApplication1.Models.ViewModel;
using WebApplication1.CommandPattern.Interface;
namespace WebApplication1.CommandPattern.ImplementInterface
{
    public class ConvertToModelCommand : Command
    {
        public ReceiverLoaiPhat receiver { get; set; }
        public void Execute()
        {
            receiver.ConvertToModel();
        }
    }
}