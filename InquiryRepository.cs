namespace ISB.CLWater.Service.Repositories
{
    public interface IInquiryRepository : ICLWaterRepository<Inquiry>
    {
    }
    public class InquiryRepository : CLWaterRepository<Inquiry>, IInquiryRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        private readonly IUserRepository _userRepository;
        private readonly ILookupCodeRepository _lookupCodeRepository;

        public InquiryRepository(IDbContextFactory<CLWaterContext> contextFactory, IUserRepository userRepository, ILookupCodeRepository lookupCodeRepository)
            : base(contextFactory)
        {
            _contextFactory = contextFactory;
            _userRepository = userRepository;
            _lookupCodeRepository = lookupCodeRepository;
        }
    }
}