namespace ISB.CLWater.Service.Repositories
{
    public interface IHitCounterRepository : ICLWaterRepository<HitCounter>
    {
    }
    public class HitCounterRepository : CLWaterRepository<HitCounter>, IHitCounterRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public HitCounterRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
    }
}