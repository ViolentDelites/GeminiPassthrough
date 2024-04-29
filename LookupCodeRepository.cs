namespace ISB.CLWater.Service.Repositories
{
    public interface ILookupCodeRepository : ICLWaterRepository<LookupCode>
    {
        Task<IEnumerable<LookupCode>> ListSuffix();
        Task<IEnumerable<LookupCode>> ListStates();
        Task<IEnumerable<LookupCode>> ListCountries();
        Task<IEnumerable<LookupCode>> ListHearAboutUS();
        Task<IEnumerable<LookupCode>> ListAddressNotes();
        Task<IEnumerable<LookupCode>> ListRegistrationTypes();
        Task<IEnumerable<LookupCode>> ListNotificationTypes();
        Task<IEnumerable<LookupCode>> ListInquiryTypes();
        Task<LookupCode> GetHearAboutUsDescriptionById(int id);
    }
    public class LookupCodeRepository : CLWaterRepository<LookupCode>, ILookupCodeRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public LookupCodeRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }
        public async Task<IEnumerable<LookupCode>> ListSuffix()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "SUFFIX")            
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListStates()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "STATE")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListCountries()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "STATE")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListHearAboutUS()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "HEARABOUTUS")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListAddressNotes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "ADDRESSNOTES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListRegistrationTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "REGISTRATIONTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListNotificationTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "NOTIFICATIONTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListInquiryTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CodeType == "INQUIRYTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<LookupCode> GetHearAboutUsDescriptionById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await _context.LookupCodes
                                 .Where(lc => lc.CodeType == "HEARABOUTUS" && lc.Id == id)
                                 .FirstOrDefaultAsync();
            }
        }

    }
}