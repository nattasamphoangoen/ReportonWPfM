using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ClassLibrary;
using System.Web.Configuration;
public partial class _SiteMaster : System.Web.UI.MasterPage
{

    SqlConnection con = new SqlConnection();
    protected string con_str = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    ConnectDB db = new ConnectDB();
    FormatText FT = new FormatText();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AccountId"] == null || Session["AccountId"].ToString() == "")
        {
            Response.Redirect("Account/Login.aspx");
        }
        string Fullname;
        Fullname = Session["USERNAME"].ToString();
        lblName.Text = Session["USERNAME"].ToString();
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
    protected void lbtLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/Account/Login");
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.DisplayMenu();
    }

    protected void DisplayMenu()
    {
        if (Session["USERTYPE"] != null && Session["USERTYPE"].ToString() != "" && Session["USERTYPE"].ToString() == "A")
        {
            //ถ้าเปิดเมนู แอดมินและเมนูรายงาน
            AdminTool.Visible = true;
        //    Report.Visible = true;
        }       
    }
}