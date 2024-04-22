namespace ISB.CLWater.Service.Repositories;

public interface IProjectUpdateRepository : ICLWaterRepository<ProjectUpdate>
{
    Task InsertProjectUpdateAsync(ProjectUpdate projectUpdate);
    Task<List<ProjectUpdate>> GetTop3ProjectUpdates();
}
public class ProjectUpdateRepository : CLWaterRepository<ProjectUpdate>, IProjectUpdateRepository
{
    private readonly IDbContextFactory<CLWaterContext> _contextFactory;
    public ProjectUpdateRepository(IDbContextFactory<CLWaterContext> contextFactory)
        : base(contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task InsertProjectUpdateAsync(ProjectUpdate projectUpdate)
    {
        Add(projectUpdate);
        await SaveChangesAsync();
    }

    public async Task<List<ProjectUpdate>> GetTop3ProjectUpdates()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.TBL_ProjectUpdate.OrderByDescending(p => p.ArticleDate).Take(3).ToListAsync();
        }
    }
}