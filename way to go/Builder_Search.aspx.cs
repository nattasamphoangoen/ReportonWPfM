using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Builder_Search : System.Web.UI.Page
{
    ConnectDB db = new ConnectDB();
    tipSortTable ST = new tipSortTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
        }
    }
    

    protected void SearchData()
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"SELECT B.BUILDER_ID, B.AREA_ID, A.AREA_NAME, B.BUILDER_NAME, 
                                    CASE B.BUILDER_STATUS 
                                        WHEN 'Y' THEN 'Active' 
                                        WHEN 'N' THEN 'Inactive'
                                        ELSE '-'
                                   END AS BUILDER_STATUS
                                FROM [PersonalIden].[dbo].[MASTER_BUILDER] AS B
                                INNER JOIN [PersonalIden].[dbo].[MASTER_AREA] AS A ON B.AREA_ID = A.AREA_ID";

        if (!string.IsNullOrEmpty(txtBuilder.Text.Trim()))
        {
            command.CommandText += " and B.BUILDER_NAME LIKE @BUILDER_NAME";
            command.Parameters.AddWithValue("@BUILDER_NAME", "%" + txtBuilder.Text.Trim() + "%");
        }
        if (!string.IsNullOrEmpty(radStatus.SelectedValue.Trim()))
        {
            command.CommandText += " and BUILDER_STATUS = @BUILDER_STATUS";
            command.Parameters.AddWithValue("@BUILDER_STATUS", radStatus.SelectedValue.Trim());
        }
        if (!string.IsNullOrEmpty(ddlArea.SelectedValue.Trim()))
        {
            command.CommandText += " and B.AREA_ID = @AREA_ID";
            command.Parameters.AddWithValue("@AREA_ID", ddlArea.SelectedValue.Trim());
        }

        DataTable blacklistDT = db.ExecuteDataTable(command);
        
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind();
        lblRecord.Text = "<span class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString("#,###") + " Person(s)</span>";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        btnAddNewBuilder.Visible = true;
        this.SearchData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlArea.SelectedValue = "";
        txtBuilder.Text = "";
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        this.btnSubmit_Click(sender, e);
    }

    protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting(sender, e, (DataTable)ViewState["dtShowData"], SD);
    }

    public SortDirection GridviewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    protected void ClearPopUp()
    {
        ddlAreaAdd.SelectedValue = "";
        txtBuilderAdd.Text = "";
        hdfBuilderID.Value = "";
        radBuilderStatus.SelectedValue = "Y";
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAddNewBuilder_Click(object sender, EventArgs e)
    {
        UpdatePanel5.Update();
        popupAddBuilder.Show();
        this.ClearPopUp();
    }
    protected void btnAddBuilder_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Update();
        if (this.SaveBuilder(hdfBuilderID.Value) == true)
        {
            this.SearchData();
            popupAddBuilder.Hide();
        }

    }
    protected void btnCancelBuilder_Click(object sender, EventArgs e)
    {
        UpdatePanel5.Update();
        popupAddBuilder.Hide();
    }


    protected bool SaveBuilder(string ID)
    {
        string sql = "";
        if (ID == "")
        {
            sql = @"INSERT INTO MASTER_BUILDER
                    (AREA_ID,   BUILDER_NAME,  BUILDER_STATUS) 
                    VALUES
                    (@AREA_ID, @BUILDER_NAME, @BUILDER_STATUS)";
        }
        else
        {
            sql = @"UPDATE MASTER_BUILDER  SET
                    AREA_ID = @AREA_ID,
                    BUILDER_NAME = @BUILDER_NAME,
                    BUILDER_STATUS = @BUILDER_STATUS
                    WHERE BUILDER_ID = @ID";
        }

        //  db.ConnectionString = con_string;
        SqlCommand command = new SqlCommand();
        command.CommandText = sql;

        try
        {
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@BUILDER_NAME", txtBuilderAdd.Text.Trim());
            command.Parameters.AddWithValue("@BUILDER_STATUS", radBuilderStatus.SelectedValue);
            command.Parameters.AddWithValue("@AREA_ID", ddlAreaAdd.SelectedValue);
            db.ExecuteNonQuery(command);

            return true;
        }
        catch (Exception ex)
        {
            lblInError.Text += "SaveBuilder = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 
    }

    protected DataTable SearchOneArea(string ID)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = @"SELECT B.BUILDER_ID, B.AREA_ID, A.AREA_NAME, B.BUILDER_NAME, B.BUILDER_STATUS
                                FROM [PersonalIden].[dbo].[MASTER_BUILDER] AS B
                                INNER JOIN [PersonalIden].[dbo].[MASTER_AREA] AS A ON B.AREA_ID = A.AREA_ID
                                WHERE B.BUILDER_ID = @BUILDER_ID";

        command.Parameters.AddWithValue("@BUILDER_ID", ID);


        try
        {
            DataTable blacklistDT = db.ExecuteDataTable(command);
            return blacklistDT;
        }
        catch (Exception ex)
        {
            lblInError.Text += "SaveBuilder = " + ex.Message + "<br />";
            return null;
        }
    }
    protected void btnEditNewBuilder_Click(object sender, EventArgs e)
    {

        GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
        string BUILDER_ID = gvData.DataKeys[row.RowIndex]["BUILDER_ID"].ToString();
        DataTable ds = this.SearchOneArea(BUILDER_ID);
        if (ds != null && ds.Rows.Count > 0)
        {
            UpdatePanel5.Update(); 
            popupAddBuilder.Show();
            radBuilderStatus.SelectedValue = ds.Rows[0]["BUILDER_STATUS"].ToString();
            ddlAreaAdd.SelectedValue = ds.Rows[0]["AREA_ID"].ToString();
            hdfBuilderID.Value = ds.Rows[0]["BUILDER_ID"].ToString();
            txtBuilderAdd.Text = ds.Rows[0]["BUILDER_NAME"].ToString();
        }
       
    }
}
