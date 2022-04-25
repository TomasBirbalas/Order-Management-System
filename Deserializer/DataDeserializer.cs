using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Deserializer
{
    public class DataDeserializer
    {
        public List<ClientOrder> DeserializeDataFile(string filepath)
        {
            var jsonString = File.ReadAllText(filepath);
            List<ClientOrder> jsonData = JsonSerializer.Deserialize<List<ClientOrder>>(jsonString);

            return jsonData;
        }

    }
}
