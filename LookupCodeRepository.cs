namespace ISB.CLWater.Service.Repositories
{
    public interface ILookupCodeRepository : ICLWaterRepository<LookupCode>
    {
        Task<IEnumerable<LookupCode>> ListSuffix();
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
    }
}