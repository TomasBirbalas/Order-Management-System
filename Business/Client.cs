using System;

namespace Business
{
    public class Client
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public int BusinessCode { get; set; }
        public string VatNumber { get; set; }
        public Address BusinessAddress { get; set; }
        public Address ShippingAddress { get; set; }


        public Client(int id, string businessName,int businessCode, string vatNumber, Address businessAddress, Address shippingAddress)
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
