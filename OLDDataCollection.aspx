<%@ Page Title="" Language="C#" MasterPageFile="~/clwater/pages/masterpages/MasterMap.Master" AutoEventWireup="true" CodeBehind="DataCollection.aspx.cs" Inherits="clwater_new.clwater.pages.DataCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="DataCollection.aspx">
        <div>
            <div class="font-15 bold float-right mt-10 mr-20">
                OMB CONTROL NUMBER:  0703-0057
                <br />
                EXPIRES ON: 12/31/19
            </div>
            <br />
            <br />
            <table class="internal-table">
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="vs_summary" runat="server" CssClass="validationError" ForeColor=""
                            HeaderText="For assistance please contact our toll free call center at 877-261-9782 or email us at <a href=mailto:clwater@usmc.mil>clwater@usmc.mil</a>." Height="177px" />
                    </td>
                </tr>
                <tr valign="top">
                    <td>
                        <table class="no-border" align="left" width="408">
                            <tr align="left">
                                <td align="left" colspan="2">
                                    <h4>&nbsp;&nbsp;Personal Info:</h4>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span> <b>Last Name:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbLastName" runat="server" MaxLength="35" />
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="tbLastName"
                                        Display="None" ErrorMessage="Last Name is required." />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span> <b>First Name:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbFirstName" runat="server" MaxLength="35" />
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="tbFirstName"
                                        Display="None" ErrorMessage="First Name is required." />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Middle Initial:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbMName" runat="server" MaxLength="1" Width="15" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Suffix:</b></p>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="tbSuffix" runat="server" DataSourceID="dsSuffixLk"
                                        DataTextField="Description" DataValueField="Id">
                                        <asp:ListItem Selected="True" Value="0">Select Suffix</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="dsSuffixLk" runat="server" SelectMethod="ListSuffix"
                                        TypeName="clwater_new.Services.LookupService" EnableCaching="True">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="addSelectEntry" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" colspan="2">
                                    <br />
                                    <h4>&nbsp;&nbsp;Current Address:                
                                    </h4>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span> <b>Mailing Address 1:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbAddress1" runat="server" CssClass="long" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="tbAddress1"
                                        Display="None" ErrorMessage="Address 1 is required." />
                                </td>
                            </tr>
                            <tr align="left">
                                <td width="150">
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Mailing Address 2:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbAddress2" runat="server" CssClass="short" MaxLength="100" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span><b> City:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbCity" runat="server" MaxLength="35" />
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="tbCity"
                                        Display="None" ErrorMessage="The City is required." />
                                </td>
                            </tr>
                            <tr align="left" valign="baseline">
                                <td>
                                    <p class="label_text">
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span><b> State:</b>
                                    </p>
                                </td>
                                <td align="left">
                                    <a class="help_text" href="javascript:HelpOpen(1);">Overseas Military Address ?</a><br />
                                    <br />

                                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True"
                                        DataSourceID="dsStateLk" DataTextField="Description"
                                        DataValueField="Id" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Select State</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="dsStateLk" runat="server" SelectMethod="ListStates"
                                        TypeName="clwater_new.Services.LookupService" EnableCaching="True">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="addSelectEntry" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:RequiredFieldValidator ID="rfvState" InitialValue="0" runat="server" ControlToValidate="ddlState"
                                        Display="None" ErrorMessage="State is required." /><br />
                                    <asp:TextBox ID="ddlStateText" runat="server" MaxLength="35" Visible="false" Enabled="false" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span> <b>Zip Code:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbZipCode" runat="server" MaxLength="10" CssClass="short" />
                                    <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="tbZipCode"
                                        Display="None" ErrorMessage="The Zip Code is required." />
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="required">*</span><b> Country:</b></p>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="dsCountryLk"
                                        DataTextField="Description" DataValueField="Id">
                                        <asp:ListItem Selected="True" Value="0">Select Country</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="dsCountryLk" runat="server"
                                        SelectMethod="ListCountries" TypeName="clwater_new.Services.LookupService" EnableCaching="True">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="addSelectEntry" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                        Display="None" ErrorMessage="Country is required." />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">

                        <table class="no-border" align="left" width="545">

                            <tr align="left" valign="top">
                                <td class="text-left vertical-align-top" colspan="2">
                                    <h4>&nbsp;&nbsp;Contact Information:</h4>
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="required">*</span><b> Primary Phone Number:</b>  </p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbPhoneNo" runat="server" MaxLength="20" /><br />
                                    <span class="italic blue bold font-11 ml-20"> No Dashes accepted </span>
                                    <br />
                                    <br />
                                    <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server" ControlToValidate="tbPhoneNo"
                                        Display="None" ErrorMessage="The Primary Phone Number is required." />
                                    <asp:RegularExpressionValidator ID="revPrimaryPhone" runat="server"
                                        ControlToValidate="tbPhoneNo" Display="None" ErrorMessage="Please enter a valid Primary Phone Number.  (Ex. 1234567890)"
                                        ValidationExpression="\d{10,20}" />
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Alternate Phone Number:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="altPhoneNo" runat="server" MaxLength="20" /><br />
                                    <span class="italic blue bold font-11 ml-20"> No Dashes accepted </span>
                                    <br />
                                    <br />
                                    <asp:RegularExpressionValidator ID="revAltPhone" runat="server"
                                        ControlToValidate="altPhoneNo" Display="None" ErrorMessage="Please enter a valid Alternate Phone Number.  (Ex. 1234567890)"
                                        ValidationExpression="\d{10,20}" />
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>
                                    <p class="label_text">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Email Address:</b></p>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="tbEmailAddress" runat="server" MaxLength="128" />
                                    <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="tbEmailAddress"
                                        Display="None" ErrorMessage="Please enter a valid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="left" colspan="2">
                                    <br />
                                    <br />
                                    <br />
                                    <h4>&nbsp;&nbsp;Miscellaneous:</h4>
                                </td>
                            </tr>
                            <tr align="left">
                                <td>
                                    <p class="label_text">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>How did you hear about us?</b>
                                    </p>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="tbHearAboutUs" runat="server" AutoPostBack="True"
                                        DataSourceID="dsHearAboutUsLk" DataTextField="Description"
                                        DataValueField="Id" OnSelectedIndexChanged="tbHearAboutUs_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Select </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="dsHearAboutUsLk" runat="server"
                                        SelectMethod="GetHearAboutUsesHearAboutUs" TypeName="clwater_new.Services.LookupService" EnableCaching="True">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="addSelectEntry" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <br />
                                    <asp:TextBox ID="tbHearAboutUsText" runat="server" MaxLength="35" Visible="false" Enabled="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="2">
                        <br />
                        <h3><b>Please review your information prior to clicking Submit</b></h3>

                        <asp:Button ID="btnSubmit" runat="server" Text="Submit Form" OnClick="btnSubmit_Click" Height="25px" />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
