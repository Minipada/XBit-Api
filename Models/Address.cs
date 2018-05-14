using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public string Zip { get; set; }
        public string HouseNr { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
