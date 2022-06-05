using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.Factories
{
    public class ServerDbContextFactory : IDbContextFactory<IcsProjectDbContext>
    {
        private readonly string _connectionString;
        private readonly bool _seedData;

        public ServerDbContextFactory(string connectionString, bool seedData = false)
        {
            _connectionString = connectionString;
            _seedData = seedData;
        }

        public IcsProjectDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<IcsProjectDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new IcsProjectDbContext(optionsBuilder.Options, _seedData);
        }
    }
}
