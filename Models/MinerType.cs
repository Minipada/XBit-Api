using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class MinerType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Watts { get; set; }
        public Guid ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
