using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ISB.CLWater.Service.DI
{
    public static class ServiceDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddDbContext<CLWaterContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAddressNoteRepository, AddressNoteRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressStagingRepository, AddressStagingRepository>();
            services.AddScoped<ICheckCACLoginNameResultRepository, CheckCACLoginNameResultRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IFollowUpReasonRepository, FollowUpReasonRepository>();
            services.AddScoped<IFullWeeklyReportResultRepository, FullWeeklyReportResultRepository>();
            services.AddScoped<IGetHitCountThisMonthResultRepository, GetHitCountThisMonthResultRepository>();
            services.AddScoped<IGetHitCountTotalResultRepository, GetHitCountTotalResultRepository>();
            services.AddScoped<IGetLKAddressNotesResultRepository, GetLKAddressNotesResultRepository>();
            services.AddScoped<IGetLKCountryResultRepository, GetLKCountryResultRepository>();
            services.AddScoped<IGetLKHearAboutUsResultRepository, GetLKHearAboutUsResultRepository>();
            services.AddScoped<IGetLKInquiryTypeResultRepository, GetLKInquiryTypeResultRepository>();
            services.AddScoped<IGetLKNotificationTypeResultRepository, GetLKNotificationTypeResultRepository>();
            services.AddScoped<IGetLKRegistrationTypeResultRepository, GetLKRegistrationTypeResultRepository>();
            services.AddScoped<IGetLKStateResultRepository, GetLKStateResultRepository>();
            services.AddScoped<IGetLKSuffixResultRepository, GetLKSuffixResultRepository>();
            services.AddScoped<IGetPersonNotificationsResultRepository, GetPersonNotificationsResultRepository>();
            services.AddScoped<IGetRegistrySummaryReportResultRepository, GetRegistrySummaryReportResultRepository>();
            services.AddScoped<IGetStateCountResultRepository, GetStateCountResultRepository>();
            services.AddScoped<IHearAboutUsRepository, HearAboutUsRepository>();
            services.AddScoped<IHitCounterRepository, HitCounterRepository>();
            services.AddScoped<IInquiryRepository, InquiryRepository>();
            services.AddScoped<IInquiryTypeRepository, InquiryTypeRepository>();
            services.AddScoped<IInsertPersonResultRepository, InsertPersonResultRepository>();
            services.AddScoped<IInsertTblInquiryResultRepository, InsertTblInquiryResultRepository>();
            services.AddScoped<IIsDuplicateResultRepository, IsDuplicateResultRepository>();
            services.AddScoped<IListStageValidationRecordsResultRepository, ListStageValidationRecordsResultRepository>();
            services.AddScoped<INotificationTrackingRepository, NotificationTrackingRepository>();
            services.AddScoped<INotificationTrackingStagingRepository, NotificationTrackingStagingRepository>();
            services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddScoped<IPersonCountAddressResultRepository, PersonCountAddressResultRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonStagingRepository, PersonStagingRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProjectUpdateRepository, ProjectUpdateRepository>();
            services.AddScoped<IRealTimeStateDataRepository, RealTimeStateDataRepository>();
            services.AddScoped<IRegistrationTypeRepository, RegistrationTypeRepository>();
            services.AddScoped<IRetrieveAddressResultRepository, RetrieveAddressResultRepository>();
            services.AddScoped<IRetrieveCommentNotifCountResultRepository, RetrieveCommentNotifCountResultRepository>();
            services.AddScoped<IRetrieveDuplicatesResultRepository, RetrieveDuplicatesResultRepository>();
            services.AddScoped<IRetrieveHearAboutUsResultRepository, RetrieveHearAboutUsResultRepository>();
            services.AddScoped<IRetrievePersonResultRepository, RetrievePersonResultRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISuffixRepository, SuffixRepository>();
            services.AddScoped<ISuspectAddressReportResultRepository, SuspectAddressReportResultRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IValidationHistoryRepository, ValidationHistoryRepository>();
            services.AddScoped<IWeeklyReportResultRepository, WeeklyReportResultRepository>();
        }
    }
}