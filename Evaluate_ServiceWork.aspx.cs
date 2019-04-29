using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;

//1
public partial class Evaluate_ServiceWork : System.Web.UI.Page {
    //=============================Service1_1 =================================================
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    DataTable dtShowData2;
    SortTable ST = new SortTable ();
    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {
        // A.ActionLog("ACCOUNTS", "", "View");
        // dtShowData = new DataTable();
        // dtShowData = this.CreateTableShowData();
        // ViewState["dtShowData"] = dtShowData;
        // this.DataSource((DataTable)ViewState["dtShowData"]);

        this.SearchData ();

        this.SearchData2 ();

        this.SearchData3 ();

        this.SearchData4 ();

        this.SearchData5 ();

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
        Response.Redirect ("~/Evaluate_Services_Academic.aspx?nID=" + rId);

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
                    ,[projectCode]
                    ,[projectName]
                    ,[projectDate]
                    ,[projectShipft]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName] 
                    ,path + fileName AS Pathfile
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[createdDate]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[updateDate]
                    ,[ipAdressUpdate]
                    ,[projectDateOut]
                    ,[updateDateOut]
                    FROM [EvaluateSevice1_1] 

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

    protected void Add1_1_Click (object sender, EventArgs e) {
        UpdatePanel1_1.Update ();
        popupAddService1_1.Show ();
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
        txtProjectCode.Text = "";
        txtProjectName.Text = "";
        txtProjectDate.Text = "";
        txtProjectShift.Text = "";
        txtProjectDateOut.Text = "";
        // txtProjectFile.Text = "";

    }
    protected void btnAddService_Click (object sender, EventArgs e) {
        UpdatePanel1_1.Update ();
        if (this.SaveService (hdf_SeviceStatus.Value) == true) {
            this.SearchData ();
            popupAddService1_1.Hide ();
        }

    }
    protected void btnCancelService_Click (object sender, EventArgs e) {
        UpdatePanel1_1.Update ();
        popupAddService1_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add1_1.Visible = true;
        this.SearchData ();
    }

    protected void btnReset_Click (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    //###################################################################################
    //###################################################################################
    //###################################################################################
    //###################################################################################

    protected void btnDownload_Click (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateSevice1_1] 
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

    //###################################################################################
    //###################################################################################
    //###################################################################################
    //###################################################################################
    string upnameNew;
    string upnameOld;

    protected bool SaveService (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName  + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        ";

        com = new SqlCommand (str, con);
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string rId = Request.QueryString["nId"];
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab1-1\\";
        string pathDelete = "Delete\\" + path;
        string pathEdit = "Edit\\" + path;
        filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete) || !Directory.Exists (filepathEdit)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload1_1.FileName);
        string NewFileName = "Sevice1_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload1_1.FileName;
        // string NewFileName = FileUpload1_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload1_1.HasFile) {
            FileUpload1_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateSevice1_1
                    (masterId,  projectCode,  projectName, projectDate, projectShipft, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectDate, @ProjectShift, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_1, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";
        } else {

            sql = @"UPDATE EvaluateSevice1_1  SET
                    updateDate = @ProjectDate,
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I',
                    updateDateOut = @ProjectDateOut
                    WHERE ID = @Id
                    
                    INSERT INTO EvaluateSevice1_1
                    (masterId,  projectCode,  projectName, projectDate, projectShipft, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectDate, @ProjectShift, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_1, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore1_1 = decimal.Parse (txtProjectShift.Text) * 2;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectCode", txtProjectCode.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectDate", txtProjectDate.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectShift", txtProjectShift.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score1_1", totalScore1_1);
            cmd.Parameters.AddWithValue ("@ProjectDateOut", txtProjectDateOut.Text.Trim ());
            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError1_1.Text += "SaveService = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectCode]
                    ,[projectName]
                    ,[projectDate]
                    ,[projectShipft]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName] 
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[createdDate]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[updateDate]
                    ,[ipAdressUpdate]
                    ,[projectDateOut]
                    ,[updateDateOut]
                                        
