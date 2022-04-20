using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Deserializer
{
    public class DeserializeAllData
    {
        public List<ClientOrder> DeserializeDataFile()
        {
            var path = @"..\..\..\..\DataAccess\JSONdata\ProjectData.json";
            var jsonString = File.ReadAllText(path);
            List<ClientOrder> jsonData = JsonSerializer.Deserialize<List<ClientOrder>>(jsonString);

            return jsonData;
        }

    }
}
