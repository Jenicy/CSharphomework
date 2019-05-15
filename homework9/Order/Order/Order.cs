using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Order
    {
        public string OId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetail> detail { get; set; }
        public Order()
        {
            detail = new List<OrderDetail>();
        }
        public Order(string id,string cus,List<OrderDetail> d)
        {
            OId = id;
            Customer = cus;
            detail = d;
        }


        
    }
}
