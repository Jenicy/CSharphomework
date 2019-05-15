using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class OrderDetail
    {
       

        public string OId { get; set; }
       public Goods goods { get; set; }

        public int quantity { get; set; }
       
        public OrderDetail()
        {
            OId = Guid.NewGuid().ToString();
        }
        public OrderDetail(string id,Goods g,int q)
        {
            OId = id;
            goods = g;
            quantity = q;
       
        }

      
    }
}
