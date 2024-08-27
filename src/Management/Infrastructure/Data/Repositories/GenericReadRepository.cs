using System.Linq.Expressions;
using DespachoWorkspace.Management.Application.Interfaces.Repositories;
using DespachoWorkspace.Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : BaseEntity
{
    protected readonly DespachoDbContext dbContext;

    public GenericReadRepository(DespachoDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public virtual Task<List<T?>> Get(bool asNoTracking = false, Expression<Func<T?, bool>>? filter = null, params Expression<Func<T, object?>>[] includes)
    {
        return Get(asNoTracking, filter, null, includes);
    }

    public virtual async Task<List<T?>> Get(bool asNoTracking = false, Expression<Func<T?, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object?>>[] includes)
    {
        IQueryable<T> query = dbContext.Set<T>();


        foreach (var include in includes)
        {
            query = query.Include(include)!;
        }


        if (filter != null)
        {
            query = query.Where(filter)!;
        }

        if (orderBy != null)
        {
            query = orderBy(query)!;
        }

        if (asNoTracking)
        {
            return (await query.AsNoTracking().ToListAsync())!;
        }

        return (await query!.ToListAsync())!;
    }

    public virtual async Task<List<T?>> GetAllAsync(bool asNoTracking = false)
    {
        if (asNoTracking)
        {
            return (await dbContext.Set<T>().AsNoTracking().ToListAsync())!;
        }

        return (await dbContext.Set<T>().ToListAsync())!;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, bool asNoTracking = false, params Expression<Func<T, object?>>[] includes)
    {
        IQueryable<T> query = dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include)!;
        }

        if (asNoTracking)
        {
            return await query.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        return await query.FirstOrDefaultAsync(i => i.Id == id);
    }

    public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false, params Expression<Func<T, object?>>[] includes)
    {
        IQueryable<T> query = dbContext.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include!);
        }

        if (asNoTracking)
        {
            return await query.Where(filter).AsNoTracking().SingleOrDefaultAsync();
        }

        return await query.Where(filter).SingleOrDefaultAsync();
    }
}