using System;
using System.Web;
using System.Web.UI;
using WebSite2;

using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using ClassLibrary;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

public partial class Account_Login : System.Web.UI.Page
{
    string initLDAPPath = "dc=slri, dc=or, dc=th";
    string initLDAPServer = "10.1.10.100";
    string initShortDomainName = "slri";
    string strErrMsg;

    Authorize A = new Authorize();

    SqlConnection con = new SqlConnection();
    protected string con_str = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            A.NotLogonLog("Account", "", "View");

            // auto redirect if session already exists
            if (Session["AccountId"] != null && Session["AccountId"].ToString() != "")
            {
                //if (string.IsNullOrEmpty(Request.QueryString["n"]) && string.IsNullOrEmpty(Request.QueryString["p"]))
                //{
                //    Response.Redirect("Personal_Search.aspx");
                //}
                //else
                //{
                //    if (Request.QueryString["p"] == "acc")
                //    {
                //        Response.Redirect("CD_Account_Edit.aspx?AccountID=" + Request.QueryString["n"]);
                //    }
                //    else if (Request.QueryString["p"] == "product")
                //    {
                //        Response.Redirect("BW_Consumption.aspx?RID=" + Request.QueryString["n"]);
                //    }
                //}
            }
        }
    }

    protected void SaveLoginDate(string Id)
    {
        string sql = "UPDATE [Account] SET "
                   + "LoginDate = getdate() "
                   + "WHERE Id = @Id";

        con.ConnectionString = con_str;
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
        }
        catch (Exception ex) { lblError.Text += "Save : " + ex.Message; }
        finally { con.Close(); }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        if (this.CheckLDAP())
        {
            lblError.Text = "";
            DataSet dsUser = new DataSet();
            dsUser = this.CheckValidUser(txtMemberID.Text);
            if (dsUser != null)
            {
                string AccountStatus = dsUser.Tables["Account"].Rows[0]["UserStatus"].ToString();
                if (AccountStatus == "A")
                {
                    Session["AccountId"] = dsUser.Tables["Account"].Rows[0]["Id"].ToString();
                    Session["USERNAME"] = dsUser.Tables["Account"].Rows[0]["Title"].ToString() + " " + dsUser.Tables["Account"].Rows[0]["Firstname"].ToString() + " " + dsUser.Tables["Account"].Rows[0]["Lastname"].ToString();
                    Session["USEREMAIL"] = dsUser.Tables["Account"].Rows[0]["Email"].ToString();
                    Session["USERTYPE"] = dsUser.Tables["Account"].Rows[0]["UserType"].ToString();
                    Session["USERLOGON"] = dsUser.Tables["Account"].Rows[0]["LoginDate"].ToString();

                    this.SaveLoginDate(Session["AccountId"].ToString());
                    //A.ActionLog(PageCode, "Logon System", "Logon success", Session["ACCOUNT_ID"].ToString());
                    A.ActionLog("Account", Session["AccountId"].ToString(), "Login-Success");

                    Response.Redirect("~/User_Search.aspx");

                    //if (string.IsNullOrEmpty(Request.QueryString["n"]) && string.IsNullOrEmpty(Request.QueryString["p"]))
                    //{
                    //    Response.Redirect("CD_MySummary.aspx");
                    //}
                    //else
                    //{
                    //    if (Request.QueryString["p"] == "acc")
                    //    {
                    //        Response.Redirect("CD_Account_Edit.aspx?AccountID=" + Request.QueryString["n"]);
                    //    }
                    //    else if (Request.QueryString["p"] == "product")
                    //    {
                    //        Response.Redirect("BW_Consumption.aspx?RID=" + Request.QueryString["n"]);
                    //    }
                    //}

                }
                else
                {
                    //A.NotLogonLog("Account", dsUser.Tables["Account"].Rows[0]["Id"].ToString(), "Login-Inactive");
                    lblError.Text += "Your Accout is Inactive. Please contact your administrator.";
                }
            }
            else
            {
                //A.NotLogonLog("Account", "", "Login-InvalidAccount");
                lblError.Text += "Account not found.";
            }
        }
    }

    public string MD5(string strString)
    {
        ASCIIEncoding ASCIIenc = new ASCIIEncoding();
        string strReturn;
        byte[] ByteSourceText = ASCIIenc.GetBytes(strString);
        MD5CryptoServiceProvider Md5Hash = new MD5CryptoServiceProvider();
        byte[] ByteHash = Md5Hash.ComputeHash(ByteSourceText);
        strReturn = "";
        foreach (byte b in ByteHash)
        {
            strReturn = (strReturn + b.ToString("x2"));
        }
        return strReturn;
    }

    public bool CheckLDAP()
    {
        string DomainAndUsername = "";
        string strCommu;
        bool flgLogin = false;

        strCommu = ("LDAP://"
                    + (initLDAPServer + ("/" + initLDAPPath)));
        DomainAndUsername = (initShortDomainName + ("\\" + txtMemberID.Text));
        DirectoryEntry entry = new DirectoryEntry(strCommu, DomainAndUsername, txtPassword.Text);
        object obj;
        try
        {
            obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            SearchResult result;
            search.Filter = ("(SAMAccountName="
                        + (txtMemberID.Text + ")"));
            search.PropertiesToLoad.Add("cn");
            result = search.FindOne();
            if ((result == null))
            {
                flgLogin = false;
                strErrMsg = "Please check user/password";
            }
            else
            {
                flgLogin = true;
            }
        }
        catch (Exception ex)
        {
            flgLogin = false;
            strErrMsg = "Please check user/password";
        }
        if ((flgLogin == true))
        {
            //this.lbDisplay.Text = ("Welcome " + txtUser.Text);
            return true;
        }
        else
        {
            lblError.Text = strErrMsg;
            return false;
        }
    }

    protected DataSet CheckValidUser(string Email)
    {
        string sql = "SELECT * "
               + "FROM [Account] A "
               + "WHERE Email = @email";

        con.ConnectionString = con_str;
        SqlCommand cmd = new SqlCommand(sql, con);

        try
        {
            cmd.Parameters.AddWithValue("@email", Email + "@slri.or.th");

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Account");

            DataTable dt = ds.Tables["Account"];

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds;
            }
        }
        catch (Exception ex) { lblError.Text = ex.Message; return null; }
        finally { con.Close(); }

    }
}