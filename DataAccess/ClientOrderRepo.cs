using Business;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataAccess
{
    public class ClientOrderRepo
    {
        public List<ClientOrder> DeserializeDataFile()
        {
            var path = @"..\..\..\..\DataAccess\JSONdata\ProjectData.json";
            var jsonString = File.ReadAllText(path);
            List<ClientOrder> clientOrders = JsonSerializer.Deserialize<List<ClientOrder>>(jsonString);

            return clientOrders;
        }
    }
}
