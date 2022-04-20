using Business;
using Deserializer;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class ClientOrderRepo
    {
        private List<ClientOrder> orderList { get; }

        public ClientOrderRepo()
        {
            DeserializeAllData deserializeAllData = new DeserializeAllData();
            orderList = deserializeAllData.DeserializeDataFile();
        }
        public List<ClientOrder> RetrieveClientOrderList()
        {
            return orderList;
        }
    }
}
