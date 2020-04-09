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
public partial class Evaluate_Develop_Mainten : System.Web.UI.Page {
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

        this.SearchData2 ();

        this.SearchData3 ();

        this.SearchData4 ();
        this.SearchData7 ();
        this.SearchData8 ();
        this.SearchData9 ();
        this.SearchData5 ();
        this.SearchData6_1 ();
        this.SearchData6_2 ();
        

    }

    protected void reportSummary_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Summary.aspx?nID=" + rId);

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
                    FROM [EvaluateDevelopMainten2_1] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        string ckdt = @"SELECT evaluateStatus
                    FROM EvaluateMaster                   
                    WHERE   id = @MasterId";

        SqlCommand cmd1 = new SqlCommand (ckdt, con);
        cmd1.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataReader reader = cmd1.ExecuteReader ();
        reader.Read ();
        string EvaluateStatus = reader["evaluateStatus"].ToString ();
        if (EvaluateStatus == "W") {
            Add2_1.Visible = true;
            Add2_2.Visible = true;
            Add2_3.Visible = true;
            Add2_4.Visible = true;
            Add2_5.Visible = true;
            Add2_6_1.Visible = true;
            Add2_6_2.Visible = true;
            Add2_7.Visible = true;
            Add2_8.Visible = true;
            Add2_9.Visible = true;
        } else {
            Add2_1.Visible = false;
            Add2_2.Visible = false;
            Add2_3.Visible = false;
            Add2_4.Visible = false;
            Add2_5.Visible = false;
            Add2_6_1.Visible = false;
            Add2_6_2.Visible = false;
            Add2_7.Visible = false;
            Add2_8.Visible = false;
            Add2_9.Visible = false;
        }
        

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind ();
        lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add2_1_Click (object sender, EventArgs e) {
        UpdatePanel2_1.Update ();
        popupAddDevelMaint2_1.Show ();
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
                    FROM [EvaluateDevelopMainten2_1] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint").Visible = false;

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
    protected void btnAddDevelMaint_Click (object sender, EventArgs e) {
        UpdatePanel2_1.Update ();
        if (this.SaveDevelMaint (hdf_DevelMaintStatus.Value) == true) {
            this.SearchData ();
            popupAddDevelMaint2_1.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click (object sender, EventArgs e) {
        UpdatePanel2_1.Update ();
        popupAddDevelMaint2_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add2_1.Visible = true;
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
                    FROM [EvaluateDevelopMainten2_1] 
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

    protected bool SaveDevelMaint (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-1\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_1.FileName);
        string NewFileName = "DevelMaint2_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_1.FileName;
        // string NewFileName = FileUpload2_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_1.HasFile) {
            FileUpload2_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_1
                    (masterId,  projectTopic,  projectType, projectQ, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectQ, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_1)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_1
                    (masterId,  projectTopic,  projectType, projectQ, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectQ, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_1 = 0;
            string Type2_1 = txtProjectType.SelectedValue.ToString ();
            string Q2_1 = txtProjectQ.SelectedValue.ToString ();
            string SType;
            if (Type2_1 == "First author                                                                                        " ||
                Type2_1 == "Corresponding author                                                                                ") {
                if (Q2_1 == "Q1                                                                                                  ") {
                    totalScore2_1 = 100;
                } else if (Q2_1 == "Q2                                                                                                  ") {
                    totalScore2_1 = 95;
                } else if (Q2_1 == "Q3                                                                                                  ") {
                    totalScore2_1 = 90;
                } else if (Q2_1 == "Q4                                                                                                  ") {
                    totalScore2_1 = 85;
                }
            } else {
                if (Q2_1 == "Q1                                                                                                  ") {
                    totalScore2_1 = 40;
                } else if (Q2_1 == "Q2                                                                                                  ") {
                    totalScore2_1 = 38;
                } else if (Q2_1 == "Q3                                                                                                  ") {
                    totalScore2_1 = 36;
                } else if (Q2_1 == "Q4                                                                                                  ") {
                    totalScore2_1 = 34;
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
            cmd.Parameters.AddWithValue ("@Score2_1", totalScore2_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_1.Text += "SaveDevelMaint = " + ex.Message + "<br />";
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
                                        
                    FROM [EvaluateDevelopMainten2_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_1.Text += "SaveDevelMaint = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_1.Update ();
            popupAddDevelMaint2_1.Show ();
            hdf_DevelMaintStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectQ.SelectedValue = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData ();
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 2_1 ###################################################################################
    //####################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 2_2######################################################################################

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
                    FROM [EvaluateDevelopMainten2_2] 

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

    protected void Add2_2_Click (object sender, EventArgs e) {
        UpdatePanel2_2.Update ();
        popupAddDevelMaint2_2.Show ();
        this.ClearPopUp2 ();
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
                    FROM [EvaluateDevelopMainten2_2] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint2").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint2").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint2").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint2").Visible = false;

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
    protected void btnAddDevelMaint_Click2 (object sender, EventArgs e) {
        UpdatePanel2_2.Update ();
        if (this.SaveDevelMaint2 (hdf_DevelMaintStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddDevelMaint2_2.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click2 (object sender, EventArgs e) {
        UpdatePanel2_2.Update ();
        popupAddDevelMaint2_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add2_2.Visible = true;
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
                    FROM [EvaluateDevelopMainten2_2] 
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

    protected bool SaveDevelMaint2 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-2\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_2.FileName);
        string NewFileName = "DevelMaint2_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_2.FileName;
        // string NewFileName = FileUpload2_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_2.HasFile) {
            FileUpload2_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_2
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_2)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_2
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_2)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_2 = 0;
            string Type2_2 = txtProjectType2.SelectedValue.ToString ();

            string SType;
            if (Type2_2 == "First author                                                                                        " ||
                Type2_2 == "Corresponding author                                                                                ") {
                totalScore2_2 = 70;
            } else {
                totalScore2_2 = 28;
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
            cmd.Parameters.AddWithValue ("@Score2_2", totalScore2_2);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_2.Text += "SaveDevelMaint2 = " + ex.Message + "<br />";
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
                                                        
                    FROM [EvaluateDevelopMainten2_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_2.Text += "SaveDevelMaint2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_2.Update ();
            popupAddDevelMaint2_2.Show ();
            hdf_DevelMaintStatus2.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic2.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType2.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus2.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-2\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 2_2 ####################################################################################
    //######################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 2_3###################################################################################

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
                    FROM [EvaluateDevelopMainten2_3] 

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

    protected void Add2_3_Click (object sender, EventArgs e) {
        UpdatePanel2_3.Update ();
        popupAddDevelMaint2_3.Show ();
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
                    FROM [EvaluateDevelopMainten2_3] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint3").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint3").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint3").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint3").Visible = false;

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
    protected void btnAddDevelMaint_Click3 (object sender, EventArgs e) {
        UpdatePanel2_3.Update ();
        if (this.SaveDevelMaint3 (hdf_DevelMaintStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddDevelMaint2_3.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click3 (object sender, EventArgs e) {
        UpdatePanel2_3.Update ();
        popupAddDevelMaint2_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add2_3.Visible = true;
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
                    FROM [EvaluateDevelopMainten2_3] 
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

    protected bool SaveDevelMaint3 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-3\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-3\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_3.FileName);
        string NewFileName = "DevelMaint2_3_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_3.FileName;
        // string NewFileName = FileUpload2_3.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_3.HasFile) {
            FileUpload2_3.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_3)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_3  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_3)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_3 = 0;
            string Type2_3 = txtProjectType3.SelectedValue.ToString ();

            string SType;
            if (Type2_3 == "สิทธิบัตร (ตปท.)                                                                                    ") {
                totalScore2_3 = 100;
            } else if (Type2_3 == "อนุสิทธิบัตร                                                                                        ") {
                totalScore2_3 = 70;
            } else {
                totalScore2_3 = 90;
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
            cmd.Parameters.AddWithValue ("@Score2_3", totalScore2_3);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_3", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_3.Text += "SaveDevelMaint3 = " + ex.Message + "<br />";
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
                                                        
                    FROM [EvaluateDevelopMainten2_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_3.Text += "SaveDevelMaint3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_3.Update ();
            popupAddDevelMaint2_3.Show ();
            hdf_DevelMaintStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic3.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType3.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus3.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-3\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 2_3 ##############################################################
    //################################################################################################################################
    //################################################################################################################################
    //##########################################################Strat 2_4#############################################################

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
                    FROM [EvaluateDevelopMainten2_4] 

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

    protected void Add2_4_Click (object sender, EventArgs e) {
        UpdatePanel2_4.Update ();
        popupAddDevelMaint2_4.Show ();
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
                    FROM [EvaluateDevelopMainten2_4] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint4").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint4").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint4").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint4").Visible = false;

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
    protected void btnAddDevelMaint_Click4 (object sender, EventArgs e) {
        UpdatePanel2_4.Update ();
        if (this.SaveDevelMaint4 (hdf_DevelMaintStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddDevelMaint2_4.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click4 (object sender, EventArgs e) {
        UpdatePanel2_4.Update ();
        popupAddDevelMaint2_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add2_4.Visible = true;
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
                    FROM [EvaluateDevelopMainten2_4] 
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

    protected bool SaveDevelMaint4 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-4\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-4\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_4.FileName);
        string NewFileName = "DevelMaint2_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_4.FileName;
        // string NewFileName = FileUpload2_4.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_4.HasFile) {
            FileUpload2_4.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectLevel, projectAgency) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_4, @ProjectLevel, @ProjectAgency)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_4  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectLevel, projectAgency) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_4, @ProjectLevel, @ProjectAgency)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_4 = 0;
            string Type2_4 = txtProjectType4.SelectedValue.ToString ();
            string Level2_4 = txtProjectLevel4.SelectedValue.ToString ();

            if (Level2_4 == "ไทย                                                                                                 ") {
                if (Type2_4 == "Oral Presentation                                                                                   ") {
                    totalScore2_4 = 15;
                } else {
                    totalScore2_4 = 10;
                }
            } else {
                if (Type2_4 == "Oral Presentation                                                                                   ") {
                    totalScore2_4 = 25;
                } else {
                    totalScore2_4 = 15;
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
            cmd.Parameters.AddWithValue ("@Score2_4", totalScore2_4);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_4", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_4.Text += "SaveDevelMaint4 = " + ex.Message + "<br />";
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
                                                        
                    FROM [EvaluateDevelopMainten2_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_4.Text += "SaveDevelMaint4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_4.Update ();
            popupAddDevelMaint2_4.Show ();
            hdf_DevelMaintStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic4.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType4.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectLevel4.SelectedValue = ds.Rows[0]["projectLevel"].ToString ();
            txtProjectAgency4.Text = ds.Rows[0]["projectAgency"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus4.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-4\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_4 ################################################################
    //##################################################################################################################################
    //##################################################################################################################################
    //##########################################################Strat 2_5###############################################################
    protected void SearchData5 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectClass]
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
                    FROM [EvaluateDevelopMainten2_5] 

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

    protected void Add2_5_Click (object sender, EventArgs e) {
        UpdatePanel2_5.Update ();
        popupAddDevelMaint2_5.Show ();
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
                    FROM [EvaluateDevelopMainten2_5] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint5").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint5").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint5").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint5").Visible = false;

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
        txtProjectClass5.Text = "";

    }
    protected void btnAddDevelMaint_Click5 (object sender, EventArgs e) {
        UpdatePanel2_5.Update ();
        if (this.SaveDevelMaint5 (hdf_DevelMaintStatus5.Value) == true) {
            this.SearchData5 ();
            popupAddDevelMaint2_5.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click5 (object sender, EventArgs e) {
        UpdatePanel2_5.Update ();
        popupAddDevelMaint2_5.Hide ();
    }

    protected void btnSubmit_Click5 (object sender, EventArgs e) {
        Add2_5.Visible = true;
        this.SearchData5 ();
    }

    protected void btnReset_Click5 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click5 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateDevelopMainten2_5] 
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

    protected bool SaveDevelMaint5 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-5\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-5\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_5.FileName);
        string NewFileName = "DevelMaint2_5_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_5.FileName;
        // string NewFileName = FileUpload2_5.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_5.HasFile) {
            FileUpload2_5.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_5
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectClass) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_5, @ProjectClass)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_5  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_5
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectClass) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_5, @ProjectClass)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_5 = 0;
            string Type2_5 = txtProjectType5.SelectedValue.ToString ();
            string Class2_5 = txtProjectClass5.SelectedValue.ToString ();

            if (Type2_5 == "Main auther                                                                                         ") {
                if (Class2_5 == "Class A                                                                                             ") {
                    totalScore2_5 = 25;
                } else if (Class2_5 == "Class B                                                                                             ") {
                    totalScore2_5 = 20;
                } else if (Class2_5 == "Class C                                                                                             ") {
                    totalScore2_5 = 15;
                } else if (Class2_5 == "Class D                                                                                             ") {
                    totalScore2_5 = 10;
                } else {
                    totalScore2_5 = 5;
                }
            } else {
                if (Class2_5 == "Class A                                                                                             ") {
                    totalScore2_5 = 25;
                } else if (Class2_5 == "Class B                                                                                             ") {
                    totalScore2_5 = 20;
                } else if (Class2_5 == "Class C                                                                                             ") {
                    totalScore2_5 = 15;
                } else if (Class2_5 == "Class D                                                                                             ") {
                    totalScore2_5 = 10;
                } else if (Class2_5 == "Class E                                                                                             ") {
                    totalScore2_5 = 5;
                } else {
                    totalScore2_5 = 0;
                }
            }
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType5.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic5.Text.Trim ());
            // cmd.Parameters.AddWithValue ("@ProjectClass", txtProjectClass5.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectClass", "รอพิจารณา");
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_5", totalScore2_5);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_5", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_5.Text += "SaveDevelMaint5 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea5 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectType]
                    ,[projectClass]
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
                                                        
                    FROM [EvaluateDevelopMainten2_5] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_5.Text += "SaveDevelMaint5 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click5 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_5.Update ();
            popupAddDevelMaint2_5.Show ();
            hdf_DevelMaintStatus5.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic5.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType5.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectClass5.SelectedValue = ds.Rows[0]["projectClass"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click5 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus5.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_5  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus5.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-5\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_5 ##################################################################
    //####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 2_6_1################################################################

    protected void SearchData6_1 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectName]
                    ,[projectPlan]
                    ,[projectInProgress]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDaye]
                    FROM [EvaluateDevelopMainten2_6_1] 

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
        gvData6_1.DataSource = blacklistDT.DefaultView;
        gvData6_1.DataBind ();
        lblRecord6_1.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add2_6_1_Click (object sender, EventArgs e) {
        UpdatePanel2_6_1.Update ();
        popupAddDevelMaint2_6_1.Show ();
        this.ClearPopUp6_1 ();
    }

    protected void gvData_Sorting6_1 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging6_1 (object sender, GridViewPageEventArgs e) {
        gvData6_1.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData6_1.PageIndex = e.NewPageIndex;
        gvData6_1.DataBind ();
        this.btnSubmit_Click6_1 (sender, e);
    }
    protected void gvData_SelectedIndexChanged6_1 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound6_1 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus6_1")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateDevelopMainten2_6_1] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint6_1").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint6_1").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint6_1").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint6_1").Visible = false;

            }

        }
        con.Close ();

    }

    public SortDirection GridviewSortDirection6_1 {
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

    protected void ClearPopUp6_1 () {
        txtProjectTopic6_1.SelectedValue = "";
        txtProjectName6_1.Text = "";
        txtProjectPlan6_1.Text = "";
        txtProjectInProgress6_1.Text = "";

    }
    protected void btnAddDevelMaint_Click6_1 (object sender, EventArgs e) {
        UpdatePanel2_6_1.Update ();
        if (this.SaveDevelMaint6_1 (hdf_DevelMaintStatus6_1.Value) == true) {
            this.SearchData6_1 ();
            popupAddDevelMaint2_6_1.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click6_1 (object sender, EventArgs e) {
        UpdatePanel2_6_1.Update ();
        popupAddDevelMaint2_6_1.Hide ();
    }

    protected void btnSubmit_Click6_1 (object sender, EventArgs e) {
        Add2_6_1.Visible = true;
        this.SearchData6_1 ();
    }

    protected void btnReset_Click6_1 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click6_1 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateDevelopMainten2_6_1] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_1.DataKeys[row.RowIndex]["id"].ToString ();
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

    protected bool SaveDevelMaint6_1 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_1\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_6_1.FileName);
        string NewFileName = "DevelMaint2_6_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_6_1.FileName;
        // string NewFileName = FileUpload2_6_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_6_1.HasFile) {
            FileUpload2_6_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_6_1
                    (masterId,  projectTopic,  projectName, projectPlan, projectInProgress, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectName, @ProjectPlan, @ProjectInProgress, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_6_1)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_6_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_6_1
                    (masterId,  projectTopic,  projectName, projectPlan, projectInProgress, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectName, @ProjectPlan, @ProjectInProgress, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_6_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_6_1 = 0;
            string Topic2_6_1 = txtProjectTopic6_1.SelectedValue.ToString ();
            decimal plan6_1 = decimal.Parse (txtProjectPlan6_1.Text);
            decimal InProgress6_1 = decimal.Parse (txtProjectInProgress6_1.Text);
            if (Topic2_6_1 == "ออกแบบระบบลำเลียงแสง                                                                                ") {
                totalScore2_6_1 = (InProgress6_1 * 100) / plan6_1;
            } else {
                totalScore2_6_1 = (InProgress6_1 * 70) / plan6_1;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectPlan", txtProjectPlan6_1.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic6_1.SelectedValue.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectInProgress", txtProjectInProgress6_1.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName6_1.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_6_1", totalScore2_6_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_6_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_6_1.Text += "SaveDevelMaint6_1 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea6_1 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectName]
                    ,[projectPlan]
                    ,[projectInProgress]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDaye]
                                                        
                    FROM [EvaluateDevelopMainten2_6_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_6_1.Text += "SaveDevelMaint6_1 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click6_1 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_1.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6_1 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_6_1.Update ();
            popupAddDevelMaint2_6_1.Show ();
            hdf_DevelMaintStatus6_1.Value = ds.Rows[0]["id"].ToString ();

            txtProjectTopic6_1.SelectedValue = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectName6_1.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectPlan6_1.Text = ds.Rows[0]["projectPlan"].ToString ();
            txtProjectInProgress6_1.Text = ds.Rows[0]["projectInProgress"].ToString ();
        }

    }

    protected void btnDeleteDevelMaint_Click6_1 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_1.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6_1 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus6_1.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_6_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus6_1.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData6_1 ();
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_1\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_6_1 ################################################################
    //####################################################################################################################################
    //####################################################################################################################################
    //##########################################################Strat 2_6_2###############################################################

    protected void SearchData6_2 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectName]
                    ,[projectClass]
                    ,[projectPlan]
                    ,[projectInProgress]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDaye]
                    FROM [EvaluateDevelopMainten2_6_2] 

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
        gvData6_2.DataSource = blacklistDT.DefaultView;
        gvData6_2.DataBind ();
        lblRecord6_2.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add2_6_2_Click (object sender, EventArgs e) {
        UpdatePanel2_6_2.Update ();
        popupAddDevelMaint2_6_2.Show ();
        this.ClearPopUp6_2 ();
    }

    protected void gvData_Sorting6_2 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging6_2 (object sender, GridViewPageEventArgs e) {
        gvData6_2.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData6_2.PageIndex = e.NewPageIndex;
        gvData6_2.DataBind ();
        this.btnSubmit_Click6_2 (sender, e);
    }
    protected void gvData_SelectedIndexChanged6_2 (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound6_2 (object sender, GridViewRowEventArgs e) {

        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus6_2")).Value);
            string sql = @"SELECT M.evaluateStatus
                    FROM [EvaluateDevelopMainten2_6_2] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint6_2").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint6_2").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint6_2").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint6_2").Visible = false;

            }

        }
        con.Close ();
    }

    public SortDirection GridviewSortDirection6_2 {
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

    protected void ClearPopUp6_2 () {
        txtProjectTopic6_2.SelectedValue = "";
        txtProjectName6_2.Text = "";
        txtProjectPlan6_2.Text = "";
        txtProjectInProgress6_2.Text = "";
        txtProjectClass6_2.SelectedValue = "";

    }
    protected void btnAddDevelMaint_Click6_2 (object sender, EventArgs e) {
        UpdatePanel2_6_2.Update ();
        if (this.SaveDevelMaint6_2 (hdf_DevelMaintStatus6_2.Value) == true) {
            this.SearchData6_2 ();
            popupAddDevelMaint2_6_2.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click6_2 (object sender, EventArgs e) {
        UpdatePanel2_6_2.Update ();
        popupAddDevelMaint2_6_2.Hide ();
    }

    protected void btnSubmit_Click6_2 (object sender, EventArgs e) {
        Add2_6_2.Visible = true;
        this.SearchData6_2 ();
    }

    protected void btnReset_Click6_2 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click6_2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateDevelopMainten2_6_2] 
                    WHERE  id =  @Id ";

        com = new SqlCommand (sql, con);

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_2.DataKeys[row.RowIndex]["id"].ToString ();
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

    protected bool SaveDevelMaint6_2 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_2\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_6_2.FileName);
        string NewFileName = "DevelMaint2_6_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_6_2.FileName;
        // string NewFileName = FileUpload2_6_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_6_2.HasFile) {
            FileUpload2_6_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_6_2
                    (masterId,  projectTopic,  projectName, projectPlan, projectInProgress, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectClass) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectName, @ProjectPlan, @ProjectInProgress, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_6_2, @Class)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_6_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_6_2
                    (masterId,  projectTopic,  projectName, projectPlan, projectInProgress, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectClass) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectName, @ProjectPlan, @ProjectInProgress, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_6_2, @Class)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_6_2 = 0;
            string Topic2_6_2 = txtProjectTopic6_2.SelectedValue.ToString ();
            decimal plan6_2 = decimal.Parse (txtProjectPlan6_2.Text);
            decimal InProgress6_2 = decimal.Parse (txtProjectInProgress6_2.Text);
            string class6_2 = txtProjectClass6_2.SelectedValue;

            if (Topic2_6_2 == "ออกแบบเครื่องมือตรวจวัดและอุปกรณ์ต่างๆ                                                              ") {
                if (class6_2 == "Class A                                                                                             ") {
                    totalScore2_6_2 = (InProgress6_2 * 30) / plan6_2;
                } else if (class6_2 == "Class B                                                                                             ") {
                    totalScore2_6_2 = (InProgress6_2 * 20) / plan6_2;
                } else {
                    totalScore2_6_2 = (InProgress6_2 * 10) / plan6_2;
                }
            } else {
                if (class6_2 == "Class A                                                                                             ") {
                    totalScore2_6_2 = (InProgress6_2 * 50) / plan6_2;
                } else if (class6_2 == "Class B                                                                                             ") {
                    totalScore2_6_2 = (InProgress6_2 * 40) / plan6_2;
                } else {
                    totalScore2_6_2 = (InProgress6_2 * 30) / plan6_2;
                }
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectPlan", txtProjectPlan6_2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic6_2.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectInProgress", txtProjectInProgress6_2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName6_2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_6_2", totalScore2_6_2);
            cmd.Parameters.AddWithValue ("@Class", txtProjectClass6_2.SelectedValue);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_6_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_6_2.Text += "SaveDevelMaint6_2 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea6_2 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectName]
                    ,[projectClass]
                    ,[projectPlan]
                    ,[projectInProgress]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDaye]
                                                        
                    FROM [EvaluateDevelopMainten2_6_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_6_2.Text += "SaveDevelMaint6_2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click6_2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6_2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_6_2.Update ();
            popupAddDevelMaint2_6_2.Show ();
            hdf_DevelMaintStatus6_2.Value = ds.Rows[0]["id"].ToString ();

            txtProjectTopic6_2.SelectedValue = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectName6_2.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectPlan6_2.Text = ds.Rows[0]["projectPlan"].ToString ();
            txtProjectInProgress6_2.Text = ds.Rows[0]["projectInProgress"].ToString ();
            txtProjectClass6_2.SelectedValue = ds.Rows[0]["projectClass"].ToString ();
        }

    }

    protected void btnDeleteDevelMaint_Click6_2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6_2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6_2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus6_2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_6_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus6_2.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData6_2 ();
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-6_2\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_6_2 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 2_7##################################################################

    protected void SearchData7 () {
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
                    FROM [EvaluateDevelopMainten2_7] 

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

    protected void Add2_7_Click (object sender, EventArgs e) {
        UpdatePanel2_7.Update ();
        popupAddDevelMaint2_7.Show ();
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
                    FROM [EvaluateDevelopMainten2_7] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint7").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint7").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint7").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint7").Visible = false;

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

        txtProjectStudentName7.Text = "";
        txtProjectThesisTopic7.Text = "";
        txtProjectInstitute7.Text = "";

    }
    protected void btnAddDevelMaint_Click7 (object sender, EventArgs e) {
        UpdatePanel2_7.Update ();
        if (this.SaveDevelMaint7 (hdf_DevelMaintStatus7.Value) == true) {
            this.SearchData7 ();
            popupAddDevelMaint2_7.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click7 (object sender, EventArgs e) {
        UpdatePanel2_7.Update ();
        popupAddDevelMaint2_7.Hide ();
    }

    protected void btnSubmit_Click7 (object sender, EventArgs e) {
        Add2_7.Visible = true;
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
                    ,path + fileName AS Pathfile
                    FROM [EvaluateDevelopMainten2_7] 
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

    protected bool SaveDevelMaint7 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-7\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-7\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_7.FileName);
        string NewFileName = "DevelMaint2_7_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_7.FileName;
        // string NewFileName = FileUpload2_7.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_7.HasFile) {
            FileUpload2_7.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_7
                    (masterId,  projectStudentName,  projectThesisTopic, projectInstitute, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectStudentName, @ProjectThesisTopic, @ProjectInstitute, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_7)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_7  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_7
                    (masterId,  projectStudentName,  projectThesisTopic, projectInstitute, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectStudentName, @ProjectThesisTopic, @ProjectInstitute, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_7)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore2_7 = 50;
            // string Topic2_7 = txtProjectTopic7.SelectedValue.ToString ();
            // decimal plan7 = decimal.Parse (txtProjectPlan7.Text);
            // decimal InProgress7 = decimal.Parse (txtProjectInProgress7.Text);
            // string class7 = txtProjectClass7.SelectedValue;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            // cmd.Parameters.AddWithValue ("@ProjectPlan", txtProjectPlan7.Text);
            cmd.Parameters.AddWithValue ("@ProjectInstitute", txtProjectInstitute7.Text);
            cmd.Parameters.AddWithValue ("@ProjectThesisTopic", txtProjectThesisTopic7.Text);
            cmd.Parameters.AddWithValue ("@ProjectStudentName", txtProjectStudentName7.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_7", totalScore2_7);
            //cmd.Parameters.AddWithValue ("@Class", txtProjectClass7.SelectedValue);

            // cmd.Parameters.AddWithValue ("@FileNameOld2_7", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_7.Text += "SaveDevelMaint7 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea7 (string ID) {
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
                                                        
                    FROM [EvaluateDevelopMainten2_7] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_7.Text += "SaveDevelMaint7 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click7 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData7.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea7 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_7.Update ();
            popupAddDevelMaint2_7.Show ();
            hdf_DevelMaintStatus7.Value = ds.Rows[0]["id"].ToString ();
            txtProjectStudentName7.Text = ds.Rows[0]["projectStudentName"].ToString ();
            txtProjectThesisTopic7.Text = ds.Rows[0]["projectThesisTopic"].ToString ();
            txtProjectInstitute7.Text = ds.Rows[0]["projectInstitute"].ToString ();
        }

    }

    protected void btnDeleteDevelMaint_Click7 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData7.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea7 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus7.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_7  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus7.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-7\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_7 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 2_8 ##################################################################

    protected void SearchData8 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[dateNumber]
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
                    FROM [EvaluateDevelopMainten2_8] 

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
        lblRecord8.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add2_8_Click (object sender, EventArgs e) {
        UpdatePanel2_8.Update ();
        popupAddDevelMaint2_8.Show ();
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
                    FROM [EvaluateDevelopMainten2_8] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint8").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint8").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint8").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint8").Visible = false;

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

        txtProjectName8.Text = "";
        txtDateNumber8.Text = "";
        //txtProjectInstitute8.Text = "";

    }
    protected void btnAddDevelMaint_Click8 (object sender, EventArgs e) {
        UpdatePanel2_8.Update ();
        if (this.SaveDevelMaint8 (hdf_DevelMaintStatus8.Value) == true) {
            this.SearchData8 ();
            popupAddDevelMaint2_8.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click8 (object sender, EventArgs e) {
        UpdatePanel2_8.Update ();
        popupAddDevelMaint2_8.Hide ();
    }

    protected void btnSubmit_Click8 (object sender, EventArgs e) {
        Add2_8.Visible = true;
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
                    FROM [EvaluateDevelopMainten2_8] 
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

    protected bool SaveDevelMaint8 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-8\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-8\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_8.FileName);
        string NewFileName = "DevelMaint2_8_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_8.FileName;
        // string NewFileName = FileUpload2_8.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_8.HasFile) {
            FileUpload2_8.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_8
                    (masterId,  projectName,  dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_8)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_8  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_8
                    (masterId,  projectName,  dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_8)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            decimal DateNumber8 = decimal.Parse (txtDateNumber8.Text);
            decimal totalScore2_8 = DateNumber8 * 2;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@DateNumber", txtDateNumber8.Text);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName8.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_8", totalScore2_8);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_8.Text += "SaveDevelMaint8 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea8 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[dateNumber]
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
                                                        
                    FROM [EvaluateDevelopMainten2_8] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_8.Text += "SaveDevelMaint8 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click8 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData8.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea8 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_8.Update ();
            popupAddDevelMaint2_8.Show ();
            hdf_DevelMaintStatus8.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName8.Text = ds.Rows[0]["projectName"].ToString ();
            txtDateNumber8.Text = ds.Rows[0]["dateNumber"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click8 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData8.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea8 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus8.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_8  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus8.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-8\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_8 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 2_9 ##################################################################

    protected void SearchData9 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[dateNumber]
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
                    FROM [EvaluateDevelopMainten2_9] 

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

    protected void Add2_9_Click (object sender, EventArgs e) {
        UpdatePanel2_9.Update ();
        popupAddDevelMaint2_9.Show ();
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
                    FROM [EvaluateDevelopMainten2_9] AS E
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
                e.Row.FindControl ("btnDeletDevelMaint9").Visible = true;
                e.Row.FindControl ("btnEditDevelMaint9").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletDevelMaint9").Visible = false;
                e.Row.FindControl ("btnEditDevelMaint9").Visible = false;

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

        txtProjectName9.Text = "";
        txtDateNumber9.Text = "";
        //txtProjectInstitute9.Text = "";

    }
    protected void btnAddDevelMaint_Click9 (object sender, EventArgs e) {
        UpdatePanel2_9.Update ();
        if (this.SaveDevelMaint9 (hdf_DevelMaintStatus9.Value) == true) {
            this.SearchData9 ();
            popupAddDevelMaint2_9.Hide ();
        }

    }
    protected void btnCancelDevelMaint_Click9 (object sender, EventArgs e) {
        UpdatePanel2_9.Update ();
        popupAddDevelMaint2_9.Hide ();
    }

    protected void btnSubmit_Click9 (object sender, EventArgs e) {
        Add2_9.Visible = true;
        this.SearchData9 ();
    }

    protected void btnReset_Click9 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click9 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateDevelopMainten2_9] 
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

    protected bool SaveDevelMaint9 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-9\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-9\\";
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
        string OldFileName = Path.GetFileName (FileUpload2_9.FileName);
        string NewFileName = "DevelMaint2_9_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload2_9.FileName;
        // string NewFileName = FileUpload2_9.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload2_9.HasFile) {
            FileUpload2_9.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateDevelopMainten2_9
                    (masterId,  projectName,  dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_9)";
        } else {

            sql = @"UPDATE EvaluateDevelopMainten2_9  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateDevelopMainten2_9
                    (masterId,  projectName,  dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score2_9)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            decimal DateNumber9 = decimal.Parse (txtDateNumber9.Text);
            decimal totalScore2_9 = DateNumber9 * 2;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@DateNumber", txtDateNumber9.Text);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName9.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score2_9", totalScore2_9);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError2_9.Text += "SaveDevelMaint9 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea9 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[dateNumber]
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
                                                        
                    FROM [EvaluateDevelopMainten2_9] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError2_9.Text += "SaveDevelMaint9 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditDevelMaint_Click9 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea9 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel2_9.Update ();
            popupAddDevelMaint2_9.Show ();
            hdf_DevelMaintStatus9.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName9.Text = ds.Rows[0]["projectName"].ToString ();
            txtDateNumber9.Text = ds.Rows[0]["dateNumber"].ToString ();

        }

    }

    protected void btnDeleteDevelMaint_Click9 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData9.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea9 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_DevelMaintStatus9.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateDevelopMainten2_9  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_DevelMaintStatus9.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab2-9\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 2_9 #################################################################
    //#####################################################################################################################################
    //#####################################################################################################################################
}