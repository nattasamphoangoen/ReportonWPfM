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
using System.Drawing;

namespace ClassLibrary
{
    public class tipFotmatTable
    {
        public void AddCellAlignCenter(TableRow tr, TableCell tc, Color Co, int Width, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.HorizontalAlign = HorizontalAlign.Center;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignLeft(TableRow tr, TableCell tc, Color Co, int Width, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.HorizontalAlign = HorizontalAlign.Left;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignRight(TableRow tr, TableCell tc, Color Co, int Width, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.HorizontalAlign = HorizontalAlign.Right;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignCenterWithRowSpan(TableRow tr, TableCell tc, Color Co, int Width, int RSpan, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.RowSpan = RSpan;
            tc.HorizontalAlign = HorizontalAlign.Center;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignCenterWithColSpan(TableRow tr, TableCell tc, Color Co, int Width, int CSpan, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.ColumnSpan = CSpan;
            tc.HorizontalAlign = HorizontalAlign.Center;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignCenterWithRowColSpan(TableRow tr, TableCell tc, Color Co, int Width, int CSpan, int RSpan, string txt)
        {
            tc.Text = txt;
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.RowSpan = RSpan;
            tc.ColumnSpan = CSpan;
            tc.HorizontalAlign = HorizontalAlign.Center;

            tr.Cells.Add(tc);
        }

        public void AddCellAlignLeftWithHyperlink(TableRow tr, TableCell tc, Color Co, int Width, HyperLink link)
        {
            tc.Controls.Add(link);
            tc.BackColor = Co;
            tc.Width = Width;
            tc.BorderWidth = 1;
            tc.BorderColor = Color.Gray;
            tc.HorizontalAlign = HorizontalAlign.Left;

            tr.Cells.Add(tc);
        }
    }
}