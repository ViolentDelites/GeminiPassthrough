namespace ISB.CLWater.Service.Migrations
{
    /// <inheritdoc />
    public partial class MigrateLegacyLookupDataToLookupCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "LK_ADDRESS_NOTE",
                schema: "dbo",
                columns: table => new
                {
                    ADDRESS_NOTES_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTES_DESC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LK_ADDRESS_NOTE", x => x.ADDRESS_NOTES_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_COUNTRY",
                schema: "dbo",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRY_DESC = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_COUNTRY__1BFD2C07", x => x.COUNTRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_FOLLOW_UP_REASON",
                schema: "dbo",
                columns: table => new
                {
                    FOLLOW_UP_REASON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FOLLOW_UP_REASON_DESC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_FOLLOW_UP_REA__239E4DCF", x => x.FOLLOW_UP_REASON_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_HEAR_ABOUT_US",
                schema: "dbo",
                columns: table => new
                {
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HEAR_ABOUT_US_DESC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_HEAR_ABOUT_US__1DE57479", x => x.HEAR_ABOUT_US_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_INQUIRY_TYPE",
                schema: "dbo",
                columns: table => new
                {
                    INQUIRY_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INQUIRY_TYPE_DESC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_INQUIRY_TYPE__1FCDBCEB", x => x.INQUIRY_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_NOTIFICATION_TYPE",
                schema: "dbo",
                columns: table => new
                {
                    NOTIFICATION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTIFICATION_TYPE_DESC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_NOTIFICATION___25869641", x => x.NOTIFICATION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_REGISTRATION_TYPE",
                schema: "dbo",
                columns: table => new
                {
                    REGISTRATION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REGISTRATION_TYPE_DESC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKLK_REGISTRATION_TYPE", x => x.REGISTRATION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_STATE",
                schema: "dbo",
                columns: table => new
                {
                    STATE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATE_NAME_LONG = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false),
                    STATE_DESC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_STATE__1A14E395", x => x.STATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LK_SUFFIX",
                schema: "dbo",
                columns: table => new
                {
                    SUFFIX_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUFFIX_DESC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LK_SUFFIX__182C9B23", x => x.SUFFIX_ID);
                });

            migrationBuilder.CreateTable(
                name: "LookupCode",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    RowNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventClass = table.Column<int>(type: "int", nullable: true),
                    TextData = table.Column<string>(type: "ntext", nullable: true),
                    ApplicationName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    NTUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CPU = table.Column<int>(type: "int", nullable: true),
                    Reads = table.Column<long>(type: "bigint", nullable: true),
                    Writes = table.Column<long>(type: "bigint", nullable: true),
                    Duration = table.Column<long>(type: "bigint", nullable: true),
                    ClientProcessID = table.Column<int>(type: "int", nullable: true),
                    SPID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    BinaryData = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profile__AAAC09D870DDC3D8", x => x.RowNumber);
                });

            migrationBuilder.CreateTable(
                name: "spCheckCACLoginNameResult",
                schema: "dbo",
                columns: table => new
                {
                    is_va_user = table.Column<bool>(type: "bit", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    first_nm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_nm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spFullWeeklyReportResult",
                schema: "dbo",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRIMARY_PHONE = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    SUFFIX_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHER_STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COUNTRY_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetHitCountThisMonthResult",
                schema: "dbo",
                columns: table => new
                {
                    total = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetHitCountTotalResult",
                schema: "dbo",
                columns: table => new
                {
                    total = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKAddressNotesResult",
                schema: "dbo",
                columns: table => new
                {
                    ADDRESS_NOTES_ID = table.Column<int>(type: "int", nullable: false),
                    NOTES_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKCountryResult",
                schema: "dbo",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: false),
                    COUNTRY_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKHearAboutUsResult",
                schema: "dbo",
                columns: table => new
                {
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: false),
                    HEAR_ABOUT_US_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKInquiryTypeResult",
                schema: "dbo",
                columns: table => new
                {
                    INQUIRY_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    INQUIRY_TYPE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKNotificationTypeResult",
                schema: "dbo",
                columns: table => new
                {
                    NOTIFICATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    NOTIFICATION_TYPE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKRegistrationTypeResult",
                schema: "dbo",
                columns: table => new
                {
                    REGISTRATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    REGISTRATION_TYPE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKStateResult",
                schema: "dbo",
                columns: table => new
                {
                    STATE_ID = table.Column<int>(type: "int", nullable: false),
                    STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATE_NAME_LONG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetLKSuffxResult",
                schema: "dbo",
                columns: table => new
                {
                    SUFFIX_ID = table.Column<int>(type: "int", nullable: false),
                    SUFFIX_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetPersonNotificationsResult",
                schema: "dbo",
                columns: table => new
                {
                    NOTIFICATION_TRACKING_ID = table.Column<int>(type: "int", nullable: false),
                    NOTIFICATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    DATE_SENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    dtSent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notification_type_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetRegistrySummaryReportResult",
                schema: "dbo",
                columns: table => new
                {
                    display_index = table.Column<int>(type: "int", nullable: false),
                    RECORD_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registration_type_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_count = table.Column<int>(type: "int", nullable: true),
                    total_count = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spGetStateCountResult",
                schema: "dbo",
                columns: table => new
                {
                    state_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spInsertPersonResult",
                schema: "dbo",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spInsertTblInquiryResult",
                schema: "dbo",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spIsDuplicateResult",
                schema: "dbo",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spListStageValidationRecordsResult",
                schema: "dbo",
                columns: table => new
                {
                    row_id = table.Column<long>(type: "bigint", nullable: true),
                    total_rows = table.Column<int>(type: "int", nullable: true),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suffix_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_phone = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    registration_type_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spPersonCountAddressResult",
                schema: "dbo",
                columns: table => new
                {
                    AddressCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spRetrieveAddressResult",
                schema: "dbo",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATE_ID = table.Column<int>(type: "int", nullable: true),
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHER_STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS_1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spRetrieveCommentNotifCountResult",
                schema: "dbo",
                columns: table => new
                {
                    notification_count = table.Column<int>(type: "int", nullable: true),
                    comment_count = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spRetrieveDuplicatesResult",
                schema: "dbo",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_type_id = table.Column<int>(type: "int", nullable: true),
                    suffix_id = table.Column<int>(type: "int", nullable: true),
                    primary_phone = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    alternate_phone = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    other_hear_about_us_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hear_about_us_id = table.Column<int>(type: "int", nullable: true),
                    is_staging = table.Column<bool>(type: "bit", nullable: true),
                    is_primary = table.Column<bool>(type: "bit", nullable: true),
                    primary_id = table.Column<int>(type: "int", nullable: true),
                    validate_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address_note_dt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address_note_id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    address_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_state_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_1 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spRetrieveHearAboutUsResult",
                schema: "dbo",
                columns: table => new
                {
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: false),
                    HEAR_ABOUT_US_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spRetrievePersonResult",
                schema: "dbo",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VARSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VARSTATIONED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VARWORKED = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VARRESIDE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGISTRATION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    VARNONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUFFIX_ID = table.Column<int>(type: "int", nullable: true),
                    PRIMARY_PHONE = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    ALTERNATE_PHONE = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: true),
                    OTHER_HEAR_ABOUT_US_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "bit", nullable: true),
                    IS_STAGING = table.Column<bool>(type: "bit", nullable: true),
                    PRIMARY_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_NOTE_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_NOTE_DT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spSuspectAddressReportResult",
                schema: "dbo",
                columns: table => new
                {
                    LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS_NOTE_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MIDDLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZIPCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHER_STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATE_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COUNTRY_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOTES_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spWeeklyReportResult",
                schema: "dbo",
                columns: table => new
                {
                    REVIEWED_RECORDS = table.Column<int>(type: "int", nullable: true),
                    VAL_RECORDS = table.Column<int>(type: "int", nullable: true),
                    EVAL_RECORDS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_ADDRESS_STAGING",
                schema: "dbo",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    CITY = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    ZIPCODE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    IS_CURRENT = table.Column<int>(type: "int", nullable: true),
                    STATE_ID = table.Column<int>(type: "int", nullable: true),
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OTHER_STATE_DESC = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ADDRESS_1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_COMMENT",
                schema: "dbo",
                columns: table => new
                {
                    COMMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    COMMENT = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_COMMENT", x => x.COMMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ERROR",
                schema: "dbo",
                columns: table => new
                {
                    ERROR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    STACK_TRACE = table.Column<string>(type: "text", nullable: false),
                    EXCEPTION_TYPE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EXCEPTION_MSG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ERROR", x => x.ERROR_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_HitCounter",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hit_Count = table.Column<long>(type: "bigint", nullable: true),
                    UserID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_HitCounter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_INQUIRY",
                schema: "dbo",
                columns: table => new
                {
                    INQUIRY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INQUIRY_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    NOTES = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    COMMENTS = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: true),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_INQUIRY__21B6055D", x => x.INQUIRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_NOTIFICATION_TRACKING_Staging",
                schema: "dbo",
                columns: table => new
                {
                    NOTIFICATION_TRACKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTIFICATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    DATE_SENT = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_PERSON_STAGING",
                schema: "dbo",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LAST_NAME = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    VARSTATUS = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    VARSTATIONED = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    VARWORKED = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    VARRESIDE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    REGISTRATION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    VARNONE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    SUFFIX_ID = table.Column<int>(type: "int", nullable: true),
                    PRIMARY_PHONE = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    ALTERNATE_PHONE = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    COMMENTS = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true),
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: true),
                    OTHER_HEAR_ABOUT_US_DESC = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    IS_STAGING = table.Column<bool>(type: "bit", nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "bit", nullable: true),
                    PRIMARY_ID = table.Column<int>(type: "int", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_ProjectUpdate",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "varchar(1500)", unicode: false, maxLength: 1500, nullable: true),
                    ArticleDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ProjectUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER",
                schema: "dbo",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LAST_NM = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LOGIN_NM = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    IS_ADMIN = table.Column<bool>(type: "bit", nullable: false),
                    IS_VA_USER = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTBL_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_VALIDATION_HISTORY",
                schema: "dbo",
                columns: table => new
                {
                    VALIDATION_HISTORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    VALIDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TBL_PERSON",
                schema: "dbo",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LAST_NAME = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    FIRST_NAME = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    MIDDLE_NAME = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    VARSTATUS = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    EMAIL_ADDRESS = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    VARSTATIONED = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    VARWORKED = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    VARRESIDE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    REGISTRATION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    VARNONE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    SUFFIX_ID = table.Column<int>(type: "int", nullable: true),
                    PRIMARY_PHONE = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    ALTERNATE_PHONE = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    COMMENTS = table.Column<string>(type: "text", nullable: true),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true),
                    HEAR_ABOUT_US_ID = table.Column<int>(type: "int", nullable: true),
                    OTHER_HEAR_ABOUT_US_DESC = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    IS_STAGING = table.Column<bool>(type: "bit", nullable: true),
                    IS_PRIMARY = table.Column<bool>(type: "bit", nullable: true),
                    PRIMARY_ID = table.Column<int>(type: "int", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALIDATE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    address_note_dt = table.Column<DateTime>(type: "datetime", nullable: true),
                    address_note_id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SUSPECT_UPDATE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBLCLNR__108B795B", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "R_10",
                        column: x => x.REGISTRATION_TYPE_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_REGISTRATION_TYPE",
                        principalColumn: "REGISTRATION_TYPE_ID");
                    table.ForeignKey(
                        name: "R_3",
                        column: x => x.SUFFIX_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_SUFFIX",
                        principalColumn: "SUFFIX_ID");
                    table.ForeignKey(
                        name: "R_8",
                        column: x => x.HEAR_ABOUT_US_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_HEAR_ABOUT_US",
                        principalColumn: "HEAR_ABOUT_US_ID");
                    table.ForeignKey(
                        name: "fk_address_note_id",
                        column: x => x.address_note_id,
                        principalSchema: "dbo",
                        principalTable: "LK_ADDRESS_NOTE",
                        principalColumn: "ADDRESS_NOTES_ID");
                });

            migrationBuilder.CreateTable(
                name: "TBL_ADDRESS",
                schema: "dbo",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    CITY = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    ZIPCODE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    IS_CURRENT = table.Column<int>(type: "int", nullable: true),
                    STATE_ID = table.Column<int>(type: "int", nullable: true),
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OTHER_STATE_DESC = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ADDRESS_1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_ADDRESS__1273C1CD", x => x.ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_PERSON_ADDRESS",
                        column: x => x.PERSON_ID,
                        principalSchema: "dbo",
                        principalTable: "TBL_PERSON",
                        principalColumn: "PERSON_ID");
                    table.ForeignKey(
                        name: "R_12",
                        column: x => x.STATE_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_STATE",
                        principalColumn: "STATE_ID");
                    table.ForeignKey(
                        name: "R_13",
                        column: x => x.COUNTRY_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_COUNTRY",
                        principalColumn: "COUNTRY_ID");
                });

            migrationBuilder.CreateTable(
                name: "TBL_NOTIFICATION_TRACKING",
                schema: "dbo",
                columns: table => new
                {
                    NOTIFICATION_TRACKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTIFICATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    DATE_SENT = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    EDITED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    EDITED_BY = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TBL_NOTIFICATION__276EDEB3", x => x.NOTIFICATION_TRACKING_ID);
                    table.ForeignKey(
                        name: "R_11",
                        column: x => x.NOTIFICATION_TYPE_ID,
                        principalSchema: "dbo",
                        principalTable: "LK_NOTIFICATION_TYPE",
                        principalColumn: "NOTIFICATION_TYPE_ID");
                    table.ForeignKey(
                        name: "R_5",
                        column: x => x.PERSON_ID,
                        principalSchema: "dbo",
                        principalTable: "TBL_PERSON",
                        principalColumn: "PERSON_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LK_COUNTRY",
                schema: "dbo",
                table: "LK_COUNTRY",
                column: "COUNTRY_DESC");

            migrationBuilder.CreateIndex(
                name: "IX_LK_STATE",
                schema: "dbo",
                table: "LK_STATE",
                column: "STATE_DESC");

            migrationBuilder.CreateIndex(
                name: "_dta_index_TBL_ADDRESS_10_181575685__K9_K2_K10_3_4",
                schema: "dbo",
                table: "TBL_ADDRESS",
                columns: new[] { "IS_CURRENT", "PERSON_ID", "STATE_ID" });

            migrationBuilder.CreateIndex(
                name: "ADDRESS_STATE_ID",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "ADDRESS_1");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS_1",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "ADDRESS_2");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS_2",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "OTHER_STATE_DESC");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS_3",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS_4",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ADDRESS_5",
                schema: "dbo",
                table: "TBL_ADDRESS",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_COMMENT",
                schema: "dbo",
                table: "TBL_COMMENT",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NOTIFICATION_TRACKING_NOTIFICATION_TYPE_ID",
                schema: "dbo",
                table: "TBL_NOTIFICATION_TRACKING",
                column: "NOTIFICATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_NOTIFICATION_TRACKING_PERSON_ID",
                schema: "dbo",
                table: "TBL_NOTIFICATION_TRACKING",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "_dta_index_TBL_PERSON_10_565577053__K22_K21_K20_K1_K13_K10_K12_2_3_4_14",
                schema: "dbo",
                table: "TBL_PERSON",
                columns: new[] { "PRIMARY_ID", "IS_PRIMARY", "IS_STAGING", "PERSON_ID", "SUFFIX_ID", "REGISTRATION_TYPE_ID", "CREATED_DATE" });

            migrationBuilder.CreateIndex(
                name: "idx_person",
                schema: "dbo",
                table: "TBL_PERSON",
                columns: new[] { "SUFFIX_ID", "IS_STAGING", "IS_PRIMARY", "PRIMARY_ID", "REGISTRATION_TYPE_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "FIRST_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_1",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "LAST_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_2",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "PRIMARY_PHONE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_3",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "EMAIL_ADDRESS");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_4",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "VALIDATE_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_5",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "HEAR_ABOUT_US_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_6",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "address_note_id");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PERSON_REGISTRATION_TYPE_ID",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "REGISTRATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "PERSON_PERSON_ID",
                schema: "dbo",
                table: "TBL_PERSON",
                column: "IS_PRIMARY");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER",
                schema: "dbo",
                table: "TBL_USER",
                column: "LOGIN_NM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LK_FOLLOW_UP_REASON",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_INQUIRY_TYPE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LookupCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "spCheckCACLoginNameResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spFullWeeklyReportResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetHitCountThisMonthResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetHitCountTotalResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKAddressNotesResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKCountryResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKHearAboutUsResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKInquiryTypeResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKNotificationTypeResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKRegistrationTypeResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKStateResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetLKSuffxResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetPersonNotificationsResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetRegistrySummaryReportResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spGetStateCountResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spInsertPersonResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spInsertTblInquiryResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spIsDuplicateResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spListStageValidationRecordsResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spPersonCountAddressResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spRetrieveAddressResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spRetrieveCommentNotifCountResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spRetrieveDuplicatesResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spRetrieveHearAboutUsResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spRetrievePersonResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spSuspectAddressReportResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "spWeeklyReportResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ADDRESS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ADDRESS_STAGING",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_COMMENT",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ERROR",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_HitCounter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_INQUIRY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_NOTIFICATION_TRACKING",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_NOTIFICATION_TRACKING_Staging",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PERSON_STAGING",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ProjectUpdate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USER",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_VALIDATION_HISTORY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_STATE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_COUNTRY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_NOTIFICATION_TYPE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PERSON",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_REGISTRATION_TYPE",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_SUFFIX",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_HEAR_ABOUT_US",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LK_ADDRESS_NOTE",
                schema: "dbo");
        }
    }
}
