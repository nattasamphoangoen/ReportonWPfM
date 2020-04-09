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

public partial class Report_User_Summary : System.Web.UI.Page
{
    Authorize A = new Authorize();
    SqlConnection con = new SqlConnection();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    SortTable ST = new SortTable();

    ConnectDB db = new ConnectDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] == null || Session["AccountId"].ToString() == "")
        {
            Response.Redirect("Account/Login.aspx");
        }

        if (!IsPostBack)
        {
            A.ActionLog("ACCOUNTS", "", "View");
            dtShowData = new DataTable();

            Session["ProjectYear"] = "";
            Session["ProjectRound"] = "";

            UpdatePanelS.Visible = false;
            dtShowData = this.CreateTableShowData();
            ViewState["dtShowData"] = dtShowData;
            //this.SearchData((DataTable)ViewState["dtShowData"]);
        }

    }
    private DataTable CreateTableShowData()
    {
        DataTable dtShowData = new DataTable();

        ST.AddColToTable(dtShowData, "AccountId", "System.String");
        ST.AddColToTable(dtShowData, "FullName", "System.String");
        ST.AddColToTable(dtShowData, "Department", "System.String");
        ST.AddColToTable(dtShowData, "Section", "System.String");
        ST.AddColToTable(dtShowData, "Position", "System.String");
        ST.AddColToTable(dtShowData, "Percentjoin", "System.String");
        ST.AddColToTable(dtShowData, "percentWorkload", "System.String");
        ST.AddColToTable(dtShowData, "TotalPoint", "System.String");

        return dtShowData;
    }



    protected void btSearch_Click(object sender, EventArgs e)
    {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;
        lbProjectYear.Text = ddlYear.SelectedValue;
        lbProjectRound.Text = ddlRound.SelectedValue;

        UpdatePanelS.Visible = true;
        this.SearchData((DataTable)ViewState["dtShowData"]);
    }

    protected void SearchData(DataTable myTable)
    {
        string sql = @"SELECT Z.AccountId, Z.FullName, Z.Department, Z.Section, Z.Position, SUM(Z.Percentjoin) AS Percentjoin , Sum(Z.percentWorkload) AS percentWorkload, CONVERT(decimal(6,2), SUM(Z.TotalPoint)) AS TotalPoint
FROM (SELECT W.projectId, W.AccountId, A.Title+ ' ' + A.Firstname+ ' ' + A.Lastname AS FullName, M.ProjectName,M.ProjectYear, M.ProjectRound, A.Department, A.Section, A.Position,
                           Sum(W.Percentjoin) AS Percentjoin, Sum(W.percentWorkload) AS percentWorkload, (W.Percentjoin*W.percentWorkload)/100 AS TotalPoint
                    FROM ProjectWorkload AS W
                    INNER JOIN ProjectMaster AS M ON M.Id = W.projectId
                    INNER JOIN Account AS A ON A.id = W.AccountId
                    WHERE W.projectYear = @projectYear AND W.projectRound = @projectRound
                    GROUP BY W.projectId, W.AccountId, M.ProjectName, A.Title+ ' ' + A.Firstname+ ' ' + A.Lastname , (W.Percentjoin*W.percentWorkload)/100, M.ProjectYear, M.ProjectRound, A.Department, A.Section, A.Position, W.percentWorkload
                     ) AS Z
GROUP BY Z.AccountId, Z.FullName, Z.Department, Z.Section, Z.Position
ORDER BY Z.Department, Z.Section, Z.FullName ";


        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@projectYear", ddlYear.SelectedValue);
            cmd.Parameters.AddWithValue("@projectRound", ddlRound.SelectedValue);


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
                string AccountId = ds.Tables["Data"].Rows[i]["AccountId"].ToString();
                string FullName = ds.Tables["Data"].Rows[i]["FullName"].ToString();
                string Department = ds.Tables["Data"].Rows[i]["Department"].ToString();
                string Section = ds.Tables["Data"].Rows[i]["Section"].ToString();
                string Position = ds.Tables["Data"].Rows[i]["Position"].ToString();
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();
                string percentWorkload = ds.Tables["Data"].Rows[i]["percentWorkload"].ToString();
                string TotalPoint = ds.Tables["Data"].Rows[i]["TotalPoint"].ToString();


                DataRow row = myTable.NewRow();

                row["AccountId"] = AccountId;
                row["FullName"] = FullName;
                row["Department"] = Department;
                row["Section"] = Section;
                row["Position"] = Position;
                row["Percentjoin"] = Percentjoin;
                row["percentWorkload"] = percentWorkload;
                row["TotalPoint"] = TotalPoint;

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
        ddlYear.SelectedValue = "0";
        ddlRound.SelectedValue = "0";
        UpdatePanelS.Visible = false;
        //Response.Redirect("Report_User_Detail_Search.aspx");
    }

    protected void btnReportDeteil_Click(object sender, EventArgs e)
    {
        Session["ProjectYear"] = ddlYear.SelectedValue;
        Session["ProjectRound"] = ddlRound.SelectedValue;
        Response.Redirect("Report_User_Detail.aspx");
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