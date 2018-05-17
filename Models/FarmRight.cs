using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class FarmRight
    {
        public Guid Id { get; set; }
        public bool CanSwitchCoins { get; set; }
        public bool CanBuyMiningPackages { get; set; }
        public bool CanWithdrawCoins { get; set; }
        public bool HasReadRights { get; set; }
    }
}
