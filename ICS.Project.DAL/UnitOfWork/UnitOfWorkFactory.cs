using System;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<IcsProjectDbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<IcsProjectDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public IUnitOfWork Create() => new UnitOfWork(_dbContextFactory.CreateDbContext());
}