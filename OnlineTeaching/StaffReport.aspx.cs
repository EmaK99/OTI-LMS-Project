using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffReport : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the staff data
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        if (Page.IsPostBack == false)
        {
            // If it's the initial page load (not a postback), retrieve staff data using the table adapter
            SDT = SAdapter.select();
            GridView1.DataSource = SDT;
            GridView1.DataBind();

            lbl.Text = GridView1.Rows.Count.ToString();
        }
    }
}
