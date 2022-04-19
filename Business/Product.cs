using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Product
    {
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public Product(string name, decimal currentPrice)
        {
            Name = name;
            CurrentPrice = currentPrice;
        }
    }
}
