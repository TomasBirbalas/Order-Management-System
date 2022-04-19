﻿using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonSerializeris
{
    public class SerializeData
    {
        public void GenerateJsonFile()
        {
            Random random = new Random();
            RandomDateTime date = new RandomDateTime();


            List<Product> productList = new List<Product>();
            for (int i = 0; i < 15; i++)
            {
                decimal price = random.Next(0, 50) + (decimal)random.NextDouble();
                price = decimal.Round(price, 2, MidpointRounding.AwayFromZero);

                productList.Add(new Product(100000 + i, $"Preke-{i}", price));
            }


            List<OrderProduct> productsInOrder = new List<OrderProduct>();
            for (int i = 0; i < random.Next(1, 15); i++)
            {
                productsInOrder.Add(new OrderProduct(productList[random.Next(0,15)], random.Next(1,20)));
            }

            List<Address> addressesList = new List<Address>();
            for (int i = 0; i < 10; i++)
            {
                addressesList.Add(new Address($"Gatve-{i}", "Kaunas", 90000, "Lietuva"));
            }

            List<ClientOrder> clientsOrders = new List<ClientOrder>();
            List<Client> client = new List<Client>();
            for (int i = 0; i < 4; i++)
            {
                client.Add(new Client(i, " ", 800000000 + i, $"LT{100000000000 + i}", addressesList[random.Next(0, 10)], addressesList[random.Next(0, 10)]));

                List<Order> ordersList = new List<Order>();
                for (int j = 0; j < 15; j++)
                {
                    int status = new Random().Next(0, 1);
                    string orderStatus = status == 1 ? "Completed" : "Pending_payment";

                    ordersList.Add(new Order(Convert.ToInt32($"20220{i}000") + j, date.Next(), productsInOrder, orderStatus));
                }
                clientsOrders.Add(new ClientOrder(client[i], ordersList));
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(clientsOrders, options);
            var jsonPath = @"..\..\..\..\DataFiles\test.json";

            File.WriteAllText(jsonPath, jsonString);
        }
    }
    class RandomDateTime
    {
        DateTime start;
        Random gen;
        int range;

        public RandomDateTime()
        {
            start = new DateTime(2022, 1, 1);
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}