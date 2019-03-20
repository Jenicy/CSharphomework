using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class ClockEventArgs : EventArgs
    {
        public bool flag;
    }//声明参数类型

    public delegate void ClockEventHandler(object sender, ClockEventArgs c);//声明委托类型

    public class Clock
    {
        public event ClockEventHandler bell;//声明事件

        private string time;
        public string Time
        {
            set
            {
                time = value;
            }
            get
            {
                return time;
            }
        }
        public void TimeTest(string s)
        {
            if (time == DateTime.Now.ToLongTimeString())
            {
                ClockEventArgs args = new ClockEventArgs();
                args.flag = true;
                bell(this, args);
            }//发生一个事件，即通知外界
        }
    }

    class Program
    {
      
        static void Main(string[] args)
        {
            Clock C = new Clock();
           
            Console.WriteLine("请设定闹钟时间：（例如 12:12:12）");
            C.Time = (Console.ReadLine());
          //  System.Threading.Thread.Sleep(10000);
       
              while (true)
              {
                Console.WriteLine("当前时间为：");
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Console.WriteLine("设定时间为："+C.Time);
               
                var clock = new Clock();//注册事件
                clock.TimeTest(C.Time);
                clock.bell += ShowProgress;
                

                System.Threading.Thread.Sleep(1000);
                Console.Clear();
              }

        }
        static void ShowProgress(object sender,ClockEventArgs c)
        {
            Console.WriteLine("时间到！！！！");
            System.Threading.Thread.Sleep(10000);

        }
    }
}
