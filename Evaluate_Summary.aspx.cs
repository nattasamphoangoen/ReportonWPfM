using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//2
public partial class Evaluate_Summary : System.Web.UI.Page {
    //=============================DevelMaint2_1 =================================================
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    DataTable dtShowData2;
    SortTable ST = new SortTable ();
    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {

        this.SearchData ();

    }

    protected void report1_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_ServiceWork.aspx?nID=" + rId);

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Develop_Mainten.aspx?nID=" + rId);

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Research.aspx?nID=" + rId);

    }
    protected void report4_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Promotion_work.aspx?nID=" + rId);

    }
    protected void report5_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_AcademicServices.aspx?nID=" + rId);

    }
    protected void report6_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Management.aspx?nID=" + rId);

    }
    protected void report7_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Other.aspx?nID=" + rId);

    }
    protected void reportSummary_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Summary.aspx?nID=" + rId);

    }

    protected void SearchData () {
        string sql = @"SELECT DISTINCT M.id, E1_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_1.score1_1, A.Position,  A.Department, E1_1.createdBy,
                '1. งานให้บริการ (ภาควิชาการ, ภาคอุตสาหกรรม)' as E1_1
                FROM EvaluateSevice1_1 AS E1_1
                INNER JOIN EvaluateMaster AS M ON M.id = E1_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_1
                    FROM EvaluateSevice1_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_1 ON E1_1.masterId = SUM1_1.masterId
                WHERE M.acountId = E1_1.createdBy AND E1_1.masterId = @MasterId

                UNION ALL

                SELECT DISTINCT M.id, E1_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_1.score1_1, A.Position,  A.Department, E1_1.createdBy,
                '1.1. งาน Local contact (Experimental setup, Sample preparation, and Measurement) งานสอบเทียบเครื่องมือและมาตรฐานการวัด' as E1_1
                FROM EvaluateSevice1_1 AS E1_1
                INNER JOIN EvaluateMaster AS M ON M.id = E1_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_1
                    FROM EvaluateSevice1_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_1 ON E1_1.masterId = SUM1_1.masterId
                WHERE M.acountId = E1_1.createdBy AND E1_1.masterId = @MasterId

                UNION ALL

                SELECT DISTINCT M.id, E1_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_2.score1_2, A.Position, A.Department, E1_2.createdBy, 
                '1.2. งานให้บริการภาคอุตสาหกรรม' as E1_1
                FROM EvaluateSevice1_2 AS E1_2
                INNER JOIN EvaluateMaster AS M ON M.id = E1_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_2
                    FROM EvaluateSevice1_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_2 ON E1_2.masterId = SUM1_2.masterId
                WHERE M.acountId = E1_2.createdBy AND E1_2.masterId = @MasterId 

                UNION ALL

                SELECT DISTINCT M.id, E1_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_3.score1_3, A.Position, A.Department, E1_3.createdBy,
                '1.3. งานเป็นที่ปรึกษาให้กับผู้ใช้บริการแสงซินโครตรอน / ภาคอุตสาหกรรม' as E1_1
                FROM EvaluateSevice1_3 AS E1_3
                INNER JOIN EvaluateMaster AS M ON M.id = E1_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_3
                    FROM EvaluateSevice1_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_3 ON E1_3.masterId = SUM1_3.masterId
                WHERE M.acountId = E1_3.createdBy AND E1_3.masterId = @MasterId 
                
				 UNION ALL

                SELECT DISTINCT M.id, E1_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_4.score1_4, A.Position, A.Department, E1_4.createdBy,
                '1.4. Technical manual (*)' as E1_1
                FROM EvaluateSevice1_4 AS E1_4
                INNER JOIN EvaluateMaster AS M ON M.id = E1_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_4
                    FROM EvaluateSevice1_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_4 ON E1_4.masterId = SUM1_4.masterId
                WHERE M.acountId = E1_4.createdBy AND E1_4.masterId = @MasterId 

				UNION ALL

                SELECT DISTINCT M.id, E1_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_5.score1_5, A.Position, A.Department, E1_5.createdBy,
                '1.5. Standard protocol (คู่มือกระบวนการดำเนินงาน)' as E1_1
                FROM EvaluateSevice1_5 AS E1_5
                INNER JOIN EvaluateMaster AS M ON M.id = E1_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_5
                    FROM EvaluateSevice1_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_5 ON E1_5.masterId = SUM1_5.masterId
                WHERE M.acountId = E1_5.createdBy AND E1_5.masterId = @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);
        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        SqlDataReader reader = cmd.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string Position = reader["Position"].ToString ();
        string Department = reader["Department"].ToString ();
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind ();
        lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";
        lbl_FullName.Text = FullName;
        lbl_Position.Text = Position;
        lbl_Department.Text = Department;
    }

    protected void Add2_1_Click (object sender, EventArgs e) {
        //  UpdatePanel2_1.Update ();
        // popupAddDevelMaint2_1.Show ();
        this.ClearPopUp ();
    }

    protected void gvData_Sorting (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging (object sender, GridViewPageEventArgs e) {
        gvData.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind ();
        this.btnSubmit_Click (sender, e);
    }
    protected void gvData_SelectedIndexChanged (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus")).Value);
        }

    }

    public SortDirection GridviewSortDirection {
        get {
            if (ViewState["sortDirection"] == null) {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection) ViewState["sortDirection"];
        }
        set {
            ViewState["sortDirection"] = value;
        }
    }

    //=============================popup=================================================

    protected void ClearPopUp () {

    }
    protected void btnAddDevelMaint_Click (object sender, EventArgs e) {

    }
    protected void btnDeleteDevelMaint_Click (object sender, EventArgs e) {

    }

    protected void btnSubmit_Click (object sender, EventArgs e) {

        this.SearchData ();
    }

    protected void btnDownload_Click (object sender, EventArgs e) {

        this.SearchData ();
    }

}