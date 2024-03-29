﻿using Business;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JsonSerializeris
{
    public class DataSerializer
    {
        public void GenerateJsonFile()
        {
            Random random = new Random();
            RandomDateTime date = new RandomDateTime();

            List<Address> addressesList = new List<Address>();
            for (int i = 0; i < 10; i++)
            {
                addressesList.Add(new Address($"Gatve-{i}", "Kaunas", 90000, "Lietuva"));
            }

            List<ClientOrder> clientsOrders = new List<ClientOrder>();
            List<Client> client = new List<Client>();
            for (int i = 0; i < 5; i++)
            {
                client.Add(new Client(i, $"UAB Company-{i}", 800000000 + i, $"LT{100000000000 + i}", addressesList[random.Next(0, 10)], addressesList[random.Next(0, 10)]));

                List<Order> ordersList = new List<Order>();
                for (int j = 0; j < random.Next(1, 15); j++)
                {
                    int status = new Random().Next(0, 2);
                    string orderStatus = status == 1 ? "Completed" : "Pending_payment";

                    List<OrderProduct> productsInOrder = GenerateProductList();

                    List<decimal> totalAmount = new List<decimal>();
                    productsInOrder.ForEach(product =>
                    {
                        decimal currentPrice = product.Product.CurrentPrice;
                        int quantity = product.Quantity;
                        decimal total = currentPrice * quantity;
                        totalAmount.Add(total);
                    });

                    ordersList.Add(new Order(Convert.ToInt32($"20220{i}000") + j, date.Next(), productsInOrder, totalAmount.Sum(), orderStatus));
                }
                clientsOrders.Add(new ClientOrder(client[i], ordersList));
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(clientsOrders, options);
            var jsonPath = @"..\..\..\..\DataAccess\JSONdata\ProjectData.json";

            if (!Directory.Exists(Path.GetDirectoryName(jsonPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));
            }

            File.WriteAllText(jsonPath, jsonString);
        }
        public List<OrderProduct> GenerateProductList()
        {
            Random random = new Random();

            List<Product> productList = new List<Product>();
            for (int i = 1; i < 15; i++)
            {
                decimal price = random.Next(0, 50) + (decimal)random.NextDouble();
                price = decimal.Round(price, 2, MidpointRounding.AwayFromZero);

                productList.Add(new Product(100000 + i, $"Preke-{i}", price));
            }
            
            List<OrderProduct> productsInOrder = new List<OrderProduct>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                bool isProductInOrder = false;
                Product randomProduct = productList[random.Next(0, 14)];

                isProductInOrder = productsInOrder.Any(x => x.Product.Id == randomProduct.Id);

                if (!isProductInOrder)
                {
                    productsInOrder.Add(new OrderProduct(randomProduct, random.Next(1, 20)));
                }
            }
            return productsInOrder;
        }
    }
}
