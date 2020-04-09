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

public partial class User_Join_Add : System.Web.UI.Page
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

        if (Session["AccountId"].ToString() == Request.QueryString["nID"])
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('คุณไม่มีสิทธิ์กรอกข้อมูล % Workload ของผู้อื่น'); location.href='User_Search.aspx';", true);
        }

    }

    protected void BindData(string AccountId)
    {
        string sql = @"SELECT M.id, M.ProjectYear,  A.Title+ ' '+ A.FirstName + ' ' + A.LastName AS FullName, A.*
                        FROM ProjectJoin AS J
                        INNER JOIN Account AS A ON A.id = J.AccountId
                        INNER JOIN ProjectMaster AS M ON J.ProjectId = M.id
						INNER JOIN ProjectControl AS C ON C.ProjectYear = M.ProjectYear AND C.ProjectRound = M.ProjectRound
                        Where C.projectStatus IN ('A','W') AND A.id = @AccountId ";

        try
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@AccountId", AccountId);

            DataTable dt = db.ExecuteDataTable(command);

            if (dt.Rows.Count > 0)
            {
                hdf_AccountId.Value = dt.Rows[0]["id"].ToString();
                lbName.Text = dt.Rows[0]["FullName"].ToString();
                lbdepartment.Text = dt.Rows[0]["department"].ToString();
                lbsection.Text = dt.Rows[0]["section"].ToString();
                lbposition.Text = dt.Rows[0]["position"].ToString();

            }
            else
            {
                Response.Redirect("User_Search.aspx");
            }
        }
        catch (Exception ex) { lblError.Text += "Search Data = " + ex.Message + "<br />"; }
    }

    protected void BindReportPaperPrice(DataTable DABrand, string AccountId)
    {
        string sql = @" SELECT J.id ,J.AccountId, M.ProjectName, M.ProjectHeader, PM.LastName, PM.Title+ ' '+ PM.FirstName + ' ' + PM.LastName AS HeaderName , 
                                ISNULL(J.Percentjoin,0) AS Percentjoin, ISNULL(J.PercentWorkload,0) AS PercentWorkload
                        FROM Account AS A 
                        INNER JOIN ProjectJoin AS J ON J.AccountId = A.id	
                        INNER JOIN ProjectMaster AS M ON M.id = J.ProjectId
                        INNER JOIN (SELECT * FROM Account) AS PM ON PM.id = M.ProjectHeader
						INNER JOIN ProjectControl AS C ON C.ProjectYear = M.ProjectYear AND C.ProjectRound = M.ProjectRound
                        WHERE J.Status = 'A' AND C.projectStatus IN ('A','W') AND J.AccountId =  @AccountId ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@AccountId", AccountId);

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
                    string HeaderName = ds.Tables["Data"].Rows[i]["HeaderName"].ToString();
                    string PercentWorkload = ds.Tables["Data"].Rows[i]["PercentWorkload"].ToString();



                    this.AddColValue(DABrand, new string[] { Id, ProjectName, HeaderName, PercentWorkload });
                }
            }
            else
            {
                this.AddColValue(DABrand, new string[] { "", "", "", "" });
            }
            this.BindValue(DABrand, gvDABrand);
        }
        catch (Exception ex) { lblError.Text += "Bind Workload " + ex.Message; }
        finally { con.Close(); }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("User_Search.aspx");
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        string uId = Request.QueryString["nId"];

        if (!this.SaveReportPaperPrice(uId))
        {
            lblError.Text = "% ร่วม เกิน 100 กรุณากรอก % ร่วมใหม่";
            //chk = false;
            //return chk;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='User_Search.aspx';", true);

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
    //            TextBox txtProjectName = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtProjectName");
    //            TextBox txtHeaderName = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtHeaderName");
    //            TextBox txtPercentWorkload = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentWorkload");


    //            if (txtProjectName.Text == "")
    //            {
    //                sql = ""; break;
    //            }
    //            else
    //            {
    //                sql += RoundId + ",NULLIF('" + txtProjectName.Text + "',''), NULLIF('"
    //                + txtHeaderName.Text + "',''),NULLIF('" + txtPercentWorkload.Text + "','')" + "," + AccountId;

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

    protected bool UpdateMD5(int RoundId)
    {
        string sql = "";

        sql = @"UPDATE Survey 
                SET IdMD5 = MD5.MD5
                FROM (SELECT id, LOWER(CONVERT(VARCHAR(32), HashBytes('MD5', CONVERT(varchar, id)), 2)) AS MD5
                      FROM Survey) MD5
                WHERE MD5.Id = Survey.Id AND Survey.RoundId=@RoundId";


        //  db.ConnectionString = con_string;
        SqlCommand command = new SqlCommand();
        command.CommandText = sql;

        object execResult = db.ExecuteScalar(command);

        try
        {
            command.Parameters.AddWithValue("@RoundId", RoundId);

            db.ExecuteNonQuery(command);

            return true;
        }

        catch (Exception ex)
        {
            lblError.Text += "Update Survey ID MD5 Error = " + ex.Message + "<br />";
            return false;
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
        ST.AddColToTable(dt, "HeaderName", "System.String");
        ST.AddColToTable(dt, "PercentWorkload", "System.String");

        return dt;
    }
    //protected void btnAdd_DABrand_Click(object sender, EventArgs e)
    //{
    //    string rId = Request.QueryString["nId"];

    //    if (!this.SaveReportPaperPrice(rId))
    //    {
    //        lblError.Text = "% ร่วม เกิน 100 กรุณากรอก % ร่วมใหม่"; 
    //        //chk = false;
    //        //return chk;
    //    }
    //    else
    //    {
    //        lblError.Text = "";
    //        Response.Redirect("Project_Join_Select.aspx?nID=" + rId);
    //    }

    //}

    protected bool SaveReportPaperPrice(string ProjectId)
    {
        //decimal SumPercent = 0;
        float SumPercent = 0;
        string sql = "";

        if (gvDABrand.Rows.Count > 0)
        {
            for (int i = 0; i < gvDABrand.Rows.Count; i++)
            {
                TextBox txtPercentWorkload = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentWorkload");
                SumPercent = SumPercent + float.Parse(txtPercentWorkload.Text);
            }
            if (SumPercent > 100)
            {
                //Pop up แจ้งเตือนว่า % เกิน100
                //Response."% ร่วมเกิน 100 กรุณากรอก % ร่วมใหม่ "
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('% ร่วมเกิน 100 กรุณากรอก % ร่วมใหม่'); location.href='User_Join_Add.aspx';", true);
            }
            else
            {

                for (int i = 0; i < gvDABrand.Rows.Count; i++)
                {
                    HiddenField hdf_Id = (HiddenField)gvDABrand.Rows[i].Cells[0].FindControl("hdf_Id");
                    TextBox txtPercentWorkload = (TextBox)gvDABrand.Rows[i].Cells[0].FindControl("txtPercentWorkload");

                    sql = @"UPDATE ProjectJoin
                        SET PercentWorkload = NULLIF('" + txtPercentWorkload.Text + "','')  WHERE id =" + hdf_Id.Value;

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
            Label lbProjectName = (Label)gv.Rows[i].Cells[0].FindControl("lbProjectName");
            Label lbHeaderName = (Label)gv.Rows[i].Cells[0].FindControl("lbHeaderName");
            TextBox txtPercentWorkload = (TextBox)gv.Rows[i].Cells[0].FindControl("txtPercentWorkload");

            this.AddColValue(myTable, new string[] { Id, lbProjectName.Text, lbHeaderName.Text, txtPercentWorkload.Text });
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
        TextBox lbProjectName = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("lbProjectName");
        TextBox lbHeaderName = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("lbHeaderName");
        TextBox txtPercentWorkload = (TextBox)gvDABrand.Rows[row].Cells[0].FindControl("txtPercentWorkload");


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