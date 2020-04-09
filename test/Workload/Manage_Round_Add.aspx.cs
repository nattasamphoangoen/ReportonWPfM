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
public partial class Manage_Round_Add : System.Web.UI.Page
{
    FormatText FT = new FormatText();
    ConnectDB db = new ConnectDB();


    SqlConnection con = new SqlConnection();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] == null || Session["AccountId"].ToString() == "")
        {
            Response.Redirect("Account/Login.aspx");
        }
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        if (this.CheckRound())
        {
            //ข้อมูลซ้ำ
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('ข้อมูลซ้ำ');", true);
        }
        else
        {
            if (this.SaveDataRound())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='Manage_Round_Search.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('ไม่สามารถบันทึกข้อมูลได้');", true);
            }

        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected bool SaveDataRound()
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"
INSERT INTO ProjectControl
           (projectYear
           ,projectRound
           ,projectStatus)
     VALUES
           (@projectYear
           ,@ProjectRound
           ,'A');";

        command.Parameters.AddWithValue("@projectYear", txtprojectYear.Text);
        command.Parameters.AddWithValue("@ProjectRound", int.Parse(ddlProjectRound.SelectedValue));

        object res = db.ExecuteScalar(command);
        if (res == null || int.Parse(res.ToString()) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool CheckRound()
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"
SELECT id, projectYear, projectRound, projectStatus
FROM  ProjectControl
WHERE projectYear = @projectYear AND projectRound = @projectRound AND projectStatus != 'I'";

        command.Parameters.AddWithValue("@projectYear", txtprojectYear.Text);
        command.Parameters.AddWithValue("@ProjectRound", int.Parse(ddlProjectRound.SelectedValue));

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
}