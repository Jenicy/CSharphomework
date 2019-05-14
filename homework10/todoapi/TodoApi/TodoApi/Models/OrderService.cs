using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class OrderService
    {
        private readonly OrderDbContext orderDb;
        public OrderService(OrderDbContext orderDbContext)
        {
            this.orderDb = orderDbContext;
        }
        public void Add(Order order)
        {
            orderDb.Entry(order).State = EntityState.Added;
            orderDb.SaveChanges();
        }
        public void Delete(string orderId)
        {
            var order = orderDb.Orders.Include("Details").SingleOrDefault(o => o.Id == orderId);
            orderDb.OrderDetails.RemoveRange(order.Details);
            orderDb.Orders.Remove(order);
            orderDb.SaveChanges();
        }


        public void Update(Order newOrder)
        {
            Delete(newOrder.Id);
            foreach (OrderDetail detail in newOrder.Details)
            {
                orderDb.Entry(detail).State = EntityState.Added;
            }
            orderDb.Entry(newOrder).State = EntityState.Added;
            orderDb.SaveChanges();
        }

        public Order GetOrder(string Id)
        {
            return orderDb.Orders.Include("Details").
              SingleOrDefault(o => o.Id == Id);
        }

        public List<Order> GetAllOrders()
        {
            return orderDb.Orders.Include("Details").ToList<Order>();
        }

        public List<Order> QueryByCustomer(string customer)
        {
            return orderDb.Orders.Include("Details")
              .Where(o => o.Customer.Equals(customer)).ToList<Order>();
        }

        public List<Order> QueryByGoods(string product)
        {
            var query = orderDb.Orders.Include("Details")
              .Where(o => o.Details.Where(
                item => item.Product.Equals(product)).Count() > 0);
            return query.ToList<Order>();
        }
    }
}
