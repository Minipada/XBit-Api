using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }

        public IEnumerable<Administrator> Administrators { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
