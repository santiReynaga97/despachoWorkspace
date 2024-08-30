using System.Linq.Expressions;
using DespachoWorkspace.Management.Domain.BaseEntities;


namespace DespachoWorkspace.Management.Application.Interfaces.Repositories;

public interface IGenericReadRepository<T> where T : BaseEntity
{
    Task<List<T?>> GetAllAsync(bool asNoTracking = false);

    Task<List<T?>> Get(bool asNoTracking = false, Expression<Func<T?, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object?>>[] includes);
    Task<List<T?>> Get(bool asNoTracking = false,Expression<Func<T?, bool>>? filter = null, params Expression<Func<T, object?>>[] includes);
    Task<T?> GetByIdAsync(Guid id,bool asNoTracking = false, params Expression<Func<T, object?>>[] includes);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false,params Expression<Func<T, object?>>[] includes);
}