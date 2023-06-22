using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Default : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "STAFFMST_SELECT" table
    DS_STAFF.STAFFMST_SELECTDataTable StaffDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "STAFFMST_SELECT" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            // Retrieve staff data based on the currently logged-in user's email and populate the controls on the page
            StaffDT = StaffAdapter.Select_by_email(Session["uname"].ToString());

            // Display staff details in the corresponding labels and textboxes on the page
            lblname.Text = StaffDT.Rows[0]["Name"].ToString();
            lblcourse.Text = StaffDT.Rows[0]["cname"].ToString();
            txtemail.Text = StaffDT.Rows[0]["email"].ToString();
            txtmobile.Text = StaffDT.Rows[0]["mobile"].ToString();
            txtadd.Text = StaffDT.Rows[0]["address"].ToString();
            txtcity.Text = StaffDT.Rows[0]["city"].ToString();
            txtpin.Text = StaffDT.Rows[0]["pincode"].ToString();
            Imgprofile.ImageUrl = StaffDT.Rows[0]["image"].ToString();
            txtexper.Text = StaffDT.Rows[0]["Experience"].ToString();
            txtqulai.Text = StaffDT.Rows[0]["Qualification"].ToString();

            // Store the staff ID in ViewState for later use
            ViewState["sid"] = StaffDT.Rows[0]["SID"].ToString();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        // Update the staff information in the database based on the provided inputs
        StaffAdapter.Update(Convert.ToInt32(ViewState["sid"].ToString()), txtemail.Text, txtmobile.Text, txtadd.Text, txtcity.Text, txtpin.Text, Imgprofile.ImageUrl.ToString(), txtqulai.Text, txtexper.Text);

        // Update the session variable with the updated email address
        Session["uname"] = txtemail.Text;

        // Redirect the user to the default page
        Response.Redirect("Default.aspx");
    }

    protected void btnchange_Click(object sender, EventArgs e)
    {
        // Save the uploaded image file to the server and update the image URL
        FileUpload1.SaveAs(Server.MapPath("~/Admin/StaffImg/" + FileUpload1.FileName));
        Imgprofile.ImageUrl = "~/Admin/StaffImg/" + FileUpload1.FileName.ToString();
    }
}
