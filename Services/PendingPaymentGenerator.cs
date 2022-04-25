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
    public class PendingPaymentGenerator
    {
        public ClientOrderRepo clientOrderRepo { get; set; }
        List<ClientOrder> clientOrders { get; set; }

        public void GenerateAllPendingPaymentOrders(string fileName)
        {
            StreamWriter page = new StreamWriter(fileName);

            page.WriteLine("<!DOCTYPE html><html><head><style>body{font-family:sans-serif}h2,h3,h4,p{margin:0}table{border-spacing:0}td,th{border:1px solid #c9c9c9;padding:8px}.client-block td{padding:16px}.order-list-heading th{text-align:left}.order-list{background-color:#f8f8f8}.order-list:nth-child(odd){background-color:#f1f1f1}.totalAmount{display:flex;justify-content:space-between;align-items:center;margin:16px 0;}</style></head><body style='width:960px; display:block; margin: 0 auto;'>");
            page.WriteLine($"<h1 style='text-align: center;'>Pending Payment Report {DateTime.Now}</h1>");

            clientOrderRepo = new ClientOrderRepo();
            clientOrders = clientOrderRepo.RetrieveClientOrderList();

            List<Order> pendingPaymentOrders = new List<Order>();

            decimal sumOfTotalPendingPayments = 0;

            var listOfTotal = new List<decimal> {};
            foreach (var client in clientOrders)
            {
                pendingPaymentOrders = client.OrderList.FindAll(order => order.OrderStatus == "Pending_payment");
                if (pendingPaymentOrders.Count > 0)
                {
                    page.WriteLine("<table style = 'width:960px;'><tbody>");
                    page.WriteLine($@"
                    <tr class = 'client-block'>
                        <td style = 'width: 33.33%;'>
                            <h2>{client.Client.BusinessName}</h2>
                        </td>
                        <td style = 'width: 66.33%;' colspan = '2'>
                            <h4>VAT number: {client.Client.VatNumber}</h4>
                            <h4>Company code: {client.Client.BusinessCode}</h4>
                            <h4>Address: {client.Client.BusinessAddress.Street}, {client.Client.BusinessAddress.City}, {client.Client.BusinessAddress.PostalCode}, {client.Client.BusinessAddress.Country}</h4>
                        </td>
                    </tr>
                    <tr class='order-list-heading'>
                        <th style = 'width: 33.33%;'>Order Id</th>
                        <th style = 'width: 33.33%;'>Order Date</th>
                        <th style = 'width: 33.33%;'>Order Total</th>
                    </tr>"
                    );

                    decimal sumOfAllOrders = pendingPaymentOrders.Sum(order => order.OrderTotalAmount); ;

                    pendingPaymentOrders.ForEach(order =>
                    {
                        page.WriteLine($@"
                            <tr class = 'order-list'>
                                <td>{order.Id}</td>
                                <td>{order.OrderDate}</td>
                                <td>{order.OrderTotalAmount} Eur</td>
                            </tr>"
                        );
                    });
                    listOfTotal.Add(sumOfAllOrders);

                    page.WriteLine($@"
                        <tr>
                            <td colspan = '2'>Count of unpaid orders</td>
                            <td>{pendingPaymentOrders.Count}</td>
                        </tr>
                        <tr>
                            <td colspan = '2'>Total pending payment amount</td>
                            <td>{sumOfAllOrders} Eur</td>
                        </tr>"
                    );
                    string customerStatus = pendingPaymentOrders.Count > 2 || sumOfAllOrders > 2000 ? "Red" : "Green";
                    page.WriteLine($@"
                        <tr>
                            <td style = 'Background-color:{customerStatus}; border:none' colspan = '3'> </td>
                        </tr>"
                    );
                    page.WriteLine("</tbody></table>");
                }
            }
            

            sumOfTotalPendingPayments = listOfTotal.Sum();
            page.WriteLine($@"<div class = 'totalAmount'>
                        <h3>Count of unpaid orders total amount</h3>
                        <h2>{sumOfTotalPendingPayments}</h2>
                        </div>"
            );

            page.WriteLine("</body></html>");
            page.Close();
        }
    }
}
