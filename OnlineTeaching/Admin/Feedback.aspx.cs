using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Feedback : System.Web.UI.Page
{   // Instantiate the dataset object for storing the data retrieved from the "FeedBackMst" table
    DS_FEED.FeedBackMst_SELECTDataTable FDT = new DS_FEED.FeedBackMst_SELECTDataTable();
    // Instantiate the table adapter object for executing queries and data operations on the "FeedBackMst" table
    DS_FEEDTableAdapters.FeedBackMst_SELECTTableAdapter FAdapter = new DS_FEEDTableAdapters.FeedBackMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            // Retrieve feedback data from the database
            FDT = FAdapter.Select();

            // Bind the retrieved data to the GridView control for display
            GridView1.DataSource = FDT;
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Retrieve the ID of the feedback entry being deleted
        int feedbackID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        // Delete the feedback entry from the database using the adapter
        FAdapter.Delete(feedbackID);

        // Retrieve updated feedback data from the database
        FDT = FAdapter.Select();

        // Bind the updated data to the GridView control for display
        GridView1.DataSource = FDT;
        GridView1.DataBind();
    }
}
