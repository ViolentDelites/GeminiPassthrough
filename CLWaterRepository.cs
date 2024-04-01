namespace ISB.CLWater.Service.Repositories;

public class CLWaterRepository<TEntity> : DbContext, ICLWaterRepository<TEntity> where TEntity : class
{
    protected CLWaterContext _context;
    private readonly IDbContextFactory<CLWaterContext> _contextFactory;
    private bool disposedValue = false;
    private string contextId = "";

    public CLWaterRepository(IDbContextFactory<CLWaterContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<TEntity> AddOrUpdateAsync(TEntity entity)
    {
        try
        {
            await EnsureContext();

            // Determine if it's an Add or Update (you'll need a strategy for this)
            if (IsNewEntity(entity))
            {
                _context.Set<TEntity>().Add(entity);
            }
            else
            {
                _context.Set<TEntity>().Update(entity);
            }

            await _context.SaveChangesAsync();

            return entity;
        }
        catch (DbUpdateConcurrencyException ucX)
        {
            // TODO: Implement actual concurrency resolution that works.
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't save or update entity of type {typeof(TEntity).Name} : {ex.Message}");
        }
        finally
        {
            _context.ChangeTracker.Clear();
        }
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            await EnsureContext();
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException ucX)
        {
            var e = _context.Entry(entity);
            var proposedValues = e.CurrentValues;
            var databaseValues = e.GetDatabaseValues();

            // Refresh original values to bypass next concurrency check
            e.OriginalValues.SetValues(databaseValues);
            _context.Set<TEntity>().Remove(e.Entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false)
    {
        try
        {
            await EnsureContext();

            _context.ChangeTracker.QueryTrackingBehavior = tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTrackingWithIdentityResolution;

            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entities of type {typeof(TEntity).Name} : {ex.Message}");
        }
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false)
    {
        try
        {
            await EnsureContext();

            _context.ChangeTracker.QueryTrackingBehavior = tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTrackingWithIdentityResolution;

            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entities of type {typeof(TEntity).Name} : {ex.Message}");
        }
        finally
        {
            _context.ChangeTracker.Clear();
        }
    }

    public async Task<TEntity> GetByIdAsync(object id, bool tracking = false)
    {
        try
        {
            if (id == null)
                throw new Exception($"No entity id passed.");

            await EnsureContext();

            _context.ChangeTracker.QueryTrackingBehavior = tracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTrackingWithIdentityResolution;

            return await _context.Set<TEntity>().FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrieve entity with id of {id} : {ex.Message}");
        }
    }

    private async Task EnsureContext()
    {
        if (_context is null)
            _context = _contextFactory.CreateDbContext();

        contextId = _context is not null ? _context.ContextId.ToString() : "";
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (_context is not null)
                    _context.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    private bool IsNewEntity(TEntity entity)
    {
        // Implement your logic to determine if an entity is new.
        // Example (assuming an 'Id' property):
        return entity == null;
    }

}