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

public partial class Project_Join_Select : System.Web.UI.Page
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
        }

    }
    private DataTable CreateTableShowData()
    {
        DataTable dtShowData = new DataTable();

        ST.AddColToTable(dtShowData, "id", "System.String");
        ST.AddColToTable(dtShowData, "Title", "System.String");
        ST.AddColToTable(dtShowData, "FirstName", "System.String");
        ST.AddColToTable(dtShowData, "LastName", "System.String");
        ST.AddColToTable(dtShowData, "Department", "System.String");
        ST.AddColToTable(dtShowData, "Section", "System.String");
        ST.AddColToTable(dtShowData, "Position", "System.String");
        ST.AddColToTable(dtShowData, "Email", "System.String");
       

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
        string sql = @"SELECT  id, Title, Title + '  ' + FirstName AS FirstName , LastName, Department, Section, Position, Email, Password, Tel, UserType, UserStatus
                            FROM  Account
                        WHERE UserStatus = 'A' AND id is not null  ";
        string prefix = " AND ";

        if (txtFirstName.Text != "")
        {
            sql += prefix + "FirstName LIKE @FirstName ";
            prefix = " AND ";
        }
        if (txtLastName.Text != "")
        {
            sql += prefix + "LastName LIKE @LastName ";
            prefix = " AND ";
        }
        if (txtDepartment.Text != "")
        {
            sql += prefix + "Department LIKE @Department ";
            prefix = " AND ";
        }
        if (txtSection.Text != "")
        {
            sql += prefix + "Section LIKE @Section ";
            prefix = " AND ";
        }

        sql += "ORDER BY FirstName ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            if (txtFirstName.Text != "")
            {
                cmd.Parameters.AddWithValue("@FirstName", "%" + txtFirstName.Text.Trim() + "%");
            }
            if (txtLastName.Text != "")
            {
                cmd.Parameters.AddWithValue("@LastName", "%" + txtLastName.Text.Trim() + "%");
            }
            if (txtDepartment.Text != "")
            {
                cmd.Parameters.AddWithValue("@Department", "%" + txtDepartment.Text.Trim() + "%");
            }
            if (txtSection.Text != "")
            {
                cmd.Parameters.AddWithValue("@Section", "%" + txtSection.Text.Trim() + "%");
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
                string id = ds.Tables["Data"].Rows[i]["id"].ToString();
                string Title = ds.Tables["Data"].Rows[i]["Title"].ToString();
                string FirstName = ds.Tables["Data"].Rows[i]["FirstName"].ToString();
                string LastName = ds.Tables["Data"].Rows[i]["LastName"].ToString();
                string Department = ds.Tables["Data"].Rows[i]["Department"].ToString();
                string Section = ds.Tables["Data"].Rows[i]["Section"].ToString();
                string Position = ds.Tables["Data"].Rows[i]["Position"].ToString();
                string Email = ds.Tables["Data"].Rows[i]["Email"].ToString();


                DataRow row = myTable.NewRow();

                row["id"] = id;
                row["Title"] = Title;
                row["FirstName"] = FirstName;
                row["LastName"] = LastName;
                row["Department"] = Department;
                row["Section"] = Section;
                row["Position"] = Position;
                row["Email"] = Email;

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
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDepartment.Text = "";
        txtSection.Text = "";
        UpdatePanel.Visible = false;
    }

    protected void btBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Project_Join_Add.aspx?nID=" + Request.QueryString["nId"]);
    }

    protected void bt_ProjectJoin_Click(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
        string sId = gvData.DataKeys[row.RowIndex]["Id"].ToString();
        string pId = Request.QueryString["nId"];
        this.insertdata(sId, pId);
        //string rId = Request.QueryString["nId"];
        Response.Redirect("Project_Join_Add.aspx?nID=" + pId);
    }

    protected void insertdata(string AccountId, string ProjectId)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"
INSERT INTO ProjectJoin
           (ProjectId
           ,AccountId )
     VALUES
           (@ProjectId
           ,@AccountId)";

        command.Parameters.AddWithValue("@AccountId", AccountId);
        command.Parameters.AddWithValue("@ProjectId", ProjectId);

        db.ExecuteNonQuery(command);   
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='Project_Search.aspx';", true);
    
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

    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtLastName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
      Response.Redirect("Project_Join_Add.aspx");
    }
}


//    protected void Page_Load(object sender, EventArgs e)
//    {

//    }

//    protected void btSearch_Click(object sender, EventArgs e)
//    {

//    }
//}