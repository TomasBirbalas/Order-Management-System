using Business;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataAccess
{
    public class OrderProductRepo
    {
        private List<OrderProduct> OrderProductsList { get; }

        public List<OrderProduct> Retrieve()
        {
            
            return OrderProductsList;
        }
    }
}
