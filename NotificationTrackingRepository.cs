namespace ISB.CLWater.Service.Repositories
{
    public interface INotificationTrackingRepository : ICLWaterRepository<NotificationTracking>
    {
        Task<int> GetNotificationCountByPersonId(int personId);
    }
    public class NotificationTrackingRepository : CLWaterRepository<NotificationTracking>, INotificationTrackingRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public NotificationTrackingRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<int> GetNotificationCountByPersonId(int personId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await _context.TBL_NOTIFICATION_TRACKING
                       .Where(n => n.PERSON_ID == personId)
                       .CountAsync();
            }
        }

    }
}