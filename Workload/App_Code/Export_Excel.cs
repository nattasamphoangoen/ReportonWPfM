using System;
using System.IO;
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

namespace ClassLibrary
{
    public class ExportExcel
    {
        public void ExportData(GridView GV, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble()); 

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();

            frm.Attributes["runat"] = "server";
            frm.Controls.Add(GV);
            GV.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }

        public void ExportData(Table TB, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble()); 

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();

            frm.Attributes["runat"] = "server";
            frm.Controls.Add(TB);
            TB.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }

        public void ExportData(Table TB, GridView GV, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();

            ;
            
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(TB);
            frm.Controls.Add(GV);

            TB.RenderControl(htw);
            GV.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }

        public void ExportData(Table TB1,Table TB2, GridView GV, string fileName)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();

            ;

            frm.Attributes["runat"] = "server";
            frm.Controls.Add(TB1);
            frm.Controls.Add(GV);
            frm.Controls.Add(TB2);

            TB1.RenderControl(htw);
            GV.RenderControl(htw);
            TB2.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();
        }
    }
}