namespace ISB.CLWater.Web.Components.Pages
{
    public partial class DataCollection : ComponentBase
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [Inject]
        private ILookupCodeRepository LookupCodeRepository { get; set; }
        [Inject]
        private IPersonRepository PersonRepository { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        
        private ValidationSummary ValidationSummary;

        private string LastName;
        private string FirstName;
        private string MiddleInitial;
        private int? SuffixId;
        private List<LookupCode> SuffixList;

        private string Address1;
        private string Address2;
        private string City;
        private int StateId;
        private List<LookupCode> StateList;
        private bool IsStateTextVisible;
        private string StateText;
        private string ZipCode;
        private int CountryId;
        private List<LookupCode> CountryList;

        private string PrimaryPhone;
        private string AlternatePhone;
        private string EmailAddress;

        private int HearAboutUsId;
        private List<LookupCode> HearAboutUsList;
        private bool IsHearAboutUsTextVisible;
        private string HearAboutUsText;

        protected override async Task OnInitializedAsync()
        {
            var SuffixResult = await LookupCodeRepository.ListSuffix();
            SuffixList = SuffixResult.ToList();
            var StatesResult = await LookupCodeRepository.ListStates();
            StateList = StatesResult.ToList();
            var CountriesResult = await LookupCodeRepository.ListCountries();
            CountryList = CountriesResult.ToList();
            var HearAboutUsResult = await LookupCodeRepository.ListHearAboutUS();
            HearAboutUsList = HearAboutUsResult.ToList();
        }

        private void OnStateChanged(ChangeEventArgs e)
        {
            StateId = Convert.ToInt32(e.Value);
            IsStateTextVisible = StateId == 0;
        }

        private async void OnHearAboutUsChanged(ChangeEventArgs e)
        {
            HearAboutUsId = Convert.ToInt32(e.Value);
            await UpdateHearAboutUsVisibility(); // Call async helper method
        }

        private async Task UpdateHearAboutUsVisibility()
        {
            LookupCode description = await LookupCodeRepository.GetHearAboutUsDescriptionById(HearAboutUsId);
            IsHearAboutUsTextVisible = HearAboutUsId == 0 || description?.Description.ToUpper().Trim() == "MAGAZINE AD";
        }

        private async Task HandleValidSubmit()
        {
            // Perform form submission logic here
            Person person = new Person
            {
                FIRST_NAME = FirstName.Trim(),
                MIDDLE_NAME = string.IsNullOrWhiteSpace(MiddleInitial?.Trim()) ? null : MiddleInitial.Trim(),
                LAST_NAME = LastName.Trim(),
                SUFFIX_ID = SuffixId == 0 ? null : SuffixId,
                PRIMARY_PHONE = decimal.Parse(PrimaryPhone.Trim()),
                ALTERNATE_PHONE = string.IsNullOrWhiteSpace(AlternatePhone?.Trim())
                                    ? null
                                    : decimal.TryParse(AlternatePhone.Trim(), out var parsedPhone) ? parsedPhone : null,
                EMAIL_ADDRESS = string.IsNullOrWhiteSpace(EmailAddress?.Trim()) ? null : EmailAddress.Trim(),
                HEAR_ABOUT_US_ID = HearAboutUsId == 0 ? null : HearAboutUsId,
                OTHER_HEAR_ABOUT_US_DESC = HearAboutUsText,
                REGISTRATION_TYPE_ID = 1, // Online
                IS_PRIMARY = false,
                IS_STAGING = true
            };

            Address address = new Address
            {
                ADDRESS_1 = Address1.Trim(),
                ADDRESS_2 = string.IsNullOrWhiteSpace(Address2?.Trim()) ? null : Address2.Trim(),
                CITY = City.Trim(),
                STATE_ID = StateId,
                OTHER_STATE_DESC = string.IsNullOrWhiteSpace(StateText?.Trim()) ? null : StateText.Trim(),
                ZIPCODE = ZipCode.Trim(),
                COUNTRY_ID = CountryId
            };

            Comment comment = new Comment { COMMENT = "" };

            if (!await PersonRepository.IsDuplicateAsync(person, address))
            {
                await PersonRepository.InsertCollectionForm(person, address, 99999, comment);
                // Navigate to success page or show success message
            }
            else
            {
                this.NavigationManager.NavigateTo("DuplicateRecordFound");
            }
        }
    }
}