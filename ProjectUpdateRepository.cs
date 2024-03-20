namespace ISB.CLWater.Services.Repositories
{
    public class ProjectUpdateRepository : CLWaterRepository<ProjectUpdate>
    {
        public ProjectUpdateRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
    }
}