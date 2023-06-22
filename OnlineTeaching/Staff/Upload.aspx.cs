using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Upload : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "UPLOADMST_SELECT" table
    DS_UPLOAD.UPLOADMST_SELECTDataTable UDT = new DS_UPLOAD.UPLOADMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "UPLOADMST_SELECT" table
    DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter UADapter = new DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize the label texts
        lbl.Text = "";
        lblsave.Text = "";

        // Check if the page is being loaded for the first time (not a postback)
        if (Page.IsPostBack == false)
        {
            // Retrieve the upload data for the current staff member based on their session name (Session["name"])
            UDT = UADapter.Select_By_Staff(Session["name"].ToString());

            // Bind the retrieved data to GridView4 control for displaying the uploads
            GridView4.DataSource = UDT;
            GridView4.DataBind();

            // Set the label text to display the total number of uploads
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        // Check if a file has been selected for uploading
        if (FileUpload1.HasFile)
        {
            // Save the uploaded file to the server
            FileUpload1.SaveAs(Server.MapPath("~/Staff/Upload/") + FileUpload1.FileName);

            // Insert the upload details into the database
            UADapter.Insert(Session["name"].ToString(), Session["cname"].ToString(), txttitle.Text, "~/Staff/Upload/" + FileUpload1.FileName);

            // Display a success message
            lblsave.Text = "File Uploaded";
            txttitle.Text = "";

            // Retrieve the updated upload data for the current staff member
            UDT = UADapter.Select_By_Staff(Session["name"].ToString());

            // Bind the updated data to GridView4 for displaying the uploads
            GridView4.DataSource = UDT;
            GridView4.DataBind();

            // Update the label text to display the total number of uploads
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
        else
        {
            // Display an error message if no file has been selected for uploading
            lblsave.Text = "Select a file please!";
        }
    }

    protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Retrieve the unique identifier (UID) of the upload being deleted
        int uploadID = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value);

        // Delete the upload record from the database
        UADapter.Delete(uploadID);

        // Retrieve the updated upload data
        UDT = UADapter.Select();

        // Bind the updated data to GridView4 for displaying the uploads
        GridView4.DataSource = UDT;
        GridView4.DataBind();

        // Update the label text to display the total number of uploads
        lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Check if the command name is "a" (related to the upload status)
        if (e.CommandName == "a")
        {
            // Retrieve the unique identifier (UID) of the upload being modified
            int uploadID = Convert.ToInt32(e.CommandArgument.ToString());

            // Retrieve the upload data for the specified upload ID
            UDT = UADapter.Select_By_UID(uploadID);

            // Check the current status of the upload
            if (UDT.Rows[0]["Status"].ToString() == "Active")
            {
                // If the status is "Active", update it to "InActive"
                UADapter.UPLOADMST_UPDATE_Status(uploadID, "InActive");
            }
            else
            {
                // If the status is "InActive", update it to "Active"
                UADapter.UPLOADMST_UPDATE_Status(uploadID, "Active");
            }

            // Retrieve the updated upload data
            UDT = UADapter.Select();

            // Bind the updated data to GridView4 for displaying the uploads
            GridView4.DataSource = UDT;
            GridView4.DataBind();

            // Update the label text to display the total number of uploads
            lbl.Text = "Total: " + GridView4.Rows.Count.ToString();
        }
    }
}
