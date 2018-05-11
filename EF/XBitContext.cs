using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XBitApi.EF
{
    public class XBitContext : DbContext
    {
        public XBitContext(DbContextOptions<XBitContext> context) : base(context) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=XBit;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
