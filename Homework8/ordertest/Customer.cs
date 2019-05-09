using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

  public class Customer
    {
    public string Name { get; set; }
    public Customer() { }
    public Customer(string name) {
      this.Name = name;
    }

    public override string ToString() {
      return $" CustomerName:{Name}";
    }

    public override bool Equals(object obj) {
      var customer = obj as Customer;
      return customer != null &&
             Name == customer.Name;
    }

    public override int GetHashCode() {
      return 2108858624 + Name.GetHashCode();
    }
  }
}
