using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_StaffReport : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "STAFFMST" table
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "STAFFMST" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            // Retrieve data from the "STAFFMST" table and populate the dataset
            SDT = SAdapter.select();

            // Bind the dataset to the GridView for displaying staff records
            GridView1.DataSource = SDT;
            GridView1.DataBind();

            // Display the count of rows in the GridView
            lbl.Text = GridView1.Rows.Count.ToString();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Retrieve the staff ID from the selected row in the GridView
        int sidd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        // Delete the staff record from the "STAFFMST" table using the table adapter
        SAdapter.Delete(sidd);

        // Retrieve updated data from the "STAFFMST" table and rebind the GridView
        SDT = SAdapter.select();
        GridView1.DataSource = SDT;
        GridView1.DataBind();

        // Update the count of rows in the GridView
        lbl.Text = GridView1.Rows.Count.ToString();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Add custom logic here if needed
    }
}
