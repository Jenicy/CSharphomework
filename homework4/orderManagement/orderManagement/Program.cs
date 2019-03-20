using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orderManagement
{
    //能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
    //在订单删除、修改失败时，能够产生异常并显示给客户错误信息。

     

    class Order//交互
    {
       public Order()
        {
            int s=0;
            OrderService service = new OrderService();
            do
            {
                Console.WriteLine("请输入要进行的操作：（1 增加订单，2 删除订单，3 查询,4 修改,0 退出)");
                s = int.Parse(Console.ReadLine());
                switch (s)
                {
                    case 1:
                        service.Add();
                        break;
                    case 2:
                        Console.WriteLine("请输入要删除的订单编号：");
                        int id2 = int.Parse(Console.ReadLine());
                        service.Del(id2);
                        break;
                    case 3:
                        Console.WriteLine("请输入要查询的订单编号：");
                        int id3 = int.Parse(Console.ReadLine());
                        service.LookForID(id3);
                        break;
                    case 4:
                        Console.WriteLine("请输入要修改的订单编号；");
                        int id4 = int.Parse(Console.ReadLine());
                        service.ChangeOrder(id4);
                        break;


                }


            }while (s != 0);
            


        }
        
   
       

    }

    class OrderDetails//订单明细，实体类
    {
        
        public int order_id { get; set; }//订单编号
        public string custmer_name { get; set; }//顾客姓名
        public string item_name { get; set; }//商品名称
        public int item_num { get; set; }//商品数量
        public int price { get; set; }//单价
        public int total_fee { get; set; }//总金额 
        public string address { get; set; }//收货人地址
        public string state { set; get; }//订单配送状态

        //private int receiver_phone { get; set; }//收货人电话
    }

    class OrderService//订单服务，服务类，订单数据保存在其中的一个List中
    {
        public List<OrderDetails> a = new List<OrderDetails>();
        public void Add()//增加
        {
            Console.WriteLine("请按提示输入新订单的信息：");
            OrderDetails b = new OrderDetails();
            Console.WriteLine("订单编号：");
            b.order_id = int.Parse(Console.ReadLine());
            Console.WriteLine("顾客姓名：");
            b.custmer_name = Console.ReadLine();
            Console.WriteLine("商品名称：");
            b.item_name = Console.ReadLine();
            Console.WriteLine("商品单价：");
            b.price = int.Parse(Console.ReadLine());
            Console.WriteLine("商品数量：");
            b.item_num = int.Parse(Console.ReadLine());
            b.total_fee = b.price * b.item_num;
            Console.WriteLine("收货人地址：");
            b.address = Console.ReadLine();
            Console.WriteLine("订单状态：");
            b.state = Console.ReadLine();
            a.Add(b);

        }
        public void Del(int id)//删除特定订单号的订单
        {
            foreach(OrderDetails o in a)
            {
                if(o.order_id==id)
                {
                    a.Remove(o);
                    break;
                }
            }
            
         
        }
        public  void  LookForID( int b)//按订单编号查询
        {
            OrderDetails temp = new OrderDetails();
            foreach(OrderDetails o in a)
            {
                if(o.order_id==b)
                {
                    temp = o;
                    break;
                }
            }
            Console.WriteLine("该订单的编号为{0}，顾客姓名：{1}，商品名称：{2}，商品单价：{3}，商品数量：{4}，总价：{5}", temp.order_id,temp.custmer_name,temp.item_name,temp.item_num,temp.price,temp.total_fee);
            Console.WriteLine("收货人地址为：{0}，订单状态：{1}", temp.address, temp.state);

        }
        public OrderDetails LookForName(string b)//按姓名查询
        {
            OrderDetails temp = new OrderDetails();
            foreach (OrderDetails o in a)
            {
                if (o.custmer_name==b)
                {
                    temp = o;
                    break;
                }
            }
            return temp;
        }
        public OrderDetails LookForITName(string b)//按商品名查询
        {
            OrderDetails temp = new OrderDetails();
            foreach (OrderDetails o in a)
            {
                if (o.item_name == b)
                {
                    temp = o;
                    break;
                }
            }
            return temp;
        }
        public void ChangeOrder(int id)
        {
            OrderDetails o = new OrderDetails();
            foreach (OrderDetails order in a)
            {
                if(order.order_id==id)
                {

                    o = order;
                    break;
                }

            }
            Console.WriteLine("请选择修改的内容：(1 商品数量，2 商品单价，3 订单状态");
            int s = int.Parse(Console.ReadLine());
            switch(s)
            {
                case 1:
                    Console.WriteLine("请输入修改后的数量：");
                    int num1 = int.Parse(Console.ReadLine());
                    o.item_num = num1;
                    o.total_fee = o.price * o.item_num;
                    break;
                case 2:
                    Console.WriteLine("请输入商品单价：");
                    int num2= int.Parse(Console.ReadLine());
                    o.price = num2;
                    o.total_fee = o.price * o.item_num;
                    break;
                case 3:
                    Console.WriteLine("请输入订单状态：");
                    string st=Console.ReadLine();
                    o.state = st;
                    break;

            }

        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            
        

                
        }
    }
}
