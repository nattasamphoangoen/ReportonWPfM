using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
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

namespace ClassLibrary
{
    public class SortTable
    {
        public void AddColToTable(DataTable dt, string ColName, string ColType)
        {
            DataColumn dc = new DataColumn();
            dc.DataType = Type.GetType(ColType);
            dc.ColumnName = ColName;
            dt.Columns.Add(dc);
        }

        public void SortGridview(DataTable myTable, GridView gv, string Expression, string Direction)
        {
            myTable.DefaultView.Sort = Expression + " " + Direction;

            gv.DataSource = myTable.DefaultView;
            gv.DataBind();
        }

        public SortDirection GridviewSorting(object Sender, GridViewSortEventArgs e, DataTable myTable, SortDirection Direction)
        {
            if (Direction == SortDirection.Ascending)
            {
                Direction = SortDirection.Descending;
                SortGridview(myTable, (GridView)Sender, e.SortExpression, "ASC");
            }
            else
            {
                Direction = SortDirection.Ascending;
                SortGridview(myTable, (GridView)Sender, e.SortExpression, "DESC");
            }

            return Direction;
        }

        public void RemoveFromDataTable(DataTable myTable, int RowIndex)
        {
            if (RowIndex >= 0 && RowIndex < myTable.Rows.Count)
            {
                myTable.Rows[RowIndex].Delete();
            }
        }

        public void RemoveFromDataTableWithBind(DataTable myTable, int RowIndex, GridView gv)
        {
            if (RowIndex >= 0 && RowIndex < myTable.Rows.Count)
            {
                myTable.Rows[RowIndex].Delete();

                gv.DataSource = myTable.DefaultView;
                gv.DataBind();
            }
        }
    }
}