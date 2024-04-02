using Microsoft.EntityFrameworkCore;

namespace ISB.CLWater.Service.Repositories
{
    public interface INotificationTrackingRepository : ICLWaterRepository<NotificationTracking>
    {
        Task<int> GetNotificationCountByPersonId(int personId);
    }
    public class NotificationTrackingRepository : CLWaterRepository<NotificationTracking>, INotificationTrackingRepository
    {
        public NotificationTrackingRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }

        public async Task<int> GetNotificationCountByPersonId(int personId)
        {
            return await _context.TBL_NOTIFICATION_TRACKING
                       .Where(n => n.PERSON_ID == personId)
                       .CountAsync();
        }

    }
}