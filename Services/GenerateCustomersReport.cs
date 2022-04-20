using Business;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenerateCustomersReport
    {
        public ClientOrderRepo clientOrderRepo { get; set; }
        List<ClientOrder> clientOrders { get; set; }

        public string GenerateAllPendingPaymentOrders()
        {
            clientOrderRepo = new ClientOrderRepo();
            clientOrders = clientOrderRepo.RetrieveClientOrderList();

            List<Order> pendingPaymentOrders = new List<Order>();

            string result = "";
            string clientList = "";
            decimal sumOfTotalPendingPayments = 0;

            var listOfTotal = new List<decimal> { };
            foreach (var client in clientOrders)
            {
                clientList = client.Client.BusinessName;

                pendingPaymentOrders = client.OrderList.FindAll(order => order.OrderStatus == "Pending_payment");
                string pendingOrders = "";
                string total = "";
                decimal sumOfCurrentOrder = 0;
                decimal sumOfAllOrders = 0;

                var totalnumbers = new List<decimal> { };
                pendingPaymentOrders.ForEach(order =>
                {
                    var numbers = new List<decimal> { };
                    order.OrderProducts.ForEach(product =>
                    {
                        decimal currentPrice = product.Product.CurrentPrice;
                        int quantity = product.Quantity;
                        decimal total = currentPrice * quantity;
                        numbers.Add(total);
                    });
                    sumOfCurrentOrder = numbers.Sum();

                    totalnumbers.Add(sumOfCurrentOrder);
                    sumOfAllOrders = totalnumbers.Sum();

                    pendingOrders += $"Order: {order.Id}: {sumOfCurrentOrder} Eur\r\n";
                });
                listOfTotal.Add(sumOfAllOrders);
                total += $"Total:{sumOfAllOrders}\r\n";

                result += $"{clientList} \r\n{pendingOrders}{total}";
            }
            sumOfTotalPendingPayments = listOfTotal.Sum();
            result += $"{sumOfTotalPendingPayments}\r\n";
            return result;
        }
    }
}
