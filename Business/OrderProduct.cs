using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
