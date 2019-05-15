using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;


namespace ADO
{
    class OrderService
    {
        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public void Delete(String orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("OrderDetail").SingleOrDefault(o => o.OId == orderId);
                db.OrderItem.RemoveRange(order.detail);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }
        public void Update(Order order, List<OrderDetail> removed, List<OrderDetail> newdetail)
        {
            using (var db = new OrderDB())
            {
                order.detail.AddRange(newdetail);
                foreach (OrderDetail d in order.detail)
                {
                    if (removed.Contains(d))
                    {
                        db.Entry(d).State = EntityState.Deleted;
                    }
                    else if (newdetail.Contains(d))
                    {
                        db.Entry(d).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(d).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Order GetOrder(String Id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Detail").
                  SingleOrDefault(o => o.OId == Id);
            }
        }
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("detail").ToList<Order>();
            }
        }
        public List<Order> QueryByCustormer(String custormer)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("detail")
                  .Where(o => o.Customer.Equals(custormer)).ToList<Order>();
            }
        }
        public List<Order> QueryByGoods(String product)
        {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("detail")
                  .Where(o => o.detail.Where(
                    item => item.goods.Equals(product)).Count() > 0);
                return query.ToList<Order>();
            }
        }
    }
}
