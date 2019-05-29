using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ClassLibrary;

public partial class Home : System.Web.UI.Page {
    protected void report1_Click (object sender, EventArgs e) {

        //string rId = Request.QueryString["nId"];
        Response.Redirect ("~/User_Search.aspx");

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_User.aspx");

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Home.aspx");

    }
    // protected void report4_Click (object sender, EventArgs e) {
    //     string rId = Request.QueryString["nId"];
    //     Response.Redirect ("~/Evaluate_Promotion_work.aspx?nID=" + rId);

    // }
    // protected void report5_Click (object sender, EventArgs e) {
    //     string rId = Request.QueryString["nId"];
    //     Response.Redirect ("~/Evaluate_AcademicServices.aspx?nID=" + rId);

    // }
    // protected void report6_Click (object sender, EventArgs e) {
    //     string rId = Request.QueryString["nId"];
    //     Response.Redirect ("~/Evaluate_Management.aspx?nID=" + rId);

    // }
    // protected void report7_Click (object sender, EventArgs e) {
    //     string rId = Request.QueryString["nId"];
    //     Response.Redirect ("~/Evaluate_Other.aspx?nID=" + rId);

    // }

}