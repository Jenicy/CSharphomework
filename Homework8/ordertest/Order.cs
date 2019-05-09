using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

  /// <summary>
  /// Order class
  /// </summary>
  [Serializable]
  public class Order :IComparable<Order>{

    private List<OrderDetail> details = new List<OrderDetail>();
    public Order() {
    }
    public Order(int orderId, Customer customer) {
      Id = orderId;
      Customer = customer;
    }

    public int Id { get; set; }

    public Customer Customer { get; set; }

  

    public List<OrderDetail> Details {
      get => this.details;
    }

    /// <summary>
    /// add new orderDetail into the order
    /// </summary>
    /// <param name="orderDetail">the new orderDetail which will be added</param>
    public void AddDetails(OrderDetail orderDetail) {
      if (this.Details.Contains(orderDetail)) {
        throw new Exception($"orderDetail of the goods ({orderDetail.Goods.name}) exists in order {Id}");
      }
      details.Add(orderDetail);
    }

    public int CompareTo(Order other) {
     if(other==null) return 1;
     return Id - other.Id;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             Id == order.Id;
    }

    public override int GetHashCode() {
      return 2108858624 + Id.GetHashCode();
    }





    /// <summary>
    /// remove orderDetail by index num
    /// </summary>
    /// <param name="num">number of the orderDetail to be removed</param>
    public void RemoveDetails(int num) {
      details.RemoveAt(num);
    }

    public override string ToString() {
      String result = $"orderId:{Id}, customer:({Customer})";
      details.ForEach(detail => result += "\n\t" + detail);
      return result;
    }


  }
}
