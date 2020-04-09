using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ClassLibrary;

public partial class Manage_Round_Search : System.Web.UI.Page {
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    SortTable ST = new SortTable ();

    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {
        if (Session["AccountId"] == null || Session["AccountId"].ToString () == "" || Session["USERTYPE"].ToString () != "A") {
            Response.Redirect ("Account/Login.aspx");
        }

        if (!IsPostBack) {
            A.ActionLog ("ACCOUNTS", "", "View");
            dtShowData = new DataTable ();
            dtShowData = this.CreateTableShowData ();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData ((DataTable) ViewState["dtShowData"]);
        }

    }
    private DataTable CreateTableShowData () {
        DataTable dtShowData = new DataTable ();

        ST.AddColToTable (dtShowData, "RoundId", "System.String");
        ST.AddColToTable (dtShowData, "projectYear", "System.String");
        ST.AddColToTable (dtShowData, "projectRound", "System.String");
        ST.AddColToTable (dtShowData, "projectStatus", "System.String");
        ST.AddColToTable (dtShowData, "projectStatusDetail", "System.String");

        return dtShowData;
    }

    protected void btSearch_Click (object sender, EventArgs e) {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;
        this.SearchData ((DataTable) ViewState["dtShowData"]);
    }

    protected void SearchData (DataTable myTable) {
        string sql = @"SELECT id, projectYear, projectRound, projectStatus,
                           CASE WHEN projectStatus = 'A' THEN 'หัวหน้าโครงการเพิ่มข้อมูล %' 
                                WHEN projectStatus = 'W' THEN 'BLS เพิ่ม % Workload' 
                                WHEN projectStatus = 'C' THEN 'ปิดรอบประเมิน' 
                                WHEN projectStatus = 'I' THEN 'ยกเลิกรอบประเมิน' END AS projectStatusDetail
                        FROM  ProjectControl

                        WHERE id is not null  ";

        string prefix = " AND ";

        if (txtRound.Text != "") {
            sql += prefix + "projectRound LIKE @projectRound ";
            prefix = " AND ";
        }
        if (txtYear.Text != "") {
            sql += prefix + "projectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "ORDER BY projectYear DESC ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        try {
            if (txtRound.Text != "") {
                cmd.Parameters.AddWithValue ("@projectRound", "%" + txtRound.Text.Trim () + "%");
            }
            if (txtYear.Text != "") {
                cmd.Parameters.AddWithValue ("@ProjectYear", "%" + txtYear.Text.Trim () + "%");
            }

            if (con.State == ConnectionState.Open) {
                con.Close ();
            }
            con.Open ();

            SqlDataAdapter da = new SqlDataAdapter (cmd);
            DataSet ds = new DataSet ();
            da.Fill (ds, "Data");
            con.Close ();
            myTable.Rows.Clear ();

            for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++) {
                string RoundId = ds.Tables["Data"].Rows[i]["Id"].ToString ();
                string projectYear = ds.Tables["Data"].Rows[i]["projectYear"].ToString ();
                string projectRound = ds.Tables["Data"].Rows[i]["projectRound"].ToString ();
                string projectStatus = ds.Tables["Data"].Rows[i]["projectStatus"].ToString ();
                string projectStatusDetail = ds.Tables["Data"].Rows[i]["projectStatusDetail"].ToString ();

                DataRow row = myTable.NewRow ();

                row["RoundId"] = RoundId;
                row["projectYear"] = projectYear;
                row["projectRound"] = projectRound;
                row["projectStatus"] = projectStatus;
                row["projectStatusDetail"] = projectStatusDetail;

                myTable.Rows.Add (row);
            }

            gvData.DataSource = myTable.DefaultView;
            gvData.DataBind ();
            lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + ds.Tables["Data"].Rows.Count.ToString ("#,###") + " Record(s)</span>";
        } catch (Exception ex) {
            lblError.Text += "SearchData = " + ex.Message + "<br />";
        } finally { con.Close (); }
    }

    protected void btReset_Click (object sender, EventArgs e) {
        txtYear.Text = "";
        txtRound.Text = "";
        UpdatePanel.Visible = false;
        Response.Redirect ("Manage_Round_Search.aspx");
    }

    protected void bt_EditRound_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Manage_Round_Edit.aspx?nID=" + rId);
    }

    protected void bt_ProjectPersonal_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];

        string pageurl = "AdminEvaluted.aspx?nID=" + rId;
        Response.Redirect (pageurl);
    }
    protected void bt_ProjectDetail_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Manage_Round_View_Project.aspx?nID=" + rId);
    }

    protected void bt_UserDetail_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Manage_Round_View_User.aspx?nID=" + rId);
    }
    protected void bt_ProjectCompleted_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Project_Percent_Completed_Add.aspx?nID=" + rId);
    }

    protected void bt_ViewData_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["RoundId"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Report_User_Summary_Detail.aspx?nID=" + rId);
    }

    protected void gvData_Sorting (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging (object sender, GridViewPageEventArgs e) {
        gvData.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind ();
    }
    protected void gvData_SelectedIndexChanged (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus")).Value);

            if (ProjectStatus == "C") {
                e.Row.FindControl ("bt_EditRound").Visible = false;
                e.Row.FindControl ("bt_ViewRound").Visible = true;
            } else {

            }
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

    protected void txtProjectName_TextChanged (object sender, EventArgs e) {

    }

    protected void txtYear_TextChanged (object sender, EventArgs e) {

    }

    protected void btnSurveyAdd_Click (object sender, EventArgs e) {
        Response.Redirect ("Manage_Round_Add.aspx");
    }
}