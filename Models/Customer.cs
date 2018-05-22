using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid UserInformationId { get; set; }
        public Guid AddressId { get; set; }
        public string FarmMail { get; set; }
        public string Password { get; set; }

        public UserInformation UserInformation { get; set; }
        public Address Address { get; set; }
    }
}
