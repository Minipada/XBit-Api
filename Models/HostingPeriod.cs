using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class HostingPeriod
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid MinerId { get; set; }
        public double PricePerMonth { get; set; }

        public Miner Miner { get; set; }
    }
}
