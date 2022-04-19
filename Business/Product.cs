using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public Product(int id, string name, decimal currentPrice)
        {
            Id = id;
            Name = name;
            CurrentPrice = currentPrice;
        }
    }
}
