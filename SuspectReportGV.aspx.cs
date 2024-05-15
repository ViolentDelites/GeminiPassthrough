using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using clwater_new.Models.Grids;
using clwater_new.Services;
using clwater_new.Utils;

namespace clwater_new.Internal.pages
{
    public partial class SuspectReportGV : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NoticeAccepted"]?.ToString() != "True")
                Response.Redirect("/internal/Notice.aspx");
            if (Session["UserId"] == null)
                Response.Redirect("/internal/pages/logon.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            gdvSuspectReport.DataSource = ReportService.SuspectAddressReport(Convert.ToInt32(ddlCriteria.SelectedValue));
            gdvSuspectReport.DataBind();
        }

        protected void gdvSuspectReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvSuspectReport.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<CompletePerson> completePersons = ReportService.SuspectAddressReport(Convert.ToInt32(ddlCriteria.SelectedValue));
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CompletePerson));
            DataTable dataTable = new DataTable();
            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                dataTable.Columns.Add(propertyDescriptor.Name,
                    Nullable.GetUnderlyingType(propertyDescriptor.PropertyType) ?? propertyDescriptor.PropertyType);
            }
            foreach (CompletePerson completePerson in completePersons)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyDescriptor propertyDescriptor in properties)
                {
                    dataRow[propertyDescriptor.Name] = propertyDescriptor.GetValue(completePerson) ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }
            CsvHelper.WriteCsvFile(dataTable, Response, "SummaryReport");

        }
    }
}