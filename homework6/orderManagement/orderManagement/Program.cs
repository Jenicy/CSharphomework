using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace orderManagement
{
    //能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
    //在订单删除、修改失败时，能够产生异常并显示给客户错误信息。

    delegate List<Order> Sort(List<Order> listO);

    class Goods//商品
{
    public string name { get; set; }//商品名称
    public int price { set; get; }//单价
    
        public Goods(string s,int n)
        {
            name = s;
            price = n;
        }
        public override string ToString()
        {
            return $" Name:{name}, Value:{price}";
        }
    }

    class OrderDetails//订单明细，实体类
        {
            private int ID;
            public Goods goods { get; }
            public int num { get; set; }
            public OrderDetails(int id,Goods g,int n)
            {
                ID = id;
                goods = g;
                num = n;
            }
        public override bool Equals(object obj)
        {
            var detail =  obj as OrderDetails;
            return detail != null && detail.goods.name != goods.name && detail.num != num;
        
        }
        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + goods.name.GetHashCode();
            hashCode = hashCode * -1521134295 + num.GetHashCode();
            return hashCode;
           
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{this.ID }:  ";
            result += goods + $", quantity:{num}";
            return result;
        }

    }
    [Serializable]
    class Order:IComparable
    {
        private List<OrderDetails> OrderDetail = new List<OrderDetails>();
        
        public int Order_ID { get;  }
        public string Customer_Name { get; set; }

        public Order(int id,Customer customer)
        {
            
            Order_ID = id;
            Customer_Name = customer.name;
        }
        public List<OrderDetails> Detail
        {
            get
            {
                return OrderDetail;
            }
            set
            {
                    OrderDetail = value;
            }
        }

       

        public void AddDetail(OrderDetails detail)
        {
            OrderDetail.Add(detail);
        }
        public void RemoveDetail(string name)
        {
            OrderDetail.RemoveAll(d => d.goods.name == name);
        }
        public override bool Equals(object obj)//重写equal
        {
            var order = obj as Order;
            return order != null && order.Order_ID != this.Order_ID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            if(!(obj is Order))
            {
                throw new System.ArgumentException();
            }
            Order ord = (Order)obj;
            return this.Order_ID - ord.Order_ID;
        }
       



    }//整个订单

    class OrderService//订单服务，服务类，
    {
        public List<Order> list = new List<Order>();
      
      
        public void AddOrder(Order order)//增加订单
        {
         
            list.Add(order);
                
        }
        public void RemoveOrder(Order order)//删除订单
        {
            list.Remove(order);
        }
        public Order GetbyID(int id)//按订单号查询订单
        {
            var query = from o in list
                        where o.Order_ID == id
                        select o;
            Order temp = (Order)query;
            return temp;
        }
      

        public void ShowAll()
        {
            foreach(Order o in list)
            {
                Console.WriteLine("ID:{0}  Customer_name:{1}  ", o.Order_ID, o.Customer_Name);
                foreach(OrderDetails d in o.Detail)
                {
                    Console.WriteLine("Item_name:{0}  Item_price:{1}  Item_num:{2}", d.goods.name, d.goods.price,d.num);
                       
                }
            }
        }
        public void SortByFee()
        {
          
            List<Order> sort = list.OrderByDescending(o => o.Order_ID).ToList<Order>();

        }
        
        public  void export(XmlSerializer ser,string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create );
            ser.Serialize(fs,list);
            fs.Close();

        }
        public void inport(XmlSerializer ser,string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            ser.Deserialize(fs);
            fs.Close();
        }





    }
    class Customer
    {
        public string name { get; set; }
        public Customer(string s)
        {
            name = s;
        }
    }



        class Program
        {
            static void Main(string[] args)
            {
            try
            {
                Customer customer1 = new Customer("zx");
                Customer customer2 = new Customer("dd");

                Goods chip = new Goods("chip", 3);
                Goods cake = new Goods("cake", 12);
                Goods milk = new Goods("milk", 5);
                Goods apple = new Goods("apple", 2);

                OrderDetails detail1 = new OrderDetails(1, chip, 10);
                OrderDetails detail2 = new OrderDetails(2, cake, 20);
                OrderDetails detail3 = new OrderDetails(1, apple, 5);
                OrderDetails details = new OrderDetails(2, milk, 12);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);

                OrderService service = new OrderService();
                service.SortByFee();



                service.AddOrder(order1);//增加订单
                service.AddOrder(order2);
                Console.WriteLine("增加订单1和2：");
                service.ShowAll();

                service.RemoveOrder(order1);//删除订单1
                Console.WriteLine("删除订单1：");
                service.ShowAll();

                Order temp = service.GetbyID(2);
                Console.WriteLine("查询id为2的订单：");
                foreach (OrderDetails d in temp.Detail)
                {
                    Console.WriteLine("Item_name:{0}  Item_price:{1}  Item_num:{2}", d.goods.name, d.goods.price, d.num);

                }
                string  a;
                a=Console.ReadLine();
               
            }
            catch 
                (Exception e) {
                    Console.WriteLine(e.Message);
                }
            
            }

       













        }
        }
    


