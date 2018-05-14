using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class LocationAdministrator
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid AdministratorId { get; set; }

        public Administrator Administrator { get; set; }
        public Location Location { get; set; }
    }
}
