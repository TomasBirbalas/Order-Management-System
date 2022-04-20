using Business;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GenerateCustomersReport
    {
        public ClientOrderRepo clientOrderRepo { get; set; }
        List<ClientOrder> clientOrders { get; set; }

        public void GenerateAllPendingPaymentOrders(string fileName)
        {
            StreamWriter page = new StreamWriter(fileName);

            page.WriteLine("<!DOCTYPE html><html><body style='width:960px; display:block; margin: 0 auto;'>");
            page.WriteLine($"<h1 style='text-align: center;'>Pending Payment Report {DateTime.Now}</h1>");

            clientOrderRepo = new ClientOrderRepo();
            clientOrders = clientOrderRepo.RetrieveClientOrderList();

            List<Order> pendingPaymentOrders = new List<Order>();

            string result = "";
            decimal sumOfTotalPendingPayments = 0;

            var listOfTotal = new List<decimal> {};
            foreach (var client in clientOrders)
            {
                page.WriteLine("<table style='width:960px;'><tbody>");
                pendingPaymentOrders = client.OrderList.FindAll(order => order.OrderStatus == "Pending_payment");

                page.WriteLine($@"
                    <tr>
                        <td style = 'width: 240px;'colspan = '2'>
                            <h2>{client.Client.BusinessName}</h2>
                        </td>
                        <td style = 'width: 240px;'colspan = '2'>
                            <h4>VAT number: {client.Client.VatNumber}</h4>
                            <h4>Company code: {client.Client.BusinessCode}</h4>
                            <h4>Address: {client.Client.BusinessAddress.Street}, {client.Client.BusinessAddress.City}, {client.Client.BusinessAddress.PostalCode}, {client.Client.BusinessAddress.Country}</h4>
                        </td>
                    </tr>
                    <tr>
                        <td style='width:240px;'>Order Id</td>
                        <td style='width:240px;'>Order Date</td>
                        <td style='width:240px;'>Order Total</td>
                        <td style='width:240px;'>1</td>
                    </tr>"
                );

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

                    page.WriteLine($@"
                        <tr>
                            <td style='width:240px;'>{order.Id}</td>
                            <td style='width:240px;'>{order.OrderDate}</td>
                            <td style='width:240px;'>{sumOfCurrentOrder} Eur</td>
                            <td style='width:240px;'></td>
                        </tr>"
                    );

                    totalnumbers.Add(sumOfCurrentOrder);
                    sumOfAllOrders = totalnumbers.Sum();
                });
                listOfTotal.Add(sumOfAllOrders);

                page.WriteLine($@"
                    <tr>
                        <td style='width:240px;'colspan='3'>Count of unpaid orders</td>
                        <td style='width:240px;'>{pendingPaymentOrders.Count}</td>
                    </tr>
                    <tr>
                        <td style='width:240px;' colspan='3'>Total pending payment sum</td>
                        <td style='width:240px;'>{sumOfAllOrders} Eur</td>
                    </tr>"
                );
                string danger = pendingPaymentOrders.Count > 2 || sumOfAllOrders > 2000 ? "Red" : "Green";
                page.WriteLine($@"
                    <tr>
                        <td style='width:240px; Background-color:{danger}' colspan='4'> </td>
                    </tr>"
                );
                page.WriteLine("</tbody></table>");
            }
            sumOfTotalPendingPayments = listOfTotal.Sum();
            result += $"Total unpaid orders sum: {sumOfTotalPendingPayments}\r\n";

            page.WriteLine("</body></html>");
            page.Close();
        }
    }
}
