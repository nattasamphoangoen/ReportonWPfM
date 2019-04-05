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

public partial class Evaluate_Index : System.Web.UI.Page
{
    protected void report1_Click(object sender, EventArgs e)
    {
        
        string rId = Request.QueryString["nId"];
         Response.Redirect("~/Evaluate_ServiceWork.aspx?nID=" + rId);
      
    }
    protected void report2_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Develop_Mainten.aspx?nID=" + rId);
     
    }
    protected void report3_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Research.aspx?nID=" + rId);
      
    }
    protected void report4_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Promotion_work.aspx?nID=" + rId);
    
    }
    protected void report5_Click(object sender, EventArgs e)
    {
      string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Services_Academic.aspx?nID=" + rId);
     
    }
    protected void report6_Click(object sender, EventArgs e)
    {
       string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Management.aspx?nID=" + rId);
     
    }
    protected void report7_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Other.aspx?nID=" + rId);
    
    }


    
}