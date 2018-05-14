using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class FarmMember
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MiningFarmId { get; set; }
        public Guid FarmRightId { get; set; }

        public Customer Customer { get; set; }
        public MiningFarm MiningFarm { get; set; }
        public FarmRight FarmRight { get; set; }
    }
}
