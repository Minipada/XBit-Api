using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Balance
    {
        public Guid Id { get; set; }
        public Guid MiningFarmId { get; set; }
        public Guid CoinId { get; set; }
        public string WalletAddress { get; set; }
        public double TotalFarmedAmount { get; set; }

        public MiningFarm MiningFarm { get; set; }
        public Coin Coin { get; set; }
    }
}
