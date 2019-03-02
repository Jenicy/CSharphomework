using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_6
{
    class Program
    {
        private static object thread;

        static void Main(string[] args)
        {
            Console.WriteLine("******该程序输出用户指定数据的所有素数因子******");
            Console.WriteLine("请输入一个整数：");
            int d1 = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}的素因子有：\r\n", d1);
            int factor = 2;
            while(factor<=d1)
            {
                if(d1%factor==0)//此时的factor是d1的一个因子
                {
                    d1 = d1 / factor;
                    Console.WriteLine("{0}", factor);
                }
                else//d1不能整除factor，则factor自增1，继续除d1
                {
                    factor++;
                }
            }

           
        }
    }
}
