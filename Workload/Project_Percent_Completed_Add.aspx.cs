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

public partial class Project_Percent_Completed_Add : System.Web.UI.Page
{

    Authorize A = new Authorize();
    FormatText FT = new FormatText();
    ConnectDB db = new ConnectDB();
    SqlConnection con = new SqlConnection();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    SortTable ST = new SortTable();

    DataTable dtDABrand;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] == null || Session["AccountId"].ToString() == "")
        {
            Response.Redirect("Account/Login.aspx");
        }

        if (!IsPostBack)
        {
            dtDABrand = new DataTable();
            dtDABrand = this.Create_dtDABrand();
            ViewState["dtDABrand"] = dtDABrand;
            this.BindReportPaperPrice((DataTable)ViewState["dtDABrand"], Request.QueryString["nID"]);
            this.BindValue((DataTable)ViewState["dtDABrand"], gvDABrand);

        }

    }

    protected void BindReportPaperPrice(DataTable DABrand, string RuondId)
    {
        string sql = @"SELECT M.Id, M.ProjectName, A.Title+' ' +A.FirstName+' '+A.LastName AS Fullname , ISNULL(M.PercentCompleted,0) AS PercentCompleted
                        FROM ProjectMaster AS M
                        INNER JOIN Account AS A ON A.id = M.ProjectHeader
                        INNER JOIN ProjectControl AS C ON C.projectYear = M.ProjectYear AND C.projectRound=M.ProjectRound
                        WHERE C.id = @RuondId ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@RuondId", RuondId);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Data");

            if (ds.Tables["Data"].Rows.Count != 0)
            {
                DataView dv = ds.Tables["Data"].DefaultView;


                if (dv.ToTable().Rows.Count == 0)
                {
                    this.AddColValue(DABrand, new string[] { "", "", "", "" });
                }

                for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                {
                    string Id = ds.Tables["Data"].Rows[i]["Id"].ToString();
                    string ProjectName = ds.Tables["Data"].Rows[i]["ProjectName"].ToString();
                    string Fullname = ds.Tables["Data"].Rows[i]["Fullname"].ToString();
                    string PercentCompleted = ds.Tables["Data"].Rows[i]["PercentCompleted"].ToString();

             

                    this.AddColValue(DABrand, new string[] { Id, ProjectName, Fullname, PercentCompleted });
                }
            }
            else
            {
                this.AddColValue(DABrand, new string[] { "", "", "", "" });
            }
            this.BindValue(DABrand, gvDABrand);
        }
        catch (Exception ex) { lblError.Text += "Bind Percent Completed " + ex.Message; }
        finally { con.Close(); }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_Round_Search.aspx");
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        if (!this.SaveReportPaperPrice())
        {
            lblError.Text = "กรุณา % ให้อยู่ในช่วง 0-100";
            //chk = false;
            //return chk;
        }
        else
        {      
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='User_Search.aspx';", true);
       
            //return chk;
        }
    }    

    protected bool InsertReceiveDetail(string sql)
    {
        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex) { Response.Write("Error Receive Detial :" + ex.Message); return false; }
        finally { con.Close(); }
    }

    private DataTable Create_dtDABrand()
    {
        DataTable dt = new DataTable();

        ST.AddColToTable(dt, "Id", "System.String");
        ST.AddColToTable(dt, "ProjectName", "System.String");
        ST.AddColToTable(dt, "Fullname", "System.String");
        ST.AddColToTable(dt, "PercentCompleted", "System.String");

        return dt;
    }

    protected bool SaveReportPaperPrice()
    {
        string sql = "";

        if (gvDABrand.Rows.Count > 0)
        {      
                for (int i = 0; i < gvDABrand.Rows.Count; i++)
                {
                    HiddenField hdf_Id = (HiddenField)gvDABrand.Rows[i].Cells[0].FindControl("hdf_Id");
                    TextBox txtPercentCompleted = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentCompleted");
                    
                    sql = @"UPDATE ProjectMaster
                        SET PercentCompleted = NULLIF('" + txtPercentCompleted.Text + "','')  WHERE id =" + hdf_Id.Value  ;

                    //if (i != gvDABrand.Rows.Count - 1)
                    //{
                    //    sql += @"), 
                    //           (";
                    //}
                    //sql += ") ";
                    this.InsertReceiveDetail(sql);
                }
           
        }

        if (sql != "")
        {
            //sql += ") ";
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void CollectData_DABrand(DataTable myTable, GridView gv)
    {
        myTable.Rows.Clear();

        for (int i = 0; i < gv.Rows.Count; i++)
        {
            string Id = gv.DataKeys[i]["Id"].ToString();

            //HiddenField hdf_Id = (HiddenField)gv.Rows[i].Cells[0].FindControl("hdf_Id");
            Label lbProjectName = (Label)gv.Rows[i].Cells[0].FindControl("lbProjectName");
            Label lbHeaderName = (Label)gv.Rows[i].Cells[0].FindControl("lbHeaderName");
            TextBox txtPercentCompleted = (TextBox)gv.Rows[i].Cells[0].FindControl("txtPercentCompleted");

            this.AddColValue(myTable, new string[] { Id, lbProjectName.Text, lbHeaderName.Text, txtPercentCompleted.Text });
        }
    }

    protected void gvDABrand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CollectData_DABrand((DataTable)ViewState["dtDABrand"], gvDABrand);
        BindValue((DataTable)ViewState["dtDABrand"], gvDABrand);

        int row = Convert.ToInt32(e.CommandArgument.ToString()); // RowIndex

        //DataKey SurveyBoardID = (DataKey)gvSurvey.Rows[row].Cells[0].FindControl("SurveyBoardID");

        HiddenField hdf_Id = (HiddenField)gvDABrand.Rows[row].Cells[0].FindControl("hdf_Id");
        TextBox lbProjectName = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("lbProjectName");
        TextBox lbHeaderName = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("lbHeaderName");
        TextBox txtPercentCompleted = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentCompleted");


        if (e.CommandName == "Delete_gvDABrand")
        {
            if (gvDABrand.Rows.Count == 1)
            {
                //txtFirstname.Text = "";
                //txtLastname.Text = "";
                //txtPercentjoin.Text = "";
            }
            else
            {
                if (gvDABrand.Rows.Count > 1)
                {
                    //ST.RemoveFromDataTableWithBind((DataTable)ViewState["dtDABrand"], row, gvDABrand);
                    if (this.DeleteReportPaperPrice(int.Parse(hdf_Id.Value)))
                    {
                        lblError.Text = "";
                    }
                    else
                    {
                        lblError.Text = "Delete Project Error";
                        //chk = false;
                        //return chk;
                    }
                }
            }
        }
    }

    protected bool DeleteReportPaperPrice(int Id)   /*Delete*/
    {
        string sql = @" UPDATE ProjectJoin
                        SET Status= 'D'
                        WHERE Id=@Id ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@Id", Id);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally { con.Close(); }
    }

    //============= ConTrol =============//
    protected void AddColValue(DataTable myTable, string[] ColValue)
    {
        DataRow row;
        row = myTable.NewRow();

        for (int i = 0; i < ColValue.GetLength(0); i++)
        {
            row[i] = ColValue[i];
        }

        myTable.Rows.Add(row);
    }
    protected void BindValue(DataTable myTable, GridView gv)
    {
        gv.DataSource = myTable.DefaultView;
        gv.DataBind();
    }

    protected void txtRound_TextChanged(object sender, EventArgs e)
    {

    }
}