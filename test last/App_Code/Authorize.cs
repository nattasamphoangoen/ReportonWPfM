using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for Language_Version
/// </summary>

namespace ClassLibrary
{
    public class Authorize
    {
        SqlConnection con = new SqlConnection();
        protected string con_str = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

        public void PageAuthorize(string PageCode)
        {
            if (HttpContext.Current.Session[PageCode] != null && HttpContext.Current.Session[PageCode].ToString() != "")
            {
                if (HttpContext.Current.Session[PageCode].ToString() != "Y")
                {
                    HttpContext.Current.Response.Redirect("Home.aspx");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("Home.aspx");
            }
        }

        public void CountryAuthorize(string CountryCode, string PageRefer)
        {
            if (HttpContext.Current.Session["COUNTRYPERM"] != null && HttpContext.Current.Session["COUNTRYPERM"].ToString() != "")
            {
                string[] CountryPerm =   HttpContext.Current.Session["COUNTRYPERM"].ToString().Split(',');
                bool Permission = false;

                for (int i = 0; i < CountryPerm.GetLength(0); i++)
                {
                    if (CountryPerm[i] == CountryCode)
                    {
                        Permission = true;
                    }
                }

                if (Permission == false)
                {
                    HttpContext.Current.Response.Redirect(PageRefer);
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect(PageRefer);
            }
        }

        public void ActionLog(string RelationTable, string RelationID, string ActionDesc)
        {
            string sql = "INSERT INTO [CD_Log] "
                       + "( "
                       + "[Page], [RelationTable], [RelationID], [ActionDesc], [ActionBy], [IP] "
                       + ") VALUES ( "
                       + "@Page, NULLIF(@RelationTable, ''), NULLIF(@RelationID, ''), @ActionDesc, @ActionBy, @IP "
                       + ")";

            con.ConnectionString = con_str;
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.Parameters.AddWithValue("@Page", this.GetCurrentPageName());
                cmd.Parameters.AddWithValue("@RelationTable", RelationTable);
                cmd.Parameters.AddWithValue("@RelationID", RelationID);
                cmd.Parameters.AddWithValue("@ActionDesc", ActionDesc);
                cmd.Parameters.AddWithValue("@ActionBy", HttpContext.Current.Session["USERID"]);
                cmd.Parameters.AddWithValue("@IP", HttpContext.Current.Request.UserHostAddress);

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {  }
            finally { con.Close(); }
        }

        public void NotLogonLog(string RelationTable, string RelationID, string ActionDesc)
        {
            string sql = "INSERT INTO [CD_Log] "
                       + "( "
                       + "[Page], [RelationTable], [RelationID], [ActionDesc], [ActionBy], [IP] "
                       + ") VALUES ( "
                       + "@Page, NULLIF(@RelationTable, ''), NULLIF(@RelationID, ''), @ActionDesc, NULLIF(@ActionBy, ''), @IP "
                       + ")";

            con.ConnectionString = con_str;
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.Parameters.AddWithValue("@Page", this.GetCurrentPageName());
                cmd.Parameters.AddWithValue("@RelationTable", RelationTable);
                cmd.Parameters.AddWithValue("@RelationID", RelationID);
                cmd.Parameters.AddWithValue("@ActionDesc", ActionDesc);
                cmd.Parameters.AddWithValue("@ActionBy", "");
                cmd.Parameters.AddWithValue("@IP", HttpContext.Current.Request.UserHostAddress);

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }

        public string GetCurrentPageName()
        {
            string Path = HttpContext.Current.Request.Url.AbsolutePath;

            FileInfo Info = new FileInfo(Path);

            string Page = Info.Name;

            return Page.ToLower();
        }
    }
}
