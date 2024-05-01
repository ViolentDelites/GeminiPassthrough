namespace ISB.CLWater.Service.Repositories
{
    public interface IInquiryRepository : ICLWaterRepository<Inquiry>
    {
        Task<IEnumerable<InquiryDTO>> GetInquiriesAsync(DateTime startDate, DateTime endDate, int? inquiryTypeId = null);
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

        public async Task<IEnumerable<InquiryDTO>> GetInquiriesAsync(DateTime startDate, DateTime endDate, int? inquiryTypeId = null)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.TBL_INQUIRY
                        .Where(inq => inq.CREATED_DATE >= startDate && inq.CREATED_DATE <= endDate)
                        .Where(inq => inquiryTypeId == null || inq.INQUIRY_TYPE_ID == inquiryTypeId)
                        .Select(inq => new InquiryDTO
                        {
                            InquiryId = inq.INQUIRY_ID,
                            InquiryTypeId = inq.INQUIRY_TYPE_ID,
                            InquiryTypeDescription = _lookupCodeRepository.GetLookupCodeDescription(inq.INQUIRY_TYPE_ID),
                            Comments = inq.COMMENTS,
                            Notes = inq.NOTES,
                            CreatedDate = inq.CREATED_DATE,
                            CreatedBy = inq.CREATED_BY,
                            CreatedByName = _userRepository.GetUserFullName(inq.CREATED_BY),
                            EditedDate = inq.EDITED_DATE,
                            EditedBy = inq.EDITED_BY,
                        })
                        .OrderByDescending(inq => inq.InquiryId)
                        .ToListAsync();
            }
        }
    }
}