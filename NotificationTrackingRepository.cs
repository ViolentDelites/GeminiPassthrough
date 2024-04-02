namespace ISB.CLWater.Service.Repositories
{
    public interface INotificationTrackingRepository : ICLWaterRepository<NotificationTracking>
    {
    }
    public class NotificationTrackingRepository : CLWaterRepository<NotificationTracking>, INotificationTrackingRepository
    {
        public NotificationTrackingRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
    }
}