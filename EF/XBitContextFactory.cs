using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace XBitApi.EF
{
    public class XBitContextFactory : IDesignTimeDbContextFactory<XBitContext>
    {
        public XBitContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<XBitContext>();
            return new XBitContext(optionsBuilder.Options);
        }
    }
}
