using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the staff data
    DS_STAFF.STAFFMST_SELECTDataTable StaffDT = new DS_STAFF.STAFFMST_SELECTDataTable();
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    // Declare a datatable and a table adapter for the student data
    DS_REGI.StudentMst_SELECTDataTable StuDT = new DS_REGI.StudentMst_SELECTDataTable();
    DS_REGITableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_REGITableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblstaff.Text = "";
        lblstudent.Text = "";
    }

    protected void btnstafflogin_Click(object sender, EventArgs e)
    {
        // Retrieve staff data from the database based on the provided username and password
        StaffDT = StaffAdapter.Select_For_Login(txtstaffuname.Text, txtstaffpass.Text);

        if (StaffDT.Rows.Count == 1)
        {
            // If a matching staff record is found, store relevant information in session variables
            Session["uname"] = txtstaffuname.Text;
            Session["email"] = txtstaffuname.Text;
            Session["name"] = StaffDT.Rows[0]["Name"].ToString();
            Session["cname"] = StaffDT.Rows[0]["cname"].ToString();

            // Redirect the user to the staff default page
            Response.Redirect("Staff/Default.aspx");
        }
        else
        {
            // Display an error message if the staff login fails
            lblstaff.Text = "Login Error!";
        }
    }

    protected void btnstulogin_Click(object sender, EventArgs e)
    {
        // Retrieve student data from the database based on the provided username and password
        StuDT = StuAdapter.Select_for_LOGIN(txtxstuuname.Text, txtstupassword.Text);

        if (StuDT.Rows.Count == 1)
        {
            // If a matching student record is found, store relevant information in session variables
            Session["uname"] = txtxstuuname.Text;
            Session["email"] = StuDT.Rows[0]["Email"].ToString();
            Session["cname"] = StuDT.Rows[0]["course"].ToString();

            // Redirect the user to the student profile page
            Response.Redirect("Student/MyProfile.aspx");
        }
        else
        {
            // Display an error message if the student login fails
            lblstudent.Text = "Login Error!";
        }
    }
}
