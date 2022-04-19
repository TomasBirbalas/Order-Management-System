using DataAccess;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Services
{
    public class AllOrdersOfClient
    {
        public string Generate()
        {
            ClientOrderRepo clientOrderRepo = new ClientOrderRepo();
            var data = clientOrderRepo.DeserializeDataFile();
            string result = "";
            string clientList = "";
            foreach (var client in data)
            {
                client.OrderList.ForEach(order => {
                    int id = order.Id;
                    string status = order.OrderStatus;

                    result += $"Uzsakymo id: {id}, statusas: {status} \r\n";
                });
                clientList += $"{client.Client.BusinessName} \r\n";
            }
            return clientList;
        }
    }
}
