using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//4
public partial class Evaluate_Promotion_work : System.Web.UI.Page {
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
        this.SearchData5 ();
        this.SearchData6 ();

    }

    protected void report1_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_ServiceWork.aspx?nID=" + rId);

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Research.aspx?nID=" + rId);

    }
    protected void report4_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Promotion_work.aspx?nID=" + rId);

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Develop_Mainten.aspx?nID=" + rId);

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
                    ,[projectName]
                    ,[projectType]
                    ,[dataNumber]
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
                    FROM [EvaluatePromotionWork4_1] 

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
            Add4_1.Visible = true;
            Add4_2.Visible = true;
            Add4_3.Visible = true;
            Add4_4.Visible = true;
            Add4_5.Visible = true;
            Add4_6.Visible = true;
        } else {
            Add4_1.Visible = false;
            Add4_2.Visible = false;
            Add4_3.Visible = false;
            Add4_4.Visible = false;
            Add4_5.Visible = false;
            Add4_6.Visible = false;
        }

        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData.DataSource = blacklistDT.DefaultView;
        gvData.DataBind ();
        lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add4_1_Click (object sender, EventArgs e) {
        UpdatePanel4_1.Update ();
        popupAddPromot4_1.Show ();
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
                    FROM [EvaluatePromotionWork4_1] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot").Visible = true;
                e.Row.FindControl ("btnEditPromot").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot").Visible = false;
                e.Row.FindControl ("btnEditPromot").Visible = false;

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
        txtProjectName.Text = "";
        txtProjectType.Text = "";
        txtdateNumber.Text = "";

    }
    protected void btnAddPromot_Click (object sender, EventArgs e) {
        UpdatePanel4_1.Update ();
        if (this.SavePromot (hdf_PromotStatus.Value) == true) {
            this.SearchData ();
            popupAddPromot4_1.Hide ();
        }

    }
    protected void btnCancelPromot_Click (object sender, EventArgs e) {
        UpdatePanel4_1.Update ();
        popupAddPromot4_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add4_1.Visible = true;
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
                    FROM [EvaluatePromotionWork4_1] 
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

    protected bool SavePromot (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-1\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_1.FileName);
        string NewFileName = "Promot4_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_1.FileName;
        // string NewFileName = FileUpload4_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_1.HasFile) {
            FileUpload4_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_1
                    (masterId,  projectName,  projectType, dataNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectType, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_1)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluatePromotionWork4_1
                    (masterId,  projectName,  projectType, dataNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectType, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore4_1 = 2;
            string Type4_1 = txtProjectType.SelectedValue.ToString ();
            decimal DateNumber = decimal.Parse (txtdateNumber.Text);
            if (Type4_1 == "Class A") {
                totalScore4_1 = 52 + (DateNumber * 2);
            } else if (Type4_1 == "Class B") {
                totalScore4_1 = 42 + (DateNumber * 2);
            } else if (Type4_1 == "Class C") {
                totalScore4_1 = 32 + (DateNumber * 2);
            } else if (Type4_1 == "Class D") {
                totalScore4_1 = 22 + (DateNumber * 2);
            } else {
                totalScore4_1 = 12 + (DateNumber * 2);
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName.Text.Trim ());
            cmd.Parameters.AddWithValue ("@DateNumber", txtdateNumber.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score4_1", totalScore4_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_1.Text += "SavePromot = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[projectType]
                        ,[dataNumber]
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
                                        
                    FROM [EvaluatePromotionWork4_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_1.Text += "SavePromot = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_1.Update ();
            popupAddPromot4_1.Show ();
            hdf_PromotStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectType.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtdateNumber.Text = ds.Rows[0]["dataNumber"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeletePromot_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 4_1 ###################################################################################
    //####################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 4_2######################################################################################

    protected void SearchData2 () {
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
                    FROM [EvaluatePromotionWork4_2] 

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

    protected void Add4_2_Click (object sender, EventArgs e) {
        UpdatePanel4_2.Update ();
        popupAddPromot4_2.Show ();
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
                    FROM [EvaluatePromotionWork4_2] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot2").Visible = true;
                e.Row.FindControl ("btnEditPromot2").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot2").Visible = false;
                e.Row.FindControl ("btnEditPromot2").Visible = false;

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
        txtProjectClass2.Text = "";
    }
    protected void btnAddPromot_Click2 (object sender, EventArgs e) {
        UpdatePanel4_2.Update ();
        if (this.SavePromot2 (hdf_PromotStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddPromot4_2.Hide ();
        }

    }
    protected void btnCancelPromot_Click2 (object sender, EventArgs e) {
        UpdatePanel4_2.Update ();
        popupAddPromot4_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add4_2.Visible = true;
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
                    FROM [EvaluatePromotionWork4_2] 
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

    protected bool SavePromot2 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-2\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_2.FileName);
        string NewFileName = "Promot4_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_2.FileName;
        // string NewFileName = FileUpload4_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_2.HasFile) {
            FileUpload4_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_2
                    (masterId,  projectTopic,  projectType, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_2)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluatePromotionWork4_2
                    (masterId,  projectTopic,  projectType, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_2)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore4_2 = 0;
            string Class = txtProjectClass2.SelectedValue;
            if (Class == "Class A") {
                totalScore4_2 = 15;
            } else if (Class == "Class B") {
                totalScore4_2 = 10;
            } else {
                totalScore4_2 = 5;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType2.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectClass", txtProjectClass2.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score4_2", totalScore4_2);

            // cmd.Parameters.AddWithValue ("@FileNameOld4_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_2.Text += "SavePromot2 = " + ex.Message + "<br />";
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
                                                        
                    FROM [EvaluatePromotionWork4_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_2.Text += "SavePromot2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_2.Update ();
            popupAddPromot4_2.Show ();
            hdf_PromotStatus2.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic2.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType2.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectClass2.SelectedValue = ds.Rows[0]["projectClass"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeletePromot_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus2.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-2\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 4_2 ####################################################################################
    //######################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 4_3###################################################################################

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
                    FROM [EvaluatePromotionWork4_3] 

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

    protected void Add4_3_Click (object sender, EventArgs e) {
        UpdatePanel4_3.Update ();
        popupAddPromot4_3.Show ();
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
                    FROM [EvaluatePromotionWork4_3] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot3").Visible = true;
                e.Row.FindControl ("btnEditPromot3").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot3").Visible = false;
                e.Row.FindControl ("btnEditPromot3").Visible = false;

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
    protected void btnAddPromot_Click3 (object sender, EventArgs e) {
        UpdatePanel4_3.Update ();
        if (this.SavePromot3 (hdf_PromotStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddPromot4_3.Hide ();
        }

    }
    protected void btnCancelPromot_Click3 (object sender, EventArgs e) {
        UpdatePanel4_3.Update ();
        popupAddPromot4_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add4_3.Visible = true;
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
                    FROM [EvaluatePromotionWork4_3] 
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

    protected bool SavePromot3 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-3\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-3\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_3.FileName);
        string NewFileName = "Promot4_3_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_3.FileName;
        // string NewFileName = FileUpload4_3.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_3.HasFile) {
            FileUpload4_3.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_3)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_3  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluatePromotionWork4_3
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_3)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore4_3 = 0;
            string Type4_3 = txtProjectType3.SelectedValue.ToString ();

            string SType;
            if (Type4_3 == "หน่วยงานต่างประเทศ") {
                totalScore4_3 = 80;
            } else if (Type4_3 == "หน่วยงานในประเทศ") {
                totalScore4_3 = 25;
            } else {
                totalScore4_3 = 10;
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
            cmd.Parameters.AddWithValue ("@Score4_3", totalScore4_3);

            // cmd.Parameters.AddWithValue ("@FileNameOld4_3", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_3.Text += "SavePromot3 = " + ex.Message + "<br />";
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
                                                        
                    FROM [EvaluatePromotionWork4_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_3.Text += "SavePromot3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_3.Update ();
            popupAddPromot4_3.Show ();
            hdf_PromotStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic3.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType3.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeletePromot_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus3.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-3\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 4_3 ##############################################################
    //################################################################################################################################
    //################################################################################################################################
    //##########################################################Strat 4_4#############################################################

    protected void SearchData4 () {
        string sql = @"SELECT [id]
                   ,[masterId]
                    ,[projectTopic]
                    ,[projectPresent]
                    ,[projectType]
                    ,[mediaNumber]
                    ,[projectNameJoint]
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
                    FROM [EvaluatePromotionWork4_4] 

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

    protected void Add4_4_Click (object sender, EventArgs e) {
        UpdatePanel4_4.Update ();
        popupAddPromot4_4.Show ();
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
                    FROM [EvaluatePromotionWork4_4] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot4").Visible = true;
                e.Row.FindControl ("btnEditPromot4").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot4").Visible = false;
                e.Row.FindControl ("btnEditPromot4").Visible = false;

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
        txtProjectType4.SelectedValue = "";
        txtProjectPresent4.SelectedValue = "";
        txtMediaNumber4.Text = "";
        txtProjectNameJoint4.Text = "";

    }
    protected void btnAddPromot_Click4 (object sender, EventArgs e) {
        UpdatePanel4_4.Update ();
        if (this.SavePromot4 (hdf_PromotStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddPromot4_4.Hide ();
        }

    }
    protected void btnCancelPromot_Click4 (object sender, EventArgs e) {
        UpdatePanel4_4.Update ();
        popupAddPromot4_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add4_4.Visible = true;
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
                    FROM [EvaluatePromotionWork4_4] 
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

    protected bool SavePromot4 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-4\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-4\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_4.FileName);
        string NewFileName = "Promot4_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_4.FileName;
        // string NewFileName = FileUpload4_4.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_4.HasFile) {
            FileUpload4_4.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectPresent, mediaNumber, projectNameJoint) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_4, @ProjectPresent, @MediaNumber, @ProjectNameJoint)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_4  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluatePromotionWork4_4
                    (masterId,  projectTopic,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectPresent, mediaNumber, projectNameJoint) 
                    VALUES
                    (@MasterId, @ProjectTopic, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_4, @ProjectPresent, @MediaNumber, @ProjectNameJoint)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore4_4 = 0;
            string Type4_4 = txtProjectType4.SelectedValue.ToString ();
            string present = txtProjectPresent4.SelectedValue.ToString ();

            if (present == "TV") {
                if (Type4_4 == "สกู๊ป") {
                    totalScore4_4 = 30;
                } else if (Type4_4 == "ข่าว") {
                    totalScore4_4 = 25;
                } else {
                    totalScore4_4 = 0;
                }
            } else if (present == "สื่อสิ่งพิมพ์") {
                if (Type4_4 == "หนังสื่อพิมพ์ออนไลน์/Web site") {
                    totalScore4_4 = 0;
                } else {
                    totalScore4_4 = 25;
                }
            } else if (present == "วิทยุ") {
                if (Type4_4 == "สกู๊ป") {
                    totalScore4_4 = 25;
                } else if (Type4_4 == "ข่าว") {
                    totalScore4_4 = 25;
                } else {
                    totalScore4_4 = 0;
                }
            } else if (present == "VDO Presentation") {
                if (Type4_4 == "สกู๊ป" || Type4_4 == "ข่าว" || Type4_4 == "หนังสื่อพิมพ์") {
                    totalScore4_4 = 25;
                } else {
                    totalScore4_4 = 0;
                }
            } else if (present == "Youtube") {
                if (Type4_4 == "สกู๊ป") {
                    totalScore4_4 = 25;
                } else if (Type4_4 == "ข่าว") {
                    totalScore4_4 = 25;
                } else {
                    totalScore4_4 = 0;
                }
            } else if (present == "หนังสือพิมพ์") {
                if (Type4_4 == "สกู๊ป") {
                    totalScore4_4 = 20;
                } else if (Type4_4 == "ข่าว") {
                    totalScore4_4 = 20;
                } else {
                    totalScore4_4 = 0;
                }
            } else {
                if (Type4_4 == "หนังสื่อพิมพ์ออนไลน์/Web site") {
                    totalScore4_4 = 15;
                } else {
                    totalScore4_4 = 0;
                }
            }
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType4.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectPresent", txtProjectPresent4.SelectedValue);
            cmd.Parameters.AddWithValue ("@MediaNumber", txtMediaNumber4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectNameJoint", txtProjectNameJoint4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score4_4", totalScore4_4);

            // cmd.Parameters.AddWithValue ("@FileNameOld4_4", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_4.Text += "SavePromot4 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea4 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectPresent]
                    ,[projectType]
                    ,[mediaNumber]
                    ,[projectNameJoint]
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
                                                        
                    FROM [EvaluatePromotionWork4_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_4.Text += "SavePromot4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_4.Update ();
            popupAddPromot4_4.Show ();
            hdf_PromotStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic4.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectType4.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            txtProjectPresent4.SelectedValue = ds.Rows[0]["projectPresent"].ToString ();
            txtMediaNumber4.Text = ds.Rows[0]["mediaNumber"].ToString ();
            txtProjectNameJoint4.Text = ds.Rows[0]["projectNameJoint"].ToString ();
        }

    }

    protected void btnDeletePromot_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus4.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-4\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 4_4 ################################################################
    //##################################################################################################################################
    //##################################################################################################################################
    //##########################################################Strat 4_5###############################################################
    protected void SearchData5 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
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
                    FROM [EvaluatePromotionWork4_5] 

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

    protected void Add4_5_Click (object sender, EventArgs e) {
        UpdatePanel4_5.Update ();
        popupAddPromot4_5.Show ();
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
                    FROM [EvaluatePromotionWork4_5] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot5").Visible = true;
                e.Row.FindControl ("btnEditPromot5").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot5").Visible = false;
                e.Row.FindControl ("btnEditPromot5").Visible = false;

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

    }
    protected void btnAddPromot_Click5 (object sender, EventArgs e) {
        UpdatePanel4_5.Update ();
        if (this.SavePromot5 (hdf_PromotStatus5.Value) == true) {
            this.SearchData5 ();
            popupAddPromot4_5.Hide ();
        }

    }
    protected void btnCancelPromot_Click5 (object sender, EventArgs e) {
        UpdatePanel4_5.Update ();
        popupAddPromot4_5.Hide ();
    }

    protected void btnSubmit_Click5 (object sender, EventArgs e) {
        Add4_5.Visible = true;
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
                    FROM [EvaluatePromotionWork4_5] 
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

    protected bool SavePromot5 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-5\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-5\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_5.FileName);
        string NewFileName = "Promot4_5_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_5.FileName;
        // string NewFileName = FileUpload4_5.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_5.HasFile) {
            FileUpload4_5.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_5
                    (masterId,  projectName, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_5)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_5  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluatePromotionWork4_5
                    (masterId,  projectName, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectTopic, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score4_5)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore4_5 = 15;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);

            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic5.Text.Trim ());

            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score4_5", totalScore4_5);

            // cmd.Parameters.AddWithValue ("@FileNameOld4_5", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_5.Text += "SavePromot5 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea5 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
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
                                                        
                    FROM [EvaluatePromotionWork4_5] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_5.Text += "SavePromot5 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click5 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_5.Update ();
            popupAddPromot4_5.Show ();
            hdf_PromotStatus5.Value = ds.Rows[0]["id"].ToString ();
            txtProjectTopic5.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeletePromot_Click5 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus5.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_5  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus5.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-5\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 4_5 ##################################################################
    //####################################################################################################################################
    //#####################################################################################################################################
    //##########################################################Strat 4_6################################################################

    protected void SearchData6 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectNameJoint]
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
                    FROM [EvaluatePromotionWork4_6] 

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

    protected void Add4_6_Click (object sender, EventArgs e) {
        UpdatePanel4_6.Update ();
        popupAddPromot4_6.Show ();
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
                    FROM [EvaluatePromotionWork4_6] AS E
                    INNER JOIN EvaluateMaster AS M ON M.id = E.masterId

                    WHERE   M.id =  @MasterId AND E.id = @ProjectID ";

            con.ConnectionString = con_string;
            con.Open ();
            SqlCommand cmd = new SqlCommand (sql, con);

            string rId = Request.QueryString["nId"];
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectID", ProjectStatus);

            SqlDataReader reader1_1 = cmd.ExecuteReader ();
            reader1_1.Read ();

            if (reader1_1["evaluateStatus"].ToString () == "W") {
                e.Row.FindControl ("btnDeletPromot6").Visible = true;
                e.Row.FindControl ("btnEditPromot6").Visible = true;

            } else {
                e.Row.FindControl ("btnDeletPromot6").Visible = false;
                e.Row.FindControl ("btnEditPromot6").Visible = false;

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

        txtProjectTopic6.Text = "";
        txtProjectNameJoint6.Text = "";
        txtProjectJoint6.Text = "";

    }
    protected void btnAddPromot_Click6 (object sender, EventArgs e) {
        UpdatePanel4_6.Update ();
        if (this.SavePromot6 (hdf_PromotStatus6.Value) == true) {
            this.SearchData6 ();
            popupAddPromot4_6.Hide ();
        }

    }
    protected void btnCancelPromot_Click6 (object sender, EventArgs e) {
        UpdatePanel4_6.Update ();
        popupAddPromot4_6.Hide ();
    }

    protected void btnSubmit_Click6 (object sender, EventArgs e) {
        Add4_6.Visible = true;
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
                    FROM [EvaluatePromotionWork4_6] 
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
                    FROM [EvaluatePromotionWork4_6] 
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

    protected bool SavePromot6 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_2\\";
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
        string OldFileName = Path.GetFileName (FileUpload4_6_2.FileName);
        string NewFileName = "Promot4_6_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_6_2.FileName;
        // string NewFileName = FileUpload4_6.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload4_6_2.HasFile) {
            FileUpload4_6_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        string filepath1;
        string filepathDelete1;

        string rootpath1 = Request.PhysicalApplicationPath;
        string path1 = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_1\\";
        string pathDelete1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_1\\";
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
        string OldFileName1 = Path.GetFileName (FileUpload4_6_1.FileName);
        string NewFileName1 = "Promot4_6_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload4_6_1.FileName;
        // string NewFileName = FileUpload4_6.FileName;

        string InsertFile1 = filepath1 + NewFileName1;
        //InsertFile.SaveAs
        if (FileUpload4_6_1.HasFile) {
            FileUpload4_6_1.SaveAs (InsertFile1);
        }
        //=============================================================================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluatePromotionWork4_6
                    (masterId,  path, ipAddressCreate, fileNameOld, projectNameJoint , projectJoint, projectTopic,
                    fileName, createdBy, projectScore, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld, @ProjectNameJoint, @ProjectJoint, @ProjectTopic,
                    @FileName, @CreatedBy, @Score4_6, @PathShare, @FileNameShare, @FileNameShareOld)";
        } else {

            sql = @"UPDATE EvaluatePromotionWork4_6  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id

                    INSERT INTO EvaluatePromotionWork4_6
                    (masterId,  path, ipAddressCreate, fileNameOld, projectNameJoint , projectJoint, projectTopic,
                    fileName, createdBy, projectScore, pathShare, fileNameShare, fileNameShareOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld, @ProjectNameJoint, @ProjectJoint, @ProjectTopic,
                    @FileName, @CreatedBy, @Score4_6, @PathShare, @FileNameShare, @FileNameShareOld)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            double Joint = double.Parse (txtProjectJoint6.Text);

            double totalScore4_6 = Joint * 0.1;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectTopic", txtProjectTopic6.Text);
            cmd.Parameters.AddWithValue ("@ProjectNameJoint", txtProjectNameJoint6.Text);
            cmd.Parameters.AddWithValue ("@ProjectJoint", txtProjectJoint6.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@PathShare", filepath1);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileNameShare", NewFileName1);
            cmd.Parameters.AddWithValue ("@FileNameShareOld", OldFileName1);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score4_6", totalScore4_6);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError4_6.Text += "SavePromot6 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea6 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectTopic]
                    ,[projectJoint]
                    ,[projectNameJoint]
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

                    FROM [EvaluatePromotionWork4_6] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError4_6.Text += "SavePromot6 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditPromot_Click6 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel4_6.Update ();
            popupAddPromot4_6.Show ();
            hdf_PromotStatus6.Value = ds.Rows[0]["id"].ToString ();
            txtProjectNameJoint6.Text = ds.Rows[0]["projectNameJoint"].ToString ();
            txtProjectJoint6.Text = ds.Rows[0]["projectJoint"].ToString ();
            txtProjectTopic6.Text = ds.Rows[0]["projectTopic"].ToString ();

        }

    }

    protected void btnDeletePromot_Click6 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData6.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea6 (Id);
        string fileSrc;
        string fileDelete;
        string fileSrc1;
        string fileDelete1;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_PromotStatus6.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluatePromotionWork4_6  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_PromotStatus6.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_1\\";
        string path1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab4-6_2\\";
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
    //#############################################################################################################

}