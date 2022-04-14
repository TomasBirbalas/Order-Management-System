using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClientOrder
    {
        public Client Client { get; }
        public List<Order> OrderList { get; }
        public string OrderStatus { get; }

        public ClientOrder(Client client, List<Order> orderList, string orderStatus)
        {
            Client = client;
            OrderList = orderList;
            OrderStatus = orderStatus;
        }
    }
}
