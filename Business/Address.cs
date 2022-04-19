﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public Address(string street, string city, int postalCode, string country)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
