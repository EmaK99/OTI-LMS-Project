using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Import required namespaces

public partial class Student_Student : System.Web.UI.MasterPage
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

            // Set the profile image URL and name label with the retrieved student data
            Image4.ImageUrl = StuDT.Rows[0]["image"].ToString();
            Label1.Text = StuDT.Rows[0]["name"].ToString();
        }
    }
}

