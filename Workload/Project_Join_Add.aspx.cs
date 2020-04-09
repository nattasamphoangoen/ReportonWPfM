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

public partial class Project_Join_Add : System.Web.UI.Page
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


        if (this.checkAuthorizeAdd(Request.QueryString["nID"]))
        {
            if (!IsPostBack)
            {
                this.BindData(Request.QueryString["nID"]);

                dtDABrand = new DataTable();
                dtDABrand = this.Create_dtDABrand();
                ViewState["dtDABrand"] = dtDABrand;
                this.BindReportPaperPrice((DataTable)ViewState["dtDABrand"], Request.QueryString["nID"]);
                this.BindValue((DataTable)ViewState["dtDABrand"], gvDABrand);

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('คุณไม่มีสิทธิ์กรอกข้อมูลผู้ % ร่วมโครงการ (เฉพาะหัวหน้าโครงการเท่านั้น)'); location.href='Project_Search.aspx';", true);
        }
    }

    protected bool checkAuthorizeAdd(string ProjectId)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"SELECT M.id, M.ProjectName, M.ProjectYear,  A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName
                        FROM ProjectMaster AS M
                        INNER JOIN Account AS A ON A.id = M.ProjectHeader
                        LEFT JOIN ProjectJoin AS J ON J.ProjectId = M.id
                        WHERE M.id = @ProjectId AND M.ProjectHeader=@AccountId ";

        command.Parameters.AddWithValue("@AccountId", Session["AccountId"]);
        command.Parameters.AddWithValue("@ProjectId", ProjectId);

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

    protected void BindData(string ProjectId)
    {
        string sql = @"SELECT M.id, M.ProjectName, M.ProjectYear, M.ProjectRound, A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName
                        FROM ProjectMaster AS M
                        INNER JOIN Account AS A ON A.id = M.ProjectHeader
                        LEFT JOIN ProjectJoin AS J ON J.ProjectId = M.id
                        WHERE M.id = @ProjectId";

        try
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@ProjectId", ProjectId);

            DataTable dt = db.ExecuteDataTable(command);

            if (dt.Rows.Count > 0)
            {
                hdf_ProjectId.Value = dt.Rows[0]["id"].ToString();
                lbProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                lbProjectYear.Text = dt.Rows[0]["ProjectYear"].ToString();
                lbProjectRound.Text = dt.Rows[0]["ProjectRound"].ToString();
                lbFullName.Text = dt.Rows[0]["FullName"].ToString();
            }
            else
            {
                Response.Redirect("Project_Search.aspx");
            }
        }
        catch (Exception ex) { lblError.Text += "Search Data = " + ex.Message + "<br />"; }
    }

    protected void BindReportPaperPrice(DataTable DABrand, string ProjectId)
    {
        string sql = @" select J.* ,A.Title+ ' '+ A.FirstName AS FirstName, A.LastName, A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName
from  Account AS A 
INNER JOIN ProjectJoin AS J ON J.AccountId = A.id
                                    WHERE J.Status = 'A' AND J.ProjectId = @ProjectId";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

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
                    string FirstName = ds.Tables["Data"].Rows[i]["FirstName"].ToString();
                    string LastName = ds.Tables["Data"].Rows[i]["LastName"].ToString();
                    string Percentjoin = ds.Tables["Data"].Rows[i]["Percentjoin"].ToString();



                    this.AddColValue(DABrand, new string[] { Id, FirstName, LastName, Percentjoin });
                }
            }
            else
            {
                this.AddColValue(DABrand, new string[] { "", "", "", "" });
            }
            this.BindValue(DABrand, gvDABrand);
        }
        catch (Exception ex) { lblError.Text += "Bind Receive Detail " + ex.Message; }
        finally { con.Close(); }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Project_Search.aspx");
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];

        if (!this.SaveReportPaperPrice(rId))
        {
            lblError.Text = "% ร่วม เกิน 100 กรุณากรอก % ร่วมใหม่";
            //chk = false;
            //return chk;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='Project_Search.aspx';", true);

            //return chk;
        }
    }

    //protected bool SaveReportPaperPrice(int RoundId, int AccountId)
    //{
    //    string sql = "";

    //    if (gvDABrand.Rows.Count > 0)
    //    {
    //        sql = @"INSERT INTO Survey
    //                       ([RoundId],[Firstname],[Lastname],[Email],[CreatedBy]) 
    //                VALUES (";

    //        for (int i = 0; i < gvDABrand.Rows.Count; i++)
    //        {
    //            TextBox txtFirstname = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtFirstname");
    //            TextBox txtLastname = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtLastname");
    //            TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentjoin");



    //            if (txtFirstname.Text == "")
    //            {
    //                sql = ""; break;
    //            }
    //            else
    //            {
    //                sql += RoundId + ",NULLIF('" + txtFirstname.Text + "',''), NULLIF('"
    //                + txtLastname.Text + "',''),NULLIF('" + txtPercentjoin.Text + "','')" + "," + AccountId;

    //                if (i != gvDABrand.Rows.Count - 1)
    //                {
    //                    sql += @"), 
    //                           (";
    //                }
    //            }
    //        }
    //    }

    //    if (sql != "")
    //    {
    //        sql += ") ";
    //        return InsertReceiveDetail(sql);
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}


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
        ST.AddColToTable(dt, "FirstName", "System.String");
        ST.AddColToTable(dt, "LastName", "System.String");
        ST.AddColToTable(dt, "Percentjoin", "System.String");

        return dt;
    }
    protected void btnAdd_DABrand_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];

        if (!this.SaveReportPaperPrice(rId))
        {
            lblError.Text = "% ร่วม เกิน 100 กรุณากรอก % ร่วมใหม่";
            //chk = false;
            //return chk;
        }
        else
        {
            lblError.Text = "";
            Response.Redirect("Project_Join_Select.aspx?nID=" + rId);
        }

    }

    protected bool SaveReportPaperPrice(string ProjectId)
    {
        //decimal SumPercent = 0;
        float SumPercent = 0;
        string sql = "";

        if (gvDABrand.Rows.Count > 0)
        {
            for (int i = 0; i < gvDABrand.Rows.Count; i++)
            {
                TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentjoin");

                if (txtPercentjoin.Text == "")
                {
                    txtPercentjoin.Text = "0";
                    SumPercent = SumPercent + float.Parse(txtPercentjoin.Text);
                }
                else
                {
                    SumPercent = SumPercent + float.Parse(txtPercentjoin.Text);
                }


            }
            if (SumPercent > 100)
            {
                //Pop up แจ้งเตือนว่า % เกิน100
                //Response."% ร่วมเกิน 100 กรุณากรอก % ร่วมใหม่ "
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('% ร่วมเกิน 100 กรุณากรอก % ร่วมใหม่'); location.href='Project_Join_Add.aspx';", true);
            }
            else
            {

                for (int i = 0; i < gvDABrand.Rows.Count; i++)
                {
                    HiddenField hdf_Id = (HiddenField)gvDABrand.Rows[i].Cells[0].FindControl("hdf_Id");
                    TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentjoin");

                    sql = @"UPDATE ProjectJoin
                        SET Percentjoin = NULLIF('" + txtPercentjoin.Text + "','0')  WHERE id =" + hdf_Id.Value;

                    //if (i != gvDABrand.Rows.Count - 1)
                    //{
                    //    sql += @"), 
                    //           (";
                    //}
                    //sql += ") ";
                    this.InsertReceiveDetail(sql);
                }
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

    //protected void btnAdd_DABrand_Click(object sender, EventArgs e)
    //{
    //    Page page = HttpContext.Current.Handler as Page;
    //    int i = 0;

    //    if (gvDABrand.Rows.Count > 0)
    //    {
    //        CollectData_DABrand((DataTable)ViewState["dtSurvey"], gvDABrand);
    //        BindValue((DataTable)ViewState["dtSurvey"], gvDABrand);

    //        i = gvDABrand.Rows.Count - 1;
    //    }
    //    if (gvDABrand.Rows.Count == 0)
    //    {
    //        lblError.Text = "";
    //        this.AddColValue((DataTable)ViewState["dtSurvey"], new string[] { "", "", "", "", "", "" });
    //        this.BindValue((DataTable)ViewState["dtSurvey"], gvDABrand);
    //    }
    //    else
    //    {
    //        TextBox txtFirstname = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtFirstname");
    //        TextBox txtLastname = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtLastname");
    //        TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentjoin");

    //        if (txtFirstname.Text != "" || txtLastname.Text != "" || txtPercentjoin.Text != "")
    //        {
    //            lblError.Text = "";
    //            this.AddColValue((DataTable)ViewState["dtSurvey"], new string[] { "", "", "", "", "", "" });
    //            this.BindValue((DataTable)ViewState["dtSurvey"], gvDABrand);

    //            ScriptManager sm = ScriptManager.GetCurrent(Page);
    //            sm.SetFocus(btnDA);
    //        }
    //        else
    //        {
    //            if (txtFirstname.Text == "")
    //            {
    //                lblError.Text = "กรุณาเลือกกรอกข้อมูลชื่อผู้ประเมินผู้ร่วมโครงการ";
    //                ScriptManager sm = ScriptManager.GetCurrent(Page);
    //                sm.SetFocus((TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtFirstname"));
    //            }
    //            if (txtLastname.Text == "")
    //            {
    //                lblError.Text = "กรุณาเลือกกรอกข้อมูลนามสกุลผู้ร่วมโครงการ";
    //                ScriptManager sm = ScriptManager.GetCurrent(Page);
    //                sm.SetFocus((TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtLastname"));
    //            }
    //            if (txtPercentjoin.Text == "")
    //            {
    //                lblError.Text = "กรุณาเลือกกรอก % ผู้ร่วมโครงการ";
    //                ScriptManager sm = ScriptManager.GetCurrent(Page);
    //                sm.SetFocus((TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentjoin"));
    //            }
    //        }
    //    }
    //}

    protected void CollectData_DABrand(DataTable myTable, GridView gv)
    {
        myTable.Rows.Clear();

        for (int i = 0; i < gv.Rows.Count; i++)
        {
            string Id = gv.DataKeys[i]["Id"].ToString();

            //HiddenField hdf_Id = (HiddenField)gv.Rows[i].Cells[0].FindControl("hdf_Id");
            Label lbFirstname = (Label)gv.Rows[i].Cells[0].FindControl("lbFirstname");
            Label lbCondition = (Label)gv.Rows[i].Cells[0].FindControl("lbLastname");
            TextBox txtPercentjoin = (TextBox)gv.Rows[i].Cells[0].FindControl("txtPercentjoin");

            this.AddColValue(myTable, new string[] { Id, lbFirstname.Text, lbCondition.Text, txtPercentjoin.Text });
        }
    }

    protected void txtFirstname_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        int row = gvr.RowIndex;

        TextBox txtFirstname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtFirstname");

        TextBox txtLastname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtLastname");
        RequiredFieldValidator ReqLastname = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqLastname");
        //RegularExpressionValidator ValidatorLastname = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorLastname");

        TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentjoin");
        RequiredFieldValidator ReqEmail = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqEmail");
        //RegularExpressionValidator ValidatorEmail = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorEmail");


        if (txtFirstname.Text != "")
        {
            ReqEmail.Enabled = true;
            //ReqEmail.Validate();

            ReqLastname.Enabled = true;
            //ReqLastname.Validate();
        }
        else
        {
            txtLastname.Text = "";
            txtPercentjoin.Text = "";

            ReqEmail.Enabled = false;
            ReqEmail.Validate();

            ReqLastname.Enabled = false;
            ReqLastname.Validate();
            //ValidatorEmail.Validate();
            //ValidatorLastname.Validate();
        }
    }

    protected void txtLastname_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        int row = gvr.RowIndex;

        TextBox txtLastname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtFirstname");

        TextBox txtFirstname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtFirstname");
        RequiredFieldValidator ReqFirstname = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqFirstname");
        //RegularExpressionValidator ValidatorFirstname = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorFirstname");

        TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentjoin");
        RequiredFieldValidator ReqEmail = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqEmail");
        //RegularExpressionValidator ValidatorEmail = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorEmail");

        if (txtLastname.Text != "")
        {
            ReqEmail.Enabled = true;
            //ReqEmail.Validate();

            ReqFirstname.Enabled = true;
            //ReqFirstname.Validate();
        }
        else
        {
            txtFirstname.Text = "";
            txtPercentjoin.Text = "";

            ReqEmail.Enabled = false;
            ReqEmail.Validate();

            ReqFirstname.Enabled = false;
            ReqFirstname.Validate();

            //ValidatorEmail.Validate();
            //ValidatorFirstname.Validate();
        }
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        int row = gvr.RowIndex;

        TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentjoin");

        TextBox txtFirstname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtFirstname");
        RequiredFieldValidator ReqFirstname = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqFirstname");
        //RegularExpressionValidator ValidatorFirstname = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorFirstname");

        TextBox txtLastname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtLastname");
        RequiredFieldValidator ReqLastname = (RequiredFieldValidator)gvDABrand.Rows[row].Cells[0].FindControl("ReqLastname");
        //RegularExpressionValidator ValidatorLastname = (RegularExpressionValidator)gvSurvey.Rows[row].Cells[0].FindControl("ExpressionValidatorLastname");


        if (txtPercentjoin.Text != "")
        {
            ReqFirstname.Enabled = true;
            //ReqFirstname.Validate();

            ReqLastname.Enabled = true;
            //ReqLastname.Validate();
        }
        else
        {
            txtLastname.Text = "";
            txtFirstname.Text = "";

            ReqFirstname.Enabled = false;
            ReqFirstname.Validate();

            ReqLastname.Enabled = false;
            ReqLastname.Validate();
            //ValidatorLastname.Validate();
            //ValidatorFirstname.Validate();
        }
    }

    protected void gvDABrand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CollectData_DABrand((DataTable)ViewState["dtDABrand"], gvDABrand);
        BindValue((DataTable)ViewState["dtDABrand"], gvDABrand);

        int row = Convert.ToInt32(e.CommandArgument.ToString()); // RowIndex

        //DataKey SurveyBoardID = (DataKey)gvSurvey.Rows[row].Cells[0].FindControl("SurveyBoardID");

        HiddenField hdf_Id = (HiddenField)gvDABrand.Rows[row].Cells[0].FindControl("hdf_Id");
        TextBox txtFirstname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtFirstname");
        TextBox txtLastname = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtLastname");
        TextBox txtPercentjoin = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentjoin");


        if (e.CommandName == "Delete_gvDABrand")
        {
            if (gvDABrand.Rows.Count == 1)
            {
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtPercentjoin.Text = "";
            }
            else
            {
                if (gvDABrand.Rows.Count > 1)
                {
                    //ST.RemoveFromDataTableWithBind((DataTable)ViewState["dtDABrand"], row, gvDABrand);
                    if (this.DeleteReportPaperPrice(int.Parse(hdf_Id.Value)))
                    {
                        Response.Redirect("Project_Join_Add.aspx?nID=" + Request.QueryString["nID"]);
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
            UpdatePanel2.Update();
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
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Project_Search.aspx");
    }
}