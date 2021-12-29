using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.StragetyPattern
{
    //Hanh vi Abstract
    public abstract class ChamCongBehavior
    {
        public abstract void AboutMe(string chamcong);

    }
    //Cham cong muon
    class LateBehavior : ChamCongBehavior
    {
        public override void AboutMe(string chamcong)
        {
            Console.WriteLine("{1} không được checkin vì đã quá giờ quy định");
        }
    }
    class EarlyBehavior : ChamCongBehavior
    {
        public override void AboutMe(string chamcong)
        {
            Console.WriteLine("{1} Không được check out. Vì bạn vừa mới check in trong giờ nghỉ");
        }
    }
    class InitialBehavior : ChamCongBehavior
    {
        public override void AboutMe(string chamcong)
        {
            Console.WriteLine("{1} Mới đến vào trang web, chưa làm gì hết");
        }
    }
    //Hanh vi
    public class ChamCong
    {
        ChamCongBehavior behavior;
        string chamcongType;
        public ChamCong(string chamcongType)
        {
            this.chamcongType = chamcongType;
            this.behavior = new InitialBehavior();
        }
        public void SetChamCongBehavior(ChamCongBehavior behavior)
        {
            this.behavior = behavior;
        }
        public void DisplayAboutMe()
        {
            this.behavior.AboutMe(this.chamcongType);
        }
    }
}