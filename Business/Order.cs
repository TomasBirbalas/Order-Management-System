using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public string OrderStatus { get; set; }
        public Order(int id, DateTime orderDate, List<OrderProduct> orderProducts, string orderStatus)
        {
            Id = id;
            OrderDate = orderDate;
            OrderProducts = orderProducts;
            OrderStatus = orderStatus;
        }
    }
}
