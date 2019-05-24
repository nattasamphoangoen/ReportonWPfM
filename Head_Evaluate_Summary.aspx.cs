using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//2
public partial class Evaluate_Summary : System.Web.UI.Page {
    //=============================DevelMaint2_1 =================================================
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    DataTable dtShowData2;
    SortTable ST = new SortTable ();
    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {

        this.SearchData ();

    }

    protected void report1_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_ServiceWork.aspx?nID=" + rId);

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Develop_Mainten.aspx?nID=" + rId);

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Research.aspx?nID=" + rId);

    }
    protected void report4_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Promotion_work.aspx?nID=" + rId);

    }
    protected void report5_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_AcademicServices.aspx?nID=" + rId);

    }
    protected void report6_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Management.aspx?nID=" + rId);

    }
    protected void report7_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Other.aspx?nID=" + rId);

    }
    protected void reportSummary_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Summary.aspx?nID=" + rId);

    }

    protected void SearchData () {
        string sql = @"SELECT [id]
                    ,[ddlType]
                    ,[ddlValue]
                    ,[ddlDisplay]
                    ,[ddlStatus]
                    ,[ddlOrder]
                    FROM [MasterDDL] 

                    WHERE  ddlType = 'Summary-1_1'";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind ();
        lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add2_1_Click (object sender, EventArgs e) {
        //  UpdatePanel2_1.Update ();
        // popupAddDevelMaint2_1.Show ();
        this.ClearPopUp ();
    }

    protected void gvData_Sorting (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging (object sender, GridViewPageEventArgs e) {
        gvData.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind ();
        this.btnSubmit_Click (sender, e);
    }
    protected void gvData_SelectedIndexChanged (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus")).Value);
        }

    }

    public SortDirection GridviewSortDirection {
        get {
            if (ViewState["sortDirection"] == null) {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection) ViewState["sortDirection"];
        }
        set {
            ViewState["sortDirection"] = value;
        }
    }

    //=============================popup=================================================

    protected void ClearPopUp () {

    }
    protected void btnAddDevelMaint_Click (object sender, EventArgs e) {

    }
    protected void btnDeleteDevelMaint_Click (object sender, EventArgs e) {

    }

    protected void btnSubmit_Click (object sender, EventArgs e) {

        this.SearchData ();
    }

    protected void btnDownload_Click (object sender, EventArgs e) {

        this.SearchData ();
    }

}