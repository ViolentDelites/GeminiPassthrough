namespace ISB.CLWater.Service.Repositories
{
    public interface IPersonRepository : ICLWaterRepository<Person> // Inherit from the base interface
    {
        Task UpdatePersonAsync(int editUserId, Person person);
        Task<Person> RetrievePersonAsync(int personId);
        Task<int> InsertPersonAsync(Person person, int userId);
        Task<bool> IsDuplicateAsync(Person person, Address address);
        Task UpdatePersonRecordAsync(int editUserId, Person person, Address address);
        Task ValidateUserAsync(int editUserId, Person person, Address address, Person compPerson = null, Address compAddress = null);
        Task InsertCollectionForm(Person person, Address address, int userId, Comment comment);
        Task<List<HearAboutUsRecord>> GetHearAboutUsRecordsAsync(string startDate, string endDate, int hearAboutUsId = 0);
        public string GetPersonFullName(int personId);
        //Reports services
        Task<List<StageValidationRecordDTO>> ListStageValidationRecordsAsync();
        Task<List<PrimaryRegistrationRecord>> GetPrimaryRegistrationRecordsAsync(int? personId, int registrationTypeId, string startCreatedDate, string endCreatedDate);
        Task<List<RegistrationRecord>> GetRegistrationRecordsAsync(int? personId, int? registrationTypeId, string startCreatedDate, string endCreatedDate);
        Task<List<ValidateRecord>> GetValidateRecordsAsync(int? personId, int? registrationTypeId, string startCreatedDate, string endCreatedDate);
        Task<WeeklyReportResultDTO> GetWeeklyReportAsync(DateTime startDate, DateTime endDate);
        Task<List<SuspectAddressRecord>> GetSuspectAddressReportAsync(int addressNoteId);
        Task<List<DuplicateRecord>> GetDuplicateRecordsAsync(int personId, string lastName, string firstName, decimal primaryPhone, string city, string zipcode, int stateId, int countryId, string address2, string address1);
        Task<List<WeeklyReportRecord>> GetFullWeeklyReportAsync(DateTime startDate, DateTime endDate);
        Task<List<RegistrySummaryReportRecord>> GetRegistrySummaryReportAsync();


    }
    public class PersonRepository : CLWaterRepository<Person>, IPersonRepository
    {
        private readonly IDbContextFactory<CLWaterContext> _contextFactory;
        private readonly IAddressRepository _addressRepository; 
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILookupCodeRepository _lookupCodeRepository;

        public PersonRepository(IDbContextFactory<CLWaterContext> contextFactory, IAddressRepository addressRepository, ICommentRepository commentRepository, IUserRepository userRepository, ILookupCodeRepository lookupCodeRepository) :base(contextFactory)
        {
            _contextFactory = contextFactory;
            _addressRepository = addressRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _lookupCodeRepository = lookupCodeRepository;
        }

        public async Task UpdatePersonAsync(int editUserId, Person person)
        {
            try
            {
                var existingPerson = await _context.TBL_PERSON.FindAsync(person.PERSON_ID);
                if (existingPerson == null)
                {
                    // Handle person not found
                    return;
                }

                // Direct field mappings
                existingPerson.LAST_NAME = person.LAST_NAME;
                existingPerson.FIRST_NAME = person.FIRST_NAME;
                existingPerson.MIDDLE_NAME = person.MIDDLE_NAME ?? "";
                existingPerson.VARSTATUS = person.VARSTATUS ?? "";
                existingPerson.EMAIL_ADDRESS = person.EMAIL_ADDRESS ?? "";
                existingPerson.VARSTATIONED = person.VARSTATIONED ?? "";
                existingPerson.VARWORKED = person.VARWORKED ?? "";
                existingPerson.VARRESIDE = person.VARRESIDE ?? "";
                existingPerson.VARNONE = person.VARNONE ?? "";
                existingPerson.SUFFIX_ID = person.SUFFIX_ID == 0 ? null : person.SUFFIX_ID;
                existingPerson.PRIMARY_PHONE = person.PRIMARY_PHONE;
                existingPerson.ALTERNATE_PHONE = person.ALTERNATE_PHONE.GetValueOrDefault();
                existingPerson.COMMENTS = person.COMMENTS ?? "";
                existingPerson.HEAR_ABOUT_US_ID = person.HEAR_ABOUT_US_ID;
                existingPerson.OTHER_HEAR_ABOUT_US_DESC = person.OTHER_HEAR_ABOUT_US_DESC ?? "";
                existingPerson.IS_PRIMARY = person.IS_PRIMARY;
                existingPerson.PRIMARY_ID = person.PRIMARY_ID;
                existingPerson.address_note_id = person.address_note_id;
                existingPerson.address_note_dt = DateTime.Now;

                // Validation Logic
                if (existingPerson.IS_PRIMARY == true && person.IS_PRIMARY == false)
                {
                    throw new InvalidOperationException("ERROR: Attempt to change primary record to duplicate.");
                }

                if (person.IS_STAGING == true && person.IS_PRIMARY == true)
                {
                    throw new InvalidOperationException("ERROR: Attempt to set record as primary & staged.");
                }

                if (existingPerson.PERSON_ID != null && existingPerson.PERSON_ID != person.PERSON_ID)
                {
                    throw new InvalidOperationException("ERROR: Attempt to change primary id of a duplicate to a new primary id.");
                }
                if (existingPerson.IS_STAGING == true && person.IS_STAGING == false)
                {
                    existingPerson.VALIDATE_DATE = DateTime.Now;
                }
                else { existingPerson.IS_STAGING = true; }

                // Audit fields 
                existingPerson.EDITED_BY = editUserId;
                existingPerson.EDITED_DATE = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the validation errors, e.g., log or return an error response
                Console.WriteLine(ex.Message); // Temporary - replace with your error handling
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
            }
        }

        public async Task<Person> RetrievePersonAsync(int personId)
        {
            try
            {
                var person = await _context.TBL_PERSON.FirstOrDefaultAsync(p => p.PERSON_ID == personId);

                if (person == null)
                {
                    throw new Exception("Retrieve Person Returned 0 Records");
                }

                return person;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, etc.)
                throw; // Re-throw for now, adjust as needed
            }
        }

        public async Task<int> InsertPersonAsync(Person person, int userId)
        {
            try
            {
                person.EDITED_BY = userId;
                person.EDITED_DATE = DateTime.Now; // Assuming you have such a field

                _context.TBL_PERSON.Add(person);
                await _context.SaveChangesAsync();

                return person.PERSON_ID; // Assuming this is auto-generated
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.) 
                throw;  // Re-throw for now; adjust as needed
            }
        }

        public async Task<bool> IsDuplicateAsync(Person person, Address address)
        {
            try
            {
                var isDuplicate = await _context.TBL_PERSON
                    .Where(p => p.LAST_NAME.ToUpper() == person.LAST_NAME.ToUpper() &&
                                p.FIRST_NAME.ToUpper() == person.FIRST_NAME.ToUpper() &&
                                p.PRIMARY_PHONE == person.PRIMARY_PHONE &&
                                (p.SUFFIX_ID == person.SUFFIX_ID || person.SUFFIX_ID == null) &&
                                p.TBL_ADDRESS.Any(a => a.ADDRESS_1.ToUpper() == address.ADDRESS_1.ToUpper() &&
                                                     a.CITY.ToUpper() == address.CITY.ToUpper() &&
                                                     a.ZIPCODE.ToUpper() == address.ZIPCODE.ToUpper() &&
                                                     a.STATE_ID == address.STATE_ID &&
                                                     a.COUNTRY_ID == address.COUNTRY_ID &&
                                                     (a.ADDRESS_2.ToUpper() == address.ADDRESS_2.ToUpper() || address.ADDRESS_2 == null)))
                    .AnyAsync();

                return isDuplicate;
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task UpdatePersonRecordAsync(int editUserId, Person person, Address address)
        {
            try
            {
                // Update Person
                await UpdatePersonAsync(editUserId, person);

                // Address Logic
                var addressCount = await _addressRepository.PersonAddressCountAsync(person.PERSON_ID);

                switch (addressCount)
                {
                    case 1:
                        await _addressRepository.UpdateAddressAsync(editUserId, address);
                        break;
                    case 0:
                        await _addressRepository.InsertAddressAsync(editUserId, address);
                        break;
                    default:
                        throw new Exception("Address Check for user " + person.PERSON_ID + " Failed!");
                }
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task ValidateUserAsync(int editUserId, Person person, Address address, Person compPerson = null, Address compAddress = null)
        {
            try
            {
                await UpdatePersonAsync(editUserId, person);

                if (person.IS_PRIMARY == true)
                {
                    var addressCount = await _addressRepository.PersonAddressCountAsync(person.PERSON_ID);

                    switch (addressCount)
                    {
                        case 1:
                            await _addressRepository.UpdateAddressAsync(editUserId, address);
                            break;
                        case 0:
                            await _addressRepository.InsertAddressAsync(editUserId, address);
                            break;
                        default:
                            throw new Exception("Address Check for user " + person.PERSON_ID + " Failed!");
                    }
                }

                if (compPerson != null && compAddress != null)
                {
                    await UpdatePersonAsync(editUserId, compPerson);

                    var compAddressCount = await _addressRepository.PersonAddressCountAsync(compPerson.PERSON_ID);

                    switch (compAddressCount)
                    {
                        case 1:
                            await _addressRepository.UpdateAddressAsync(editUserId, compAddress);
                            break;
                        case 0:
                            await _addressRepository.InsertAddressAsync(editUserId, compAddress);
                            break;
                        default:
                            throw new Exception("Address Check for user " + compPerson.PERSON_ID + " Failed!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Implement error handling (logging, re-throwing, etc.)
                throw; // Re-throw for now; adjust as needed
            }
        }

        public async Task InsertCollectionForm(Person person, Address address, int userId, Comment comment)
        {
            address.PERSON_ID = await InsertPersonAsync(person, userId);
            _addressRepository.InsertAddressAsync(userId, address); // Delegate to AddressRepository

            if (comment != null)
            {
                comment.PERSON_ID = address.PERSON_ID;
                _commentRepository.InsertCommentAsync(userId, comment); // Delegate to CommentRepository
            }
        }

        public async Task<List<HearAboutUsRecord>> GetHearAboutUsRecordsAsync(string startDate, string endDate, int hearAboutUsId = 0)
        {
            var query = _context.TBL_PERSON
                .Where(p => p.HEAR_ABOUT_US_ID != null &&
                            p.CREATED_DATE >= DateTime.Parse(startDate) &&
                            p.CREATED_DATE <= DateTime.Parse(endDate));

            if (hearAboutUsId > 0)
            {
                query = query.Where(p => p.HEAR_ABOUT_US_ID == hearAboutUsId);
            }

            return await query
                .OrderByDescending(p => p.HEAR_ABOUT_US_ID)
                .Select(p => new HearAboutUsRecord
                {
                    HearAboutUsId = p.HEAR_ABOUT_US_ID.Value,
                    OtherHearAboutUsDescription = p.OTHER_HEAR_ABOUT_US_DESC,
                    HearAboutUsDescription = _lookupCodeRepository.GetLookupCodeDescription(p.HEAR_ABOUT_US_ID ?? 0),
                    CreatedBy = p.CREATED_BY.Value,
                    CreatedDate = p.CREATED_DATE,
                    CreatedByName = _userRepository.GetUserFullName(p.CREATED_BY ?? 0)
                })
                .ToListAsync();
        }

        public string GetPersonFullName(int personId)
        {
            return _context.TBL_PERSON
                       .Where(p => p.PERSON_ID == personId)
                       .Select(p => p.FIRST_NAME + " " + p.LAST_NAME)
                       .FirstOrDefault();
        }

        public async Task<List<StageValidationRecordDTO>> ListStageValidationRecordsAsync()
        {
            var query = _context.TBL_PERSON
                .Where(p => p.IS_STAGING == true && p.IS_PRIMARY == false && p.PRIMARY_ID == null)
                .Join(_context.TBL_ADDRESS,
                    p => p.PERSON_ID,
                    a => a.PERSON_ID,
                    (p, a) => new { Person = p, Address = a })
                .Where(pa => pa.Address.IS_CURRENT == 1)
                .Join(_context.LookupCodes.Where(lc => lc.CODE_TYPE == "SUFFIX"),
                    pa => pa.Person.SUFFIX_ID,
                    s => s.ID,
                    (pa, s) => new { pa.Person, pa.Address, Suffix = s })
                .Join(_context.LookupCodes.Where(lc => lc.CODE_TYPE == "STATE"),
                    pas => pas.Address.STATE_ID,
                    st => st.ID,
                    (pas, st) => new { pas.Person, pas.Address, pas.Suffix, State = st })
                .Join(_context.LookupCodes.Where(lc => lc.CODE_TYPE == "COUNTRY"),
                    pass => pass.Address.COUNTRY_ID,
                    c => c.ID,
                    (pass, c) => new { pass.Person, pass.Address, pass.Suffix, pass.State, Country = c })
                .Join(_context.LookupCodes.Where(lc => lc.CODE_TYPE == "REGISTRATION_TYPE"),
                    passc => passc.Person.REGISTRATION_TYPE_ID,
                    rt => rt.ID,
                    (passc, rt) => new
                    {
                        passc.Person,
                        passc.Address,
                        passc.Suffix,
                        passc.State,
                        passc.Country,
                        RegistrationType = rt
                    })
                .OrderBy(x => x.Person.CREATED_DATE);

            var totalRows = await query.CountAsync();

            var result = await query
                .Select((x, index) => new StageValidationRecordDTO
                {
                    RowId = index + 1,
                    TotalRows = totalRows,
                    PersonId = x.Person.PERSON_ID,
                    LastName = x.Person.LAST_NAME,
                    FirstName = x.Person.FIRST_NAME,
                    MiddleName = x.Person.MIDDLE_NAME,
                    SuffixDescription = x.Suffix.NAME,
                    Address1 = x.Address.ADDRESS_1,
                    City = x.Address.CITY,
                    StateDescription = x.State.NAME,
                    Zipcode = x.Address.ZIPCODE,
                    PrimaryPhone = x.Person.PRIMARY_PHONE,
                    RegistrationTypeDescription = x.RegistrationType.NAME
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<PrimaryRegistrationRecord>> GetPrimaryRegistrationRecordsAsync(int? personId, int registrationTypeId, string startCreatedDate, string endCreatedDate)
        {
            return await _context.TBL_PERSON
                .Where(p => p.IS_PRIMARY == true &&
                            p.REGISTRATION_TYPE_ID == registrationTypeId &&
                            (personId == null || p.PERSON_ID == personId) &&
                            p.CREATED_DATE >= DateTime.Parse(startCreatedDate) &&
                            p.CREATED_DATE <= DateTime.Parse(endCreatedDate))
                .Join(_context.TBL_ADDRESS,
                    p => p.PERSON_ID,
                    a => a.PERSON_ID,
                    (p, a) => new { Person = p, Address = a })
                .Where(pa => pa.Address.IS_CURRENT == 1)
                .Select(pa => new PrimaryRegistrationRecord
                {
                    PersonId = pa.Person.PERSON_ID,
                    RegistrationType = pa.Person.REGISTRATION_TYPE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.REGISTRATION_TYPE_ID.Value) : null,
                    LastName = pa.Person.LAST_NAME,
                    FirstName = pa.Person.FIRST_NAME,
                    MiddleName = pa.Person.MIDDLE_NAME,
                    Suffix = pa.Person.SUFFIX_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.SUFFIX_ID.Value) : null,
                    PrimaryPhone = pa.Person.PRIMARY_PHONE,
                    Address1 = pa.Address.ADDRESS_1,
                    Address2 = pa.Address.ADDRESS_2,
                    City = pa.Address.CITY,
                    State = pa.Address.STATE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.STATE_ID.Value) : null,
                    Country = pa.Address.COUNTRY_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.COUNTRY_ID.Value) : null,
                    Zipcode = pa.Address.ZIPCODE,
                    Note = _lookupCodeRepository.GetLookupCodeDescription(pa.Person.address_note_id)
                })
                .ToListAsync();
        }

        public async Task<List<RegistrationRecord>> GetRegistrationRecordsAsync(int? personId, int? registrationTypeId, string startCreatedDate, string endCreatedDate)
        {
            var query = _context.TBL_PERSON
                .Where(p => (personId == null || p.PERSON_ID == personId) &&
                            (registrationTypeId == null || p.REGISTRATION_TYPE_ID == registrationTypeId) &&
                            (string.IsNullOrEmpty(startCreatedDate) || string.IsNullOrEmpty(endCreatedDate) ||
                             (p.CREATED_DATE >= DateTime.Parse(startCreatedDate) && p.CREATED_DATE <= DateTime.Parse(endCreatedDate).AddDays(1).AddSeconds(-1))))
                .Join(_context.TBL_ADDRESS,
                    p => p.PERSON_ID,
                    a => a.PERSON_ID,
                    (p, a) => new { Person = p, Address = a })
                .Where(pa => pa.Address.IS_CURRENT == 1)
                .Select(pa => new RegistrationRecord
                {
                    AlternatePhone = pa.Person.ALTERNATE_PHONE,
                    Comments = pa.Person.COMMENTS,
                    CreatedBy = pa.Person.CREATED_BY,
                    CreatedDate = pa.Person.CREATED_DATE,
                    EditedBy = pa.Person.EDITED_BY,
                    EditedDate = pa.Person.EDITED_DATE,
                    EmailAddress = pa.Person.EMAIL_ADDRESS,
                    FirstName = pa.Person.FIRST_NAME,
                    HearAboutUsId = pa.Person.HEAR_ABOUT_US_ID,
                    IsPrimary = pa.Person.IS_PRIMARY,
                    IsStaging = pa.Person.IS_STAGING,
                    LastName = pa.Person.LAST_NAME,
                    MiddleName = pa.Person.MIDDLE_NAME,
                    OtherHearAboutUsDesc = pa.Person.OTHER_HEAR_ABOUT_US_DESC,
                    PersonId = pa.Person.PERSON_ID,
                    PrimaryId = pa.Person.PRIMARY_ID,
                    PrimaryPhone = pa.Person.PRIMARY_PHONE,
                    RegistrationTypeId = pa.Person.REGISTRATION_TYPE_ID,
                    RegistrationTypeDesc = pa.Person.REGISTRATION_TYPE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.REGISTRATION_TYPE_ID.Value) : null,
                    SuffixId = pa.Person.SUFFIX_ID,
                    SuffixDesc = pa.Person.SUFFIX_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.SUFFIX_ID.Value) : null,
                    VarNone = pa.Person.VARNONE,
                    VarReside = pa.Person.VARRESIDE,
                    VarStationed = pa.Person.VARSTATIONED,
                    VarStatus = pa.Person.VARSTATUS,
                    VarWorked = pa.Person.VARWORKED,
                    Address1 = pa.Address.ADDRESS_1,
                    Address2 = pa.Address.ADDRESS_2,
                    City = pa.Address.CITY,
                    StateId = pa.Address.STATE_ID,
                    StateDesc = pa.Address.STATE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.STATE_ID.Value) : null,
                    OtherStateDesc = pa.Address.OTHER_STATE_DESC,
                    CountryId = pa.Address.COUNTRY_ID,
                    CountryDesc = pa.Address.COUNTRY_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.COUNTRY_ID.Value) : null,
                    Zipcode = pa.Address.ZIPCODE,
                    PersonName = $"{pa.Person.FIRST_NAME} {(string.IsNullOrEmpty(pa.Person.MIDDLE_NAME) ? "" : pa.Person.MIDDLE_NAME)} {pa.Person.LAST_NAME} {(pa.Person.SUFFIX_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.SUFFIX_ID.Value) : "")}"
                });

            return await query.ToListAsync();
        }

        public async Task<List<ValidateRecord>> GetValidateRecordsAsync(int? personId, int? registrationTypeId, string startCreatedDate, string endCreatedDate)
        {
            var query = _context.TBL_PERSON
                .Where(p => p.IS_PRIMARY == true &&
                            (personId == null || p.PERSON_ID == personId) &&
                            (registrationTypeId == null || p.REGISTRATION_TYPE_ID == registrationTypeId) &&
                            (string.IsNullOrEmpty(startCreatedDate) || string.IsNullOrEmpty(endCreatedDate) ||
                             (p.VALIDATE_DATE >= DateTime.Parse(startCreatedDate) && p.VALIDATE_DATE <= DateTime.Parse(endCreatedDate).AddDays(1).AddSeconds(-1))))
                .Join(_context.TBL_ADDRESS,
                    p => p.PERSON_ID,
                    a => a.PERSON_ID,
                    (p, a) => new { Person = p, Address = a })
                .Where(pa => pa.Address.IS_CURRENT == 1)
                .Select(pa => new ValidateRecord
                {
                    AlternatePhone = pa.Person.ALTERNATE_PHONE,
                    Comments = pa.Person.COMMENTS,
                    CreatedBy = pa.Person.CREATED_BY,
                    CreatedDate = pa.Person.CREATED_DATE,
                    EditedBy = pa.Person.EDITED_BY,
                    EditedDate = pa.Person.EDITED_DATE,
                    EmailAddress = pa.Person.EMAIL_ADDRESS,
                    FirstName = pa.Person.FIRST_NAME,
                    HearAboutUsId = pa.Person.HEAR_ABOUT_US_ID,
                    IsPrimary = pa.Person.IS_PRIMARY,
                    IsStaging = pa.Person.IS_STAGING,
                    LastName = pa.Person.LAST_NAME,
                    MiddleName = pa.Person.MIDDLE_NAME,
                    OtherHearAboutUsDesc = pa.Person.OTHER_HEAR_ABOUT_US_DESC,
                    PersonId = pa.Person.PERSON_ID,
                    PrimaryId = pa.Person.PRIMARY_ID,
                    PrimaryPhone = pa.Person.PRIMARY_PHONE,
                    RegistrationTypeId = pa.Person.REGISTRATION_TYPE_ID,
                    RegistrationTypeDesc = pa.Person.REGISTRATION_TYPE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.REGISTRATION_TYPE_ID.Value) : null,
                    SuffixId = pa.Person.SUFFIX_ID,
                    SuffixDesc = pa.Person.SUFFIX_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.SUFFIX_ID.Value) : null,
                    VarNone = pa.Person.VARNONE,
                    VarReside = pa.Person.VARRESIDE,
                    VarStationed = pa.Person.VARSTATIONED,
                    VarStatus = pa.Person.VARSTATUS,
                    VarWorked = pa.Person.VARWORKED,
                    Address1 = pa.Address.ADDRESS_1,
                    Address2 = pa.Address.ADDRESS_2,
                    City = pa.Address.CITY,
                    StateId = pa.Address.STATE_ID,
                    StateDesc = pa.Address.STATE_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.STATE_ID.Value) : null,
                    OtherStateDesc = pa.Address.OTHER_STATE_DESC,
                    CountryId = pa.Address.COUNTRY_ID,
                    CountryDesc = pa.Address.COUNTRY_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Address.COUNTRY_ID.Value) : null,
                    Zipcode = pa.Address.ZIPCODE,
                    PersonName = $"{pa.Person.FIRST_NAME} {(string.IsNullOrEmpty(pa.Person.MIDDLE_NAME) ? "" : pa.Person.MIDDLE_NAME)} {pa.Person.LAST_NAME} {(pa.Person.SUFFIX_ID.HasValue ? _lookupCodeRepository.GetLookupCodeDescription(pa.Person.SUFFIX_ID.Value) : "")}"
                });

            return await query.ToListAsync();
        }

        public async Task<WeeklyReportResultDTO> GetWeeklyReportAsync(DateTime startDate, DateTime endDate)
        {
            var validatedRecordsCount = await _context.TBL_PERSON
                .CountAsync(p => p.IS_PRIMARY == true &&
                                 p.VALIDATE_DATE >= startDate &&
                                 p.VALIDATE_DATE <= endDate.AddDays(1).AddSeconds(-1));

            var evaluatedRecordsCount = await _context.TBL_PERSON
                .CountAsync(p => p.IS_STAGING == false &&
                                 p.IS_PRIMARY == false &&
                                 p.VALIDATE_DATE >= startDate &&
                                 p.VALIDATE_DATE <= endDate.AddDays(1).AddSeconds(-1));

            var reviewedRecordsCount = validatedRecordsCount + evaluatedRecordsCount;

            return new WeeklyReportResultDTO
            {
                ReviewedRecords = reviewedRecordsCount,
                ValidatedRecords = validatedRecordsCount,
                EvaluatedRecords = evaluatedRecordsCount
            };
        }

        public async Task<List<SuspectAddressRecord>> GetSuspectAddressReportAsync(int addressNoteId)
        {
            var query = from person in _context.TBL_PERSON
                        join address in _context.TBL_ADDRESS on person.PERSON_ID equals address.PERSON_ID
                        join suffix in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "SUFFIX") on person.SUFFIX_ID equals suffix.ID into personSuffix
                        from suffix in personSuffix.DefaultIfEmpty()
                        join state in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "STATE") on address.STATE_ID equals state.ID into addressState
                        from state in addressState.DefaultIfEmpty()
                        join country in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "COUNTRY") on address.COUNTRY_ID equals country.ID into addressCountry
                        from country in addressCountry.DefaultIfEmpty()
                        join addressNote in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "ADDRESS_NOTE") on person.address_note_id equals addressNote.ID into personAddressNote
                        from addressNote in personAddressNote.DefaultIfEmpty()
                        where person.IS_PRIMARY == true &&
                              (addressNoteId == 1 || person.address_note_id == addressNoteId)
                        orderby person.address_note_id, person.LAST_NAME, person.FIRST_NAME
                        select new SuspectAddressRecord
                        {
                            LastName = person.LAST_NAME,
                            FirstName = person.FIRST_NAME,
                            AddressNoteDate = person.address_note_dt,
                            MiddleName = person.MIDDLE_NAME ?? "",
                            City = address.CITY,
                            Zipcode = address.ZIPCODE,
                            Address1 = address.ADDRESS_1,
                            OtherStateDesc = address.OTHER_STATE_DESC ?? "",
                            Address2 = address.ADDRESS_2 ?? "",
                            StateDesc = state != null ? state.NAME : "",
                            CountryDesc = country != null ? country.NAME : "",
                            NotesDesc = addressNote != null ? addressNote.DESCRIPTION : ""
                        };

            return await query.ToListAsync();
        }

        public async Task<List<DuplicateRecord>> GetDuplicateRecordsAsync(int personId, string lastName, string firstName, decimal primaryPhone, string city, string zipcode, int stateId, int countryId, string address2, string address1)
        {
            var firstLastColonConcat = $"{firstName.Trim().ToUpper()}:{lastName.Trim().ToUpper()}";
            var firstLastColonConcatRev = $"{lastName.Trim().ToUpper()}:{firstName.Trim().ToUpper()}";
            var addressConcat = $"{address1.Trim().ToUpper()}:{address2.Trim().ToUpper()}:{city.Trim().ToUpper()}:{stateId.ToString().Trim().ToUpper()}:{zipcode.Trim().ToUpper()}:{countryId.ToString().Trim().ToUpper()}";

            var query = from person in _context.TBL_PERSON
                        join address in _context.TBL_ADDRESS on person.PERSON_ID equals address.PERSON_ID into personAddress
                        from address in personAddress.DefaultIfEmpty()
                        join suffix in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "SUFFIX") on person.SUFFIX_ID equals suffix.ID into personSuffix
                        from suffix in personSuffix.DefaultIfEmpty()
                        join state in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "STATE") on address.STATE_ID equals state.ID into addressState
                        from state in addressState.DefaultIfEmpty()
                        join country in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "COUNTRY") on address.COUNTRY_ID equals country.ID into addressCountry
                        from country in addressCountry.DefaultIfEmpty()
                        where person.IS_PRIMARY == true &&
                              (($"{person.FIRST_NAME.Trim().ToUpper()}:{person.LAST_NAME.Trim().ToUpper()}" == firstLastColonConcat ||
                                $"{person.FIRST_NAME.Trim().ToUpper()}:{person.LAST_NAME.Trim().ToUpper()}" == firstLastColonConcatRev ||
                                person.PRIMARY_PHONE == primaryPhone ||
                                $"{address.ADDRESS_1.Trim().ToUpper()}:{address.ADDRESS_2.Trim().ToUpper()}:{address.CITY.Trim().ToUpper()}:{address.STATE_ID.ToString().Trim().ToUpper()}:{address.ZIPCODE.Trim().ToUpper()}:{address.COUNTRY_ID.ToString().Trim().ToUpper()}" == addressConcat) &&
                               person.PERSON_ID != personId)
                        select new DuplicateRecord
                        {
                            PersonId = person.PERSON_ID,
                            LastName = person.LAST_NAME,
                            FirstName = person.FIRST_NAME,
                            MiddleName = person.MIDDLE_NAME,
                            EmailAddress = person.EMAIL_ADDRESS,
                            RegistrationTypeId = person.REGISTRATION_TYPE_ID,
                            SuffixId = person.SUFFIX_ID,
                            PrimaryPhone = person.PRIMARY_PHONE,
                            AlternatePhone = person.ALTERNATE_PHONE,
                            OtherHearAboutUsDesc = person.OTHER_HEAR_ABOUT_US_DESC,
                            HearAboutUsId = person.HEAR_ABOUT_US_ID,
                            IsStaging = person.IS_STAGING,
                            IsPrimary = person.IS_PRIMARY,
                            PrimaryId = person.PRIMARY_ID,
                            ValidateDate = person.VALIDATE_DATE,
                            AddressNoteDate = person.address_note_dt,
                            AddressNoteId = person.address_note_id,
                            AddressId = address != null ? address.ADDRESS_ID : 0,
                            City = address != null ? address.CITY : null,
                            Zipcode = address != null ? address.ZIPCODE : null,
                            StateId = address != null ? address.STATE_ID : null,
                            CountryId = address != null ? address.COUNTRY_ID : null,
                            Address2 = address != null ? address.ADDRESS_2 : null,
                            OtherStateDesc = address != null ? address.OTHER_STATE_DESC : null,
                            Address1 = address != null ? address.ADDRESS_1 : null
                        };

            return await query.ToListAsync();
        }

        public async Task<List<WeeklyReportRecord>> GetFullWeeklyReportAsync(DateTime startDate, DateTime endDate)
        {
            var query = from person in _context.TBL_PERSON
                        join address in _context.TBL_ADDRESS on person.PERSON_ID equals address.PERSON_ID
                        join suffix in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "SUFFIX") on person.SUFFIX_ID equals suffix.ID into personSuffix
                        from suffix in personSuffix.DefaultIfEmpty()
                        join state in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "STATE") on address.STATE_ID equals state.ID into addressState
                        from state in addressState.DefaultIfEmpty()
                        join country in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "COUNTRY") on address.COUNTRY_ID equals country.ID into addressCountry
                        from country in addressCountry.DefaultIfEmpty()
                        where person.IS_PRIMARY == true &&
                              person.VALIDATE_DATE >= startDate &&
                              person.VALIDATE_DATE <= endDate.AddDays(1).AddSeconds(-1)
                        select new WeeklyReportRecord
                        {
                            PersonId = person.PERSON_ID,
                            LastName = person.LAST_NAME,
                            FirstName = person.FIRST_NAME,
                            MiddleName = person.MIDDLE_NAME ?? "",
                            PrimaryPhone = person.PRIMARY_PHONE,
                            SuffixDesc = suffix != null ? suffix.NAME : "",
                            City = address.CITY,
                            Zipcode = address.ZIPCODE,
                            Address1 = address.ADDRESS_1,
                            OtherStateDesc = address.OTHER_STATE_DESC ?? "",
                            Address2 = address.ADDRESS_2 ?? "",
                            StateDesc = state != null ? state.NAME : "",
                            CountryDesc = country != null ? country.NAME : ""
                        };

            return await query.ToListAsync();
        }

        public async Task<List<RegistrySummaryReportRecord>> GetRegistrySummaryReportAsync()
        {
            var primaryRecords = await GetRegistrySummaryReportRecordsAsync(true, false);
            var duplicateRecords = await GetRegistrySummaryReportRecordsAsync(false, false);
            var stageRecords = await GetRegistrySummaryReportRecordsAsync(false, true);

            var totalPrimaryRecords = await _context.TBL_PERSON.CountAsync(p => p.IS_PRIMARY == true);
            var totalDuplicateRecords = await _context.TBL_PERSON.CountAsync(p => p.IS_PRIMARY == false && p.IS_STAGING == false);
            var totalStageRecords = await _context.TBL_PERSON.CountAsync(p => p.IS_PRIMARY == false && p.IS_STAGING == true);
            var totalRecords = await _context.TBL_PERSON.CountAsync();

            var result = new List<RegistrySummaryReportRecord>();

            result.AddRange(primaryRecords);
            result.Add(new RegistrySummaryReportRecord { DisplayIndex = 1, RecordType = "PRIMARY RECORDS TOTAL : ", TotalCount = totalPrimaryRecords });

            result.AddRange(duplicateRecords);
            result.Add(new RegistrySummaryReportRecord { DisplayIndex = 2, RecordType = "DUPLICATE RECORDS TOTAL : ", TotalCount = totalDuplicateRecords });

            result.AddRange(stageRecords);
            result.Add(new RegistrySummaryReportRecord { DisplayIndex = 3, RecordType = "STAGE RECORDS TOTAL : ", TotalCount = totalStageRecords });

            result.Add(new RegistrySummaryReportRecord { DisplayIndex = 4, RecordType = "TOTAL RECORDS : ", TotalCount = totalRecords });

            return result.OrderBy(r => r.DisplayIndex).ThenBy(r => r.RecordType).ToList();
        }

        private async Task<List<RegistrySummaryReportRecord>> GetRegistrySummaryReportRecordsAsync(bool isPrimary, bool isStaging)
        {
            var query = from registrationType in _context.LookupCodes.Where(lc => lc.CODE_TYPE == "REGISTRATION_TYPE")
                        join person in _context.TBL_PERSON on registrationType.ID equals person.REGISTRATION_TYPE_ID into personGroup
                        from p in personGroup.DefaultIfEmpty()
                        where p == null || (p.IS_PRIMARY == isPrimary && p.IS_STAGING == isStaging)
                        group p by registrationType.NAME into g
                        select new RegistrySummaryReportRecord
                        {
                            DisplayIndex = isPrimary ? 1 : (isStaging ? 3 : 2),
                            RecordType = isPrimary ? "PRIMARY RECORDS" : (isStaging ? "STAGE RECORDS" : "DUPLICATE RECORDS"),
                            RegistrationTypeDesc = g.Key,
                            UserCount = g.Count(p => p != null)
                        };

            return await query.ToListAsync();
        }

    }
}