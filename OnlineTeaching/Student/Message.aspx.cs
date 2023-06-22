using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Message : System.Web.UI.Page
{
    // Declare and initialize DataTables and TableAdapters
    // Declare and initialize a DataTable for staff data retrieval
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Declare and initialize a TableAdapter for staff data retrieval
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    // Declare and initialize a DataTable for message data retrieval
    DS_MSG.MSGMST_SELECTDataTable MDT = new DS_MSG.MSGMST_SELECTDataTable();

    // Declare and initialize a TableAdapter for message data retrieval
    DS_MSGTableAdapters.MSGMST_SELECTTableAdapter MAdapter = new DS_MSGTableAdapters.MSGMST_SELECTTableAdapter();


    protected void Page_Load(object sender, EventArgs e)
    {
        // Initialize the page
        MultiView1.ActiveViewIndex = 0;

        // Retrieve new messages for the logged-in student
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 0);
        GridView2.DataSource = MDT;
        GridView2.DataBind();
        lblnew.Text = GridView2.Rows.Count.ToString();
    }

    protected void btnappluleave_Click(object sender, EventArgs e)
    {
        // Implement the logic for applying leave
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        // Switch to the view for new messages
        MultiView1.ActiveViewIndex = 0;

        // Retrieve new messages for the logged-in student
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 0);
        GridView2.DataSource = MDT;
        GridView2.DataBind();
        lblnew.Text = GridView2.Rows.Count.ToString();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        // Switch to the view for old messages
        MultiView1.ActiveViewIndex = 1;

        // Retrieve old messages for the logged-in student
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 1);
        GridView3.DataSource = MDT;
        GridView3.DataBind();
        lblold.Text = GridView3.Rows.Count.ToString();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Handle the row command for new messages
        MAdapter.MSGMST_Update_Status(1, Convert.ToInt32(e.CommandArgument.ToString()));
        MultiView1.ActiveViewIndex = 2;

        // Retrieve details of the selected message
        MDT = MAdapter.Select_By_ID(Convert.ToInt32(e.CommandArgument.ToString()));
        lblfname.Text = MDT.Rows[0]["Fname"].ToString();
        lblsub.Text = MDT.Rows[0]["subject"].ToString();
        lblmsg.Text = MDT.Rows[0]["message"].ToString();
    }

    protected void btnreply_Click(object sender, EventArgs e)
    {
        // Reply to the selected message
        MAdapter.Insert(Session["email"].ToString(), lblfname.Text, lblsub.Text, txtreply.Text);
        lblsub.Text = "Reply Successfully";
        txtreply.Text = "";
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Handle the row command for old messages
        MAdapter.Delete(Convert.ToInt32(e.CommandArgument.ToString()));
        MultiView1.ActiveViewIndex = 1;

        // Retrieve updated old messages
        MDT = MAdapter.Select_Status_TName(Session["email"].ToString(), 1);
        GridView3.DataSource = MDT;
        GridView3.DataBind();
        lblold.Text = GridView3.Rows.Count.ToString();
    }

    protected void btnsendmsg_Click(object sender, EventArgs e)
    {
        // Send a new message to staff
        MultiView1.ActiveViewIndex = 3;
        MAdapter.Insert(Session["email"].ToString(), drpstaff.SelectedItem.Text, txtsubmsg.Text, txtmsgmsg.Text);
        lblsendmsg.Text = "Message Send";
        txtmsgmsg.Text = "";
        txtsubmsg.Text = "";
        drpstaff.SelectedIndex = 0;
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        // Switch to the view for sending a new message
        MultiView1.ActiveViewIndex = 3;

        // Retrieve staff members/teachers for the logged-in student's course
        SDT = SAdapter.Select_By_Course(Session["cname"].ToString());

        drpstaff.DataSource = SDT;
        drpstaff.DataTextField = "Email";
        drpstaff.DataValueField = "SID";
        drpstaff.DataBind();
    }

    protected void GridView2_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        // Handle the row command for new messages 
    }

    protected void GridView3_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        // Handle the row command for old messages 
    }

    protected void btnreply_Click1(object sender, EventArgs e)
    {
        // Handle the reply button click 
    }
}
