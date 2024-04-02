namespace ISB.CLWater.Service.Repositories
{
    public interface IProjectUpdateRepository : ICLWaterRepository<ProjectUpdate>
    {
    }
    public class ProjectUpdateRepository : CLWaterRepository<ProjectUpdate>, IProjectUpdateRepository
    {
        public ProjectUpdateRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
    }
}