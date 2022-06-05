using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ICS.Project.BL.Facades;
using ICS.Project.BL;
using ICS.Project.DAL;
using ICS.Project.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ICS.Project.BL;

public class BusinessLogic {}

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddSingleton<RideFacade>();
        services.AddSingleton<CarFacade>();
        services.AddSingleton<UserFacade>();


        services.AddAutoMapper((serviceProvider, cfg) =>
        {
            cfg.AddCollectionMappers();

            var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<IcsProjectDbContext>>();
            using var dbContext = dbContextFactory.CreateDbContext();
            cfg.UseEntityFrameworkCoreModel<IcsProjectDbContext>(dbContext.Model);
        }, typeof(BusinessLogic).Assembly);
        return services;
    }
}