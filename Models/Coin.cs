using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Coin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PriceUrl { get; set; }
        public string Website { get; set; }

        public IEnumerable<CoinAlgorithm> CoinAlgorithms { get; set; }
        public IEnumerable<Balance> Balances { get; set; }
    }
}
