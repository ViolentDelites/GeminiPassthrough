<%@ Page Title="" Language="C#" MasterPageFile="~/clwater/pages/masterpages/MasterInternal.Master" AutoEventWireup="true" CodeBehind="SuspectReportGV.aspx.cs" Inherits="clwater_new.Internal.pages.SuspectReportGV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" action="SuspectReportGV.aspx">
        <div class="interior-breadcrumb">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="interior-breadcrumb" NavigateUrl="~/Internal/pages/selection.aspx"><span class="arial-font bold">Back to Index</span></asp:HyperLink>
        </div>
        <div class="content-p-crumb">
            <h3>Suspect Address Report:</h3>
            <table class="internal-table">
                <tr>
                    <td align="left"></td>
                    <td align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="left" colspan="2">Field Criteria:
                    <asp:DropDownList ID="ddlCriteria" runat="server">
                        <asp:ListItem Value="1">All</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">Deceased</asp:ListItem>
                        <asp:ListItem Value="3">Suspect</asp:ListItem>
                    </asp:DropDownList>
                        <asp:Button ID="btnSearch" runat="server" Text="Run Report" OnClick="btnSearch_Click" />
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gdvSuspectReport" runat="server" AllowPaging="True" PageSize="50" AutoGenerateColumns="false" Width="928px" OnPageIndexChanging="gdvSuspectReport_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="MiddleInitial" HeaderText="MI" SortExpression="MiddleInitial" />
                    <asp:BoundField DataField="PrimaryPhone" HeaderText="Primary Phone" SortExpression="PrimaryPhone" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="Suffix" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" SortExpression="ZipCode" />
                    <asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="Address1" />
                    <asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="Address2" />
                    <asp:BoundField DataField="OtherStateDescription" HeaderText="State Desc" SortExpression="OtherStateDescription" />
                    <asp:BoundField DataField="PersonID" HeaderText="Person ID" SortExpression="PersonID" />
                    <asp:BoundField DataField="RegistrationType" HeaderText="Reg Type" SortExpression="RegistrationType" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="width-100px ml-auto mr-auto">
            <asp:Button Visible="true" ID="btnExport" runat="server" Text="Export to Excel" Width="109px" OnClick="btnExport_Click" />
        </div>
        <br />
    </form>
</asp:Content>
