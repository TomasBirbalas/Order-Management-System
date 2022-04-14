using System;

namespace Business
{
    public class Client
    {
        public int Id { get; }
        public string BusinessName { get; }
        public int BusinessCode { get; }
        public string VatNumber { get; }
        public string BusinessAddress { get; }
        public string ShippingAddress { get; }


        public Client(int id, string businessName,int businessCode, string vatNumber, string businessAddress, string shippingAddress)
        {
            Id = id;
            BusinessName = businessName;
            BusinessCode = businessCode;
            VatNumber = vatNumber;
            BusinessAddress = businessAddress;
            ShippingAddress = shippingAddress;
        }
    }
}
