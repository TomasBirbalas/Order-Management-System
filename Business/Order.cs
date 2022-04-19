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
        public DateTime PaidTill { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public string OrderStatus { get; set; }
        public Order(int id, DateTime orderDate, DateTime paidTill, List<OrderProduct> orderProducts, string orderStatus)
        {
            Id = id;
            OrderDate = orderDate;
            PaidTill = paidTill;
            OrderProducts = orderProducts;
            OrderStatus = orderStatus;
        }
    }
}
