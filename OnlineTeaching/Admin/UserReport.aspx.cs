using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserReport : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "StudentMst_SELECT" table
    DS_REGI.StudentMst_SELECTDataTable StuDT = new DS_REGI.StudentMst_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "StudentMst_SELECT" table
    DS_REGITableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_REGITableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            // Retrieve data from the "StudentMst_SELECT" table and bind it to the GridView
            StuDT = StuAdapter.Select();
            GridView1.DataSource = StuDT;
            GridView1.DataBind();
            lbl.Text = GridView1.Rows.Count.ToString();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Retrieve the ID of the selected row and delete the corresponding record from the database
        StuAdapter.Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value));

        // Retrieve updated data from the "StudentMst_SELECT" table and rebind it to the GridView
        StuDT = StuAdapter.Select();
        GridView1.DataSource = StuDT;
        GridView1.DataBind();
        lbl.Text = GridView1.Rows.Count.ToString();
    }
}
