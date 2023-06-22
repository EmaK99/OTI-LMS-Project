using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Staff : System.Web.UI.MasterPage
{
    // Instantiating the dataset object here for storing the data retrieved from the "STAFFMST_SELECT" table
    DS_STAFF.STAFFMST_SELECTDataTable StaffDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // here instantiating the table adapter object for executing queries and data operations on the "STAFFMST_SELECT" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the page is being loaded for the first time (not a postback)
        if (Page.IsPostBack == false)
        {
            // Retrieve the staff's data based on the current username (Session["uname"])
            StaffDT = StaffAdapter.Select_by_email(Session["uname"].ToString());

            // Set the image URL of Image4 control to the staff's image URL
            Image4.ImageUrl = StaffDT.Rows[0]["Image"].ToString();

            // Set the text of Label1 control to display a welcome message with the staff's name
            Label1.Text = "Welcome " + StaffDT.Rows[0]["name"].ToString();
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        //  no functionality is implemented here 
    }
}
