using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Upload : System.Web.UI.Page
{
    // Instantiate the dataset object for storing the data retrieved from the "VIDEOMST_SELECT" table
    DS_VIDEO.VIDEOMST_SELECTDataTable VDt = new DS_VIDEO.VIDEOMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "VIDEOMST_SELECT" table
    DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter VAdapter = new DS_VIDEOTableAdapters.VIDEOMST_SELECTTableAdapter();

    // Instantiate the dataset object for storing the data retrieved from the "STAFFMST_SELECT" table
    DS_STAFF.STAFFMST_SELECTDataTable SDT = new DS_STAFF.STAFFMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "STAFFMST_SELECT" table
    DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter SAdapter = new DS_STAFFTableAdapters.STAFFMST_SELECTTableAdapter();

    // Instantiate the dataset object for storing the data retrieved from the "UPLOADMST_SELECT" table
    DS_UPLOAD.UPLOADMST_SELECTDataTable UDT = new DS_UPLOAD.UPLOADMST_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "UPLOADMST_SELECT" table
    DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter UAdapter = new DS_UPLOADTableAdapters.UPLOADMST_SELECTTableAdapter();

    // Instantiate the dataset object for storing the data retrieved from the "catemst_SELECT" table
    DS_CATE.catemst_SELECTDataTable CDT = new DS_CATE.catemst_SELECTDataTable();

    // Instantiate the table adapter object for executing queries and data operations on the "catemst_SELECT" table
    DS_CATETableAdapters.catemst_SELECTTableAdapter CAdapter = new DS_CATETableAdapters.catemst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = "";

        if (Page.IsPostBack == false)
        {
            // Retrieve data from the "catemst_SELECT" table and populate the dropdown list for courses
            CDT = CAdapter._select();
            drpcourse.DataSource = CDT;
            drpcourse.DataTextField = "Cname";
            drpcourse.DataValueField = "Cid";
            drpcourse.DataBind();
            drpcourse.Items.Insert(0, "SELECT");

            // Retrieve data from the "STAFFMST_SELECT" table and populate the dropdown list for staff
            SDT = SAdapter.select();
            drpstaff.DataSource = SDT;
            drpstaff.DataTextField = "Name";
            drpstaff.DataValueField = "sid";
            drpstaff.DataBind();
            drpstaff.Items.Insert(0, "SELECT");
        }
    }

    protected void btnsearchcourse_Click(object sender, EventArgs e)
    {
        if (rdofile.Checked == true)
        {
            // Retrieve data from the "UPLOADMST_SELECT" table based on the selected course and bind it to the GridView
            UDT = UAdapter.Select_By_Course(drpcourse.SelectedItem.Text);
            GvUpload.DataSource = UDT;
            GvUpload.DataBind();
            MultiView1.ActiveViewIndex = 0;
            lbl.Text = "Total = " + GvUpload.Rows.Count.ToString();
        }
        else
        {
            // Retrieve data from the "VIDEOMST_SELECT" table based on the selected course and bind it to the GridView
            VDt = VAdapter.Select_By_Course(drpcourse.SelectedItem.Text);
            GvPDF.DataSource = VDt;
            GvPDF.DataBind();
            MultiView1.ActiveViewIndex = 1;
            lbl.Text = "Total = " + GvPDF.Rows.Count.ToString();
        }

        // Retrieve data from the "STAFFMST_SELECT" table and populate the dropdown list for staff
        SDT = SAdapter.select();
        drpstaff.DataSource = SDT;
        drpstaff.DataTextField = "Name";
        drpstaff.DataValueField = "sid";
        drpstaff.DataBind();
        drpstaff.Items.Insert(0, "SELECT");
    }

    protected void btnsearchstafff_Click(object sender, EventArgs e)
    {
        if (rdofile.Checked == true)
        {
            // Retrieve data from the "UPLOADMST_SELECT" table based on the selected staff and bind it to the GridView
            UDT = UAdapter.Select_By_Staff(drpstaff.SelectedItem.Text);
            GvUpload.DataSource = UDT;
            GvUpload.DataBind();
            MultiView1.ActiveViewIndex = 0;
            lbl.Text = "Total = " + GvUpload.Rows.Count.ToString();
        }
        else
        {
            // Retrieve data from the "VIDEOMST_SELECT" table based on the selected staff and bind it to the GridView
            VDt = VAdapter.Select_By_Staff(drpstaff.SelectedItem.Text);
            GvPDF.DataSource = VDt;
            GvPDF.DataBind();
            MultiView1.ActiveViewIndex = 1;
            lbl.Text = "Total = " + GvPDF.Rows.Count.ToString();
        }

        // Retrieve data from the "catemst_SELECT" table and populate the dropdown list for courses
        CDT = CAdapter._select();
        drpcourse.DataSource = CDT;
        drpcourse.DataTextField = "Cname";
        drpcourse.DataValueField = "Cid";
        drpcourse.DataBind();
        drpcourse.Items.Insert(0, "SELECT");
    }

    protected void GvPDF_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Redirect to the URL specified in the CommandArgument of the selected row in the PDF GridView
        Response.Redirect(e.CommandArgument.ToString());
    }

    protected void GvUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Redirect to the URL specified in the CommandArgument of the selected row in the Upload GridView
        Response.Redirect(e.CommandArgument.ToString());
    }
}
