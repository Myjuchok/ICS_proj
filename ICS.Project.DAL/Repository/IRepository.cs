using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ICS.Project.DAL.Entities.Base;

namespace ICS.Project.DAL.Repository;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
	IQueryable<TEntity> Get();
    void Delete(Guid entityId);
    Task<TEntity> InsertOrUpdateAsync<TModel>(
        TModel model,
        IMapper mapper,
        CancellationToken cancellationToken = default
    ) where TModel : class;
}
