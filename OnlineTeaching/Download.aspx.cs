using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Download : System.Web.UI.Page
{
    // Declaring a datatable and a table adapter here for the category data
    DS_CATE.catemst_SELECTDataTable CDT = new DS_CATE.catemst_SELECTDataTable();
    DS_CATETableAdapters.catemst_SELECTTableAdapter CAdapter = new DS_CATETableAdapters.catemst_SELECTTableAdapter();

    // Declaring a datatable and a table adapter here for the upload data
    DS_UPLOAD.UPLOADMST_SELECTDataTable UDT = new DS_UPLOAD.UPLOADMST_SELECTDataTable();
    DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter UAdapter = new DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Perform initialization tasks and load data when the page is accessed for the first time
        if (Page.IsPostBack == false)
        {
            // Retrieve category data and bind it to the drpcourse dropdown list
            CDT = CAdapter._select();
            drpcourse.DataSource = CDT;
            drpcourse.DataTextField = "Cname";
            drpcourse.DataValueField = "Cid";
            drpcourse.DataBind();
            drpcourse.Items.Insert(0, "SELECT");

            // Retrieve upload data and bind it to the GvUpload GridView for display
            UDT = UAdapter.Select_Tot();
            GvUpload.DataSource = UDT;
            GvUpload.DataBind();
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        // Perform search operation based on the selected course in the drpcourse dropdown list
        if (drpcourse.SelectedIndex != 0)
        {
            UDT = UAdapter.Select_By_Course(drpcourse.SelectedItem.Text);

            GvUpload.DataSource = UDT;
            GvUpload.DataBind();
        }
    }

    protected void GvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Redirect to the Default.aspx page when a row is clicked in the GvUpload GridView
        Response.Redirect("Default.aspx");
    }

    protected void btndnload_Click(object sender, EventArgs e)
    {
        // Retrieve all upload data and bind it to the GvUpload GridView for display
        UDT = UAdapter.Select_Tot();

        GvUpload.DataSource = UDT;
        GvUpload.DataBind();
    }
}
