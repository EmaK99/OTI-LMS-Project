using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registartion : System.Web.UI.Page
{
    // Declare a datatable and a table adapter for the student data
    DS_REGI.StudentMst_SELECTDataTable StuDT = new DS_REGI.StudentMst_SELECTDataTable();
    DS_REGITableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_REGITableAdapters.StudentMst_SELECTTableAdapter();

    // Declare a datatable and a table adapter for the category data
    DS_CATE.catemst_SELECTDataTable CDT = new DS_CATE.catemst_SELECTDataTable();
    DS_CATETableAdapters.catemst_SELECTTableAdapter CAdapter = new DS_CATETableAdapters.catemst_SELECTTableAdapter();


    protected void Page_Load(object sender, EventArgs e)
    {
        // This event handler is executed when the page is loaded
        // Check if it is the first load (not a postback)
        if (Page.IsPostBack == false)
        {
            // Retrieve category data and bind it to the drpcourse dropdown list
            CDT = CAdapter._select();
            drpcourse.DataSource = CDT;
            drpcourse.DataTextField = "cname";
            drpcourse.DataValueField = "cid";
            drpcourse.DataBind();

            drpcourse.Items.Insert(0, "SELECT");
        }
    }

    protected void btnstuadd_Click(object sender, EventArgs e)
    {
        // This event handler is executed when the "Add" button is clicked
        // Check if a file is selected in the FileUpload control
        if (FileUpload1.HasFile)
        {
            // Save the file to the specified directory
            FileUpload1.SaveAs(Server.MapPath("~/Studentimg/" + FileUpload1.FileName));

            // Insert student data into the database using the table adapter
            StuAdapter.Insert(
                txtname.Text,
                txtemail.Text,
                txtmobi.Text,
                "~/Studentimg/" + FileUpload1.FileName,
                drpcourse.SelectedItem.Text,
                txtadd.Text,
                txtcity.Text,
                txtpin.Text,
                txtuname.Text,
                txtpass.Text
            );

            // Display a success message and reset the form fields
            lblmsg.Text = "Student Added.";
            txtname.Text = "";
            txtadd.Text = "";
            txtcity.Text = "";
            txtemail.Text = "";
            txtmobi.Text = "";
            txtpass.Text = "";
            txtpin.Text = "";
            txtuname.Text = "";
            txtcpass.Text = "";
            drpcourse.SelectedIndex = 0;
        }
    }
}
