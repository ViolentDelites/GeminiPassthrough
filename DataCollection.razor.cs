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

        private Model model = new Model();

        private List<LookupCode> SuffixList = new List<LookupCode>();
        private List<LookupCode> StateList = new List<LookupCode>();
        private List<LookupCode> CountryList = new List<LookupCode>();
        private List<LookupCode> HearAboutUsList = new List<LookupCode>();

        private bool IsStateTextVisible;
        private bool IsHearAboutUsTextVisible;

        protected override async Task OnInitializedAsync()
        {
            SuffixList = (await LookupCodeRepository.ListSuffix()).ToList();
            StateList = (await LookupCodeRepository.ListStates()).ToList();
            CountryList = (await LookupCodeRepository.ListCountries()).ToList();
            HearAboutUsList = (await LookupCodeRepository.ListHearAboutUS()).ToList();
        }

        private void OnStateChanged(ChangeEventArgs e)
        {
            model.StateId = Convert.ToInt32(e.Value);
            var selectedState = StateList.Find(s => s.ID == model.StateId);
            IsStateTextVisible = selectedState?.DESCRIPTION.ToUpper().Trim() == "OTHER";
        }

        private void OnHearAboutUsChanged(ChangeEventArgs e)
        {
            model.HearAboutUsId = Convert.ToInt32(e.Value);
            var selectedHearAboutUs = HearAboutUsList.Find(h => h.ID == model.HearAboutUsId);
            IsHearAboutUsTextVisible = selectedHearAboutUs?.DESCRIPTION.ToUpper().Trim() == "OTHER";
        }

        private async Task UpdateHearAboutUsVisibility()
        {
            LookupCode description = await LookupCodeRepository.GetHearAboutUsDescriptionById(model.HearAboutUsId);
            IsHearAboutUsTextVisible = model.HearAboutUsId == 0 || description?.DESCRIPTION.ToUpper().Trim() == "MAGAZINE AD";
        }

        private async Task HandleValidSubmit()
        {
            Person person = new Person
            {
                FIRST_NAME = model.FirstName.Trim(),
                MIDDLE_NAME = string.IsNullOrWhiteSpace(model.MiddleInitial?.Trim()) ? null : model.MiddleInitial.Trim(),
                LAST_NAME = model.LastName.Trim(),
                SUFFIX_ID = model.SuffixId == 0 ? null : model.SuffixId,
                PRIMARY_PHONE = decimal.Parse(model.PrimaryPhone.Trim()),
                ALTERNATE_PHONE = string.IsNullOrWhiteSpace(model.AlternatePhone?.Trim())
                                    ? null
                                    : decimal.TryParse(model.AlternatePhone.Trim(), out var parsedPhone) ? parsedPhone : null,
                EMAIL_ADDRESS = string.IsNullOrWhiteSpace(model.EmailAddress?.Trim()) ? null : model.EmailAddress.Trim(),
                HEAR_ABOUT_US_ID = model.HearAboutUsId == 0 ? null : model.HearAboutUsId,
                OTHER_HEAR_ABOUT_US_DESC = model.HearAboutUsText,
                REGISTRATION_TYPE_ID = 1, // Online, Fix this hardcode
                IS_PRIMARY = false,
                IS_STAGING = true
            };

            Address address = new Address
            {
                ADDRESS_1 = model.Address1.Trim(),
                ADDRESS_2 = string.IsNullOrWhiteSpace(model.Address2?.Trim()) ? null : model.Address2.Trim(),
                CITY = model.City.Trim(),
                STATE_ID = model.StateId,
                OTHER_STATE_DESC = string.IsNullOrWhiteSpace(model.StateText?.Trim()) ? null : model.StateText.Trim(),
                ZIPCODE = model.ZipCode.Trim(),
                COUNTRY_ID = model.CountryId
            };

            Comment comment = new Comment { COMMENT = "" };

            if (!await PersonRepository.IsDuplicateAsync(person, address))
            {
                await PersonRepository.InsertCollectionForm(person, address, 99999, comment);
                this.NavigationManager.NavigateTo("/closing-statement");
            }
            else
            {
                this.NavigationManager.NavigateTo("/duplicate-record-found");
            }
        }

        private class Model
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public int SuffixId { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public int StateId { get; set; }
            public string StateText { get; set; }
            public string ZipCode { get; set; }
            public int CountryId { get; set; }
            public string PrimaryPhone { get; set; }
            public string AlternatePhone { get; set; }
            public string EmailAddress { get; set; }
            public int HearAboutUsId { get; set; }
            public string HearAboutUsText { get; set; }
        }
    }
}