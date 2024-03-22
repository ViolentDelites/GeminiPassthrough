namespace ISB.CLWater.Service.Repositories
{
    public interface ILookupCodeRepository : ICLWaterRepository<LookupCode>
    {
    }
    public class LookupCodeRepository : CLWaterRepository<LookupCode>, ILookupCodeRepository
    {
        public LookupCodeRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
        }
        public async Task<IEnumerable<GetLKSuffixResult>> ListSuffix()
        {
            return await _context.LookupCodes
                     .Where(lc => lc.CodeType == "SUFFIX")
                     .Select(lc => new GetLKSuffixResult
                     {
                         SUFFIX_ID = lc.Id,
                         SUFFIX_DESC = lc.Name
                     })
                     .ToListAsync();
        }
    }
}