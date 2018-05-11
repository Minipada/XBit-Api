using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class MinerAlgorithm
    {
        public Guid Id { get; set; }
        public Guid MinerTypeId { get; set; }
        public double Hashrate { get; set; }
        public Guid AlgorithmId { get; set; }

        public Algorithm Algorithm { get; set; }
        public MinerType MinerType { get; set; }
    }
}
