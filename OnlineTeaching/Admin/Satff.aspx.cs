using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Satff : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "catemst" table
    DS_CATE.catemst_SELECTDataTable CDT = new DS_CATE.catemst_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "catemst" table
    DS_CATETableAdapters.catemst_SELECTTableAdapter CAdapter = new DS_CATETableAdapters.catemst_SELECTTableAdapter();

    // Instantiate the dataset object for storing the data retrieved from the "STAFFMST" table
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "STAFFMST" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblfile.Text = "";

        if (Page.IsPostBack == false)
        {
            // Retrieve data from the "catemst" table and populate the dataset
            CDT = CAdapter._select();

            // Bind the dataset to the dropdown list for displaying course options
            drpcourse.DataSource = CDT;
            drpcourse.DataTextField = "cname";
            drpcourse.DataValueField = "cid";
            drpcourse.DataBind();

            // Insert a default "SELECT" option at the beginning of the dropdown list
            drpcourse.Items.Insert(0, "SELECT");
        }
    }

    protected void btnaddstaff_Click(object sender, EventArgs e)
    {
        // Check if the email already exists in the "STAFFMST" table
        SDT = SAdapter.Select_by_email(txtemail.Text);

        if (SDT.Rows.Count == 1)
        {
            lblerror.Text = "Email already exists!";
        }
        else
        {
            if (FileUpload1.HasFile)
            {
                // Save the uploaded file to the server
                FileUpload1.SaveAs(Server.MapPath("~/Admin/staffimg/") + FileUpload1.FileName);

                // Insert staff details into the "STAFFMST" table using the table adapter
                SAdapter.Insert(txtname.Text, txtmobile.Text, txtadd.Text, txtcity.Text, txtpin.Text, "~/Admin/staffimg/" + FileUpload1.FileName, txteducation.Text, txtexperience.Text, drpcourse.SelectedItem.Text, txtemail.Text, txtpassword.Text);

                // Clear the input fields
                txtpin.Text = "";
                txtmobile.Text = "";
                txtname.Text = "";
                txtadd.Text = "";
                txtcity.Text = "";
                txteducation.Text = "";
                txtexperience.Text = "";
                txtemail.Text = "";
                txtpassword.Text = "";
                txtconfirmpass.Text = "";

                lblerror.Text = "Teacher details added successfully!";
            }
            else
            {
                lblfile.Text = "No file selected!";
            }
        }
    }

    // Event handlers for text changed events
    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
       
       

    }
    protected void txtname_TextChanged(object sender, EventArgs e)
    {
      
    }
    protected void txtmobile_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtadd_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void txtcity_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void txteducation_TextChanged(object sender, EventArgs e)
    {
      
    }
    protected void txtexperience_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtemail_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtpassword_TextChanged(object sender, EventArgs e)
    {
        
      

    }
    protected void txtconfirmpass_TextChanged(object sender, EventArgs e)
    {
       
    }
}