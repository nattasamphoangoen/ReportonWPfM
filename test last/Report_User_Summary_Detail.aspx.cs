using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using ClassLibrary;
using System.Text.RegularExpressions;
using System.IO;


public partial class Report_User_Summary_Detail : System.Web.UI.Page
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
            string rId = Request.QueryString["nId"];
            A.ActionLog("ACCOUNTS", "", "View");
            dtShowData = new DataTable();
            dtShowData = this.CreateTableShowData();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData((DataTable)ViewState["dtShowData"], rId);

            //lbProjectYear.Text = Session["ProjectYear"].ToString();
            //lbProjectRound.Text = Session["ProjectRound"].ToString();
        }

    }
    private DataTable CreateTableShowData()
    {
        DataTable dtShowData = new DataTable();

        ST.AddColToTable(dtShowData, "ProjectId", "System.String");
        ST.AddColToTable(dtShowData, "AccountId", "System.String");
        ST.AddColToTable(dtShowData, "FullName", "System.String");
        ST.AddColToTable(dtShowData, "ProjectName", "System.String");
        ST.AddColToTable(dtShowData, "Percentjoin", "System.String");
        ST.AddColToTable(dtShowData, "percentWorkload", "System.String");
        ST.AddColToTable(dtShowData, "TotalPoint", "System.String");
        ST.AddColToTable(dtShowData, "ProjectYear", "System.String");
        ST.AddColToTable(dtShowData, "ProjectRound", "System.String");

        return dtShowData;
    }



    protected void btSearch_Click(object sender, EventArgs e)
    {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;
        //lbProjectYear.Text = ddlYear.SelectedValue;
        //lbProjectRound.Text = ddlRound.SelectedValue;

        
    }

    protected void SearchData(DataTable myTable, string rId)
    {
        string sql = @"SELECT W.projectId, W.AccountId, A.Title+ ' ' + A.Firstname+ ' ' + A.Lastname AS FullName, M.ProjectName,M.ProjectYear, M.ProjectRound, A.Department, A.Section,
                           Sum(W.Percentjoin) AS Percentjoin, Sum(W.percentWorkload) AS percentWorkload, CONVERT(decimal(6,2), (W.Percentjoin*W.percentWorkload)/100) AS TotalPoint
                    FROM ProjectJoin AS W
                    INNER JOIN ProjectMaster AS M ON M.Id = W.projectId
                    INNER JOIN Account AS A ON A.id = W.AccountId
					INNER JOIN ProjectControl AS C  ON C.projectYear = M.ProjectYear AND C.projectRound = M.ProjectRound
                    WHERE W.Status = 'A' AND A.UserPosition IS NOT NULL AND C.id = @ProjectRound 
                    GROUP BY W.projectId, W.AccountId, M.ProjectName, A.Title+ ' ' + A.Firstname+ ' ' + A.Lastname , (W.Percentjoin*W.percentWorkload)/100, M.ProjectYear, M.ProjectRound, A.Department, A.Section, W.percentWorkload
                    ORDER BY A.Department, A.Section, W.AccountId ";


        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            //cmd.Parameters.AddWithValue("@projectYear", Session["ProjectYear"]);
            //cmd.Parameters.AddWithValue("@projectRound", Session["ProjectRound"]);
            cmd.Parameters.AddWithValue("@ProjectRound", rId);


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
                string ProjectId = ds.Tables["Data"].Rows[i]["projectId"].ToString();
                string AccountId = ds.Tables["Data"].Rows[i]["AccountId"].ToString();
                string FullName = ds.Tables["Data"].Rows[i]["FullName"].ToString();
                string ProjectName = ds.Tables["Data"].Rows[i]["ProjectName"].ToString();
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();
                string percentWorkload = ds.Tables["Data"].Rows[i]["percentWorkload"].ToString();
                string TotalPoint = ds.Tables["Data"].Rows[i]["TotalPoint"].ToString();
                string ProjectYear = ds.Tables["Data"].Rows[i]["ProjectYear"].ToString();
                string ProjectRound = ds.Tables["Data"].Rows[i]["ProjectRound"].ToString();


                DataRow row = myTable.NewRow();

                row["ProjectId"] = ProjectId;
                row["AccountId"] = AccountId;
                row["FullName"] = FullName;
                row["ProjectName"] = ProjectName;
                row["Percentjoin"] = Percentjoin;
                row["percentWorkload"] = percentWorkload;
                row["TotalPoint"] = TotalPoint;
                row["ProjectYear"] = ProjectYear;
                row["ProjectRound"] = ProjectRound;

                myTable.Rows.Add(row);
            }

            gvData.DataSource = myTable.DefaultView;
            gvData.DataBind();
            lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + ds.Tables["Data"].Rows.Count.ToString("#,###") + " Record(s)</span>";
        }
        catch (Exception ex)
        {
            //lblError.Text += "SearchData = " + ex.Message + "<br />";
        }
        finally { con.Close(); }
    }

    protected void btReset_Click(object sender, EventArgs e)
    {
        //ddlYear.SelectedValue = "0";
        //ddlRound.SelectedValue = "0";
        //UpdatePanelS.Visible = false;
        //Response.Redirect("Report_User_Detail_Search.aspx");
    }

    protected void bt_ProjectJoin_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string sId = gvData.DataKeys[row.RowIndex]["ProjectId"].ToString();
        //string rId = Request.QueryString["nId"];
        Response.Redirect("User_Join_Add.aspx?nID=" + sId);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        gvData.AllowPaging = false;
        gvData.DataSource = ((DataTable)ViewState["dtShowData"]).DefaultView;
        gvData.DataBind();

        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Report_Workload_Summary_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.ContentType = "application/vnd.xls";
        HttpContext.Current.Response.Write("<style>.String_Num {mso-number-format:\\@;}</style>");//ให้เลขศูนย์ออกในExcel

        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        HtmlForm frm = new HtmlForm();

        frm.Attributes["runat"] = "server";
        frm.Controls.Add(gvData);
        gvData.RenderControl(htw);

        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();

        gvData.AllowPaging = true;
        gvData.DataSource = ((DataTable)ViewState["dtShowData"]).DefaultView;
        gvData.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
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

    protected void txtProjectName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtYear_TextChanged(object sender, EventArgs e)
    {

    }
}