using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.CommandPattern.Interface;
using WebApplication1.CommandPattern.Receiver;
namespace WebApplication1.CommandPattern.ImplementInterface
{
    public class AddModelCommand : Command
    {
        public ReceiverLoaiPhat receiver { get; set; }
        public void Execute()
        {
            receiver.AddModel();
        }
    }
}