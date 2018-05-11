using System;
using System.Collections.Generic;

namespace XBitApi.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Shelf> Shelves { get; set; }
    }
}
