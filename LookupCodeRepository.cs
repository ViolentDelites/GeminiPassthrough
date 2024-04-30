namespace ISB.CLWater.Service.Repositories
{
    public interface ILookupCodeRepository : ICLWaterRepository<LookupCode>
    {
        public string GetLookupCodeDescription(int id);
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
        public string GetLookupCodeDescription(int id)
        {
            return _context.LookupCodes
                           .Where(lc => lc.ID == id)
                           .Select(lc => lc.DESCRIPTION)
                           .FirstOrDefault();
        }

        public async Task<IEnumerable<LookupCode>> ListSuffix()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "SUFFIX")            
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListStates()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CODE_TYPE == "STATE")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListCountries()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "STATE")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListHearAboutUS()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "HEARABOUTUS")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListAddressNotes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "ADDRESSNOTES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListRegistrationTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "REGISTRATIONTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListNotificationTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "NOTIFICATIONTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<IEnumerable<LookupCode>> ListInquiryTypes()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "INQUIRYTYPES")
                                 .ToListAsync();
            }
        }
        public async Task<LookupCode> GetHearAboutUsDescriptionById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await _context.LookupCodes
                                 .Where(lc => lc.CODE_TYPE == "HEARABOUTUS" && lc.ID == id)
                                 .FirstOrDefaultAsync();
            }
        }

    }
}