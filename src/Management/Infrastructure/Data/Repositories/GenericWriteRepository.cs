using DespachoWorkspace.Management.Application.Interfaces.Repositories;
using DespachoWorkspace.Management.Domain.BaseEntities;


namespace DespachoWorkspace.Management.Infrastructure.Data.Repositories;

public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : BaseEntity
{
    private readonly DespachoDbContext dbContext;

    public GenericWriteRepository(DespachoDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public virtual T Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
        return entity;
    }

    public virtual bool Remove(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        return true;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}