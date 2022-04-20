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
    public class GenerateAllCustomersReport
    {
        public ClientOrderRepo clientOrderRepo { get; set; }
        List<ClientOrder> clientOrders { get; set; }

        public void GenerateAllCustomers(string fileName)
        {
            StreamWriter page = new StreamWriter(fileName);
            // Create html-document
            page.WriteLine("<!DOCTYPE html><html><head><style>body{font-family:sans-serif;margin:0;padding:0}h1{text-align:center}h2,h3,h4,p{margin:0;line-height:1.5}.container{display:block;width:960px;margin:0 auto}.client-row{display:flex;border:1px solid #bdbdbd}.client-detail-block{display:flex;flex-direction:column;padding:32px;justify-content:center}.orders-block{flex:1}.order{display:flex;flex:1;background-color:#f6f6f6;margin-bottom:8px}.order:last-child{margin-bottom:0}.order div{flex:1;padding:16px 16px}.order div:last-child{flex:1;max-width:20px;background-color:red;padding:0}.total-order-details{display:flex}.total-order-details div{flex:1}.clients{display:flex}.clients div{flex:1;margin:0 32px;border-bottom:10px solid green}.clients div:first-child{margin-left:0}.clients div:last-child{margin-right:0}.best-clients .client-detail-block{text-align:center;background-color:#f6f6f6}</style></head><body>");
            page.WriteLine("<div class='container'>");
            page.WriteLine($"<h1 style='text-align: center;'>All clients report {DateTime.Now}</h1>");

            clientOrderRepo = new ClientOrderRepo();
            clientOrders = clientOrderRepo.RetrieveClientOrderList();

            List<Order> allOrdersOfClient = new List<Order>();
            List<Order> pendingPaymentOrders = new List<Order>();
            List<Order> completedOrders = new List<Order>();

            string result = "";
            decimal sumOfTotalPendingPayments = 0;

            var listOfTotal = new List<decimal> { };
            foreach (var client in clientOrders)
            {
                page.WriteLine("<div class='client-row'>");
                page.WriteLine("<div class='client-detail-block'>");

                allOrdersOfClient = client.OrderList;
                pendingPaymentOrders = client.OrderList.FindAll(order => order.OrderStatus == "Pending_payment");
                completedOrders = client.OrderList.FindAll(order => order.OrderStatus == "Completed");

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

                decimal sumOfCurrentOrder = 0;
                decimal sumOfAllOrders = 0;

                var totalnumbers = new List<decimal> { };

                allOrdersOfClient.ForEach(order =>
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
                            <p>{sumOfCurrentOrder} Eur</p>
                        </div>
                        <div class='status'>
                        </div>
                    </div>
                    ");

                    totalnumbers.Add(sumOfCurrentOrder);
                    sumOfAllOrders = totalnumbers.Sum();
                });
                page.WriteLine("</div>");
                page.WriteLine("<div class='total-order-details'>");
                    page.WriteLine("<div class='pending-orders'>");
                        page.WriteLine("<h4>Total pending Orders Sum</h4>");
                        page.WriteLine("<h3>2500.00 Eur</h3>");
                    page.WriteLine("</div>");
                    page.WriteLine("<div class='pending-orders'>");
                        page.WriteLine("<h4>Total pending Orders Sum</h4>");
                        page.WriteLine("<h3>2500.00 Eur</h3>");
                    page.WriteLine("</div>");
                page.WriteLine("</div>");
                page.WriteLine("</div>");
                page.WriteLine("</div>");

                listOfTotal.Add(sumOfAllOrders);

                string danger = pendingPaymentOrders.Count > 2 || sumOfAllOrders > 2000 ? "Red" : "Green";

            }


            page.WriteLine("<div class='best-clients'>");
            page.WriteLine("<h1>Best Clients</h1>");
            page.WriteLine("<div class='clients'>");
            page.WriteLine("<div class='client-detail-block'>");
            page.WriteLine("<h2>UAB tralialia</h2>");
            page.WriteLine("<span>Vat number: 0000</span>");
            page.WriteLine("<span>Company code: 0000</span>");
            page.WriteLine("<span>Address: 0000</span>");
            page.WriteLine("</div>");
            page.WriteLine("<div class='client-detail-block'>");
            page.WriteLine("<h2>UAB tralialia</h2>");
            page.WriteLine("<span>Vat number: 0000</span>");
            page.WriteLine("<span>Company code: 0000</span>");
            page.WriteLine("<span>Address: 0000</span>");
            page.WriteLine("</div>");
            page.WriteLine("</div>");
            page.WriteLine("</div>");
            sumOfTotalPendingPayments = listOfTotal.Sum();

            page.WriteLine("</div></body></html>");
            page.Close();
        }
    }
}
