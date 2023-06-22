using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Staff_UploadVideo : System.Web.UI.Page
{
    // Declare the necessary data table and table adapter
    DS_VIDEO.VIDEOMST_SELECTDataTable VDT = new DS_VIDEO.VIDEOMST_SELECTDataTable();
    DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter VAdapter = new DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize labels
        lbl.Text = "";
        lblsave.Text = "";

        // Check if the page is being loaded for the first time (not a postback)
        if (Page.IsPostBack == false)
        {
            // Retrieve video data for the current staff member based on their session name
            VDT = VAdapter.Select_By_Staff(Session["name"].ToString());

            // Bind the data to the GridView control for displaying the videos
            GridView4.DataSource = VDT;
            GridView4.DataBind();

            // Update the total number of videos in the label
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Handle row commands in the GridView control
        if (e.CommandName == "a")
        {
            // Retrieve video data for the specified video ID
            VDT = VAdapter.Select_By_ID(Convert.ToInt32(e.CommandArgument.ToString()));

            // Check the current status of the video
            if (VDT.Rows[0]["Status"].ToString() == "Active")
            {
                // If the video is active, update its status to "InActive"
                VAdapter.VIDEOMST_UPDATE_STATUS(Convert.ToInt32(e.CommandArgument.ToString()), "InActive");
            }
            else
            {
                // If the video is inactive, update its status to "Active"
                VAdapter.VIDEOMST_UPDATE_STATUS(Convert.ToInt32(e.CommandArgument.ToString()), "Active");
            }

            // Retrieve updated video data for the current staff member
            VDT = VAdapter.Select_By_Staff(Session["name"].ToString());

            // Bind the updated data to the GridView control for displaying the videos
            GridView4.DataSource = VDT;
            GridView4.DataBind();

            // Update the total number of videos in the label
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
    }

    protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Handle row deletion in the GridView control
        // Delete the video record from the database based on the video ID
        VAdapter.Delete(Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value));

        // Retrieve updated video data
        VDT = VAdapter.Select();

        // Bind the updated data to the GridView control for displaying the videos
        GridView4.DataSource = VDT;
        GridView4.DataBind();

        // Update the total number of videos in the label
        lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        // Handle the click event of the "Upload" button

        if (FileUpload1.HasFile)
        {
            // If a file has been selected for uploading
            FileUpload1.SaveAs(Server.MapPath("~/Staff/Pdf/") + FileUpload1.FileName);
            string abc = FileUpload1.FileName.ToString();

            // Insert video details (staff name, course name, title, and file URL) into the database
            VAdapter.Insert(Session["name"].ToString(), Session["cname"].ToString(), txttitle.Text, "~/Staff/Pdf/" + FileUpload1.FileName);

            // Display a success message in the label and clear the title text box
            lblsave.Text = "PDF File Uploaded";
            txttitle.Text = "";

            // Retrieve updated video data for the current staff member
            VDT = VAdapter.Select_By_Staff(Session["name"].ToString());

            // Bind the updated data to the GridView control for displaying the videos
            GridView4.DataSource = VDT;
            GridView4.DataBind();

            // Update the total number of videos in the label
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
        else
        {
            // If no file has been selected for uploading, display an error message
            lblsave.Text = "Select a PDF please!";
        }
    }
}
