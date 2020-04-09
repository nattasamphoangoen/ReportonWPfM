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

public partial class Project_Search : System.Web.UI.Page
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
            dtShowData = this.CreateTableShowData();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData1((DataTable)ViewState["dtShowData"]);
        }

    }
    private DataTable CreateTableShowData()
    {
        DataTable dtShowData = new DataTable();

        ST.AddColToTable(dtShowData, "ProjectId", "System.String");
        ST.AddColToTable(dtShowData, "ProjectName", "System.String");
        ST.AddColToTable(dtShowData, "ProjectYear", "System.String");
        ST.AddColToTable(dtShowData, "ProjectRound", "System.String");
        ST.AddColToTable(dtShowData, "ProjectHeader", "System.String");
        ST.AddColToTable(dtShowData, "FirstName", "System.String"); 
        ST.AddColToTable(dtShowData, "FullName", "System.String"); 
        ST.AddColToTable(dtShowData, "projectStatus", "System.String"); 
        ST.AddColToTable(dtShowData, "Percentjoin", "System.String");

        return dtShowData;
    }    

    protected void btSearch_Click(object sender, EventArgs e)
    {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;

        UpdatePanel.Visible = true;
        this.SearchData((DataTable)ViewState["dtShowData"]);
    }

    protected void SearchData(DataTable myTable)
    {
        string sql = @"SELECT  M.id, M.idRef, M.ProjectName, M.ProjectYear, M.ProjectRound, M.Email, M.ProjectHeader, M.PercentGoal, M.PercentCompleted, 
                            A.Title, A.FirstName,A.LastName, A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName, C.projectStatus , SUM(J.Percentjoin) AS Percentjoin
                            FROM  ProjectMaster AS M
                            INNER JOIN Account AS A ON A.id = M.ProjectHeader
							INNER JOIN ProjectJoin AS J ON J.ProjectId = M.id
							INNER JOIN ProjectControl AS C ON C.projectYear = M.ProjectYear AND C.projectRound = M.ProjectRound AND C.projectStatus IN ('A','W','C')

                        WHERE M.ProjectHeader = @AccountId AND M.id is not null AND J.Status ='A' ";
        string prefix = " AND ";

        if (txtProjectName.Text != "")
        {
            sql += prefix + "M.ProjectName LIKE @ProjectName ";
            prefix = " AND ";
        }
        if (txtYear.Text != "")
        {
            sql += prefix + "M.ProjectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "GROUP BY M.id, M.idRef, M.ProjectName, M.ProjectYear, M.ProjectRound, M.Email, M.ProjectHeader, M.PercentGoal, M.PercentCompleted,A.Title, A.FirstName,A.LastName, A.Title+ ' '+ A.FirstName + ' ' + A.LastName , C.projectStatus " +
               "ORDER BY M.ProjectYear DESC, M.id ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@AccountId", Session["AccountId"]);
            if (txtProjectName.Text != "")
            {
                cmd.Parameters.AddWithValue("@ProjectName", "%" + txtProjectName.Text.Trim() + "%");
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
                string ProjectId = ds.Tables["Data"].Rows[i]["Id"].ToString();
                string ProjectName = ds.Tables["Data"].Rows[i]["ProjectName"].ToString();
                string ProjectYear = ds.Tables["Data"].Rows[i]["ProjectYear"].ToString();
                string ProjectRound = ds.Tables["Data"].Rows[i]["ProjectRound"].ToString();
                string ProjectHeader = ds.Tables["Data"].Rows[i]["ProjectHeader"].ToString();
                string FirstName = ds.Tables["Data"].Rows[i]["FirstName"].ToString(); 
                string FullName = ds.Tables["Data"].Rows[i]["FullName"].ToString();
                string projectStatus = ds.Tables["Data"].Rows[i]["projectStatus"].ToString(); 
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();

                DataRow row = myTable.NewRow();

                row["ProjectId"] = ProjectId;
                row["ProjectName"] = ProjectName;
                row["ProjectYear"] = ProjectYear;
                row["ProjectRound"] = ProjectRound;
                row["ProjectHeader"] = ProjectHeader;
                row["FirstName"] = FirstName; 
                row["FullName"] = FullName;
                row["projectStatus"] = projectStatus;
                row["Percentjoin"] = Percentjoin;

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

    protected void SearchData1(DataTable myTable)
    {
        string sql = @"SELECT  M.id, M.idRef, M.ProjectName, M.ProjectYear, M.ProjectRound, M.Email, M.ProjectHeader, M.PercentGoal, M.PercentCompleted, 
                            A.Title, A.FirstName,A.LastName, A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName, C.projectStatus , SUM(J.Percentjoin) AS Percentjoin
                            FROM  ProjectMaster AS M
                            INNER JOIN Account AS A ON A.id = M.ProjectHeader
							INNER JOIN ProjectJoin AS J ON J.ProjectId = M.id
							INNER JOIN ProjectControl AS C ON C.projectYear = M.ProjectYear AND C.projectRound = M.ProjectRound AND C.projectStatus IN ('A','W','C')

                        WHERE M.ProjectHeader = @AccountId AND M.id is not null AND J.Status ='A' AND C.projectStatus IN ('A','W')  ";
        string prefix = " AND ";

        if (txtProjectName.Text != "")
        {
            sql += prefix + "M.ProjectName LIKE @ProjectName ";
            prefix = " AND ";
        }
        if (txtYear.Text != "")
        {
            sql += prefix + "M.ProjectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "GROUP BY M.id, M.idRef, M.ProjectName, M.ProjectYear, M.ProjectRound, M.Email, M.ProjectHeader, M.PercentGoal, M.PercentCompleted,A.Title, A.FirstName,A.LastName, A.Title+ ' '+ A.FirstName + ' ' + A.LastName , C.projectStatus " +
               "ORDER BY M.ProjectYear DESC, M.id ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@AccountId", Session["AccountId"]);
            if (txtProjectName.Text != "")
            {
                cmd.Parameters.AddWithValue("@ProjectName", "%" + txtProjectName.Text.Trim() + "%");
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
                string ProjectId = ds.Tables["Data"].Rows[i]["Id"].ToString();
                string ProjectName = ds.Tables["Data"].Rows[i]["ProjectName"].ToString();
                string ProjectYear = ds.Tables["Data"].Rows[i]["ProjectYear"].ToString();
                string ProjectRound = ds.Tables["Data"].Rows[i]["ProjectRound"].ToString();
                string ProjectHeader = ds.Tables["Data"].Rows[i]["ProjectHeader"].ToString();
                string FirstName = ds.Tables["Data"].Rows[i]["FirstName"].ToString();
                string FullName = ds.Tables["Data"].Rows[i]["FullName"].ToString();
                string projectStatus = ds.Tables["Data"].Rows[i]["projectStatus"].ToString();
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();

                DataRow row = myTable.NewRow();

                row["ProjectId"] = ProjectId;
                row["ProjectName"] = ProjectName;
                row["ProjectYear"] = ProjectYear;
                row["ProjectRound"] = ProjectRound;
                row["ProjectHeader"] = ProjectHeader;
                row["FirstName"] = FirstName;
                row["FullName"] = FullName;
                row["projectStatus"] = projectStatus;
                row["Percentjoin"] = Percentjoin;

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
        txtProjectName.Text = "";
        txtYear.Text = "";
        UpdatePanel.Visible = false;
    }

    protected void bt_ProjectJoin_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string sId = gvData.DataKeys[row.RowIndex]["ProjectId"].ToString();
        //string rId = Request.QueryString["nId"];
        Response.Redirect("Project_Join_Add.aspx?nID=" + sId);
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
            
            if (ProjectStatus == "A")
            {
                e.Row.FindControl("bt_ProjectJoin").Visible = true;
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
   
    protected void txtProjectName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtYear_TextChanged(object sender, EventArgs e)
    {

    }
}