using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Goods
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Goods()
        {
            Name= Guid.NewGuid().ToString();
        }
        public Goods(string n,int p)
        {
            Name = n;
            Price = p;
        }
        public override bool Equals(object obj)
        {
            var item = obj as Goods;
            return item != null &&
                   Name == item.Name;
        }
    }
}
