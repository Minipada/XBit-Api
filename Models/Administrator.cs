using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Administrator
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public Guid UserInformationId { get; set; }

        public UserInformation UserInformation { get; set; }
    }
}
