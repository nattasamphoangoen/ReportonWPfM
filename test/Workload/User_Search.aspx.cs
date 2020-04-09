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

public partial class User_Search : System.Web.UI.Page
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
            string uId = Session["AccountId"].ToString();

            A.ActionLog("ACCOUNTS", "", "View");
            dtShowData = new DataTable();
            dtShowData = this.CreateTableShowData();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData1((DataTable)ViewState["dtShowData"]);

            if (!this.CheckData(uId))
            {
                btnSurveyAdd.Visible = false;
            }
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
        ST.AddColToTable(dtShowData, "Percentjoin", "System.String");
        ST.AddColToTable(dtShowData, "PercentWorkload", "System.String");



        return dtShowData;
    }



    protected void btSearch_Click(object sender, EventArgs e)
    {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;

        UpdatePanel.Visible = true;
        this.SearchData((DataTable)ViewState["dtShowData"]);
    }

    protected bool CheckData(string uId)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"SELECT M.*,A.Title, A.FirstName,A.LastName, PM.Title+ ' '+ PM.FirstName + ' ' + PM.LastName AS FullName, ISNULL(J.Percentjoin,0) AS Percentjoin, ISNULL(J.PercentWorkload,0) AS PercentWorkload, C.projectStatus
                            FROM  ProjectJoin As J 
                            INNER JOIN Account AS A ON A.id = J.AccountId  AND J.Status = 'A'
							Left Join ProjectMaster AS M ON J.ProjectId = M.id 
							INNER JOIN ProjectControl AS C ON C.projectYear = M.ProjectYear AND C.projectRound = M.ProjectRound AND C.projectStatus IN ('A','W')
							INNER JOIN (SELECT * FROM Account) AS PM ON PM.id = M.ProjectHeader

                            WHERE J.AccountId = @AccountId AND M.id is not null ";

        command.Parameters.AddWithValue("@AccountId", Session["AccountId"]);

        object res = db.ExecuteScalar(command);
        if (res != null)
            if (int.Parse(res.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        else
        {
            return false;
        }
    }

    protected void SearchData(DataTable myTable)
    {
        string sql = @"SELECT M.*,A.Title, A.FirstName,A.LastName, PM.Title+ ' '+ PM.FirstName + ' ' + PM.LastName AS FullName, J.Percentjoin, ISNULL(J.PercentWorkload,0) AS PercentWorkload
                            FROM  ProjectJoin As J 
                            INNER JOIN Account AS A ON A.id = J.AccountId  AND J.Status = 'A'
							Left Join ProjectMaster AS M ON J.ProjectId = M.id 
							INNER JOIN (SELECT * FROM Account) AS PM ON PM.id = M.ProjectHeader
                            WHERE J.AccountId = @AccountId AND M.id is not null ";

        string prefix = " AND ";

        if (txtProjectName.Text != "")
        {
            sql += prefix + "ProjectName LIKE @ProjectName ";
            prefix = " AND ";
        }
        if (txtYear.Text != "")
        {
            sql += prefix + "ProjectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "ORDER BY ProjectYear DESC ";

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
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();
                string PercentWorkload = ds.Tables["Data"].Rows[i]["PercentWorkload"].ToString();


                DataRow row = myTable.NewRow();

                row["ProjectId"] = ProjectId;
                row["ProjectName"] = ProjectName;
                row["ProjectYear"] = ProjectYear;
                row["ProjectRound"] = ProjectRound;
                row["ProjectHeader"] = ProjectHeader;
                row["FirstName"] = FirstName;
                row["FullName"] = FullName;
                row["Percentjoin"] = Percentjoin;
                row["PercentWorkload"] = PercentWorkload;

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
        string sql = @"SELECT M.*,A.Title, A.FirstName,A.LastName, PM.Title+ ' '+ PM.FirstName + ' ' + PM.LastName AS FullName, J.Percentjoin, ISNULL(J.PercentWorkload,0) AS PercentWorkload
                            FROM  ProjectJoin As J 
                            INNER JOIN Account AS A ON A.id = J.AccountId  AND J.Status = 'A'
							Left Join ProjectMaster AS M ON J.ProjectId = M.id 
							INNER JOIN (SELECT * FROM Account) AS PM ON PM.id = M.ProjectHeader
							INNER JOIN ProjectControl AS C ON C.projectYear = M.ProjectYear AND C.projectRound = M.ProjectRound
                            WHERE J.AccountId = @AccountId AND C.projectStatus IN ('A','W') AND M.id is not null ";

        string prefix = " AND ";

        if (txtProjectName.Text != "")
        {
            sql += prefix + "ProjectName LIKE @ProjectName ";
            prefix = " AND ";
        }
        if (txtYear.Text != "")
        {
            sql += prefix + "ProjectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "ORDER BY ProjectYear DESC ";

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
                string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();
                string PercentWorkload = ds.Tables["Data"].Rows[i]["PercentWorkload"].ToString();


                DataRow row = myTable.NewRow();

                row["ProjectId"] = ProjectId;
                row["ProjectName"] = ProjectName;
                row["ProjectYear"] = ProjectYear;
                row["ProjectRound"] = ProjectRound;
                row["ProjectHeader"] = ProjectHeader;
                row["FirstName"] = FirstName;
                row["FullName"] = FullName;
                row["Percentjoin"] = Percentjoin;
                row["PercentWorkload"] = PercentWorkload;

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
        txtProjectName.Text = "";
        UpdatePanel.Visible = false;
    }

    protected void bt_ProjectJoin_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string sId = gvData.DataKeys[row.RowIndex]["ProjectId"].ToString();
        //string rId = Request.QueryString["nId"];
        Response.Redirect("User_Join_Add.aspx?nID=" + sId);
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

    protected void btnUserWorkload_Click(object sender, EventArgs e)
    {
        Response.Redirect("User_Join_Add.aspx?nID=" + Session["AccountId"]);
    }
}