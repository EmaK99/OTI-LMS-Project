using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffFPass : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the staff data
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        // Initialize the lblpass label
        lblpass.Text = "";
    }

    protected void btngetpass_Click(object sender, EventArgs e)
    {
        // This event handler is executed when the "Get Password" button is clicked
        // Retrieve staff data based on the provided email and mobile number using the table adapter
        SDT = SAdapter.ForgotPassword(txtemail.Text, txtmobile.Text);

        if (SDT.Rows.Count == 0)
        {
            // If no matching staff record is found, display an error message
            lblpass.Text = "Invalid Detail";
        }
        else
        {
            // If a matching staff record is found, display the corresponding password
            lblpass.Text = "Password = " + SDT.Rows[0]["Password"].ToString();
        }
    }
}
