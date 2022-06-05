using ICS.Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.Tests.Common.Factories;

public class DbContextLocalDBTestingFactory : IDbContextFactory<IcsProjectDbContext>
{
    private readonly string _databaseName;
    private readonly bool _seedTestingData;

    public DbContextLocalDBTestingFactory(string databaseName, bool seedTestingData = false)
    {
        _databaseName = databaseName;
        _seedTestingData = seedTestingData;
    }
    public IcsProjectDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<IcsProjectDbContext> builder = new();
        builder.UseSqlServer($"Data Source={_databaseName};MultipleActiveResultSets = True;Integrated Security = True; ");
        
        return new ICSProjectTestingDbContext(builder.Options, _seedTestingData);
    }
}