                    FROM [EvaluateSevice1_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError1_1.Text += "SaveService = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditService_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel1_1.Update ();
            popupAddService1_1.Show ();
            hdf_SeviceStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectCode.Text = ds.Rows[0]["projectCode"].ToString ();
            txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectDate.Text = Convert.ToDateTime (ds.Rows[0]["updateDate"]).ToString ("yyyy-MM-dd");
            txtProjectShift.Text = ds.Rows[0]["projectShipft"].ToString ();
            txtProjectDateOut.Text = Convert.ToDateTime (ds.Rows[0]["updateDateOut"]).ToString ("yyyy-MM-dd");

        }

    }

    protected void btnDeleteService_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_SeviceStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateSevice1_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_SeviceStatus.Value);
            db.ExecuteDataTable (cmd1);
        }
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + "Delete\\File\\2562\\2\\เจษฎาภาชนนท์\\tab1-1\\" + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        this.SearchData ();
    }

    //###############################EvaluateSevice1_1 end#####################################################
    //###############################EvaluateSevice1_2 Strat#####################################################

    protected void SearchData2 () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectCode]
                    ,[projectName]
                    ,[projectDate]
                    ,[projectShipft]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName] 
                    ,path + fileName AS Pathfile
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[createdDate]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[updateDate]
                    ,[ipAdressUpdate]
                    ,[projectDateOut]
                    ,[updateDateOut]
                    FROM [EvaluateSevice1_2] 

                    WHERE  projectStatus = 'A' AND masterId =  @MasterId ";

        //string prefix = " AND ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);

        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();
        //da.Fill(ds, "Data");
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData2.DataSource = blacklistDT.DefaultView;
        gvData2.DataBind ();
        lblRecord2.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add1_2_Click (object sender, EventArgs e) {
        UpdatePanel1_2.Update ();
        popupAddService1_2.Show ();
        this.ClearPopUp2 ();
    }

    protected void gvData_Sorting2 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection2;
        GridviewSortDirection2 = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging2 (object sender, GridViewPageEventArgs e) {
        gvData2.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData2.PageIndex = e.NewPageIndex;
        gvData2.DataBind ();
        this.btnSubmit_Click2 (sender, e);
    }
    protected void gvData_SelectedIndexChanged2 (object sender, EventArgs e) { }

    protected void gvData_RowDataBound2 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus2 = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus2")).Value);
        }

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
        txtProjectCode2.Text = "";
        txtProjectName2.Text = "";
        txtProjectDate2.Text = "";
        txtProjectShift2.Text = "";
        txtProjectDateOut2.Text = "";
        //  txtProjectFile2.Text = "";

    }
    protected void btnAddService_Click2 (object sender, EventArgs e) {
        // string rId = "";
        // UpdatePanel1_2.Update();
        // this.SaveService2(rId);
        // this.SearchData2();
        // popupAddService1_2.Hide();

        string rId = "";
        UpdatePanel1_2.Update ();
        if (this.SaveService2 (hdf_SeviceStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddService1_2.Hide ();
        }

    }
    protected void btnCancelService_Click2 (object sender, EventArgs e) {
        UpdatePanel1_2.Update ();
        popupAddService1_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add1_2.Visible = true;
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
                    FROM [EvaluateSevice1_2] 
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

    protected bool SaveService2 (string ID) {
        SqlCommand com;
        string str;
        string filepath2;
        string filepathDelete2;
        string filepathEdit2;
        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        ";

        com = new SqlCommand (str, con);
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string rId = Request.QueryString["nId"];
        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================

        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab1-2\\";
        string pathDelete = "Delete\\" + path;
        string pathEdit = "Edit\\" + path;
        filepathEdit2 = rootpath + pathEdit;
        filepath2 = rootpath + path;
        filepathDelete2 = rootpath + pathDelete;

        var directoryInfo = new DirectoryInfo (filepath2);
        if (!Directory.Exists (filepath2) || !Directory.Exists (filepathDelete2) || !Directory.Exists (filepathEdit2)) {
            Directory.CreateDirectory (filepath2);
            Directory.CreateDirectory (filepathDelete2);
            Directory.CreateDirectory (filepathEdit2);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload1_2.FileName);
        string NewFileName = "Sevice1_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload1_2.FileName;
        string InsertFile = filepath2 + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload1_2.HasFile) {
            FileUpload1_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateSevice1_2
                    (masterId,  projectCode,  projectName, projectDate, projectShipft, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectDate, @ProjectShift, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_2, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";
        } else {

            sql = @"UPDATE EvaluateSevice1_2  SET
                    updateDate = @ProjectDate,
                    ipAdressUpdate = @Host,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I',
                    updateDateOut = @ProjectDateOut
                    WHERE ID = @Id
                    
                    INSERT INTO EvaluateSevice1_2
                    (masterId,  projectCode,  projectName, projectDate, projectShipft, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectDate, @ProjectShift, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_2, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            decimal totalScore1_2 = decimal.Parse (txtProjectShift2.Text) * 2;
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@ProjectCode", txtProjectCode2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectDate", txtProjectDate2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectShift", txtProjectShift2.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath2);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score1_2", totalScore1_2);
            cmd.Parameters.AddWithValue ("@ProjectDateOut", txtProjectDateOut2.Text.Trim ());

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError1_2.Text += "SaveService2 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 
    }
    protected DataTable SearchOneArea2 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectCode]
                        ,[projectName]
                        ,[projectDate]
                        ,[projectShipft]
                        ,[projectScore]
                        ,[projectStatus]
                        ,[path]
                        ,[fileName]
                        ,[fileNameOld]
                        ,[createdBy]
                        ,[createdDate]
                        ,[ipAddressCreate]
                        ,[updatedBy]
                        ,[updateDate]
                        ,[ipAdressUpdate]
                        ,[projectDateOut]
                        ,[updateDateOut]
                                        
                    FROM [EvaluateSevice1_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError1_2.Text += "SaveService2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditService_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel1_2.Update ();
            popupAddService1_2.Show ();
            hdf_SeviceStatus2.Value = ds.Rows[0]["id"].ToString ();
            txtProjectCode2.Text = ds.Rows[0]["projectCode"].ToString ();
            txtProjectName2.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectDate2.Text = Convert.ToDateTime (ds.Rows[0]["updateDate"]).ToString ("yyyy-MM-dd");
            txtProjectShift2.Text = ds.Rows[0]["projectShipft"].ToString ();
            txtProjectDateOut2.Text = Convert.ToDateTime (ds.Rows[0]["updateDateOut"]).ToString ("yyyy-MM-dd");
        }

    }
    string fileSrc2;
    string fileDelete2;
    protected void btnDeleteService_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);

        if (ds != null && ds.Rows.Count > 0) {
            hdf_SeviceStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateSevice1_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_SeviceStatus2.Value);
            db.ExecuteDataTable (cmd1);

        }
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc2 = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete2 = rootpath + "Delete\\File\\2562\\2\\เจษฎาภาชนนท์\\tab1-2\\" + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc2, fileDelete2);
        this.SearchData2 ();

    }

    //###############################EvaluateSevice1_2 end#####################################################
    //###############################EvaluateSevice1_3 Strat#####################################################

    protected void SearchData3 () {
        string sql = @"SELECT [id]
                        ,[masterId]
                        ,[projectCode]
                        ,[projectName]
                        ,[projectClass]
                        ,[projectDescription]
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
                                        
                    FROM [EvaluateSevice1_3] 

                    WHERE masterId =  @MasterId ";

        //string prefix = " AND ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);

        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();
        //da.Fill(ds, "Data");
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData3.DataSource = blacklistDT.DefaultView;
        gvData3.DataBind ();
        lblRecord3.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add1_3_Click (object sender, EventArgs e) {
        UpdatePanel1_3.Update ();
        popupAddService1_3.Show ();
        this.ClearPopUp3 ();
    }

    protected void gvData_Sorting3 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection3;
        GridviewSortDirection3 = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging3 (object sender, GridViewPageEventArgs e) {
        gvData3.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData3.PageIndex = e.NewPageIndex;
        gvData3.DataBind ();
        this.btnSubmit_Click3 (sender, e);
    }
    protected void gvData_SelectedIndexChanged3 (object sender, EventArgs e) { }

    protected void gvData_RowDataBound3 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus3 = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus3")).Value);
        }

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
        txtProjectCode3.Text = "";
        txtProjectName3.Text = "";
        txtProjectDescription3.Text = "";
        txtProjectClass3.SelectedValue = "";

    }
    protected void ddlClass_SelectedIndexChanged (object sender, EventArgs e) { }
    protected void btnAddService_Click3 (object sender, EventArgs e) {

        UpdatePanel1_3.Update ();
        if (this.SaveService3 (hdf_SeviceStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddService1_3.Hide ();
        }

    }
    protected void btnCancelService_Click3 (object sender, EventArgs e) {
        UpdatePanel1_3.Update ();
        popupAddService1_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add1_3.Visible = true;
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
                    FROM [EvaluateSevice1_3] 
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

    protected bool SaveService3 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        ";

        com = new SqlCommand (str, con);
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string rId = Request.QueryString["nId"];
        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================

        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab1-3\\";
        string pathDelete = "Delete\\" + path;
        string pathEdit = "Edit\\" + path;
        string filepath = rootpath + path;
        string filepathDelete = rootpath + pathDelete;
        string filepathEdit = rootpath + pathEdit;
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete) || !Directory.Exists (filepathEdit)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload1_3.FileName);
        string NewFileName = "Sevice1_3_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload1_3.FileName;
        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload1_3.HasFile) {
            FileUpload1_3.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {
            sql = @"INSERT INTO EvaluateSevice1_3
                    (masterId,  projectCode,  projectName, projectClass, projectDescription, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectClass, @ProjectDescription, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_3)";
        } else {
            sql = @"UPDATE EvaluateSevice1_3  SET
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'
                    WHERE id = @Id
                    
                    INSERT INTO EvaluateSevice1_3
                    (masterId,  projectCode,  projectName, projectClass, projectDescription, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectCode, @ProjectName, @ProjectClass, @ProjectDescription, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_3)";
        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;
        string classet1_3 = "";
        decimal totalScore1_3 = 0;
        try {

            String class1_3 = txtProjectClass3.SelectedValue;
            if (class1_3 == "A") {
                totalScore1_3 = 10;
                classet1_3 = "Class A";
            } else if (class1_3 == "B") {
                totalScore1_3 = 9;
                classet1_3 = "Class B";
            } else if (class1_3 == "C") {
                totalScore1_3 = 8;
                classet1_3 = "Class C";
            } else if (class1_3 == "D") {
                totalScore1_3 = 7;
                classet1_3 = "Class D";
            } else if (class1_3 == "E") {
                totalScore1_3 = 6;
                classet1_3 = "Class E";
            } else if (class1_3 == "F") {
                totalScore1_3 = 5;
                classet1_3 = "Class F";
            }
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@ProjectCode", txtProjectCode3.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName3.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectClass", classet1_3);
            cmd.Parameters.AddWithValue ("@ProjectDescription", txtProjectDescription3.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score1_3", totalScore1_3);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError1_3.Text += "SaveService3 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 
    }
    protected DataTable SearchOneArea3 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                            ,[masterId]
                            ,[projectCode]
                            ,[projectName]
                            ,[projectClass]
                            ,[projectDescription]
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
                                        
                    FROM [EvaluateSevice1_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError1_3.Text += "SaveService3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditService_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel1_3.Update ();
            popupAddService1_3.Show ();
            hdf_SeviceStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectCode3.Text = ds.Rows[0]["projectCode"].ToString ();
            txtProjectName3.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectDescription3.Text = ds.Rows[0]["projectDescription"].ToString ();
        }

    }

    protected void btnDeleteService_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);

        if (ds != null && ds.Rows.Count > 0) {
            hdf_SeviceStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateSevice1_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_SeviceStatus3.Value);
            db.ExecuteDataTable (cmd1);

        }
        string rootpath = Request.PhysicalApplicationPath;
        string fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        string fileDelete = rootpath + "Delete\\File\\2562\\2\\เจษฎาภาชนนท์\\tab1-3\\" + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        this.SearchData3 ();

    }

    //###############################EvaluateSevice1_3 end#####################################################
    //###############################EvaluateSevice1_4 Strat#####################################################

    protected void SearchData4 () {
        string sql = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[projectClass]
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
                                        
                    FROM [EvaluateSevice1_4] 

                    WHERE projectStatus = 'A' AND masterId =  @MasterId ";

        //string prefix = " AND ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);

        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();
        // da.Fill(ds, "Data");
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData4.DataSource = blacklistDT.DefaultView;
        gvData4.DataBind ();
        lblRecord4.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add1_4_Click (object sender, EventArgs e) {
        UpdatePanel1_4.Update ();
        popupAddService1_4.Show ();
        this.ClearPopUp4 ();
    }

    protected void gvData_Sorting4 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection4;
        GridviewSortDirection4 = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging4 (object sender, GridViewPageEventArgs e) {
        gvData4.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData4.PageIndex = e.NewPageIndex;
        gvData4.DataBind ();
        this.btnSubmit_Click4 (sender, e);
    }
    protected void gvData_SelectedIndexChanged4 (object sender, EventArgs e) { }

    protected void gvData_RowDataBound4 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus4 = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus4")).Value);
        }

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

        txtProjectName4.Text = "";
        //  txtprojectPrecentJoint4.Text = "";
        txtProjectClass4.SelectedValue = "";

    }

    protected void btnAddService_Click4 (object sender, EventArgs e) {
        // string rId = "";
        // UpdatePanel1_2.Update();
        // this.SaveService2(rId);
        // this.SearchData2();
        // popupAddService1_2.Hide();

        string rId = "";
        UpdatePanel1_4.Update ();
        if (this.SaveService4 (hdf_SeviceStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddService1_4.Hide ();
        }

    }
    protected void btnCancelService_Click4 (object sender, EventArgs e) {
        UpdatePanel1_4.Update ();
        popupAddService1_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add1_4.Visible = true;
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
                    FROM [EvaluateSevice1_4] 
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

    string classet1_4;
    double totalScore1_4;
    protected bool SaveService4 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        ";

        com = new SqlCommand (str, con);
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string rId = Request.QueryString["nId"];
        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================

        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab1-4\\";
        string pathDelete = "Delete\\" + path;
        string pathEdit = "Edit\\" + path;
        string filepath = rootpath + path;
        string filepathDelete = rootpath + pathDelete;
        string filepathEdit = rootpath + pathEdit;
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete) || !Directory.Exists (filepathEdit)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        if (!Directory.Exists (filepath)) {
            Directory.CreateDirectory (filepath);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload1_4.FileName);
        string NewFileName = "Sevice1_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload1_4.FileName;
        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload1_4.HasFile) {
            FileUpload1_4.SaveAs (InsertFile);
        }

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {
            sql = @"INSERT INTO EvaluateSevice1_4
                    (masterId, projectName, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore ) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_4 )";
        } else {
            sql = @"UPDATE EvaluateSevice1_4  SET
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'
                    WHERE id = @Id
                    
                    INSERT INTO EvaluateSevice1_4
                    (masterId, projectName, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore ) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_4 )";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            String class1_4 = txtProjectClass4.SelectedValue.ToString ();

            if (class1_4 == "A") {
                totalScore1_4 = 0.2 * 100;
                classet1_4 = "Class A";
            } else if (class1_4 == "B") {
                totalScore1_4 = 0.15 * 100;
                classet1_4 = "Class B";
            } else if (class1_4 == "C") {
                totalScore1_4 = 0.1 * 100;
                classet1_4 = "Class C";
            } else if (class1_4 == "D") {
                totalScore1_4 = 0.05 * 100;
                classet1_4 = "Class D";
            }

            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName4.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectClass", classet1_4);

            cmd.Parameters.AddWithValue ("@Path", filepath);

            cmd.Parameters.AddWithValue ("@IpAddress", ip);

            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score1_4", totalScore1_4);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError1_4.Text += "SaveService4 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 
    }
    protected DataTable SearchOneArea4 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[projectClass]
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
                                        
                    FROM [EvaluateSevice1_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError1_4.Text += "SaveService4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditService_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel1_4.Update ();
            popupAddService1_4.Show ();
            hdf_SeviceStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName4.Text = ds.Rows[0]["projectName"].ToString ();
            //  txtProjectClass4.Text = ds.Rows[0]["projectClass"].ToString();
            // txtprojectPrecentJoint4.Text = ds.Rows[0]["projectPrecentJoint"].ToString ();
        }

    }

    protected void btnDeleteService_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);

        if (ds != null && ds.Rows.Count > 0) {
            hdf_SeviceStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateSevice1_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_SeviceStatus4.Value);
            db.ExecuteDataTable (cmd1);

        }
        string rootpath = Request.PhysicalApplicationPath;
        string fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        string fileDelete = rootpath + "Delete\\File\\2562\\2\\เจษฎาภาชนนท์\\tab1-4\\" + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        this.SearchData4 ();

    }

    //###############################EvaluateSevice1_4 end#####################################################
    //###############################EvaluateSevice1_5 Strat#####################################################

    protected void SearchData5 () {
        string sql = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[projectClass]
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
                                        
                    FROM [EvaluateSevice1_5] 

                    WHERE projectStatus = 'A' AND masterId =  @MasterId ";

        //string prefix = " AND ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);

        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();
        // da.Fill(ds, "Data");
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
        gvData5.DataSource = blacklistDT.DefaultView;
        gvData5.DataBind ();
        lblRecord5.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + blacklistDT.Rows.Count.ToString ("#,###") + " Record(s)</span>";

    }

    protected void Add1_5_Click (object sender, EventArgs e) {
        UpdatePanel1_5.Update ();
        popupAddService1_5.Show ();
        this.ClearPopUp5 ();
    }

    protected void gvData_Sorting5 (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection5;
        GridviewSortDirection5 = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging5 (object sender, GridViewPageEventArgs e) {
        gvData5.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData5.PageIndex = e.NewPageIndex;
        gvData5.DataBind ();
        this.btnSubmit_Click5 (sender, e);
    }
    protected void gvData_SelectedIndexChanged5 (object sender, EventArgs e) { }

    protected void gvData_RowDataBound5 (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus5 = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus5")).Value);
        }

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

        txtProjectName5.Text = "";

        txtProjectClass5.SelectedValue = "";

    }

    protected void btnAddService_Click5 (object sender, EventArgs e) {
        // string rId = "";
        // UpdatePanel1_2.Update();
        // this.SaveService2(rId);
        // this.SearchData2();
        // popupAddService1_2.Hide();

        string rId = "";
        UpdatePanel1_5.Update ();
        if (this.SaveService5 (hdf_SeviceStatus5.Value) == true) {
            this.SearchData5 ();
            popupAddService1_5.Hide ();
        }

    }
    protected void btnCancelService_Click5 (object sender, EventArgs e) {
        UpdatePanel1_5.Update ();
        popupAddService1_5.Hide ();
    }

    protected void btnSubmit_Click5 (object sender, EventArgs e) {
        Add1_5.Visible = true;
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
                    FROM [EvaluateSevice1_5] 
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

    string classet1_5;
    double totalScore1_5;
    protected bool SaveService5 (string ID) {
        SqlCommand com;
        string str;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        str = @"select C.projectYear, C.projectRound, 
                        M.acountId ,A.FirstName + A.LastName AS FullName
                        from ProjectControl AS C
                        INNER JOIN EvaluateMaster AS M ON M.roundId = C.id
                        INNER JOIN Account AS A ON M.acountId = A.id 
                        ";

        com = new SqlCommand (str, con);
        SqlDataReader reader = com.ExecuteReader ();

        reader.Read ();
        string FullName = reader["FullName"].ToString ();
        string AcountId = reader["acountId"].ToString ();
        string projectYear = reader["projectYear"].ToString ();
        string projectRound = reader["projectRound"].ToString ();

        string rId = Request.QueryString["nId"];
        //==========================IPADDRESS ==================================
        string strHostName = System.Net.Dns.GetHostName ();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry (strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        string ip = addr[1].ToString ();
        //==========================IPADDRESS END==================================
        //==========================upfile====================================

        string rootpath = Request.PhysicalApplicationPath;
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab1-5\\";
        string pathDelete = "Delete\\" + path;
        string pathEdit = "Edit\\" + path;
        string filepath = rootpath + path;
        string filepathDelete = rootpath + pathDelete;
        string filepathEdit = rootpath + pathEdit;
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete) || !Directory.Exists (filepathEdit)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload1_5.FileName);
        string NewFileName = "Sevice1_5_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload1_5.FileName;
        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload1_5.HasFile) {
            FileUpload1_5.SaveAs (InsertFile);
        }

        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {
            sql = @"INSERT INTO EvaluateSevice1_5
                    (masterId, projectName, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore ) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_5)";
        } else {
            sql = @"UPDATE EvaluateSevice1_5  SET
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'
                    WHERE id = @Id
                    
                    
                    INSERT INTO EvaluateSevice1_5
                    (masterId, projectName, projectClass, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore ) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectClass, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score1_5)
                    
                    ";
        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {

            String class1_5 = txtProjectClass5.SelectedValue.ToString ();

            if (class1_5 == "A") {
                totalScore1_5 = 0.2 * 100;
                classet1_5 = "Class A";
            } else if (class1_5 == "B") {
                totalScore1_5 = 0.15 * 100;
                classet1_5 = "Class B";
            } else if (class1_5 == "C") {
                totalScore1_5 = 0.1 * 100;
                classet1_5 = "Class C";
            } else if (class1_5 == "D") {
                totalScore1_5 = 0.05 * 100;
                classet1_5 = "Class D";
            }

            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName5.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectClass", classet1_5);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);

            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score1_5", totalScore1_5);
            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError1_5.Text += "SaveService5 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 
    }
    protected DataTable SearchOneArea5 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[projectClass]
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
                                        
                    FROM [EvaluateSevice1_5] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError1_5.Text += "SaveService5 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditService_Click5 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel1_5.Update ();
            popupAddService1_5.Show ();
            hdf_SeviceStatus5.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName5.Text = ds.Rows[0]["projectName"].ToString ();
            //  txtProjectClass4.Text = ds.Rows[0]["projectClass"].ToString();
        }

    }

    protected void btnDeleteService_Click5 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);

        if (ds != null && ds.Rows.Count > 0) {
            hdf_SeviceStatus5.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateSevice1_5  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_SeviceStatus5.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData5 ();
        }
        string rootpath = Request.PhysicalApplicationPath;
        string fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        string fileDelete = rootpath + "Delete\\File\\2562\\2\\เจษฎาภาชนนท์\\tab1-5\\" + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);

    }

}