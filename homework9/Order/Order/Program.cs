using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            //orderService.Delete("001");
            Goods apple = new Goods("apple", 3);
            Goods egg = new Goods("egg", 1);
            Goods cake = new Goods("cake", 10);
            Goods milk = new Goods("milk", 5);

            List<OrderDetail> detail1 = new List<OrderDetail>()
            {
                new OrderDetail("1", apple, 10),
                new OrderDetail("1", egg, 2),
                new OrderDetail("1",milk,5)
            };
            List<OrderDetail> detail2 = new List<OrderDetail>()
            {
                new OrderDetail("1", milk, 10),
                new OrderDetail("1", cake, 2),
                new OrderDetail("1",apple,5)

            };

            Order order1 = new Order("1", "ZX", detail1);
            Order order2 = new Order("2", "zxx", detail2);


            orderService.Add(order1);

           
            List<OrderDetail> removed = new List<OrderDetail>();
            List<OrderDetail> newdetail = new List<OrderDetail>();
            removed.Add(new OrderDetail("1", apple, 10));
            newdetail.Add(new OrderDetail("3", milk, 30));
            orderService.Update(order2, removed, newdetail);






            List<Order> orders = orderService.QueryByCustormer("jia2");
            orders.ForEach(
              o => Console.WriteLine($"{o.OId},{o.Customer}"));


        }
    }
}
