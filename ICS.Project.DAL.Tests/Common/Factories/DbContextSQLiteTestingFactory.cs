using ICS.Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.Tests.Common.Factories;

public class DbContextSQLiteTestingFactory : IDbContextFactory<IcsProjectDbContext>
{
    private readonly string _databaseName;
    private readonly bool _seedTestingData;

    public DbContextSQLiteTestingFactory(string databaseName, bool seedTestingData = false)
    {
        _databaseName = databaseName;
        _seedTestingData = seedTestingData;
    }
    public IcsProjectDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<IcsProjectDbContext> builder = new();
        builder.UseSqlite($"Data Source={_databaseName};Cache=Shared");

        return new ICSProjectTestingDbContext(builder.Options, _seedTestingData);
    }
}