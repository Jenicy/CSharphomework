using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] flags = new int[100];
            for(int n=0;n<100;n++)
            {
                flags[n] = 1;
            }
            flags[0] = 0;
            flags[1] = 0;
            int i;
            for(i=2;i<100;++i)
            {
                if(flags[i]==1)
                {
                    for(int j=i*i;j<100;j+=i)
                    {
                        flags[j] = 0;
                    }
                    
                }
            }
            Console.WriteLine("1到100 以内的素数为：");
            for(i=2;i<100;i++)
            {
                if(flags[i]==1)
                {
                    Console.WriteLine(i);
                }
            }


            

        }
    }
}
