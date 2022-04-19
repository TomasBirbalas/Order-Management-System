using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClientOrder
    {
        public Client Client { get; set; }
        public List<Order> OrderList { get; set; }

        public ClientOrder(Client client, List<Order> orderList)
        {
            Client = client;
            OrderList = orderList;
        }
    }
}
