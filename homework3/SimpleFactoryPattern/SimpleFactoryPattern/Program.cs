using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    class Program
    {
        interface IShape
        {
             void draw();
            void erase();

        }//接口

        public class Circle : IShape
        {
            public void draw()
            {
                Console.WriteLine("绘制圆形");
            }
            public void erase()
            {
                Console.WriteLine("擦除圆形");
            }
        }
        public class Rect : IShape
        {
            public void draw()
            {
                Console.WriteLine("绘制方形");

            }
            public void erase()
            {
                Console.WriteLine("擦除方形");
            }

        }

        public class Triangle : IShape
        {
            public void draw()
            {
                Console.WriteLine("绘制三角形");
                
            }
            public void erase()
            {
                Console.WriteLine("擦除三角形");
            }
        }

        class ShapeFactory
        {
            public static IShape getShape(String type)
            {
                IShape shape=null;
                if(type.Equals("Circle"))
                {
                    shape = new Circle();
                    Console.WriteLine("初始化圆形");

                }
                else if(type.Equals("Rect"))
                {
                    shape = new Rect();
                    Console.WriteLine("初始化方形");

                }
                else if(type.Equals("Triangle"))
                {
                    shape = new Triangle();
                    Console.WriteLine("初始化三角形");
                }
                else
                {
                    Console.WriteLine("UnSupportedShapeException");
                }

                return shape;
            }
        }

     

        static void Main(string[] args)
        {
            string shape,move;
            IShape s;
            bool flag=false;
            while (true)
            {
                Console.WriteLine("请输入要进行的操作：（start绘制并擦除图形、end退出）");
                move = Console.ReadLine();
                flag = false;
                if (move == "start")
                {
                    while (!flag)
                    {
                        Console.WriteLine("请输入要绘制的图形：（c圆形、r正方形、t三角形）");
                        shape = Console.ReadLine();
                        switch (shape)
                        {
                            case "c":
                                s = ShapeFactory.getShape("Circle");
                                s.draw();
                                s.erase();
                                flag = true;
                                break;
                            case "r":
                                s = ShapeFactory.getShape("Rect");
                                s.draw();
                                s.erase();
                                flag = true;
                                break;
                            case "t":
                                s = ShapeFactory.getShape("Triangle");
                                s.draw();
                                s.erase();
                                flag = true;
                                break;
                            default:
                                Console.WriteLine("请按提示正确输入！");
                                flag = false;
                                break;
                        }
                    }
                    
                }
                
                else if (move == "end")
                {
                    Console.WriteLine("程序结束！");
                    break;
                }
                else
                {
                    Console.WriteLine("请按提示正确输入！");
                }
                     
               
            }
           
       
        }
    }
}
