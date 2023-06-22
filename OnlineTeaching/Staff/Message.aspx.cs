using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Message : System.Web.UI.Page
{
    // here declaring a datatable and a table adapter for the message data
    DS_MSG.MSGMST_SELECTDataTable MDT = new DS_MSG.MSGMST_SELECTDataTable();
    DS_MSGTableAdapters.MSGMST_SELECTTableAdapter MAdapter = new DS_MSGTableAdapters.MSGMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Here setting the initial view of the MultiView control to the first view
        MultiView1.ActiveViewIndex = 0;

        // Retrieving message data with status 0 (new messages) for the current user's email
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 0);

        // Binding the message data to GridView2 for display
        GridView2.DataSource = MDT;
        GridView2.DataBind();

        // Displaying the count of new messages in the lblnew label
        lblnew.Text = GridView2.Rows.Count.ToString();
    }

    protected void btnappluleave_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        // Switching to the first view of the MultiView control
        MultiView1.ActiveViewIndex = 0;

        // Retrieving message data with status 0 (new messages) for the current user's email
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 0);

        // Binding the message data to GridView2 for display
        GridView2.DataSource = MDT;
        GridView2.DataBind();

        // Displaying the count of new messages in the lblnew label
        lblnew.Text = GridView2.Rows.Count.ToString();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        // here switching to the second view of the MultiView control
        MultiView1.ActiveViewIndex = 1;

        // here retrieving message data with status 1 (old messages) for the current user's email address
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 1);

        // Binding the message data to GridView3 for display
        GridView3.DataSource = MDT;
        GridView3.DataBind();

        // Displaying the count of old messages in the lblold label
        lblold.Text = GridView3.Rows.Count.ToString();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Updating the status of the selected message to 1 (old)
        MAdapter.MSGMST_Update_Status(1, Convert.ToInt32(e.CommandArgument.ToString()));

        // Switching to the third view of the MultiView control
        MultiView1.ActiveViewIndex = 2;

        // Retrieving the details of the selected message
        MDT = MAdapter.Select_By_ID(Convert.ToInt32(e.CommandArgument.ToString()));

        // Displaingy the details of the selected message in the appropriate labels
        lblfname.Text = MDT.Rows[0]["Fname"].ToString();
        lblsub.Text = MDT.Rows[0]["subject"].ToString();
        lblmsg.Text = MDT.Rows[0]["message"].ToString();
    }

    protected void btnreply_Click(object sender, EventArgs e)
    {
        // Inserting a reply message in the database
        MAdapter.Insert(Session["email"].ToString(), lblfname.Text, lblsub.Text, txtreply.Text);

        // Displaying a success message in the lblsub label
        lblsub.Text = "Reply Successfully";
        txtreply.Text = "";
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Deleting the selected message from the database
        MAdapter.Delete(Convert.ToInt32(e.CommandArgument.ToString()));

        // Switching back to the second view of the MultiView control
        MultiView1.ActiveViewIndex = 1;

        // Retrieve message data with status 1 (old messages) for the current user's email
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 1);

        // Bind the message data to GridView3 for display
        GridView3.DataSource = MDT;
        GridView3.DataBind();

        // Display the count of old messages in the lblold label
        lblold.Text = GridView3.Rows.Count.ToString();
    }

    protected void GridView3_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void btnreply_Click1(object sender, EventArgs e)
    {
        
    }
}
