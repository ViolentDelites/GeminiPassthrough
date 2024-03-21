namespace ISB.CLWater.Service.Repositories;

public interface ICLWaterRepository<TEntity> : IDisposable
{
    Task<TEntity> AddOrUpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false);
    Task<TEntity> GetByIdAsync(object id, bool tracking = false);
}
