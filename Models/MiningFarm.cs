using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class MiningFarm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Miner> Miners { get; set; }
        public IEnumerable<Balance> Balances { get; set; }
    }
}
