using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i1, i2, mul;
            Console.WriteLine("Please input the first number:");
            i1 = int.Parse(Console.ReadLine());
            Console.Write("Please input the second number:");
            i2 = int.Parse(Console.ReadLine());

            mul = i1 * i2;
            Console.WriteLine("mul=" + mul);
            System.Threading.Thread.Sleep(10000);
        }
    }
}
