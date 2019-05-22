using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using WebSite2;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using ClassLibrary;
using System.Text.RegularExpressions;

public partial class Evaluate_User : System.Web.UI.Page
{
   Authorize A = new Authorize();
    SqlConnection con = new SqlConnection();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    SortTable ST = new SortTable();

    ConnectDB db = new ConnectDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] == null || Session["AccountId"].ToString() == "" || Session["USERTYPE"].ToString() != "A")
        {
            Response.Redirect("Account/Login.aspx");
        }

        if (!IsPostBack)
        {
            A.ActionLog("ACCOUNTS", "", "View");
            dtShowData = new DataTable();
            dtShowData = this.CreateTableShowData();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData((DataTable)ViewState["dtShowData"]);
        }

    }
    private DataTable CreateTableShowData()
    {
        DataTable dtShowData = new DataTable();

        ST.AddColToTable(dtShowData, "MId", "System.String");
        ST.AddColToTable(dtShowData, "acountId", "System.String");
        ST.AddColToTable(dtShowData, "projectYear", "System.String");
        ST.AddColToTable(dtShowData, "projectRound", "System.String");
        ST.AddColToTable(dtShowData, "projectUserStatus", "System.String");
      
              
                
        return dtShowData;
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;
        this.SearchData((DataTable)ViewState["dtShowData"]);
    }

    protected void SearchData(DataTable myTable)
    {
        string sql = @"SELECT M.id as Mid, M.acountId, C.projectYear, C.projectRound,
                                CASE WHEN C.projectUserStatus = 'W' THEN 'เปิด' 
                                WHEN C.projectUserStatus = 'C' THEN 'ปิด' END AS projectUserStatus
                        FROM EvaluateMaster AS M
                        LEFT JOIN ProjectControl AS C ON M.roundId = C.id
                        LEFT JOIN Account AS A ON M.acountId = A.id
                        WHERE M.acountId =  @AccountId ";

        

        string prefix = " AND ";

        if (txtRound.Text != "")
        {
            sql += prefix + "projectRound LIKE @projectRound ";
            prefix = " AND ";
        }
        if (txtYear.Text != "")
        {
            sql += prefix + "projectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "ORDER BY projectYear DESC ";


        
        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@AccountId", Session["AccountId"]);
            if (txtRound.Text != "")
            {
                cmd.Parameters.AddWithValue("@projectRound", "%" + txtRound.Text.Trim() + "%");
            }
            if (txtYear.Text != "")
            {
                cmd.Parameters.AddWithValue("@ProjectYear", "%" + txtYear.Text.Trim() + "%");
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Data");
            con.Close();
            myTable.Rows.Clear();

            for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
            {
              
                string MId = ds.Tables["Data"].Rows[i]["Mid"].ToString();
                string acountId = ds.Tables["Data"].Rows[i]["acountId"].ToString();
                string projectYear = ds.Tables["Data"].Rows[i]["projectYear"].ToString();
                string projectRound = ds.Tables["Data"].Rows[i]["projectRound"].ToString();
                string projectUserStatus = ds.Tables["Data"].Rows[i]["projectUserStatus"].ToString();
               // string MId = ds.Tables["Data"].Rows[i]["Id"].ToString();
               
                DataRow row = myTable.NewRow();

                row["MId"] = MId;
                row["acountId"] = acountId;
                row["projectYear"] = projectYear;
                row["projectRound"] = projectRound;
                row["projectUserStatus"] = projectUserStatus;
                

                myTable.Rows.Add(row);
            }

            gvData.DataSource = myTable.DefaultView;
            gvData.DataBind();
            lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + ds.Tables["Data"].Rows.Count.ToString("#,###") + " Record(s)</span>";
        }
        catch (Exception ex)
        {
            lblError.Text += "SearchData = " + ex.Message + "<br />";
        }
        finally { con.Close(); }
    }

    protected void btReset_Click(object sender, EventArgs e)
    {
        txtYear.Text = "";
        txtRound.Text = "";
        UpdatePanel.Visible = false;
        Response.Redirect("Evaluate_User.aspx");
    }

    protected void bt_EditRound_Click(object sender, EventArgs e)
    {        
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["MId"].ToString();
        //string rId = Request.QueryString["nId"];
        Response.Redirect("Evaluate_Index.aspx?nID=" + rId);
    }


    protected void bt_ViewData_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["MId"].ToString();
        //string rId = Request.QueryString["nId"];
        Response.Redirect("Evaluate_User.aspx?nID=" + rId);
    }

    protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting(sender, e, (DataTable)ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.DataSource = ((DataTable)ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind();
    }
    protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String ProjectStatus = Convert.ToString(((HiddenField)e.Row.FindControl("hdf_ProjectStatus")).Value);

            if (ProjectStatus == "ปิด")
            {
                e.Row.FindControl("bt_EditRound").Visible = false;
                e.Row.FindControl("bt_ViewRound").Visible = true;
            }
            else
            {

            }
        }

    }

    public SortDirection GridviewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

}