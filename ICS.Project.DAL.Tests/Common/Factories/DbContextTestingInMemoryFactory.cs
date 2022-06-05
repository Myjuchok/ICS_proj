using ICS.Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.Tests.Common.Factories;

public class DbContextTestingInMemoryFactory : IDbContextFactory<IcsProjectDbContext>
{
private readonly string _databaseName;
        private readonly bool _seedTestingData;

        public DbContextTestingInMemoryFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }

        public IcsProjectDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<IcsProjectDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
        
            return new ICSProjectTestingDbContext(contextOptionsBuilder.Options, _seedTestingData);
        }
    }