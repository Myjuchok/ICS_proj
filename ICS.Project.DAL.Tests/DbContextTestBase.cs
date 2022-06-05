using System;
using System.Threading.Tasks;
using ICS.Project.DAL.Tests.Common;
using ICS.Project.DAL.Tests.Common.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;


namespace ICS.Project.DAL.Tests;

public class DbContextTestBase : IAsyncLifetime
{
    protected DbContextTestBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        dbContextFactory = new DbContextSQLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        
        IcsProjectDbContextSUT = dbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<IcsProjectDbContext> dbContextFactory { get; }
    protected IcsProjectDbContext IcsProjectDbContextSUT { get; }

    public async Task InitializeAsync()
    {
        await IcsProjectDbContextSUT.Database.EnsureDeletedAsync();
        await IcsProjectDbContextSUT.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await IcsProjectDbContextSUT.Database.EnsureDeletedAsync();
        await IcsProjectDbContextSUT.DisposeAsync();
    }
}
