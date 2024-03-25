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
    }
    public class LookupCodeRepository : CLWaterRepository<LookupCode>, ILookupCodeRepository
    {
        public LookupCodeRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
        public async Task<IEnumerable<LookupCode>> ListSuffix()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "SUFFIX")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListStates()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "STATE")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListCountries()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "COUNTRY")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListHearAboutUS()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "HEARABOUTUS")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListAddressNotes()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "ADDRESSNOTES")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListRegistrationTypes()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "REGISTRATIONTYPES")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListNotificationTypes()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "NOTIFICATIONTYPES")
                     .ToListAsync();
        }
        public async Task<IEnumerable<LookupCode>> ListInquiryTypes()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "INQUIRYTYPES")
                     .ToListAsync();
        }

    }
}