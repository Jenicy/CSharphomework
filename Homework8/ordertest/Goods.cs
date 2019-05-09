using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

 public class Goods {

     public string name { get; set; }//商品名称
     public int Price {
      get { return Price; }
      set {
        if (value < 0)
          throw new ArgumentOutOfRangeException("value must >= 0!");
        Price = value;
      }
    }


    public Goods() { }
    public Goods( string name, float price) {
 
      this.name = name;
      this.Price = Price;
    }

   

    public override bool Equals(object obj) {
      var goods = obj as Goods;
      return goods != null &&
             name == goods.name;
    }

    public override int GetHashCode() {
      return 2108858624 + name.GetHashCode();
    }

    public override string ToString() {
      return $"Name:{name}, Value:{Price}";
    }
  }
}
