using System;

namespace Business
{
    public class Client
    {
        public int Id { get; }
        public string BusinessName { get; }
        public int VatNumber { get; }
        public string BusinessAddress { get; }
        public string ShippingAddress { get; }


        public Client(int id, string businessName, int vatNumber, string businessAddress, string shippingAddress)
        {
            Id = id;
            BusinessName = businessName;
            VatNumber = vatNumber;
            BusinessAddress = businessAddress;
            ShippingAddress = shippingAddress;
        }
    }
}
