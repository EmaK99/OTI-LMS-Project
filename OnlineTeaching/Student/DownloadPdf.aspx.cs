using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_DownloadPdf : System.Web.UI.Page
{
    // Declare necessary data tables and table adapters
    // Create a new instance of the DataTable for storing video/file data
    DS_VIDEO.VIDEOMST_SELECTDataTable VDt = new DS_VIDEO.VIDEOMST_SELECTDataTable();

    // Create a new instance of the TableAdapter for retrieving and updating video data
    DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter VAdapter = new DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter();

    // Create a new instance of the DataTable for storing teacher data
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Create a new instance of the TableAdapter for retrieving teacher data
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();


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

            // Retrieve video/file data for the current course
            VDt = VAdapter.Select_By_Course(lblcourse.Text);

            // Bind the video/file data to the GridView control for displaying the uploads
            GvUpload.DataSource = VDt;
            GvUpload.DataBind();

            // Update the total number of videos/files in the label
            lbl.Text = "Total = " + GvUpload.Rows.Count.ToString();
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        // Handle the click event of the "Search" button

        // Retrieve video/file data for the selected staff member (teacher)
        VDt = VAdapter.Select_By_Staff(drpteacher.SelectedItem.Text);

        // Bind the video/file data to the GridView control for displaying the uploads
        GvUpload.DataSource = VDt;
        GvUpload.DataBind();

        // Update the total number of videos/files in the label
        lbl.Text = "Total = " + GvUpload.Rows.Count.ToString();
    }

    protected void GvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Handle row commands in the GridView control

        if (e.CommandName == "read")
        {
            // If the command is to read/view the video

            // Update the download count for the specified video ID
            VAdapter.VIDEOMST_DOWMLOAD(Convert.ToInt32(e.CommandArgument.ToString()));

            // Retrieve video data for the specified video ID
            VDt = VAdapter.Select_By_ID(Convert.ToInt32(e.CommandArgument.ToString()));

            // Redirect the user to the URL of the file
            Response.Redirect(VDt.Rows[0]["Video"].ToString());
        }
        else if (e.CommandName == "download")
        {
            // If the command is to download the file

            // Redirect the user to the download URL of the file
            Response.Redirect(e.CommandArgument.ToString());
        }
    }
}
