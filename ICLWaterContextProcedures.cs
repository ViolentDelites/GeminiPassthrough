// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ISB.CLWater.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ISB.CLWater.Service.DataAccess.Context
{
    public partial interface ICLWaterContextProcedures
    {
        Task<List<spCheckCACLoginNameResult>> spCheckCACLoginNameAsync(string p_login_nm, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spFullWeeklyReportResult>> spFullWeeklyReportAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spGetHearAboutUsAsync(int? hearAboutUsID, string startCreatedDate, string endCreatedDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetHitCountThisMonthResult>> spGetHitCountThisMonthAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetHitCountTotalResult>> spGetHitCountTotalAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKAddressNotesResult>> spGetLKAddressNotesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKCountryResult>> spGetLKCountryAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKHearAboutUsResult>> spGetLKHearAboutUsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKInquiryTypeResult>> spGetLKInquiryTypeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKNotificationTypeResult>> spGetLKNotificationTypeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKRegistrationTypeResult>> spGetLKRegistrationTypeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKStateResult>> spGetLKStateAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetLKSuffxResult>> spGetLKSuffxAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetPersonNotificationsResult>> spGetPersonNotificationsAsync(int? personID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetRegistrySummaryReportResult>> spGetRegistrySummaryReportAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGetStateCountResult>> spGetStateCountAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spGetTblInquiryAsync(int? inquiryTypeID, string startCreatedDate, string endCreatedDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spImportDataAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spInsertAddressAsync(int? p_person_id, string p_city, string p_zipcode, int? p_created_by, int? p_state_id, int? p_country_id, string p_address_2, string p_other_state_desc, string p_address_1, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spInsertCommentAsync(int? p_user_id, int? p_person_id, string p_comment, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spInsertHitCountAsync(string userid, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spInsertPersonResult>> spInsertPersonAsync(string p_last_name, string p_first_name, string p_middle_name, string p_varstatus, string p_email_address, string p_varstationed, string p_varworked, string p_varreside, string p_varnone, int? p_suffix_id, decimal? p_primary_phone, decimal? p_alternate_phone, string p_comments, int? p_hear_about_us_id, string p_other_hear_about_us_desc, bool? p_is_staging, bool? p_is_primary, int? p_primary_id, int? p_edited_by, int? p_reg_type_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spInsertProjectUpdateAsync(string p_title, string p_url, string p_description, DateOnly? p_archivedate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spInsertTblInquiryResult>> spInsertTblInquiryAsync(string comments, int? createdBy, int? editedBy, int? inquiryTypeID, string notes, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spInsertTblNotificationTrackingAsync(int? createdBy, DateTime? dateSent, int? editedBy, int? notificationTypeID, int? personID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spIsDuplicateResult>> spIsDuplicateAsync(string p_last_name, string p_first_name, int? p_suffix_id, decimal? p_primary_phone, string p_city, string p_zipcode, int? p_state_id, int? p_country_id, string p_address_2, string p_address_1, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spListStageValidationRecordsResult>> spListStageValidationRecordsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spLogErrorAsync(int? p_user_id, string p_stack_trace, string p_exception_type, string p_exception_msg, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spPersonCountAddressResult>> spPersonCountAddressAsync(int? p_person_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spReportPrimaryRegistrationAsync(int? personID, int? registrationTypeId, string startCreatedDate, string endCreatedDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spReportRegistrationAsync(int? personID, int? registrationTypeId, string startCreatedDate, string endCreatedDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spReportValidateAsync(int? personID, int? registrationTypeId, string startCreatedDate, string endCreatedDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRetrieveAddressResult>> spRetrieveAddressAsync(int? p_person_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRetrieveCommentNotifCountResult>> spRetrieveCommentNotifCountAsync(int? p_person_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRetrieveDuplicatesResult>> spRetrieveDuplicatesAsync(int? p_person_id, string p_last_name, string p_first_name, decimal? p_primary_phone, string p_city, string p_zipcode, int? p_state_id, int? p_country_id, string p_address_2, string p_address_1, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRetrieveHearAboutUsResult>> spRetrieveHearAboutUsAsync(int? p_hear_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRetrievePersonResult>> spRetrievePersonAsync(int? p_person_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spSuspectAddressReportResult>> spSuspectAddressReportAsync(int? p_address_note_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spUpdateAddressAsync(int? p_person_id, string p_city, string p_zipcode, int? p_edited_by, int? p_state_id, int? p_country_id, string p_address_2, string p_address_1, string p_other_state_desc, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spUpdatePersonAsync(int? p_person_id, string p_last_name, string p_first_name, string p_middle_name, string p_varstatus, string p_email_address, string p_varstationed, string p_varworked, string p_varreside, string p_varnone, int? p_suffix_id, decimal? p_primary_phone, decimal? p_alternate_phone, string p_comments, int? p_hear_about_us_id, string p_other_hear_about_us_desc, bool? p_is_staging, bool? p_is_primary, int? p_primary_id, int? p_edited_by, int? p_address_note_id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spWeeklyReportResult>> spWeeklyReportAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
