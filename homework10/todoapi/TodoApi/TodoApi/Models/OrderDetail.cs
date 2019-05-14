using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public string Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }
        public OrderDetail(string id, string product, double unitPrice, int quantity)
        {
            Id = id;
            Product = product;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null &&
                   Id == item.Id;
        }
    }
}
