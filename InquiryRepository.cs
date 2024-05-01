namespace ISB.CLWater.Service.Repositories
{
    public interface IInquiryRepository : ICLWaterRepository<Inquiry>
    {
    }
    public class InquiryRepository : CLWaterRepository<Inquiry>, IInquiryRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        public InquiryRepository(IDbContextFactory<CLWaterContext> contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}