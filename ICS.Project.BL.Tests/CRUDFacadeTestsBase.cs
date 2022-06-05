﻿using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ICS.Project.DAL.Tests.Common;
using ICS.Project.DAL.Tests.Common.Factories;
using ICS.Project.DAL;
using ICS.Project.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.Project.BL.Tests;

public class CRUDFacadeTestsBase : IAsyncLifetime
{
    protected CRUDFacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSQLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);

        var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[]
                {
                    typeof(BusinessLogic),
                });
                cfg.AddCollectionMappers();

                using var dbContext = DbContextFactory.CreateDbContext();
                cfg.UseEntityFrameworkCoreModel<IcsProjectDbContext>(dbContext.Model);
            }
        );
        Mapper = new Mapper(configuration);
        Mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    protected IDbContextFactory<IcsProjectDbContext> DbContextFactory { get; }

    protected Mapper Mapper { get; }

    protected UnitOfWorkFactory UnitOfWorkFactory { get; }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}