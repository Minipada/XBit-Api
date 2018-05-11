using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class MinerType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public IEnumerable<MinerAlgorithm> MinerAlgorithms { get; set; }
        public IEnumerable<Miner> Miners { get; set; }
    }
}
