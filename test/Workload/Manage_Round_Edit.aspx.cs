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
public partial class Manage_Round_Edit : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            this.BindData(Request.QueryString["nID"]);
        }
    }

    protected void BindData(string RoundId)
    {
        string sql = @"SELECT id, projectYear, projectRound, projectStatus
                        FROM   ProjectControl
                        WHERE id = @RoundId";

        try
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@RoundId", RoundId);

            DataTable dt = db.ExecuteDataTable(command);

            if (dt.Rows.Count > 0)
            {
                hdf_RoundId.Value = dt.Rows[0]["id"].ToString();
                lbProjectYear.Text = dt.Rows[0]["projectYear"].ToString();
                lbProjectRound.Text = dt.Rows[0]["projectRound"].ToString();
                ddlProjectStatus.SelectedValue = dt.Rows[0]["projectStatus"].ToString();
                if (ddlProjectStatus.SelectedValue =="C")
                {
                    btnSubmit1.Visible = false;
                    ddlProjectStatus.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("Manage_Round_Search.aspx");
            }
        }
        catch (Exception ex) { lblError.Text += "Search Data Project Round = " + ex.Message + "<br />"; }
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_Round_Search.aspx");
    }

    protected bool SaveDataRound()
    {
        SqlCommand command = new SqlCommand();
        if (ddlProjectStatus.SelectedValue =="C")
        {
            
            command.CommandText = @"
INSERT INTO ProjectWorkload (ProjectJoinId, projectId, peojectYear, projectRound, accountId, Percentjoin, percentWorkload, createdBy, createdDate)

SELECT J.id, J.ProjectId, M.ProjectYear, M.ProjectRound, J.AccountId, J.Percentjoin, J.percentWorkload, @createdBy, GETDATE()
FROM ProjectJoin AS J
INNER JOIN ProjectMaster AS M ON M.id = J.ProjectId
WHERE M.projectYear = @ProjectYear AND M.projectRound = @ProjectRound AND J.Status IN ('A','W') AND J.id NOT IN (SELECT ProjectJoinId FROM ProjectWorkload)
ORDER BY J.id ";

            command.Parameters.AddWithValue("@ProjectRound", lbProjectRound.Text);
            command.Parameters.AddWithValue("@ProjectYear", lbProjectYear.Text);
            command.Parameters.AddWithValue("@createdBy", Session["AccountId"]);

            db.ExecuteNonQuery(command);
            command.Parameters.Clear();
        }
        //SqlCommand command = new SqlCommand();
        command.CommandText = @"
                UPDATE ProjectControl
                SET projectStatus = @ProjectRound
               
                WHERE Id = @Id";

        command.Parameters.AddWithValue("@ProjectRound", ddlProjectStatus.SelectedValue);
        command.Parameters.AddWithValue("@Id", hdf_RoundId.Value);

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
}