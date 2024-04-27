using System;
using clwater_new.Models;
using clwater_new.Services;
using NLog;

namespace clwater_new.clwater.pages
{
    public partial class DataCollection : System.Web.UI.Page
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            Address address = new Address();
            PersonService personSvc = new PersonService();
            try
            {
                person.FirstName = tbFirstName.Text.Trim();
                person.MiddleInitial = (tbMName.Text.Trim() == "" ? null : tbMName.Text.Trim());
                person.LastName = tbLastName.Text.Trim();
                person.SuffixId = (tbSuffix.SelectedItem.Value == "0" ? 0 : Convert.ToInt32(tbSuffix.SelectedItem.Value));
                person.PrimaryPhone = tbPhoneNo.Text.Trim();
                person.AlternatePhone = (altPhoneNo.Text.Trim() == "" ? null : altPhoneNo.Text.Trim());
                person.EmailAddress = (tbEmailAddress.Text.Trim() == "" ? null : tbEmailAddress.Text.Trim());
                person.HearAboutUsId = (tbHearAboutUs.SelectedItem.Value == "0" ? 0 : Convert.ToInt32(tbHearAboutUs.SelectedItem.Value));
                person.OtherHearAboutUsId = tbHearAboutUsText.Text;
                person.RegistrationTypeId = 1; //Online
                person.IsPrimary = 0;
                person.IsStaging = 1;
                address.Address1 = tbAddress1.Text.Trim();
                address.Address2 = (tbAddress2.Text.Trim() == "" ? null : tbAddress2.Text.Trim());
                address.City = tbCity.Text.Trim();
                address.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
                address.OtherStateDescription = (ddlStateText.Text.Trim() == "" ? null : ddlStateText.Text.Trim());
                address.ZipCode = tbZipCode.Text.Trim();
                address.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                Comment comment = new Comment { CommentDesc = "" };
                if (!personSvc.IsDuplicte(person, address))
                    personSvc.InsertCollectionForm(person, address, 99999, comment);
                else
                    Response.Redirect("DuplicateRecordFound.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("InvalidRecord.aspx");
            }
            Response.Redirect("ClosingStatement.aspx");
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.SelectedItem.Text.ToUpper() == "OTHER")
            {
                ddlStateText.Enabled = true;
                ddlStateText.Visible = true;
            }
            else
            {
                ddlStateText.Text = "";
                ddlStateText.Visible = false;
                ddlStateText.Enabled = false;
            }
        }

        protected void tbHearAboutUs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbHearAboutUs.SelectedItem.Text.ToUpper().Trim() == "OTHER" || tbHearAboutUs.SelectedItem.Text.ToUpper().Trim() == "MAGAZINE AD")
                {
                    tbHearAboutUsText.Enabled = true;
                    tbHearAboutUsText.Visible = true;
                }
                else
                {
                    tbHearAboutUsText.Text = "";
                    tbHearAboutUsText.Visible = false;
                    tbHearAboutUsText.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                logger.Debug($"Potential Errors with Dropdown Text box. See Errors below:");
                logger.Debug(ex.Message);
            }
        }
    }
}