using ISB.CLWater.Web.ViewModels;

namespace ISB.CLWater.Web.Components.Pages
{
    public partial class DataCollection : ComponentBase
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [Inject]
        protected PersonService PersonSvc { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        private string tbFirstName;
        private string tbMName;
        private string tbLastName;
        private string tbSuffix;
        private string tbPhoneNo;
        private string altPhoneNo;
        private string tbEmailAddress;
        private string tbHearAboutUs;
        private string tbHearAboutUsText;
        private string tbAddress1;
        private string tbAddress2;
        private string tbCity;
        private string ddlState;
        private string ddlStateText;
        private string tbZipCode;
        private string ddlCountry;

        private async Task SubmitForm()
        {
            Person person = new Person();
            Address address = new Address();

            try
            {
                person.FirstName = tbFirstName.Trim();
                person.MiddleInitial = string.IsNullOrWhiteSpace(tbMName.Trim()) ? null : tbMName.Trim();
                person.LastName = tbLastName.Trim();
                person.SuffixId = tbSuffix == "0" ? 0 : Convert.ToInt32(tbSuffix);
                person.PrimaryPhone = tbPhoneNo.Trim();
                person.AlternatePhone = string.IsNullOrWhiteSpace(altPhoneNo.Trim()) ? null : altPhoneNo.Trim();
                person.EmailAddress = string.IsNullOrWhiteSpace(tbEmailAddress.Trim()) ? null : tbEmailAddress.Trim();
                person.HearAboutUsId = tbHearAboutUs == "0" ? 0 : Convert.ToInt32(tbHearAboutUs);
                person.OtherHearAboutUsId = tbHearAboutUsText;
                person.RegistrationTypeId = 1; //Online
                person.IsPrimary = 0;
                person.IsStaging = 1;

                address.Address1 = tbAddress1.Trim();
                address.Address2 = string.IsNullOrWhiteSpace(tbAddress2.Trim()) ? null : tbAddress2.Trim();
                address.City = tbCity.Trim();
                address.StateId = Convert.ToInt32(ddlState);
                address.OtherStateDescription = string.IsNullOrWhiteSpace(ddlStateText.Trim()) ? null : ddlStateText.Trim();
                address.ZipCode = tbZipCode.Trim();
                address.CountryId = Convert.ToInt32(ddlCountry);

                Comment comment = new Comment { CommentDesc = "" };

                if (!await PersonSvc.IsDuplicate(person, address))
                    await PersonSvc.InsertCollectionForm(person, address, 99999, comment);
                else
                    NavigationManager.NavigateTo("DuplicateRecordFound");
            }
            catch (Exception)
            {
                NavigationManager.NavigateTo("InvalidRecord");
            }

            NavigationManager.NavigateTo("ClosingStatement");
        }

        private void OnStateChanged(ChangeEventArgs e)
        {
            ddlState = e.Value.ToString();
            IsStateTextVisible = ddlState.ToUpper() == "OTHER";
        }

        private void OnHearAboutUsChanged(ChangeEventArgs e)
        {
            try
            {
                tbHearAboutUs = e.Value.ToString();
                IsHearAboutUsTextVisible = tbHearAboutUs.ToUpper().Trim() == "OTHER" || tbHearAboutUs.ToUpper().Trim() == "MAGAZINE AD";
            }
            catch (Exception ex)
            {
                logger.Debug($"Potential Errors with Dropdown Text box. See Errors below:");
                logger.Debug(ex.Message);
            }
        }
    }
}