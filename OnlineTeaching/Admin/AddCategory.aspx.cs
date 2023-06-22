using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddCategory : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the category data
    DS_CATE.catemst_SELECTDataTable CDT = new DS_CATE.catemst_SELECTDataTable();
    DS_CATETableAdapters.catemst_SELECTTableAdapter CAdapter = new DS_CATETableAdapters.catemst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        if (Page.IsPostBack == false)
        {
            // If the page is not a postback, bind the category data to the GridView control
            CDT = CAdapter._select();
            GridView1.DataSource = CDT;
            GridView1.DataBind();
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        // This event handler is executed when the "Add" button is clicked
        // It inserts a new category into the database using the category name from the text box

        // Insert the category into the database
        CAdapter.Insert(txtadd.Text);

        // Retrieve the updated category data and bind it to the GridView control
        CDT = CAdapter._select();
        GridView1.DataSource = CDT;
        GridView1.DataBind();

        // Clear the text box and set focus to it
        txtadd.Text = "";
        txtadd.Focus();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // This event handler is executed when a row is being deleted from the GridView control

        // Get the category ID from the data keys of the selected row
        int cidd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        // Delete the category from the database
        CAdapter.Delete(cidd);

        // Retrieve the updated category data and bind it to the GridView control
        CDT = CAdapter._select();
        GridView1.DataSource = CDT;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // This event handler is executed when a row in the GridView control is selected
        // No action is performed in this event handler
    }
}
