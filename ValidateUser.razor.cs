namespace ISB.CLWater.Web.Components.Internal.Pages
{
    public partial class ValidateUser : AuthorizedComponentBase
    {
        [Parameter]
        public int PersonId { get; set; }
        private ValidateUserModel model = new ValidateUserModel();
        public List<SearchResultDTO> SearchResults { get; set; }
        public bool ShowComparisonPanel { get; set; }
        public bool CanSave { get; set; }
        public int userId { get; set; }
        public bool CanEditStageRecord { get; set; }
        public bool CanEditComparisonRecord { get; set; }
        public List<LookupCode> SuffixList { get; set; }
        public List<LookupCode> StateList { get; set; }
        public List<LookupCode> CountryList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.CheckAuthorizationAsync();

            userId = await base.GetCurrentUserIdAsync();
            PersonId = await base.GetPersonIdAsync();

            SuffixList = (await base.LookupCodeRepository.ListSuffix()).ToList();
            StateList = (await base.LookupCodeRepository.ListStates()).ToList();
            CountryList = (await base.LookupCodeRepository.ListCountries()).ToList();

            await LoadPersonRecord(PersonId, 1);
            await LoadSearchResults();
        }

        private async Task LoadPersonRecord(int personId, int recordViewPanel)
        {
            try
            {
                var person = await base.PersonRepository.RetrievePersonAsync(personId);
                var address = await base.AddressRepository.RetrieveAddressAsync(personId);

                if (recordViewPanel == 1)
                {
                    // Load Stage Record fields
                    model.RegistrationType = base.LookupCodeRepository.GetLookupCodeDescription(person.REGISTRATION_TYPE_ID ?? 0);
                    model.LastName = person.LAST_NAME;
                    model.FirstName = person.FIRST_NAME;
                    model.MiddleInitial = person.MIDDLE_NAME;
                    model.SuffixId = person.SUFFIX_ID ?? 0;
                    model.PrimaryPhone = person.PRIMARY_PHONE?.ToString();
                    model.AlternatePhone = person.ALTERNATE_PHONE?.ToString();
                    model.EmailAddress = person.EMAIL_ADDRESS;
                    model.Address1 = address?.ADDRESS_1;
                    model.Address2 = address?.ADDRESS_2;
                    model.City = address?.CITY;
                    model.StateId = address?.STATE_ID ?? 0;
                    model.OtherStateText = address?.OTHER_STATE_DESC;
                    model.ZipCode = address?.ZIPCODE;
                    model.CountryId = address?.COUNTRY_ID ?? 0;
                    model.IsPrimary = person.IS_PRIMARY ?? false;
                    CanEditStageRecord = person.IS_STAGING ?? false;

                    CanSave = model.IsPrimary;
                }
                else
                {
                    // Load Comparison Record fields
                    model.ComparisonPersonId = person.PERSON_ID;
                    model.ComparisonRegistrationType = base.LookupCodeRepository.GetLookupCodeDescription(person.REGISTRATION_TYPE_ID ?? 0);
                    model.ComparisonLastName = person.LAST_NAME;
                    model.ComparisonFirstName = person.FIRST_NAME;
                    model.ComparisonMiddleInitial = person.MIDDLE_NAME;
                    model.ComparisonSuffixId = person.SUFFIX_ID ?? 0;
                    model.ComparisonPrimaryPhone = person.PRIMARY_PHONE?.ToString();
                    model.ComparisonAlternatePhone = person.ALTERNATE_PHONE?.ToString();
                    model.ComparisonEmailAddress = person.EMAIL_ADDRESS;
                    model.ComparisonAddress1 = address?.ADDRESS_1;
                    model.ComparisonAddress2 = address?.ADDRESS_2;
                    model.ComparisonCity = address?.CITY;
                    model.ComparisonStateId = address?.STATE_ID ?? 0;
                    model.ComparisonOtherStateText = address?.OTHER_STATE_DESC;
                    model.ComparisonZipCode = address?.ZIPCODE;
                    model.ComparisonCountryId = address?.COUNTRY_ID ?? 0;
                    model.ComparisonIsPrimary = person.IS_PRIMARY ?? false;
                    CanEditComparisonRecord = !model.ComparisonIsPrimary;

                    CanSave = model.ComparisonIsPrimary;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log the error, or display an error message
                // ...
            }
        }

        private async Task LoadSearchResults()
        {
            try
            {
                var person = new Person
                {
                    LAST_NAME = model.LastName,
                    FIRST_NAME = model.FirstName,
                    MIDDLE_NAME = model.MiddleInitial,
                    SUFFIX_ID = model.SuffixId,
                    PRIMARY_PHONE = decimal.Parse(model.PrimaryPhone),
                    IS_PRIMARY = true
                };

                var address = new Address
                {
                    ADDRESS_1 = model.Address1,
                    ADDRESS_2 = model.Address2,
                    CITY = model.City,
                    STATE_ID = model.StateId,
                    ZIPCODE = model.ZipCode,
                    COUNTRY_ID = model.CountryId
                };

                SearchResults = await base.PersonRepository.SearchPersonsAsync(person, address, PersonId);
            }
            catch (Exception ex)
            {
                // Handle the exception, log the error, or display an error message
                // ...
            }
        }

        private async Task CompareRecord(SearchResultDTO result)
        {
            try
            {
                await LoadPersonRecord(result.PersonId, 2);
                model.ComparisonIsPrimary = false;
                CanEditComparisonRecord = true;
                ShowComparisonPanel = true;
                CanSave = model.ComparisonIsPrimary;

                // Manually clear validation messages
                var editContext = new EditContext(model);
                var messages = new ValidationMessageStore(editContext);
                messages.Clear();
                editContext.NotifyValidationStateChanged();
            }
            catch (Exception ex)
            {
                // Handle the exception, log the error, or display an error message
                // ...
            }
        }
    

        private void ClearComparisonPanel()
        {
            model.ComparisonPersonId = 0;
            model.ComparisonRegistrationType = string.Empty;
            model.ComparisonLastName = string.Empty;
            model.ComparisonFirstName = string.Empty;
            model.ComparisonMiddleInitial = string.Empty;
            model.ComparisonSuffixId = 0;
            model.ComparisonPrimaryPhone = string.Empty;
            model.ComparisonAlternatePhone = string.Empty;
            model.ComparisonEmailAddress = string.Empty;
            model.ComparisonAddress1 = string.Empty;
            model.ComparisonAddress2 = string.Empty;
            model.ComparisonCity = string.Empty;
            model.ComparisonStateId = 0;
            model.ComparisonOtherStateText = string.Empty;
            model.ComparisonZipCode = string.Empty;
            model.ComparisonCountryId = 0;
            model.ComparisonIsPrimary = false;
            CanEditComparisonRecord = false;
            ShowComparisonPanel = false;
            CanSave = false;

            // Manually trigger form validation
            EditContext editContext = new EditContext(model);
            editContext.Validate();
        }

        private async Task SaveChanges()
        {
            try
            {
                var person = new Person
                {
                    PERSON_ID = PersonId,
                    LAST_NAME = model.LastName,
                    FIRST_NAME = model.FirstName,
                    MIDDLE_NAME = model.MiddleInitial,
                    SUFFIX_ID = model.SuffixId,
                    PRIMARY_PHONE = decimal.Parse(model.PrimaryPhone),
                    ALTERNATE_PHONE = string.IsNullOrEmpty(model.AlternatePhone) ? null : decimal.Parse(model.AlternatePhone),
                    EMAIL_ADDRESS = model.EmailAddress,
                    IS_PRIMARY = model.IsPrimary,
                    IS_STAGING = !model.IsPrimary,
                    PRIMARY_ID = model.ComparisonIsPrimary ? model.ComparisonPersonId : null
                };

                var address = new Address
                {
                    PERSON_ID = PersonId,
                    ADDRESS_1 = model.Address1,
                    ADDRESS_2 = model.Address2,
                    CITY = model.City,
                    STATE_ID = model.StateId,
                    OTHER_STATE_DESC = model.OtherStateText,
                    ZIPCODE = model.ZipCode,
                    COUNTRY_ID = model.CountryId
                };

                Person comparisonPerson = null;
                Address comparisonAddress = null;

                if (ShowComparisonPanel)
                {
                    comparisonPerson = new Person
                    {
                        PERSON_ID = model.ComparisonPersonId,
                        LAST_NAME = model.ComparisonLastName,
                        FIRST_NAME = model.ComparisonFirstName,
                        MIDDLE_NAME = model.ComparisonMiddleInitial,
                        SUFFIX_ID = model.ComparisonSuffixId,
                        PRIMARY_PHONE = decimal.Parse(model.ComparisonPrimaryPhone),
                        ALTERNATE_PHONE = string.IsNullOrEmpty(model.ComparisonAlternatePhone) ? null : decimal.Parse(model.ComparisonAlternatePhone),
                        EMAIL_ADDRESS = model.ComparisonEmailAddress,
                        IS_PRIMARY = model.ComparisonIsPrimary,
                        IS_STAGING = !model.ComparisonIsPrimary
                    };

                    comparisonAddress = new Address
                    {
                        PERSON_ID = model.ComparisonPersonId,
                        ADDRESS_1 = model.ComparisonAddress1,
                        ADDRESS_2 = model.ComparisonAddress2,
                        CITY = model.ComparisonCity,
                        STATE_ID = model.ComparisonStateId,
                        OTHER_STATE_DESC = model.ComparisonOtherStateText,
                        ZIPCODE = model.ComparisonZipCode,
                        COUNTRY_ID = model.ComparisonCountryId
                    };
                }

                // Save the changes
                await base.PersonRepository.ValidateUserAsync(userId, person, address, comparisonPerson, comparisonAddress);

                // Navigate back to the validation report page
                base.NavigationManager.NavigateTo("/Internal/ValidationReport");
            }
            catch (Exception ex)
            {
                // Handle the exception, log the error, or display an error message
                // ...
            }
        }

        private void NavigateBack()
        {
            base.NavigationManager.NavigateTo("/Internal/ValidationReport", forceLoad : true);
        }
    }

    public class ValidateUserModel
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }
        public string RegistrationType { get; set; }
        public int SuffixId { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string OtherStateText { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public bool IsPrimary { get; set; } = false;

        public int ComparisonPersonId { get; set; }
        public string ComparisonRegistrationType { get; set; }
        [Required]
        public string ComparisonLastName { get; set; }
        [Required]
        public string ComparisonFirstName { get; set; }
        public string ComparisonMiddleInitial { get; set; }
        public int ComparisonSuffixId { get; set; }
        public string ComparisonPrimaryPhone { get; set; }
        public string ComparisonAlternatePhone { get; set; }
        public string ComparisonEmailAddress { get; set; }
        public string ComparisonAddress1 { get; set; }
        public string ComparisonAddress2 { get; set; }
        public string ComparisonCity { get; set; }
        public int ComparisonStateId { get; set; }
        public string ComparisonOtherStateText { get; set; }
        public string ComparisonZipCode { get; set; }
        public int ComparisonCountryId { get; set; }
        public bool ComparisonIsPrimary { get; set; }
    }
}