using DetectoristApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DetectoristApp.DAL.Data.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(DbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        DbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        var a = await DbSet.AddAsync(entity);

        return a.Entity;
    }

    public void UpdateAsync(T entity)
    {
        DbSet.Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
    }
    
    public async Task<List<T>> GetByBrandAsync(string brand)
    {
        var entityType = typeof(T);
        var brandProperty = entityType.GetProperty("Brand");

        if (brandProperty == null)
        {
            throw new ArgumentException($"Type {entityType.Name} does not have a property named 'Brand'.");
        }

        return await DbSet.Where(t => string.Equals(brandProperty.GetValue(t).ToString(), brand, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
    }
    
    public async Task<T> GetByBrandAndModelAsync(string brand, string model)
    {
        var entityType = typeof(T);

        var brandProperty = entityType.GetProperty("Brand");
        var modelProperty = entityType.GetProperty("Model");

        if (brandProperty == null || modelProperty == null)
        {
            throw new ArgumentException($"Type {entityType.Name} does not have the required properties.");
        }

        return await DbSet.FirstOrDefaultAsync(t =>
            string.Equals(brandProperty.GetValue(t).ToString(), brand, StringComparison.CurrentCultureIgnoreCase) &&
            string.Equals(modelProperty.GetValue(t).ToString(), model, StringComparison.CurrentCultureIgnoreCase)
        );
    }


}
