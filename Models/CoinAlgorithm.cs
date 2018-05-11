using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class CoinAlgorithm
    {
        public Guid Id { get; set; }
        public Guid AlgorithmId { get; set; }
        public Guid CoinId { get; set; }

        public Algorithm Algorithm { get; set; }
        public Coin Coin { get; set; }

        public IEnumerable<Miner> Miners { get; set; }
    }
}
