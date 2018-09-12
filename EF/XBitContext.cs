using Microsoft.EntityFrameworkCore;
using XBitApi.Models;

namespace XBitApi.EF
{
    public class XBitContext : DbContext
    {
        public XBitContext(DbContextOptions<XBitContext> context) : base(context) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql_server;Database=master;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<MinerType> MinerTypes { get; set; }
        public DbSet<MinerAlgorithm> MinerAlgorithms { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<CoinAlgorithm> CoinAlgorithms { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Miner> Miners { get; set; }
        public DbSet<HostingPeriod> HostingPeriods { get; set; }
        public DbSet<MiningFarm> MiningFarms { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<LocationAdministrator> LocationAdministrators { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FarmMember> FarmMembers { get; set; }
        public DbSet<FarmRight> FarmRights { get; set; }
    }
}
