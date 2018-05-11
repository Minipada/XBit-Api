using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Miner
    {
        public Guid Id { get; set; }
        public Guid MinerTypeId { get; set; }
        public Guid CoinAlgorithmId { get; set; }
        public Guid MiningFarmId { get; set; }
        public Guid ShelfId { get; set; }

        public MinerType MinerType { get; set; }
        public CoinAlgorithm CoinAlgorithm { get; set; }
        public MiningFarm MiningFarm { get; set; }
        public Shelf Shelf { get; set; }

        public IEnumerable<HostingPeriod> HostingPeriods { get; set; }
    }
}
