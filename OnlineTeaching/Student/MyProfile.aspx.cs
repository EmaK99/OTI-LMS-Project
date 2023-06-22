using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Import required namespaces

public partial class Student_MyProfile : System.Web.UI.Page
{
    // Declare a DataTable for student data retrieval
    DS_REGI.StudentMst_SELECTDataTable StuDT = new DS_REGI.StudentMst_SELECTDataTable();

    // Declare a TableAdapter for student data retrieval
    DS_REGITableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_REGITableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the page is being loaded for the first time
        if (Page.IsPostBack == false)
        {
            // Retrieve student data based on the username stored in the session
            StuDT = StuAdapter.Select_By_Uname(Session["uname"].ToString());

            // Display student information on the page
            lblname.Text = StuDT.Rows[0]["Name"].ToString();
            txtemail.Text = StuDT.Rows[0]["email"].ToString();
            txtmobile.Text = StuDT.Rows[0]["mobile"].ToString();
            txtadd.Text = StuDT.Rows[0]["address"].ToString();
            txtcity.Text = StuDT.Rows[0]["city"].ToString();
            txtpin.Text = StuDT.Rows[0]["pincode"].ToString();
            Imgprofile.ImageUrl = StuDT.Rows[0]["image"].ToString();
            lblcourse.Text = StuDT.Rows[0]["course"].ToString();
            ViewState["sid"] = StuDT.Rows[0]["SID"].ToString();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        // Update the student's information in the database
        StuAdapter.Update(Convert.ToInt32(ViewState["sid"].ToString()), txtemail.Text, txtmobile.Text, Imgprofile.ImageUrl.ToString(), txtadd.Text, txtcity.Text, txtpin.Text);

        // Redirect the user back to the profile page
        Response.Redirect("MyProfile.aspx");
    }

    protected void btnchange_Click(object sender, EventArgs e)
    {
        // Save the uploaded image file to the server
        FileUpload1.SaveAs(Server.MapPath("~/Studentimg/" + FileUpload1.FileName));
        Imgprofile.ImageUrl = "~/Studentimg/" + FileUpload1.FileName.ToString();
    }
}
