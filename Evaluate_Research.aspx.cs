using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//3
public partial class Evaluate_Research : System.Web.UI.Page {
    //=============================Research3_1 =================================================
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    DataTable dtShowData3;
    SortTable ST = new SortTable ();
    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {

        this.SearchData ();

        this.SearchData2 ();

        this.SearchData3 ();

        this.SearchData4 ();
        this.SearchData7 ();
        this.SearchData8 ();
        this.SearchData9 ();
        this.SearchData5 ();
        this.SearchData6 ();
        if (!this.CheckData ()) {
            Add3_1.Visible = false;
            Add3_2.Visible = false;
            Add3_3.Visible = false;
            Add3_4.Visible = false;
            Add3_5.Visible = false;
            Add3_6.Visible = false;
            Add3_7.Visible = false;
            Add3_8.Visible = false;
            Add3_9.Visible = false;
        }

    }
    protected bool CheckData () {
        string sql = @"SELECT evaluateStatus
                    FROM EvaluateMaster                   
                    WHERE   id = @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataReader reader = cmd.ExecuteReader ();
        reader.Read ();

        object res = db.ExecuteScalar (cmd);
        if (res != null)
            if (reader["evaluateStatus"].ToString () == "W") {
                return true;
            }
        else {
            return false;
        } else {
            return false;
        }
        con.Close ();

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
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectQ]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[createdDate]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    FROM [EvaluateResearch3_1] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind ();
        lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_1_Click (object sender, EventArgs e) {
        UpdatePanel3_1.Update ();
        popupAddResearch3_1.Show ();
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
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_1] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch").Visible = true;
                e.Row.FindControl ("btnEditResearch").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch").Visible = false;
                e.Row.FindControl ("btnEditResearch").Visible = false;

            }

        }
        con.Close ();
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
        txtProjectTopic.Text = "";
        txtProjectType.Text = "";
        txtProjectQ.Text = "";

    }
    protected void btnAddResearch_Click (object sender, EventArgs e) {
        UpdatePanel3_1.Update ();
        if (this.SaveResearch (hdf_ResearchStatus.Value) == true) {
            this.SearchData ();
            popupAddResearch3_1.Hide ();
        }

    }
    protected void btnCancelResearch_Click (object sender, EventArgs e) {
        UpdatePanel3_1.Update ();
        popupAddResearch3_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add3_1.Visible = true;
        this.SearchData ();
    }

    protected void btnReset_Click (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_1] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-1\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            // Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_1.FileName);
        string NewFileName = "Research3_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_1.FileName;
        // string NewFileName = FileUpload3_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_1.HasFile) {
            FileUpload3_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_1
                    (masterId,  projectTopic,  projectType, projectQ, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectQ, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_1)";
        } else {

            sql = @"UPDATE EvaluateResearch3_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateResearch3_1
                    (masterId,  projectTopic,  projectType, projectQ, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectQ, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_1 = 0;
            string Type3_1 = txtProjectType.SelectedValue.ToString ();
            string Q3_1 = txtProjectQ.SelectedValue.ToString ();
            string SType;
            if (Type3_1 == "First author                                                                                        " ||
                Type3_1 == "Corresponding author                                                                                ") {
                if (Q3_1 == "Q1                                                                                                  ") {
                    totalScore3_1 = 100;
                } else if (Q3_1 == "Q2                                                                                                  ") {
                    totalScore3_1 = 95;
                } else if (Q3_1 == "Q3                                                                                                  ") {
                    totalScore3_1 = 90;
                } else if (Q3_1 == "Q4                                                                                                  ") {
                    totalScore3_1 = 85;
                }
            } else {
                if (Q3_1 == "Q1                                                                                                  ") {
                    totalScore3_1 = 40;
                } else if (Q3_1 == "Q2                                                                                                  ") {
                    totalScore3_1 = 38;
                } else if (Q3_1 == "Q3                                                                                                  ") {
                    totalScore3_1 = 36;
                } else if (Q3_1 == "Q4                                                                                                  ") {
                    totalScore3_1 = 34;
                }
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectQ", txtProjectQ.SelectedValue);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_1", totalScore3_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_1.Text += "SaveResearch = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectTopic]
                        ,[projectType]
                        ,[projectQ]
                        ,[projectScore]
                        ,[projectStatus]
                        ,[path]
                        ,[fileName]
                        ,[fileNameOld]
                        ,[createdBy]
                        ,[createdDate]
                        ,[ipAddressCreate]
                        ,[updatedBy]
                        ,[ipAdressUpdate]
                                        
                    FROM [EvaluateResearch3_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_1.Text += "SaveResearch = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_1.Update ();
            popupAddResearch3_1.Show ();
            hdf_ResearchStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectQ.SelectedValue = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData ();
            ClearPopUp ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab6-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        SearchData ();
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 3_1 ###################################################################################
    //####################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 3_2######################################################################################

    protected void SearchData2 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    FROM [EvaluateResearch3_2] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData2.DataSource = blacklistDT.DefaultView;
        gvData2.DataBind ();
        lblRecord2.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_2_Click (object sender, EventArgs e) {
        UpdatePanel3_2.Update ();
        popupAddResearch3_2.Show ();
        this.ClearPopUp3 ();
    }

    protected void gvData_Sorting2 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging2 (object sender, GridViewPageEventArgs e) {
        gvData2.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData2.PageIndex = e.NewPageIndex;
        gvData2.DataBind ();
        this.btnSubmit_Click2 (sender, e);
    }
    protected void gvData_SelectedIndexChanged2 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound2 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus2")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_2] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch2").Visible = true;
                e.Row.FindControl ("btnEditResearch2").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch2").Visible = false;
                e.Row.FindControl ("btnEditResearch2").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection2 {
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

    protected void ClearPopUp2 () {
        txtProjectTopic2.Text = "";
        txtProjectType2.Text = "";

    }
    protected void btnAddResearch_Click2 (object sender, EventArgs e) {
        UpdatePanel3_2.Update ();
        if (this.SaveResearch2 (hdf_ResearchStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddResearch3_2.Hide ();
        }

    }
    protected void btnCancelResearch_Click2 (object sender, EventArgs e) {
        UpdatePanel3_2.Update ();
        popupAddResearch3_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add3_2.Visible = true;
        this.SearchData2 ();
    }

    protected void btnReset_Click2 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_2] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch2 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-2\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_2.FileName);
        string NewFileName = "Research3_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_2.FileName;
        // string NewFileName = FileUpload3_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_2.HasFile) {
            FileUpload3_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_2
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_2)";
        } else {

            sql = @"UPDATE EvaluateResearch3_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateResearch3_2
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_2)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_2 = 0;
            string Type3_2 = txtProjectType2.SelectedValue.ToString ();

            string SType;
            if (Type3_2 == "First author                                                                                        " ||
                Type3_2 == "Corresponding author                                                                                ") {
                totalScore3_2 = 70;
            } else {
                totalScore3_2 = 28;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType2.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_2", totalScore3_2);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_2.Text += "SaveResearch2 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea2 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                      ,[projectTopic]
                      ,[projectType]
                      ,[projectScore]
                      ,[projectStatus]
                      ,[path]
                      ,[fileName]
                      ,[fileNameOld]
                      ,[createdBy]
                      ,[ipAddressCreate]
                      ,[updatedBy]
                      ,[ipAdressUpdate]
                                                        
                    FROM [EvaluateResearch3_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_2.Text += "SaveResearch2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_2.Update ();
            popupAddResearch3_2.Show ();
            hdf_ResearchStatus2.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic2.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType2.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus2.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData2 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-2\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 3_2 ####################################################################################
    //######################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 3_3###################################################################################

    protected void SearchData3 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    FROM [EvaluateResearch3_3] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData3.DataSource = blacklistDT.DefaultView;
        gvData3.DataBind ();
        lblRecord3.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_3_Click (object sender, EventArgs e) {
        UpdatePanel3_3.Update ();
        popupAddResearch3_3.Show ();
        this.ClearPopUp3 ();
    }

    protected void gvData_Sorting3 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging3 (object sender, GridViewPageEventArgs e) {
        gvData3.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData3.PageIndex = e.NewPageIndex;
        gvData3.DataBind ();
        this.btnSubmit_Click3 (sender, e);
    }
    protected void gvData_SelectedIndexChanged3 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound3 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus3")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_3] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch3").Visible = true;
                e.Row.FindControl ("btnEditResearch3").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch3").Visible = false;
                e.Row.FindControl ("btnEditResearch3").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection3 {
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

    protected void ClearPopUp3 () {
        txtProjectTopic3.Text = "";
        txtProjectType3.Text = "";

    }
    protected void btnAddResearch_Click3 (object sender, EventArgs e) {
        UpdatePanel3_3.Update ();
        if (this.SaveResearch3 (hdf_ResearchStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddResearch3_3.Hide ();
        }

    }
    protected void btnCancelResearch_Click3 (object sender, EventArgs e) {
        UpdatePanel3_3.Update ();
        popupAddResearch3_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add3_3.Visible = true;
        this.SearchData3 ();
    }

    protected void btnReset_Click3 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click3 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_3] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch3 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-3\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-3\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_3.FileName);
        string NewFileName = "Research3_3_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_3.FileName;
        // string NewFileName = FileUpload3_3.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_3.HasFile) {
            FileUpload3_3.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_3)";
        } else {

            sql = @"UPDATE EvaluateResearch3_3  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateResearch3_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_3)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_3 = 0;
            string Type3_3 = txtProjectType3.SelectedValue.ToString ();

            string SType;
            if (Type3_3 == "สิทธิบัตร (ตปท.)                                                                                    ") {
                totalScore3_3 = 100;
            } else if (Type3_3 == "อนุสิทธิบัตร                                                                                        ") {
                totalScore3_3 = 70;
            } else {
                totalScore3_3 = 90;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType3.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic3.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_3", totalScore3_3);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_3", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_3.Text += "SaveResearch3 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea3 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                                                        
                    FROM [EvaluateResearch3_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_3.Text += "SaveResearch3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_3.Update ();
            popupAddResearch3_3.Show ();
            hdf_ResearchStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic3.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType3.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus3.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData3 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-3\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 3_3 ##############################################################
    //################################################################################################################################
    //################################################################################################################################
    //##########################################################Strat 3_4#############################################################

    protected void SearchData4 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectAgency]
                    ,[projectLevel]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    FROM [EvaluateResearch3_4] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData4.DataSource = blacklistDT.DefaultView;
        gvData4.DataBind ();
        lblRecord4.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_4_Click (object sender, EventArgs e) {
        UpdatePanel3_4.Update ();
        popupAddResearch3_4.Show ();
        this.ClearPopUp4 ();
    }

    protected void gvData_Sorting4 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging4 (object sender, GridViewPageEventArgs e) {
        gvData4.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData4.PageIndex = e.NewPageIndex;
        gvData4.DataBind ();
        this.btnSubmit_Click4 (sender, e);
    }
    protected void gvData_SelectedIndexChanged4 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound4 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus4")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_4] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch4").Visible = true;
                e.Row.FindControl ("btnEditResearch4").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch4").Visible = false;
                e.Row.FindControl ("btnEditResearch4").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection4 {
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

    protected void ClearPopUp4 () {
        txtProjectTopic4.Text = "";
        txtProjectType4.Text = "";
        txtProjectAgency4.Text = "";
        txtProjectLevel4.Text = "";

    }
    protected void btnAddResearch_Click4 (object sender, EventArgs e) {
        UpdatePanel3_4.Update ();
        if (this.SaveResearch4 (hdf_ResearchStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddResearch3_4.Hide ();
        }

    }
    protected void btnCancelResearch_Click4 (object sender, EventArgs e) {
        UpdatePanel3_4.Update ();
        popupAddResearch3_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add3_4.Visible = true;
        this.SearchData4 ();
    }

    protected void btnReset_Click4 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click4 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_4] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch4 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-4\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-4\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_4.FileName);
        string NewFileName = "Research3_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_4.FileName;
        // string NewFileName = FileUpload3_4.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_4.HasFile) {
            FileUpload3_4.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectLevel, projectAgency) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_4, @ProjectLevel, @ProjectAgency)";
        } else {

            sql = @"UPDATE EvaluateResearch3_4  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateResearch3_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectLevel, projectAgency) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_4, @ProjectLevel, @ProjectAgency)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_4 = 0;
            string Type3_4 = txtProjectType4.SelectedValue.ToString ();
            string Level3_4 = txtProjectLevel4.SelectedValue.ToString ();

            if (Level3_4 == "ไทย                                                                                                 ") {
                if (Type3_4 == "Oral Presentation                                                                                   ") {
                    totalScore3_4 = 15;
                } else {
                    totalScore3_4 = 10;
                }
            } else {
                if (Type3_4 == "Oral Presentation                                                                                   ") {
                    totalScore3_4 = 35;
                } else {
                    totalScore3_4 = 15;
                }
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType4.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectLevel", txtProjectLevel4.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectAgency", txtProjectAgency4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_4", totalScore3_4);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_4", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_4.Text += "SaveResearch4 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea4 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectAgency]
                    ,[projectLevel]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                                                        
                    FROM [EvaluateResearch3_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_4.Text += "SaveResearch4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_4.Update ();
            popupAddResearch3_4.Show ();
            hdf_ResearchStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic4.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType4.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectLevel4.SelectedValue = ds.Rows[0]["projectLevel"].ToString ();
            txtProjectAgency4.Text = ds.Rows[0]["projectAgency"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus4.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData4 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-4\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_4 ################################################################
    //##################################################################################################################################
    //##################################################################################################################################
    //##########################################################Strat 3_5###############################################################

    protected void SearchData5 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateResearch3_5] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData5.DataSource = blacklistDT.DefaultView;
        gvData5.DataBind ();
        lblRecord5.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_5_Click (object sender, EventArgs e) {
        UpdatePanel3_5.Update ();
        popupAddResearch3_5.Show ();
        this.ClearPopUp5 ();
    }

    protected void gvData_Sorting5 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging5 (object sender, GridViewPageEventArgs e) {
        gvData5.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData5.PageIndex = e.NewPageIndex;
        gvData5.DataBind ();
        this.btnSubmit_Click5 (sender, e);
    }
    protected void gvData_SelectedIndexChanged5 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound5 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus5")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_5] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch5").Visible = true;
                e.Row.FindControl ("btnEditResearch5").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch5").Visible = false;
                e.Row.FindControl ("btnEditResearch5").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection5 {
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

    protected void ClearPopUp5 () {
        txtProjectTopic5.Text = "";
        txtProjectType5.Text = "";
        txtProjectJoint5.Text = "";

    }
    protected void btnAddResearch_Click5 (object sender, EventArgs e) {
        UpdatePanel3_5.Update ();
        if (this.SaveResearch5 (hdf_ResearchStatus5.Value) == true) {
            this.SearchData5 ();
            popupAddResearch3_5.Hide ();
        }

    }
    protected void btnCancelResearch_Click5 (object sender, EventArgs e) {
        UpdatePanel3_5.Update ();
        popupAddResearch3_5.Hide ();
    }

    protected void btnSubmit_Click5 (object sender, EventArgs e) {
        Add3_5.Visible = true;
        this.SearchData5 ();
    }

    protected void btnReset_Click5 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click5_1 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,pathShare + fileNameShare AS Pathfile
                    FROM [EvaluateResearch3_5] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }
    protected void btnDownload_Click5_2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_5] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch5 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-5_2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-5_2\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_5_2.FileName);
        string NewFileName = "Research3_5_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_5_2.FileName;
        // string NewFileName = FileUpload3_5.FileName;

        string InsertFile = filepath + NewFileName;
        //======================================================================================================
        string filepathShare;
        string filepathDeleteShare;
        string filepathEditShare;
        string rootpathShare = Request.PhysicalApplicationPath;
        string pathShare = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tabShare3-5_1\\";
        string pathDeleteShare = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tabShare3-5_1\\";
        string pathEditShare = "Edit\\" + path;
        // filepathEditShare = rootpath + pathEdit;
        filepathShare = rootpath + pathShare;
        filepathDeleteShare = rootpath + pathDeleteShare;
        //var directoryInfoShare = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepathShare) || !Directory.Exists (filepathDeleteShare)) {
            Directory.CreateDirectory (filepathShare);
            Directory.CreateDirectory (filepathDeleteShare);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileNameShare = Path.GetFileName (FileUploadShare3_5_1.FileName);
        string NewFileNameShare = "Research3_5_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUploadShare3_5_1.FileName;
        // string NewFileName = FileUpload3_5.FileName;

        string InsertFileShare = filepathShare + NewFileNameShare;
        //InsertFile.SaveAs
        if (FileUpload3_5_2.HasFile || FileUploadShare3_5_1.HasFile) {
            FileUpload3_5_2.SaveAs (InsertFile);
            FileUploadShare3_5_1.SaveAs (InsertFileShare);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_5
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectJoint, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_5, @ProjectJoint, @PathShare, @FileNameShare, @FileNameShareOld)";
        } else {

            sql = @"UPDATE EvaluateResearch3_5  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                    INSERT INTO EvaluateResearch3_5
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectJoint, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_5, @ProjectJoint, @PathShare, @FileNameShare, @FileNameShareOld)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_5 = 0;
            string Type3_5 = txtProjectType5.SelectedValue.ToString ();
            decimal Joint5 = decimal.Parse (txtProjectJoint5.Text);
            if (Type3_5 == "Main auther") {
                totalScore3_5 = 60;
            } else {
                if (Joint5 >= 1 && Joint5 <= 10) {
                    totalScore3_5 = 10;
                } else {
                    totalScore3_5 = Joint5;
                }
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType5.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic5.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectJoint", txtProjectJoint5.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@PathShare", filepathShare);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@FileNameShareOld", OldFileNameShare);
            cmd.Parameters.AddWithValue ("@FileNameShare", NewFileNameShare);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_5", totalScore3_5);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_5", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_5.Text += "SaveResearch5 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea5 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                                                        
                    FROM [EvaluateResearch3_5] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_5.Text += "SaveResearch5 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click5 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_5.Update ();
            popupAddResearch3_5.Show ();
            hdf_ResearchStatus5.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic5.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType5.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectJoint5.Text = ds.Rows[0]["projectJoint"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click5 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        string fileSrc;
        string fileDelete;
        string fileSrcPresent;
        string fileDeletePresent;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus5.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_5  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus5.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData5 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-5_2\\";
        string pathPresent = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-5_1\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        fileSrcPresent = ds.Rows[0]["pathShare"].ToString () + ds.Rows[0]["fileNameShare"].ToString ();
        fileDeletePresent = rootpath + pathPresent + ds.Rows[0]["fileNameShare"].ToString ();
        File.Move (fileSrc, fileDelete);
        File.Move (fileSrcPresent, fileDeletePresent);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_5 ##################################################################
    //####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 3_6################################################################

    protected void SearchData6 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[projectJoint]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateResearch3_6] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData6.DataSource = blacklistDT.DefaultView;
        gvData6.DataBind ();
        lblRecord6.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_6_Click (object sender, EventArgs e) {
        UpdatePanel3_6.Update ();
        popupAddResearch3_6.Show ();
        this.ClearPopUp6 ();
    }

    protected void gvData_Sorting6 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging6 (object sender, GridViewPageEventArgs e) {
        gvData6.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData6.PageIndex = e.NewPageIndex;
        gvData6.DataBind ();
        this.btnSubmit_Click6 (sender, e);
    }
    protected void gvData_SelectedIndexChanged6 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound6 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus6")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_6] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch6").Visible = true;
                e.Row.FindControl ("btnEditResearch6").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch6").Visible = false;
                e.Row.FindControl ("btnEditResearch6").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection6 {
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

    protected void ClearPopUp6 () {

        txtProjectName6.Text = "";
        txtProjectJoint6.Text = "";

    }
    protected void btnAddResearch_Click6 (object sender, EventArgs e) {
        UpdatePanel3_6.Update ();
        if (this.SaveResearch6 (hdf_ResearchStatus6.Value) == true) {
            this.SearchData6 ();
            popupAddResearch3_6.Hide ();
        }

    }
    protected void btnCancelResearch_Click6 (object sender, EventArgs e) {
        UpdatePanel3_6.Update ();
        popupAddResearch3_6.Hide ();
    }

    protected void btnSubmit_Click6 (object sender, EventArgs e) {
        Add3_6.Visible = true;
        this.SearchData6 ();
    }

    protected void btnReset_Click6 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click6_1 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,pathShare + fileNameShare AS Pathfile
                    FROM [EvaluateResearch3_6] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }
    protected void btnDownload_Click6_2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_6] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch6 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-6_1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-6_1\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_6_1.FileName);
        string NewFileName = "Research3_6_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_6_1.FileName;
        // string NewFileName = FileUpload3_6.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_6_1.HasFile) {
            FileUpload3_6_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);
        //==========================================================
        string filepath1;
        string filepathDelete1;
        string filepathEdit1;
        string rootpath1 = Request.PhysicalApplicationPath;
        string path1 = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-6_2\\";
        string pathDelete1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-6_2\\";
        string pathEdit1 = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath1 = rootpath1 + path1;
        filepathDelete1 = rootpath1 + pathDelete1;
        var directoryInfo1 = new DirectoryInfo (filepath1);
        if (!Directory.Exists (filepath1) || !Directory.Exists (filepathDelete1)) {
            Directory.CreateDirectory (filepath1);
            Directory.CreateDirectory (filepathDelete1);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName1 = Path.GetFileName (FileUpload3_6_2.FileName);
        string NewFileName1 = "Research3_6_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_6_2.FileName;
        // string NewFileName = FileUpload3_6.FileName;

        string InsertFile1 = filepath1 + NewFileName1;
        //InsertFile.SaveAs
        if (FileUpload3_6_2.HasFile) {
            FileUpload3_6_2.SaveAs (InsertFile1);
        }
        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_6
                    (masterId,  projectName, projectJOint, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, pathShare, fileNameShareOld ,fileNameShare) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectJoint, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_6, @PathShare, @FileNameShareOld, @FileNameShare)";
        } else {

            sql = @"UPDATE EvaluateResearch3_6  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateResearch3_6
                    (masterId,  projectName, projectJOint, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, pathShare, fileNameShareOld ,fileNameShare) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectJoint, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_6,@PathShare, @FileNameShareOld, @FileNameShare)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            double totalScore3_6 = 0;
            // string Topic3_6 = txtProjectTopic6.SelectedValue.ToString ();
            double Joint6 = double.Parse (txtProjectJoint6.Text);
            // decimal InProgress6 = decimal.Parse (txtProjectInProgress6.Text);
            totalScore3_6 = Joint6 * 0.7;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectJoint", txtProjectJoint6.Text);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName6.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath1);
            cmd.Parameters.AddWithValue ("@PathShare", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName1);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName1);
            cmd.Parameters.AddWithValue ("@FileNameShareOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileNameShare", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_6", totalScore3_6);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_6", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_6.Text += "SaveResearch6 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea6 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[projectJoint]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                                                        
                    FROM [EvaluateResearch3_6] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_6.Text += "SaveResearch6 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click6 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_6.Update ();
            popupAddResearch3_6.Show ();
            hdf_ResearchStatus6.Value = ds.Rows[0]["id"].ToString ();

            //   txtProjectTopic6.SelectedValue = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectName6.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectJoint6.Text = ds.Rows[0]["projectJoint"].ToString ();
            //    txtProjectInProgress6.Text = ds.Rows[0]["projectInProgress"].ToString ();
        }

    }

    protected void btnDeleteResearch_Click6 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus6.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_6  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus6.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData6 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-6\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_6 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 3_7##################################################################

    protected void SearchData7 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[fileNameShare]
                    ,[fileNameShareOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateResearch3_7] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData7.DataSource = blacklistDT.DefaultView;
        gvData7.DataBind ();
        lblRecord7.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_7_Click (object sender, EventArgs e) {
        UpdatePanel3_7.Update ();
        popupAddResearch3_7.Show ();
        this.ClearPopUp7 ();
    }

    protected void gvData_Sorting7 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging7 (object sender, GridViewPageEventArgs e) {
        gvData7.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData7.PageIndex = e.NewPageIndex;
        gvData7.DataBind ();
        this.btnSubmit_Click7 (sender, e);
    }
    protected void gvData_SelectedIndexChanged7 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound7 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus7")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_7] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch7").Visible = true;
                e.Row.FindControl ("btnEditResearch7").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch7").Visible = false;
                e.Row.FindControl ("btnEditResearch7").Visible = false;

            }

        }
        con.Close ();
    }

    public SortDirection GridviewSortDirection7 {
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

    protected void ClearPopUp7 () {
        txtProjectTopic7.Text = "";
        txtProjectType7.Text = "";
        txtProjectJoint7.Text = "";

    }
    protected void btnAddResearch_Click7 (object sender, EventArgs e) {
        UpdatePanel3_7.Update ();
        if (this.SaveResearch7 (hdf_ResearchStatus7.Value) == true) {
            this.SearchData7 ();
            popupAddResearch3_7.Hide ();
        }

    }
    protected void btnCancelResearch_Click7 (object sender, EventArgs e) {
        UpdatePanel3_7.Update ();
        popupAddResearch3_7.Hide ();
    }

    protected void btnSubmit_Click7 (object sender, EventArgs e) {
        Add3_7.Visible = true;
        this.SearchData7 ();
    }

    protected void btnReset_Click7 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click7 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,pathShare + fileNameShare AS Pathfile
                    FROM [EvaluateResearch3_7] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData7.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch7 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================

        //======================================================================================================
        string filepathShare;
        string filepathDeleteShare;
        string filepathEditShare;
        string rootpath = Request.PhysicalApplicationPath;
        string pathShare = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-7\\";
        string pathDeleteShare = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-7\\";
        // string pathEditShare = "Edit\\" + path;
        // filepathEditShare = rootpath + pathEdit;
        filepathShare = rootpath + pathShare;
        filepathDeleteShare = rootpath + pathDeleteShare;
        //var directoryInfoShare = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepathShare) || !Directory.Exists (filepathDeleteShare)) {
            Directory.CreateDirectory (filepathShare);
            Directory.CreateDirectory (filepathDeleteShare);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileNameShare = Path.GetFileName (FileUploadShare3_7.FileName);
        string NewFileNameShare = "Research3_7_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUploadShare3_7.FileName;
        // string NewFileName = FileUpload3_7.FileName;

        string InsertFileShare = filepathShare + NewFileNameShare;
        //InsertFile.SaveAs
        if (FileUploadShare3_7.HasFile) {
            // FileUpload3_7_2.SaveAs (InsertFile);
            FileUploadShare3_7.SaveAs (InsertFileShare);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_7
                    (masterId,  projectTopic,  projectType, ipAddressCreate,
                     createdBy, projectScore, projectJoint, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @IpAddress, 
                    @CreatedBy, @Score3_7, @ProjectJoint, @PathShare, @FileNameShare, @FileNameShareOld)";
        } else {

            sql = @"UPDATE EvaluateResearch3_7  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                    INSERT INTO EvaluateResearch3_7
                    (masterId,  projectTopic,  projectType, ipAddressCreate,
                     createdBy, projectScore, projectJoint, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @IpAddress, 
                    @CreatedBy, @Score3_7, @ProjectJoint, @PathShare, @FileNameShare, @FileNameShareOld)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore3_7 = 0;
            string Type3_7 = txtProjectType7.SelectedValue.ToString ();
            decimal Joint7 = decimal.Parse (txtProjectJoint7.Text);
            if (Type3_7 == "หัวหน้าโครงการ") {
                totalScore3_7 = 35;
            } else {
                totalScore3_7 = Joint7 * 7;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType7.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic7.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectJoint", txtProjectJoint7.Text);
            cmd.Parameters.AddWithValue ("@PathShare", filepathShare);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameShareOld", OldFileNameShare);
            cmd.Parameters.AddWithValue ("@FileNameShare", NewFileNameShare);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_7", totalScore3_7);

            // cmd.Parameters.AddWithValue ("@FileNameOld3_7", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_7.Text += "SaveResearch7 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea7 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectType]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[fileNameShare]
                    ,[fileNameShareOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                                                        
                    FROM [EvaluateResearch3_7] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_7.Text += "SaveResearch7 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click7 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData7.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea7 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_7.Update ();
            popupAddResearch3_7.Show ();
            hdf_ResearchStatus7.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic7.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType7.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectJoint7.Text = ds.Rows[0]["projectJoint"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click7 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData7.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea7 (Id);

        string fileSrcPresent;
        string fileDeletePresent;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus7.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_7  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus7.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData7 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string pathPresent = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-7\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrcPresent = ds.Rows[0]["pathShare"].ToString () + ds.Rows[0]["fileNameShare"].ToString ();
        fileDeletePresent = rootpath + pathPresent + ds.Rows[0]["fileNameShare"].ToString ();
        File.Move (fileSrcPresent, fileDeletePresent);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_7 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 3_8 ##################################################################

    protected void SearchData8 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectStudentName]
                    ,[projectThesisTopic]
                    ,[projectInstitute]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateResearch3_8] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData8.DataSource = blacklistDT.DefaultView;
        gvData8.DataBind ();
        lblRecord8.Text = "<span Font-Size='Small' class='tex13b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_8_Click (object sender, EventArgs e) {
        UpdatePanel3_8.Update ();
        popupAddResearch3_8.Show ();
        this.ClearPopUp8 ();
    }

    protected void gvData_Sorting8 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging8 (object sender, GridViewPageEventArgs e) {
        gvData8.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData8.PageIndex = e.NewPageIndex;
        gvData8.DataBind ();
        this.btnSubmit_Click8 (sender, e);
    }
    protected void gvData_SelectedIndexChanged8 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound8 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus8")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_8] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch8").Visible = true;
                e.Row.FindControl ("btnEditResearch8").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch8").Visible = false;
                e.Row.FindControl ("btnEditResearch8").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection8 {
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

    protected void ClearPopUp8 () {

        txtProjectStudentName8.Text = "";
        txtProjectThesisTopic8.Text = "";
        txtProjectInstitute8.Text = "";

    }
    protected void btnAddResearch_Click8 (object sender, EventArgs e) {
        UpdatePanel3_8.Update ();
        if (this.SaveResearch8 (hdf_ResearchStatus8.Value) == true) {
            this.SearchData8 ();
            popupAddResearch3_8.Hide ();
        }

    }
    protected void btnCancelResearch_Click8 (object sender, EventArgs e) {
        UpdatePanel3_8.Update ();
        popupAddResearch3_8.Hide ();
    }

    protected void btnSubmit_Click8 (object sender, EventArgs e) {
        Add3_8.Visible = true;
        this.SearchData8 ();
    }

    protected void btnReset_Click8 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click8 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_8] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData8.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch8 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-8\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-8\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_8.FileName);
        string NewFileName = "Research3_8_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_8.FileName;
        // string NewFileName = FileUpload3_8.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_8.HasFile) {
            FileUpload3_8.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_8
                    (masterId,  projectThesisTopic,  projectStudentName, projectInstitute, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId,  @ProjectThesisTopic, @ProjectStudentName, @ProjectInstitute, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_8)";
        } else {

            sql = @"UPDATE EvaluateResearch3_8  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id

                   INSERT INTO EvaluateResearch3_8
                    (masterId,  projectThesisTopic,  projectStudentName, projectInstitute, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectThesisTopic, @ProjectStudentName,  @ProjectInstitute, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score3_8)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            // decimal DateNumber8 = decimal.Parse (txtDateNumber8.Text);
            decimal totalScore3_8 = 50;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectStudentName", txtProjectStudentName8.Text);
            cmd.Parameters.AddWithValue ("@ProjectThesisTopic", txtProjectThesisTopic8.Text);
            cmd.Parameters.AddWithValue ("@ProjectInstitute", txtProjectInstitute8.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_8", totalScore3_8);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_8.Text += "SaveResearch8 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea8 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectStudentName]
                    ,[projectThesisTopic]
                    ,[projectInstitute]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]

                    FROM [EvaluateResearch3_8] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_8.Text += "SaveResearch8 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click8 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData8.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea8 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_8.Update ();
            popupAddResearch3_8.Show ();
            hdf_ResearchStatus8.Value = ds.Rows[0]["id"].ToString ();
            txtProjectStudentName8.Text = ds.Rows[0]["projectStudentName"].ToString ();
            txtProjectThesisTopic8.Text = ds.Rows[0]["projectThesisTopic"].ToString ();
            txtProjectInstitute8.Text = ds.Rows[0]["projectInstitute"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click8 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData8.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea8 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus8.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_8  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus8.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData8 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-8\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_8 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 3_9 ##################################################################

    protected void SearchData9 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectInstituteName]
                    ,[projectJoint]
                    ,[projectAmount]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateResearch3_9] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData9.DataSource = blacklistDT.DefaultView;
        gvData9.DataBind ();
        lblRecord9.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add3_9_Click (object sender, EventArgs e) {
        UpdatePanel3_9.Update ();
        popupAddResearch3_9.Show ();
        this.ClearPopUp9 ();
    }

    protected void gvData_Sorting9 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging9 (object sender, GridViewPageEventArgs e) {
        gvData9.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData9.PageIndex = e.NewPageIndex;
        gvData9.DataBind ();
        this.btnSubmit_Click9 (sender, e);
    }
    protected void gvData_SelectedIndexChanged9 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound9 (object sender, GridViewRowEventArgs e) {
       if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus9")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateResearch3_9] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader = cmd.ExecuteReader ();
            reader.Read ();

            if (reader["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletResearch9").Visible = true;
                e.Row.FindControl ("btnEditResearch9").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletResearch9").Visible = false;
                e.Row.FindControl ("btnEditResearch9").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection9 {
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

    protected void ClearPopUp9 () {

        txtProjectInstituteName9.Text = "";
        txtProjectAmount9.Text = "";
        txtProjectJoint9.Text = "";

    }
    protected void btnAddResearch_Click9 (object sender, EventArgs e) {
        UpdatePanel3_9.Update ();
        if (this.SaveResearch9 (hdf_ResearchStatus9.Value) == true) {
            this.SearchData9 ();
            popupAddResearch3_9.Hide ();
        }

    }
    protected void btnCancelResearch_Click9 (object sender, EventArgs e) {
        UpdatePanel3_9.Update ();
        popupAddResearch3_9.Hide ();
    }

    protected void btnSubmit_Click9 (object sender, EventArgs e) {
        Add3_9.Visible = true;
        this.SearchData9 ();
    }

    protected void btnReset_Click9 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click9_1 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,pathShare + fileNameShare AS Pathfile
                    FROM [EvaluateResearch3_9] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected void btnDownload_Click9_2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateResearch3_9] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        com.Parameters.AddWithValue ("@Id", Id);
        SqlDataAdapter da = new SqlDataAdapter (com);
        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string Pathfile = reader["Pathfile"].ToString ();

        Response.Clear ();
        byte[] Content = File.ReadAllBytes (Pathfile);
        //Response.ContentType = "text/plain";
        Response.ContentType = "application/octect-stream";
        Response.AddHeader ("Content-Disposition", "attachment; filename=" + Path.GetFileName (Pathfile));
        Response.TransmitFile (Pathfile);
        Response.BufferOutput = true;
        Response.OutputStream.Write (Content, 0, Content.Length);
        Response.WriteFile (Pathfile);
        Response.Flush ();
        Response.End ();
        con.Close ();

    }

    protected bool SaveResearch9 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);
        DataSet ds = new DataSet ();
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================
        string filepath;
        string filepathDelete;
        string filepathEdit;
        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_2\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload3_9_2.FileName);
        string NewFileName = "Research3_9_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_9_2.FileName;
        // string NewFileName = FileUpload3_9.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload3_9_2.HasFile) {
            FileUpload3_9_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        string filepath1;
        string filepathDelete1;

        string rootpath1 = Request.PhysicalApplicationPath;
        string path1 = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_1\\";
        string pathDelete1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_1\\";
        string pathEdit1 = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath1 = rootpath1 + path1;
        filepathDelete1 = rootpath1 + pathDelete1;
        var directoryInfo1 = new DirectoryInfo (filepath1);
        if (!Directory.Exists (filepath1) || !Directory.Exists (filepathDelete1)) {
            Directory.CreateDirectory (filepath1);
            Directory.CreateDirectory (filepathDelete1);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName1 = Path.GetFileName (FileUpload3_9_1.FileName);
        string NewFileName1 = "Research3_9_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload3_9_1.FileName;
        // string NewFileName = FileUpload3_9.FileName;

        string InsertFile1 = filepath1 + NewFileName1;
        //InsertFile.SaveAs
        if (FileUpload3_9_1.HasFile) {
            FileUpload3_9_1.SaveAs (InsertFile1);
        }
        //=============================================================================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateResearch3_9
                    (masterId,  path, ipAddressCreate, fileNameOld, projectInstituteName , projectJoint, projectAmount,
                    fileName, createdBy, projectScore, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld, @ProjectInstituteName, @ProjectJoint, @ProjectAmount,
                    @FileName, @CreatedBy, @Score3_9, @PathShare, @FileNameShare, @FileNameShareOld)";
        } else {

            sql = @"UPDATE EvaluateResearch3_9  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id

                    INSERT INTO EvaluateResearch3_9
                    (masterId,  path, ipAddressCreate, fileNameOld, projectInstituteName , projectJoint, projectAmount,
                    fileName, createdBy, projectScore, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld, @ProjectInstituteName, @ProjectJoint, @ProjectAmount,
                    @FileName, @CreatedBy, @Score3_9, @PathShare, @FileNameShare, @FileNameShareOld)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            decimal Amount = decimal.Parse (txtProjectAmount9.Text);
            decimal Joint = decimal.Parse (txtProjectJoint9.Text);
            decimal totalScore3_9 = 0;

            totalScore3_9 = (((Amount / 100000) * 10) * Joint) / 100;
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectAmount", txtProjectAmount9.Text);
            cmd.Parameters.AddWithValue ("@ProjectInstituteName", txtProjectInstituteName9.Text);
            cmd.Parameters.AddWithValue ("@ProjectJoint", txtProjectJoint9.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@PathShare", filepath1);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileNameShare", NewFileName1);
            cmd.Parameters.AddWithValue ("@FileNameShareOld", OldFileName1);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score3_9", totalScore3_9);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError3_9.Text += "SaveResearch9 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea9 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectInstituteName]
                    ,[projectJoint]
                    ,[projectAmount]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathShare]
                    ,[path]
                    ,[fileNameShare]
                    ,[fileName]
                    ,[fileNameShareOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]

                    FROM [EvaluateResearch3_9] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError3_9.Text += "SaveResearch9 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditResearch_Click9 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea9 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel3_9.Update ();
            popupAddResearch3_9.Show ();
            hdf_ResearchStatus9.Value = ds.Rows[0]["id"].ToString ();
            txtProjectInstituteName9.Text = ds.Rows[0]["projectInstituteName"].ToString ();
            txtProjectJoint9.Text = ds.Rows[0]["projectJoint"].ToString ();
            txtProjectAmount9.Text = ds.Rows[0]["projectAmount"].ToString ();

        }

    }

    protected void btnDeleteResearch_Click9 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea9 (Id);
        string fileSrc;
        string fileDelete;
        string fileSrc1;
        string fileDelete1;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_ResearchStatus9.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateResearch3_9  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_ResearchStatus9.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData9 ();
        }
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        WHERE M.id = @MId
                        ";

        com = new SqlCommand (str, con);
        string rId = Request.QueryString["nId"];
        com.Parameters.AddWithValue ("@MId", rId);
        SqlDataAdapter da = new SqlDataAdapter (com);

        SqlDataReader reader = com.ExecuteReader ();
        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_1\\";
        string path1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab3-9_2\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path1 + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);

        fileSrc1 = ds.Rows[0]["pathShare"].ToString () + ds.Rows[0]["fileNameShare"].ToString ();
        fileDelete1 = rootpath + path + ds.Rows[0]["fileNameShare"].ToString ();
        File.Move (fileSrc1, fileDelete1);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 3_9 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################

}