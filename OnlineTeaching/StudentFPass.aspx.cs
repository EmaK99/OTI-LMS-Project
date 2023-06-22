using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentFPass : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the student data
    DS_REGI.StudentMst_SELECTDataTable StuDT = new DS_REGI.StudentMst_SELECTDataTable();
    DS_REGITableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_REGITableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        lblpass.Text = "";
    }

    protected void btngetpass_Click(object sender, EventArgs e)
    {
        // This event handler is executed when the "Get Password" button is clicked
        StuDT = StuAdapter.ForgotPassword(txtemail.Text, txtmobile.Text);
        if (StuDT.Rows.Count == 0)
        {
            // If no matching student records are found, display an error message
            lblpass.Text = "Invalid Detail";
        }
        else
        {
            // If a matching student record is found, display the password
            lblpass.Text = "Password = " + StuDT.Rows[0]["Password"].ToString();
        }
    }
}
