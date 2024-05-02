namespace ISB.CLWater.Service.Repositories
{
    public interface IHitCounterRepository : ICLWaterRepository<HitCounter>
    {
        Task<int> GetHitCountForCurrentMonthAsync();
        Task<long> GetTotalHitCountAsync();
    }
    public class HitCounterRepository : CLWaterRepository<HitCounter>, IHitCounterRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public HitCounterRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<int> GetHitCountForCurrentMonthAsync()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            using (var context = _contextFactory.CreateDbContext())
            {
                return (int)(await _context.TBL_HitCounter
                        .Where(hc => hc.Date >= startDate && hc.Date <= endDate)
                        .SumAsync(hc => hc.Hit_Count) ?? 0);
            }
        }

        public async Task<long> GetTotalHitCountAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var sum = await context.TBL_HitCounter.SumAsync(hc => hc.Hit_Count);
                return sum ?? 0;
            }
        }
    }
}