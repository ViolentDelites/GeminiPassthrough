using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using clwater_new.Models;
using clwater_new.Services;
using NLog;

namespace clwater_new.Internal.pages
{
    public partial class ValidateUser : Page
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NoticeAccepted"]?.ToString() != "True")
                Response.Redirect("/internal/Notice.aspx", true);
            if (Session["UserId"] == null)
                Response.Redirect("/internal/pages/logon.aspx", true);
            if (!IsPostBack)
            {
                string strConnect = ConfigurationManager.ConnectionStrings["ClWaterDb"].ConnectionString;
                OleDbConnection conConnection = new OleDbConnection(strConnect);
                try
                {
                    conConnection.Open();
                    loadLookups(conConnection, tbSuffix, tbSuffix2,
                        "SELECT suffix_desc,suffix_id  FROM LK_Suffix where is_active=1", "suffix_desc", "suffix_id");
                    loadLookups(conConnection, tbState, tbState2,
                        "SELECT state_desc,state_id  FROM LK_State where is_active=1", "state_desc", "state_id");
                    loadLookups(conConnection, ddlCountry, ddlCountry2,
                        "SELECT country_desc,country_id  FROM LK_Country  where is_active=1", "country_desc",
                        "country_id");
                    ListItem listItem = ddlCountry.Items.FindByText("United States");
                    ddlCountry.Items.Remove(listItem);
                    ddlCountry2.Items.Remove(listItem);
                    ddlCountry.Items.Insert(1, listItem);
                    ddlCountry2.Items.Insert(1, listItem);
                    loadPersonRecord(conConnection, Session["CLNR_ID"]?.ToString(), 1);
                    lbl_userID.Text = (string)Session["CLNR_ID"];
                    loadSearchResults(gvSearchResults, true);
                }
                catch (Exception ex)
                {
                    Response.Write("An error has occurred while processing your request. ");
                }
                finally
                {
                    conConnection.Close();
                }
            }
        }

        protected void gvSearchResults_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                gvSearchResults.PageIndex = e.NewPageIndex;
                loadSearchResults(gvSearchResults, false);
            }
            catch (Exception ex)
            {
                Response.Write("An error has occurred while processing your request. ");
            }
        }

        public void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string strConnect = ConfigurationManager.ConnectionStrings["ClWaterDb"].ConnectionString;
            using (OleDbConnection conConnection = new OleDbConnection(strConnect))
            {
                try
                {
                    if (e.CommandName == "Compare")
                    {
                        int index = Convert.ToInt32(e.CommandArgument);
                        GridViewRow selectedRow = gvSearchResults.Rows[index];
                        ClearComparePanel();
                        conConnection.Open();
                        loadPersonRecord(conConnection, selectedRow.Cells[0].Text, 2);
                        cbPrimary2.Enabled = false;
                        cbIsPrimary.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("An error has occurred while processing your request. ");
                }
                finally
                {
                    conConnection.Close();
                }
            }
        }

        private void ClearComparePanel()
        {
            lbRegistrationType2.Text = "";
            tbFirstName2.Text = "";
            tbLastName2.Text = "";
            tbMiddleName2.Text = "";
            tbAddress1_2.Text = "";
            tbAddress2_2.Text = "";
            tbcity2.Text = "";
            tbzipcode2.Text = "";
            tbPrimaryPhone2.Text = "";
            lbid2.Text = "";
            cbPrimary2.Checked = false;
            pnlComparison.Visible = false;
            btnClear.Enabled = false;
            tbSuffix2.SelectedIndex = 0;
            tbState2.SelectedIndex = 0;
            ddlCountry2.SelectedIndex = 0;
            tbOtherStateText2.Text = "";
            tbAltPhone2.Text = "";
            tbEmailAddress2.Text = "";
            tbOtherStateText2.Visible = false;
            rfvLastName2.Enabled = false;
            rfvFirstName2.Enabled = false;
            rfvPrimaryPhone2.Enabled = false;
            rfvAddress1_2.Enabled = false;
            rfvcity2.Enabled = false;
            rfvZipCode2.Enabled = false;
            rfvState2.Enabled = false;
            rfvCountry2.Enabled = false;
            revAltPhone2.Enabled = false;
            revPrimaryPhone2.Enabled = false;
            revEmailAddress2.Enabled = false;
        }
        protected void btnClear_Click(object sender, System.EventArgs e)
        {
            ClearComparePanel();
            cbIsPrimary.Enabled = true;
            if (cbIsPrimary.Checked == true)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        protected void cbIsPrimary_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbIsPrimary.Checked == true & pnlComparison.Visible == true)
            {
                showHideEdit(1, true, BorderStyle.Inset);
                cbPrimary2.Checked = false;
                showHideEdit(2, false, BorderStyle.None);
                btnSave.Enabled = true;
            }
            else if (cbIsPrimary.Checked == true & pnlComparison.Visible == false)
            {
                showHideEdit(1, true, BorderStyle.Inset);
                btnSave.Enabled = true;
            }
            else if (cbIsPrimary.Checked == false & pnlComparison.Visible == false)
            {
                showHideEdit(1, false, BorderStyle.None);
                btnSave.Enabled = false;
            }
            else if (cbIsPrimary.Checked == false & pnlComparison.Visible == true & cbPrimary2.Checked == false)
            {
                btnSave.Enabled = false;
                showHideEdit(1, false, BorderStyle.None);
                showHideEdit(2, false, BorderStyle.None);
            }

            if (btnSave.Enabled == true)
            {
            }
            else
            {
                showHideEdit(1, false, BorderStyle.None);
            }
        }

        protected void cbPrimary2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbPrimary2.Checked == true)
            {
                cbIsPrimary.Checked = false;
                showHideEdit(1, false, BorderStyle.None);
                showHideEdit(2, true, BorderStyle.Inset);
                btnSave.Enabled = true;
            }
            else if (cbPrimary2.Checked == false && cbIsPrimary.Checked == false)
            {
                showHideEdit(1, false, BorderStyle.None);
                showHideEdit(2, false, BorderStyle.None);
                btnSave.Enabled = false;
            }
            else if (cbPrimary2.Checked == false && cbIsPrimary.Checked == true)
            {
                showHideEdit(1, true, BorderStyle.Inset);
                showHideEdit(2, false, BorderStyle.None);
                btnSave.Enabled = true;
            }
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            bool proceedFlag = true;
            if (pnlComparison.Visible)
            {
                if (cbIsPrimary.Checked == false && cbPrimary2.Checked == false)
                {
                    proceedFlag = false;
                }
            }
            else
            {
                if (cbIsPrimary.Checked == false)
                {
                    proceedFlag = false;
                }
            }
            if (proceedFlag)
            {
                try
                {
                    Person person = new Person();
                    Address address = new Address();
                    Address compAddress = null;
                    Person compPerson = null;
                    person.FirstName = tbFirstName.Text.Trim();
                    person.MiddleInitial = (string.IsNullOrEmpty(tbMName.Text.Trim()) ? null : tbMName.Text.Trim());
                    person.LastName = tbLastName.Text.Trim();
                    person.SuffixId = (tbSuffix.SelectedItem.Value == "0" ? 0 : Convert.ToInt32(tbSuffix.SelectedItem.Value));
                    person.PrimaryPhone = tbPrimaryPhone.Text.Trim();
                    person.AlternatePhone = (string.IsNullOrEmpty(tbAltPhone.Text.Trim()) ? null : tbAltPhone.Text.Trim());
                    person.EmailAddress = (string.IsNullOrEmpty(tbEmailAddress.Text.Trim()) ? null : tbEmailAddress.Text.Trim());
                    if (cbIsPrimary.Checked)
                    {
                        person.IsPrimary = 1;
                        person.IsStaging = 0;
                    }
                    else
                    {
                        person.IsPrimary = 0;
                        person.IsStaging = 0;
                    }
                    if (cbPrimary2.Checked)
                    {
                        person.PrimaryId = Convert.ToInt32(lbid2.Text.Trim());
                    }
                    else
                    {
                        person.PrimaryId = null;
                    }
                    if ((lbl_userID.Text == Session["CLNR_ID"]?.ToString()))
                    {
                        person.PersonId = Convert.ToInt32(lbl_userID.Text);
                    }
                    else
                    {
                        throw new Exception("Session ID != Form ID on Validating Record. Contact Site Admin!");
                    }
                    if (cbIsPrimary.Checked)
                    {
                        address.PersonId = Convert.ToInt32(lbl_userID.Text);
                        address.Address1 = tbaddress1.Text.Trim();
                        address.Address2 = (string.IsNullOrEmpty(tbaddress2.Text.Trim()) ? null : tbaddress2.Text.Trim());
                        address.City = tbcity.Text.Trim();
                        address.StateId = Convert.ToInt32(tbState.SelectedItem.Value);
                        address.OtherStateDescription = (string.IsNullOrEmpty(tbOtherStateText.Text.Trim()) ? null : tbOtherStateText.Text.Trim());
                        address.ZipCode = tbZipCode.Text.Trim();
                        address.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                    }
                    if (pnlComparison.Visible)
                    {
                        compPerson = new Person
                        {
                            PersonId = Convert.ToInt32(lbid2.Text.Trim()),
                            FirstName = tbFirstName2.Text.Trim(),
                            MiddleInitial = (string.IsNullOrEmpty(tbMiddleName2.Text.Trim())
                                ? null
                                : tbMiddleName2.Text.Trim()),
                            LastName = tbLastName2.Text.Trim(),
                            SuffixId = (tbSuffix2.SelectedItem.Value == "0"
                                ? 0
                                : Convert.ToInt32(tbSuffix2.SelectedItem.Value)),
                            PrimaryPhone = tbPrimaryPhone2.Text.Trim(),
                            AlternatePhone = (string.IsNullOrEmpty(tbAltPhone2.Text.Trim())
                                ? null
                                : tbAltPhone2.Text.Trim()),
                            EmailAddress = (string.IsNullOrEmpty(tbEmailAddress2.Text.Trim())
                                ? null
                                : tbEmailAddress2.Text.Trim())
                        };
                        if (cbPrimary2.Checked)
                        {
                            compPerson.IsPrimary = 1;
                            compPerson.IsStaging = 0;
                        }
                        else
                        {
                            compPerson.IsPrimary = 0;
                            compPerson.IsStaging = 0;
                        }
                        if (cbPrimary2.Checked)
                        {
                            compAddress = new Address
                            {
                                PersonId = Convert.ToInt32(lbid2.Text),
                                Address1 = tbAddress1_2.Text.Trim(),
                                Address2 = (string.IsNullOrEmpty(tbAddress2_2.Text.Trim())
                                    ? null
                                    : tbAddress2_2.Text.Trim()),
                                City = tbcity2.Text.Trim(),
                                StateId = Convert.ToInt32(tbState2.SelectedItem.Value),
                                OtherStateDescription = (string.IsNullOrEmpty(tbOtherStateText2.Text.Trim())
                                    ? null
                                    : tbOtherStateText2.Text.Trim()),
                                ZipCode = tbzipcode2.Text.Trim(),
                                CountryId = Convert.ToInt32(ddlCountry2.SelectedItem.Value)
                            };
                        }
                    }
                    PersonService peopleService = new PersonService();
                    int editUserID = Convert.ToInt32(Session["UserId"]?.ToString().Trim());
                    if (compPerson != null && compAddress != null)
                    {
                        Person TempValPerson = peopleService.RetrievePerson(person.PersonId);
                        Person TempCompPerson = peopleService.RetrievePerson(person.PersonId);
                        person = SelectiveFieldReplace(person, TempValPerson);
                        compPerson = SelectiveFieldReplace(compPerson, TempCompPerson);
                        peopleService.ValidateUser(editUserID, person, address, compPerson, compAddress);
                    }
                    else if ((compPerson == null && compAddress == null))
                    {
                        Person TempValPerson = peopleService.RetrievePerson(person.PersonId);
                        person = SelectiveFieldReplace(person, TempValPerson);
                        peopleService.ValidateUser(editUserID, person, address);
                    }
                    else
                    {
                        throw new Exception("Page Failed to determine if comparison record should be updated");
                    }
                    Response.Write("<script>alert(' Record was Successfully Updated.'); window.location.href='ValidationReport.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write(" An error has occured. - Edit.aspx.cs - btnSubmit_Click - ");
                }
            }
        }

        private void showHideEdit(int boxId, bool showFlag, BorderStyle tbBorderStyle)
        {
            if (boxId == 1)
            {
                tbFirstName.Enabled = showFlag;
                tbFirstName.BorderStyle = tbBorderStyle;
                tbLastName.Enabled = showFlag;
                tbLastName.BorderStyle = tbBorderStyle;
                tbMName.Enabled = showFlag;
                tbMName.BorderStyle = tbBorderStyle;
                tbaddress1.Enabled = showFlag;
                tbaddress1.BorderStyle = tbBorderStyle;
                tbaddress2.Enabled = showFlag;
                tbaddress2.BorderStyle = tbBorderStyle;
                tbcity.Enabled = showFlag;
                tbcity.BorderStyle = tbBorderStyle;
                tbZipCode.Enabled = showFlag;
                tbZipCode.BorderStyle = tbBorderStyle;
                tbPrimaryPhone.Enabled = showFlag;
                tbPrimaryPhone.BorderStyle = tbBorderStyle;
                tbAltPhone.Enabled = showFlag;
                tbAltPhone.BorderStyle = tbBorderStyle;
                tbEmailAddress.Enabled = showFlag;
                tbEmailAddress.BorderStyle = tbBorderStyle;
                tbSuffix.Enabled = showFlag;
                tbState.Enabled = showFlag;
                ddlCountry.Enabled = showFlag;
                tbOtherStateText.Enabled = showFlag;
                tbOtherStateText.BorderStyle = tbBorderStyle;
                rfvLastName.Enabled = showFlag;
                rfvFirstName.Enabled = showFlag;
                rfvPrimaryPhone.Enabled = showFlag;
                rfvAddress1.Enabled = showFlag;
                rfvcity.Enabled = showFlag;
                rfvZipCode.Enabled = showFlag;
                rfvState.Enabled = showFlag;
                rfvCountry.Enabled = showFlag;
                revAltPhone.Enabled = showFlag;
                revPrimaryPhone.Enabled = showFlag;
                revEmailAddress.Enabled = showFlag;
            }
            else
            {
                tbFirstName2.Enabled = showFlag;
                tbFirstName2.BorderStyle = tbBorderStyle;
                tbLastName2.Enabled = showFlag;
                tbLastName2.BorderStyle = tbBorderStyle;
                tbMiddleName2.Enabled = showFlag;
                tbMiddleName2.BorderStyle = tbBorderStyle;
                tbAddress1_2.Enabled = showFlag;
                tbAddress1_2.BorderStyle = tbBorderStyle;
                tbAddress2_2.Enabled = showFlag;
                tbAddress2_2.BorderStyle = tbBorderStyle;
                tbcity2.Enabled = showFlag;
                tbcity2.BorderStyle = tbBorderStyle;
                tbzipcode2.Enabled = showFlag;
                tbzipcode2.BorderStyle = tbBorderStyle;
                tbPrimaryPhone2.Enabled = showFlag;
                tbPrimaryPhone2.BorderStyle = tbBorderStyle;
                tbAltPhone2.Enabled = showFlag;
                tbAltPhone2.BorderStyle = tbBorderStyle;
                tbEmailAddress2.Enabled = showFlag;
                tbEmailAddress2.BorderStyle = tbBorderStyle;
                tbSuffix2.Enabled = showFlag;
                tbState2.Enabled = showFlag;
                ddlCountry2.Enabled = showFlag;
                tbOtherStateText2.Enabled = showFlag;
                tbOtherStateText2.BorderStyle = tbBorderStyle;
                rfvLastName2.Enabled = showFlag;
                rfvFirstName2.Enabled = showFlag;
                rfvPrimaryPhone2.Enabled = showFlag;
                rfvAddress1_2.Enabled = showFlag;
                rfvcity2.Enabled = showFlag;
                rfvZipCode2.Enabled = showFlag;
                rfvState2.Enabled = showFlag;
                rfvCountry2.Enabled = showFlag;
                revAltPhone2.Enabled = showFlag;
                revPrimaryPhone2.Enabled = showFlag;
                revEmailAddress2.Enabled = showFlag;
            }
        }

        private void loadLookups(OleDbConnection conConnection, DropDownList ddList1, DropDownList ddList2, string sqlStr, string descStr, string valStr)
        {
            OleDbDataReader myReader = default(OleDbDataReader);
            OleDbCommand cmdSelect = default(OleDbCommand);
            bool loadList1Flag = false;
            bool loadList2Flag = false;
            if (ddList1.Items.Count < 2 | ddList2.Items.Count < 2)
            {
                if (ddList1.Items.Count < 2)
                {
                    loadList1Flag = true;
                }
                if (ddList2.Items.Count < 2)
                {
                    loadList2Flag = true;
                }
                cmdSelect = new OleDbCommand(sqlStr, conConnection);
                myReader = cmdSelect.ExecuteReader();
                while (myReader.Read())
                {
                    if (loadList1Flag)
                    {
                        ddList1.Items.Add(new ListItem(myReader[descStr].ToString(), myReader[valStr].ToString()));
                    }
                    if (loadList2Flag)
                    {
                        ddList2.Items.Add(new ListItem(myReader[descStr].ToString(), myReader[valStr].ToString()));
                    }
                }
                myReader.Close();
            }
        }

        private void loadSearchResults(GridView gview, bool firstPageFlag)
        {
            string strSelect = "";
            string strConnect = ConfigurationManager.ConnectionStrings["ClWaterDb"].ConnectionString;
            OleDbConnection conConnection = new OleDbConnection(strConnect);
            try
            {
                OleDbCommand sqlCommand = new OleDbCommand();
                strSelect =
                    "select tbl_person.* , case when is_primary=1 then 'YES' else 'NO' end as IsPrimary ,suffix_desc,state_desc ,other_state_desc, country_desc, address_1 , address_2 , city , tbl_address.state_id , zipcode , tbl_address.country_id from tbl_person " +
                    " left outer join tbl_address on tbl_person.person_id = tbl_address.person_id   and tbl_address.is_current = 1 " +
                    "LEFT OUTER JOIN LK_SUFFIX on tbl_person.suffix_id = lk_suffix.suffix_id " +
                    "LEFT OUTER JOIN LK_STATE on tbl_address.state_id = lk_state.state_id " +
                    "LEFT OUTER JOIN LK_COUNTRY on tbl_address.country_id = lk_country.country_id " +
                    " where tbl_person.is_primary = 1";
                strSelect = strSelect + " AND (upper(Ltrim(rtrim(first_name)))+':'+upper(Ltrim(rtrim(last_name))) = ? + ':' + ?";
                sqlCommand.Parameters.AddWithValue("@FirstName1", tbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@LastName1", tbLastName.Text);
                strSelect = strSelect + " OR upper(Ltrim(rtrim(first_name)))+':'+upper(Ltrim(rtrim(last_name))) = ? + ':' + ?";
                sqlCommand.Parameters.AddWithValue("@FirstName2", tbLastName.Text);
                sqlCommand.Parameters.AddWithValue("@LastName2", tbFirstName.Text);
                strSelect = strSelect + " OR primary_phone= ?";
                sqlCommand.Parameters.AddWithValue("@Phone", tbPrimaryPhone.Text);
                strSelect = strSelect +
                            " OR upper(Ltrim(rtrim(address_1)))+':'+upper(Ltrim(rtrim(isnull(address_2, ''))))+':'+upper(Ltrim(rtrim(city)))+':'+upper(Ltrim(rtrim(CAST(tbl_address.state_id as varchar(10)))))+':'+upper(Ltrim(rtrim(zipcode)))+':'+upper(Ltrim(rtrim(cast(tbl_address.country_id as varchar(10)))))= ";
                strSelect = strSelect + "? + ':' + ? + ':' + ? + ':' + ? + ':' + ? + ':' + ?)";
                sqlCommand.Parameters.AddWithValue("@Address1", tbaddress1.Text);
                sqlCommand.Parameters.AddWithValue("@Address2", tbaddress2.Text);
                sqlCommand.Parameters.AddWithValue("@City", tbcity.Text);
                sqlCommand.Parameters.AddWithValue("@State", tbState.SelectedItem.Value);
                sqlCommand.Parameters.AddWithValue("@ZipCode", tbZipCode.Text);
                sqlCommand.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.Value);
                strSelect = strSelect + " and tbl_person.person_id <> ?";
                sqlCommand.Parameters.AddWithValue("@Id", Session["CLNR_ID"]);
                sqlCommand.CommandText = strSelect;
                DataSet dataSet = DataProcess.SqlConnection.ExecuteSelectParameterizedQuery(sqlCommand);
                gvSearchResults.DataSource = dataSet.Tables[0];
                if (firstPageFlag)
                {
                    gview.PageIndex = 0;
                }
                gvSearchResults.DataBind();
                gview.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                conConnection.Close();
            }
        }

        private void loadPersonRecord(OleDbConnection conConnection, string strPersonID, int recordViewPanel)
        {
            string strSelect = "";
            OleDbCommand cmdSelect = default(OleDbCommand);
            OleDbDataAdapter daSelect = new OleDbDataAdapter(strSelect, conConnection);
            DataSet ds = new DataSet();
            strSelect = "Select TBL_Person.*, case when is_primary=1 then 'YES' else 'NO' end as IsPrimary ,Suffix_desc,  " + "Address_1, Address_2, City ,tbl_address.state_id ,state_desc,other_state_desc, ZipCode,country_desc, tbl_address.country_id , " + "  TBL_Person.Registration_Type_ID, " + "LK_Registration_Type.Registration_Type_Desc, TBL_person.Created_Date , TBL_Address.Created_By " + "From TBL_person LEFT OUTER JOIN TBL_Address on tbl_person.person_id = tbl_address.person_id   and tbl_address.is_current = 1 " + "LEFT OUTER JOIN LK_SUFFIX on tbl_person.suffix_id = lk_suffix.suffix_id " + "LEFT OUTER JOIN LK_STATE on tbl_address.state_id = lk_state.state_id " + "LEFT OUTER JOIN LK_COUNTRY on tbl_address.country_id = lk_country.country_id " + ",LK_REGISTRATION_TYPE  Where TBL_person.Registration_Type_ID = LK_Registration_Type.Registration_Type_ID AND TBL_PERSON.person_ID = " + strPersonID;
            cmdSelect = new OleDbCommand(strSelect, conConnection);
            daSelect.SelectCommand = cmdSelect;
            daSelect.Fill(ds);
            if (recordViewPanel == 1)
            {
                lbRegistrationType.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["registration_type_desc"].ToString().ToUpper().Trim());
                tbFirstName.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["first_name"].ToString().ToUpper().Trim());
                tbLastName.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["last_name"].ToString().ToUpper().Trim());
                tbMName.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["middle_name"].ToString().ToUpper().Trim());
                tbaddress1.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["address_1"].ToString().ToUpper().Trim());
                tbaddress2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["address_2"].ToString().ToUpper().Trim());
                tbcity.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["City"].ToString().ToUpper().Trim());
                tbZipCode.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["ZipCode"].ToString().Trim().ToUpper());
                tbPrimaryPhone.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["primary_phone"].ToString().Trim());
                tbAltPhone.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["alternate_phone"].ToString().Trim());
                tbEmailAddress.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["email_address"].ToString().Trim());
                tbOtherStateText.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["other_state_desc"].ToString().Trim());
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Suffix_id"].ToString()))
                {
                    tbSuffix.SelectedItem.Selected = false;
                    tbSuffix.Items.FindByValue(ds.Tables[0].Rows[0]["Suffix_id"].ToString()).Selected = true;
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["State_id"].ToString()))
                {
                    tbState.SelectedItem.Selected = false;
                    tbState.Items.FindByValue(ds.Tables[0].Rows[0]["State_id"].ToString()).Selected = true;
                    if (tbState.SelectedItem.Text.ToUpper() == "OTHER")
                    {
                        tbOtherStateText.Visible = true;
                    }
                }
                tbOtherStateText.Text = ds.Tables[0].Rows[0]["other_state_desc"].ToString().Trim();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["country_id"].ToString()))
                {
                    ddlCountry.SelectedItem.Selected = false;
                    ddlCountry.Items.FindByValue(ds.Tables[0].Rows[0]["country_id"].ToString()).Selected = true;
                }
            }
            else
            {
                lbRegistrationType2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["registration_type_desc"].ToString().ToUpper().Trim());
                tbFirstName2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["first_name"].ToString().ToUpper().Trim());
                tbLastName2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["last_name"].ToString().ToUpper().Trim());
                tbMiddleName2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["middle_name"].ToString().ToUpper().Trim());
                tbAddress1_2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["address_1"].ToString().ToUpper().Trim());
                tbAddress2_2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["address_2"].ToString().ToUpper().Trim());
                tbcity2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["City"].ToString().ToUpper().Trim());
                tbzipcode2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["ZipCode"].ToString().Trim().ToUpper());
                tbPrimaryPhone2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["primary_phone"].ToString().Trim());
                tbOtherStateText2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["other_state_desc"].ToString().Trim());
                tbAltPhone2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["alternate_phone"].ToString().Trim());
                tbEmailAddress2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["email_address"].ToString().Trim());
                lbid2.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["person_id"].ToString().ToUpper().Trim());
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Suffix_id"].ToString()))
                {
                    tbSuffix2.SelectedItem.Selected = false;
                    tbSuffix2.Items.FindByValue(ds.Tables[0].Rows[0]["Suffix_id"].ToString()).Selected = true;
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["State_id"].ToString()))
                {
                    tbState2.SelectedItem.Selected = false;
                    tbState2.Items.FindByValue(ds.Tables[0].Rows[0]["State_id"].ToString()).Selected = true;
                    if (tbState2.SelectedItem.Text.ToUpper() == "OTHER")
                    {
                        tbOtherStateText2.Visible = true;
                    }
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Country_id"].ToString()))
                {
                    ddlCountry2.SelectedItem.Selected = false;
                    ddlCountry2.Items.FindByValue(ds.Tables[0].Rows[0]["Country_id"].ToString()).Selected = true;
                }
                if (btnSave.Enabled)
                {
                    cbIsPrimary.Checked = false;
                    btnSave.Enabled = false;
                }
                if (ds.Tables[0].Rows[0]["isPrimary"].ToString().ToUpper().Trim() == "YES")
                {
                    cbPrimary2.Checked = true;
                    showHideEdit(2, true, BorderStyle.Inset);
                    showHideEdit(1, false, BorderStyle.None);
                    btnSave.Enabled = true;
                }
                pnlComparison.Visible = true;
                btnClear.Enabled = true;
            }
        }

        protected void tbState_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            handleOtherState(tbState, tbOtherStateText);
        }

        private void handleOtherState(DropDownList ddlist, TextBox tbox)
        {
            if (ddlist.SelectedItem.Text.ToUpper() == "OTHER")
            {
                tbox.Enabled = true;
                tbox.Visible = true;
            }
            else
            {
                tbox.Visible = false;
                tbox.Enabled = false;
            }
        }

        protected void tbState2_SelectedIndexChanged1(object sender, System.EventArgs e)
        {
            handleOtherState(tbState2, tbOtherStateText2);
        }

        protected Person SelectiveFieldReplace(Person formPerson, Person dbPerson)
        {
            formPerson.HearAboutUsId = dbPerson.HearAboutUsId;
            formPerson.OtherHearAboutUsId = dbPerson.OtherHearAboutUsId;
            formPerson.RegistrationTypeId = dbPerson.RegistrationTypeId;
            formPerson.VarNone = dbPerson.VarNone;
            formPerson.VarReside = dbPerson.VarReside;
            formPerson.VarStationed = dbPerson.VarStationed;
            formPerson.VarStatus = dbPerson.VarStatus;
            formPerson.VarWorked = dbPerson.VarWorked;
            formPerson.PrimaryId = dbPerson.PrimaryId;
            formPerson.AddressNoteId = dbPerson.AddressNoteId;
            return (formPerson);
        }
    }
}