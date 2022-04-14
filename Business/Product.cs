using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Product
    {
        public string Name { get; }
        public decimal CurrentPrice { get; }
        public Product(string name, decimal currentPrice)
        {
            Name = name;
            CurrentPrice = currentPrice;
        }
    }
}
