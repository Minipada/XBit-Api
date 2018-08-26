using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBitApi.Models
{
    public class ClaimRoles
    {
        public int Id { get; set; }
        public int RolesId { get; set; }
        public int ClaimsId { get; set; }

        public Claims Claims { get; set; }
        public Roles Roles { get; set; }
    }
}
