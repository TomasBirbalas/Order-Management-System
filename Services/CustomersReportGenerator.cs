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
    public class CustomersReportGenerator
    {
        public ClientOrderRepo clientOrderRepo { get; set; }
        List<ClientOrder> clientOrders { get; set; }

        public void GenerateAllOrdersOfCustomerReport(string fileName)
        {
            StreamWriter page = new StreamWriter(fileName);
            // Create html-document
            page.WriteLine("<!DOCTYPE html><html><head><style>body{font-family:sans-serif;margin:0;padding:0}h1{text-align:center}h2,h3,h4,p{margin:0;line-height:1.5}p{font-size:14px}.container{display:block;width:1240px;margin:0 auto}.client-row{display:flex;margin:16px 0;border:1px solid #bdbdbd}.client-detail-block{display:flex;flex-direction:column;padding:32px;justify-content:center}.orders-block{flex:1}.order{display:flex;flex:1;background-color:#f6f6f6;margin-bottom:8px}.order:last-child{margin-bottom:0}.order div{flex:1;padding:16px 16px}.order div:last-child{flex:1;max-width:20px;padding:0}.Completed{background-color:green}.Pending_payment{background-color:red}.total-order-details{display:flex}.total-order-details div{flex:1}.clients{display:flex}.clients div{flex:1;margin:0 32px;border-bottom:10px solid green}.clients div:first-child{margin-left:0}.clients div:last-child{margin-right:0}.best-clients .client-detail-block{text-align:center;background-color:#f6f6f6}</style></head><body>");
            page.WriteLine("<div class='container'>");
            page.WriteLine($"<h1 style='text-align: center;'>All clients report {DateTime.Now}</h1>");

            clientOrderRepo = new ClientOrderRepo();
            clientOrders = clientOrderRepo.RetrieveClientOrderList();

            List<Order> allOrdersOfClient = new List<Order>();

            var listOfTotal = new List<decimal> { };
            foreach (var client in clientOrders)
            {
                List<Order> pendingPaymentOrders = new List<Order>();
                List<Order> completedOrders = new List<Order>();

                page.WriteLine("<div class='client-row'>");
                page.WriteLine("<div class='client-detail-block'>");

                allOrdersOfClient = client.OrderList;

                page.WriteLine(@$"
                    <h2>{client.Client.BusinessName}</h2>
                    <span>Vat number: {client.Client.VatNumber}</span>
                    <span>Company code: {client.Client.BusinessCode}</span>
                    <span>Business Address:</span>
                    <span>{client.Client.BusinessAddress.Street}</span>
                    <span>{client.Client.BusinessAddress.City}</span>
                    <span>{client.Client.BusinessAddress.PostalCode}</span>
                    <span>{client.Client.BusinessAddress.Country}</span>
                </div>
                <div class='orders-block'>
                    <div class='order-list'>"
                );

                allOrdersOfClient.ForEach(order =>
                {
                    var numbers = new List<decimal> { };
                    if(order.OrderStatus == "Completed")
                    {
                        completedOrders.Add(order);
                    }else
                    {
                        pendingPaymentOrders.Add(order);
                    }

                    page.WriteLine($@"
                    <div class='order'>
                        <div>
                            <h4>Order Id</h4>
                            <p>{order.Id}</p>
                        </div>
                        <div>
                            <h4>Order date</h4>
                            <p>{order.OrderDate}</p>
                        </div>
                        <div>
                            <h4>Order Total</h4>
                            <p>{order.OrderTotalAmount} Eur</p>
                        </div>
                        <div>
                            <h4>Order Status</h4>
                            <p>{order.OrderStatus}</p>
                        </div>
                        <div class='{order.OrderStatus}'>
                        </div>
                    </div>
                    ");
                });

                decimal completedOrdersTotalAmount = completedOrders.Sum(order => order.OrderTotalAmount);
                decimal pendingPaymentOrdersTotalAmount = pendingPaymentOrders.Sum(order => order.OrderTotalAmount);

                page.WriteLine("</div>");
                page.WriteLine("<div class='total-order-details'>");
                    page.WriteLine("<div class='pending-orders'>");
                        page.WriteLine("<h4>Completed orders amount</h4>");
                        page.WriteLine($"<h3>{completedOrdersTotalAmount} Eur</h3>");
                    page.WriteLine("</div>");
                    page.WriteLine("<div class='pending-orders'>");
                        page.WriteLine("<h4>Total pending orders amount</h4>");
                        page.WriteLine($"<h3>{pendingPaymentOrdersTotalAmount} Eur</h3>");
                    page.WriteLine("</div>");
                page.WriteLine("</div>");
                page.WriteLine("</div>");
                page.WriteLine("</div>");

            }
            List<ClientOrder> sortedClients = clientOrders.OrderBy(listOfClientsOrder => listOfClientsOrder.OrderList.Where(order => order.OrderStatus == "Completed").Sum(order => order.OrderTotalAmount)).ToList();

            page.WriteLine("<div class='best-clients'><h1>Best Clients</h1><div class='clients'>");


            for (int i = sortedClients.Count -1 ; i > sortedClients.Count - 4; i--)
            {
                page.WriteLine($@"
                <div class='client-detail-block'>
                    <h2>{sortedClients[i].Client.BusinessName}</h2>
                    <span>Vat number: {sortedClients[i].Client.VatNumber}</span>
                    <span>Company code: {sortedClients[i].Client.BusinessCode}</span>
                    <span>Address: {sortedClients[i].Client.BusinessAddress.Street}, {sortedClients[i].Client.BusinessAddress.City}, {sortedClients[i].Client.BusinessAddress.PostalCode}, {sortedClients[i].Client.BusinessAddress.Country}</span>
                </div>
                ");
            }
            page.WriteLine("</div></div>");
            page.WriteLine("</div></body></html>");
            page.Close();
        }
    }
}
