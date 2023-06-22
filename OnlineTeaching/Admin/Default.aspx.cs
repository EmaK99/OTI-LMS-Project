using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        // No action is performed in this event handler
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // This event handler is executed when Button1 is clicked

        lbl.Text = ""; // Clear the label text

        if (txtname.Text == "admin" && txtpasss.Text == "admin")
        {
            // If the entered username and password match the expected values

            Response.Redirect("AddCategory.aspx"); // Redirect to the AddCategory.aspx page
        }
        else
        {
            // If the entered username and password do not match the expected values

            lbl.Text = "Invalid Detail"; // Display an error message in the label
        }
    }
}
