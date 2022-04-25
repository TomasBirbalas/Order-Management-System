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

            DataDeserializer deserializeAllData = new DataDeserializer();
            orderList = deserializeAllData.DeserializeDataFile(@"..\..\..\..\DataAccess\JSONdata\ProjectData.json");
        }
        public List<ClientOrder> RetrieveClientOrderList()
        {
            return orderList;
        }
    }
}
