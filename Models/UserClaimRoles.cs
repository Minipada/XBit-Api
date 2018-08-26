using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBitApi.Models
{
    public class UserClaimRoles
    {
        public int Id { get; set; }
        public Guid UserInformationId { get; set; }
        public int ClaimRolesId { get; set; }

        public ClaimRoles ClaimRoles { get; set; }
        public UserInformation UserInformation { get; set; }

    }
}
