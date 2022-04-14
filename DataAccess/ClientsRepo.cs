using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientsRepo
    {


        public static async Client Retrieve()
        {
            string fileName = @"D:\Programavimo kursai\NET\Order-Management-System\Order Management System\DataAccess\JSONdata\Client.json";
            using FileStream openStream = File.OpenRead(fileName);
            Client ClientList = await JsonSerializer.DeserializeAsync<Client>(openStream);

        }
    }
}
