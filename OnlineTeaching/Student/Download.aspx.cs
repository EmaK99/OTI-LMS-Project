using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Download : System.Web.UI.Page
{
    // Declare necessary data tables and table adapters
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    DS_UPLOAD.UPLOADMST_SELECTDataTable UDT = new DS_UPLOAD.UPLOADMST_SELECTDataTable();
    DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter UAdapter = new DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize label
        lbl.Text = "";

        // Check if the page is being loaded for the first time (not a postback)
        if (Page.IsPostBack == false)
        {
            // Retrieve staff data for the current course
            SDT = SAdapter.Select_By_Course(Session["cname"].ToString());

            // Bind the staff data to the drop-down list for selecting a teacher
            drpteacher.DataSource = SDT;
            drpteacher.DataTextField = "Name";
            drpteacher.DataValueField = "sid";
            drpteacher.DataBind();
            drpteacher.Items.Insert(0, "SELECT");

            // Display the current course name in labels
            lblcourse.Text = Session["cname"].ToString();
            lblcourse0.Text = Session["cname"].ToString();

            // Retrieve upload data for the current course
            UDT = UAdapter.Select_By_Course(lblcourse.Text);

            // Bind the upload data to the GridView control for displaying the uploads
            GvUpload.DataSource = UDT;
            GvUpload.DataBind();

            // Update the total number of uploads in the label
            lbl.Text = "Total: " + GvUpload.Rows.Count.ToString();
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        // Handle the click event of the "Search" button

        // Retrieve upload data for the selected staff member (teacher)
        UDT = UAdapter.Select_By_Staff(drpteacher.SelectedItem.Text);

        // Bind the upload data to the GridView control for displaying the uploads
        GvUpload.DataSource = UDT;
        GvUpload.DataBind();

        // Update the total number of uploads in the label
        lbl.Text = "Total: " + GvUpload.Rows.Count.ToString();
    }

    protected void GvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Handle row commands in the GridView control

        // Update the download count for the specified upload ID
        UAdapter.UPLOADMST_DOWMLOAD(Convert.ToInt32(e.CommandArgument.ToString()));

        // Retrieve upload data for the specified upload ID
        UDT = UAdapter.Select_By_UID(Convert.ToInt32(e.CommandArgument.ToString()));

        // Redirect the user to the download URL of the upload
        Response.Redirect(UDT.Rows[0]["Upload"].ToString());
    }
}
