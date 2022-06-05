using ICS.Project.DAL.Tests.Common.Seeds;
using ICS.Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.Tests.Common
{
    public class ICSProjectTestingDbContext : IcsProjectDbContext
    {
        private readonly bool _seedTestingData;

        public ICSProjectTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
            : base(contextOptions, seedData: false)
        {
            _seedTestingData = seedTestingData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_seedTestingData)
            {
                CarSeeds.Seed(modelBuilder);
                RideSeeds.Seed(modelBuilder);
                UserSeeds.Seed(modelBuilder);
            }
        }
    }
}