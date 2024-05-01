namespace ISB.CLWater.Service.Repositories
{
    public interface INotificationTrackingRepository : ICLWaterRepository<NotificationTracking>
    {
        Task<int> GetNotificationCountByPersonId(int personId);
        Task<IEnumerable<NotificationDTO>> GetPersonNotificationsAsync(int personId);

        public class NotificationTrackingRepository : CLWaterRepository<NotificationTracking>, INotificationTrackingRepository
        {
            private readonly IDbContextFactory<CLWaterContext> _contextFactory;

            private readonly DbSet<Person> _people;
            private readonly IPersonRepository _personRepository;
            private readonly ICommentRepository _commentRepository;
            private readonly IUserRepository _userRepository;
            private readonly ILookupCodeRepository _lookupCodeRepository;

            public NotificationTrackingRepository(IDbContextFactory<CLWaterContext> contextFactory, IPersonRepository personRepository, ICommentRepository commentRepository, IUserRepository userRepository, ILookupCodeRepository lookupCodeRepository)
                : base(contextFactory)
            {
                _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
                _personRepository = personRepository;
                _commentRepository = commentRepository;
                _userRepository = userRepository;
                _lookupCodeRepository = lookupCodeRepository;
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

            public async Task<IEnumerable<NotificationDTO>> GetPersonNotificationsAsync(int personId)
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.TBL_NOTIFICATION_TRACKING
                                .Where(nt => nt.PERSON_ID == personId ||
                                             nt.PERSON.PERSON_ID == personId)
                                .Select(nt => new NotificationDTO
                                {
                                    NotificationTrackingId = nt.NOTIFICATION_TRACKING_ID,
                                    DateSent = nt.DATE_SENT,
                                    PersonName = _personRepository.GetPersonFullName(nt.PERSON_ID),
                                    NotificationTypeDescription = _lookupCodeRepository.GetLookupCodeDescription(nt.NOTIFICATION_TYPE_ID),
                                    CreatedByName = nt.CREATED_BY != null ?
                                                    _userRepository.GetUserFullName(nt.CREATED_BY) :
                                                    String.Empty //possibly replace with a default value
                                })
                                .ToListAsync();
                }
            }

            public async Task<NotificationCommentCount> RetrieveNotificationCommentCount(int personId)   //temp solution to NotificationCommentCount question 
            {
                int commentCount = await _commentRepository.GetCommentCountByPersonId(personId);
                int notificationCount = await GetNotificationCountByPersonId(personId);

                return new NotificationCommentCount
                {
                    CommentCount = commentCount,
                    NotificationCount = notificationCount
                };

            }
        }
    }
}