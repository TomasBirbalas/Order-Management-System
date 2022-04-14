using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Order
    {
        public int Id { get; }
        public DateTime OrderDate { get; }
        public DateTime PaidTill { get; }
        public List<OrderProduct> OrderProducts { get; }
        public Order(int id, DateTime orderDate, DateTime paidTill, List<OrderProduct> orderProducts)
        {
            Id = id;
            OrderDate = orderDate;
            PaidTill = paidTill;
            OrderProducts = orderProducts;
        }
    }
}
