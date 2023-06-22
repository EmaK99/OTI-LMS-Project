using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_Password : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "STAFFMST_SELECT" table
    DS_STAFF.STAFFMST_SELECTDataTable StaffDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "STAFFMST_SELECT" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // This event is not used in this code snippet, so no functionality is implemented here.
    }

    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        // Retrieve the staff's data based on the current email and the entered current password
        StaffDT = StaffAdapter.Staff_check_Surr_pass(txtcurrent.Text, Session["email"].ToString());

        if (StaffDT.Rows.Count == 1)
        {
            // If a matching record is found, update the staff's password with the entered new password
            StaffAdapter.StaffMST_SELECT_ChangePass(txtnewpass.Text, Session["email"].ToString());
            lbl.Text = "Password has been changed!";
        }
        else
        {
            // If no matching record is found, display an error message indicating an invalid current password
            lbl.Text = "Invalid current password entered!";
        }
    }
}
