using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _2_7
{
    class Program
    {
       
   

        static void Main(string[] args)
        {
            int[] array= { 34, 65, 34, 55, 66, 3, 22, 87, 54, 9, 122, 5 };
            int max, min,  sum;
            max = array[0];
            min = array[0];
            sum = 0;
            double ave;
            Console.WriteLine("该数组为：");
            foreach(int a in array)
            {
                if(a>=max)
                {
                    max = a;
                }
                if(a<=min)
                {
                    min = a;
                }
                sum += a;
                Console.WriteLine("{0},",a);
            }
            int n = array.Length;
            ave = Convert .ToDouble(sum / n);
            Console.WriteLine("\r\n最大值为{0}，最小值为{1},和为{2},平均值为{3}", max, min, sum, ave);
            
        }
    }
}
