using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//5
public partial class Evaluate_AcademicServices : System.Web.UI.Page {
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

    }

    protected void report1_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_ServiceWork.aspx?nID=" + rId);

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_Research.aspx?nID=" + rId);

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_Develop_Mainten.aspx?nID=" + rId);

    }
    protected void report4_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_Promotion_work.aspx?nID=" + rId);

    }
    protected void report6_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_Management.aspx?nID=" + rId);

    }
    protected void report7_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Head_Evaluate_Other.aspx?nID=" + rId);

    }
    protected void reportSummary_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Summary.aspx?nID=" + rId);

    }

    protected void SearchData () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[dateNumber]
                    ,[projectLocation]
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
                    FROM [EvaluateAcademicServices5_1] 

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

    protected void Add5_1_Click (object sender, EventArgs e) {
        UpdatePanel5_1.Update ();
        popupAddAcademic5_1.Show ();
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
        txtProjectName.Text = "";
        txtProjectLocation.SelectedValue = "";
        txtdateNumber.Text = "";

    }
    protected void btnAddAcademic_Click (object sender, EventArgs e) {
        UpdatePanel5_1.Update ();
        if (this.SaveAcademic (hdf_AcademicStatus.Value) == true) {
            this.SearchData ();
            popupAddAcademic5_1.Hide ();
        }

    }
    protected void btnCancelAcademic_Click (object sender, EventArgs e) {
        UpdatePanel5_1.Update ();
        popupAddAcademic5_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add5_1.Visible = true;
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
                    FROM [EvaluateAcademicServices5_1] 
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

    protected bool SaveAcademic (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-1\\";
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
        string OldFileName = Path.GetFileName (FileUpload5_1.FileName);
        string NewFileName = "Academic5_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload5_1.FileName;
        // string NewFileName = FileUpload5_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload5_1.HasFile) {
            FileUpload5_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateAcademicServices5_1
                    (masterId,  projectName,  projectLocation, dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectLocation, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_1)";
        } else {

            sql = @"UPDATE EvaluateAcademicServices5_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateAcademicServices5_1
                    (masterId,  projectName,  projectLocation, dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectName, @ProjectLocation, @DateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore5_1 = 0;
            string Location = txtProjectLocation.SelectedValue.ToString ();
            decimal DateNumber = decimal.Parse (txtdateNumber.Text);
            if (Location == "ระดับนานาชาติ") {
                totalScore5_1 = DateNumber * 4;
            } else {
                totalScore5_1 = DateNumber * 2;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectLocation", txtProjectLocation.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName.Text.Trim ());
            cmd.Parameters.AddWithValue ("@DateNumber", txtdateNumber.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score5_1", totalScore5_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError5_1.Text += "SaveAcademic = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectName]
                        ,[dateNumber]
                        ,[projectLocation]
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
                                        
                    FROM [EvaluateAcademicServices5_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError5_1.Text += "SaveAcademic = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditAcademic_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel5_1.Update ();
            popupAddAcademic5_1.Show ();
            hdf_AcademicStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();
            txtProjectLocation.SelectedValue = ds.Rows[0]["projectLocation"].ToString ();
            txtdateNumber.Text = ds.Rows[0]["dateNumber"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteAcademic_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_AcademicStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateAcademicServices5_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_AcademicStatus.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 5_1 ###################################################################################
    //####################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 5_2######################################################################################

    protected void SearchData2 () {
        string sql = @"SELECT [id]
                   ,[masterId]
                    ,[projectAcadenicName]
                    ,[projectStudentName]
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
                    FROM [EvaluateAcademicServices5_2] 

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

    protected void Add5_2_Click (object sender, EventArgs e) {
        UpdatePanel5_2.Update ();
        popupAddAcademic5_2.Show ();
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
        txtProjectAcadenicName2.Text = "";
        txtProjectStudentName2.Text = "";
        // txtProjectClass2.Text = "";
    }
    protected void btnAddAcademic_Click2 (object sender, EventArgs e) {
        UpdatePanel5_2.Update ();
        if (this.SaveAcademic2 (hdf_AcademicStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddAcademic5_2.Hide ();
        }

    }
    protected void btnCancelAcademic_Click2 (object sender, EventArgs e) {
        UpdatePanel5_2.Update ();
        popupAddAcademic5_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add5_2.Visible = true;
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
                    FROM [EvaluateAcademicServices5_2] 
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

    protected bool SaveAcademic2 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-2\\";
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
        string OldFileName = Path.GetFileName (FileUpload5_2.FileName);
        string NewFileName = "Academic5_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload5_2.FileName;
        // string NewFileName = FileUpload5_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload5_2.HasFile) {
            FileUpload5_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateAcademicServices5_2
                    (masterId,  projectStudentName,  projectAcadenicName, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectStudentName, @ProjectAcadenicName, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_2)";
        } else {

            sql = @"UPDATE EvaluateAcademicServices5_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateAcademicServices5_2
                    (masterId,  projectStudentName,  projectAcadenicName, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectStudentName, @ProjectAcadenicName, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_2)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore5_2 = 5;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectAcadenicName", txtProjectAcadenicName2.Text);
            cmd.Parameters.AddWithValue ("@ProjectStudentName", txtProjectStudentName2.Text);

            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score5_2", totalScore5_2);

            // cmd.Parameters.AddWithValue ("@FileNameOld5_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError5_2.Text += "SaveAcademic2 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea2 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectAcadenicName]
                    ,[projectStudentName]
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
                                                        
                    FROM [EvaluateAcademicServices5_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError5_2.Text += "SaveAcademic2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditAcademic_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel5_2.Update ();
            popupAddAcademic5_2.Show ();
            hdf_AcademicStatus2.Value = ds.Rows[0]["id"].ToString ();
            //     txtProjectTopic2.Text = ds.Rows[0]["projectTopic"].ToString ();
            txtProjectAcadenicName2.Text = ds.Rows[0]["projectAcadenicName"].ToString ();
            txtProjectStudentName2.Text = ds.Rows[0]["projectStudentName"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteAcademic_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_AcademicStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateAcademicServices5_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_AcademicStatus2.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-2\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 5_2 ####################################################################################
    //######################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 5_3###################################################################################

    protected void SearchData3 () {
        string sql = @"SELECT [id]
                   ,[masterId]
                    ,[projectAcademicName]
                    ,[projectStudentName]
                    ,[projectThesisTopic]
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
                    FROM [EvaluateAcademicServices5_3] 

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

    protected void Add5_3_Click (object sender, EventArgs e) {
        UpdatePanel5_3.Update ();
        popupAddAcademic5_3.Show ();
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
        txtProjectAcademicName3.Text = "";
        txtProjectStudentName3.Text = "";
        txtProjectThesisTopic3.Text = "";
    }
    protected void btnAddAcademic_Click3 (object sender, EventArgs e) {
        UpdatePanel5_3.Update ();
        if (this.SaveAcademic3 (hdf_AcademicStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddAcademic5_3.Hide ();
        }

    }
    protected void btnCancelAcademic_Click3 (object sender, EventArgs e) {
        UpdatePanel5_3.Update ();
        popupAddAcademic5_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add5_3.Visible = true;
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
                    FROM [EvaluateAcademicServices5_3] 
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

    protected bool SaveAcademic3 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-3\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-3\\";
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
        string OldFileName = Path.GetFileName (FileUpload5_3.FileName);
        string NewFileName = "Academic5_3_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload5_3.FileName;
        // string NewFileName = FileUpload5_3.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload5_3.HasFile) {
            FileUpload5_3.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateAcademicServices5_3
                    (masterId,  path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectAcademicName, projectStudentName, projectThesisTopic) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_3, @ProjectAcademicName, @ProjectStudentName, @ProjectThesisTopic)";
        } else {

            sql = @"UPDATE EvaluateAcademicServices5_3  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateAcademicServices5_3
                    (masterId,  path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectAcademicName, projectStudentName, projectThesisTopic) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_3, @ProjectAcademicName, @ProjectStudentName, @ProjectThesisTopic)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore5_3 = 6;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectStudentName", txtProjectStudentName3.Text);
            cmd.Parameters.AddWithValue ("@ProjectThesisTopic", txtProjectThesisTopic3.Text);
            cmd.Parameters.AddWithValue ("@ProjectAcademicName", txtProjectAcademicName3.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score5_3", totalScore5_3);

            // cmd.Parameters.AddWithValue ("@FileNameOld5_3", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError5_3.Text += "SaveAcademic3 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea3 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectAcademicName]
                    ,[projectStudentName]
                    ,[projectThesisTopic]
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
                                                        
                    FROM [EvaluateAcademicServices5_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError5_3.Text += "SaveAcademic3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditAcademic_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel5_3.Update ();
            popupAddAcademic5_3.Show ();
            hdf_AcademicStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectAcademicName3.Text = ds.Rows[0]["projectAcademicName"].ToString ();
            txtProjectStudentName3.Text = ds.Rows[0]["projectStudentName"].ToString ();
            txtProjectThesisTopic3.Text = ds.Rows[0]["projectThesisTopic"].ToString ();
            // txtProjectQ.Text = ds.Rows[0]["projectQ"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteAcademic_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_AcademicStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateAcademicServices5_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_AcademicStatus3.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-3\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 5_3 ##############################################################
    //################################################################################################################################
    //################################################################################################################################
    //##########################################################Strat 5_4#############################################################

    protected void SearchData4 () {
        string sql = @"SELECT [id]
                  ,[masterId]
                    ,[projectOfNumber]
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
                    FROM [EvaluateAcademicServices5_4] 

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

    protected void Add5_4_Click (object sender, EventArgs e) {
        UpdatePanel5_4.Update ();
        popupAddAcademic5_4.Show ();
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
        txtProjectOfNumber4.Text = "";

    }
    protected void btnAddAcademic_Click4 (object sender, EventArgs e) {
        UpdatePanel5_4.Update ();
        if (this.SaveAcademic4 (hdf_AcademicStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddAcademic5_4.Hide ();
        }

    }
    protected void btnCancelAcademic_Click4 (object sender, EventArgs e) {
        UpdatePanel5_4.Update ();
        popupAddAcademic5_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add5_4.Visible = true;
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
                    FROM [EvaluateAcademicServices5_4] 
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

    protected bool SaveAcademic4 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-4\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-4\\";
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
        string OldFileName = Path.GetFileName (FileUpload5_4.FileName);
        string NewFileName = "Academic5_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload5_4.FileName;
        // string NewFileName = FileUpload5_4.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload5_4.HasFile) {
            FileUpload5_4.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateAcademicServices5_4
                    (masterId,  projectOfNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectOfNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_4)";
        } else {

            sql = @"UPDATE EvaluateAcademicServices5_4  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateAcademicServices5_4
                    (masterId,  projectOfNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectOfNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_4)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            double totalScore5_4 = 0;
            double number = double.Parse (txtProjectOfNumber4.Text);
            totalScore5_4 = number * 0.4;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectOfNumber", txtProjectOfNumber4.Text);

            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score5_4", totalScore5_4);

            // cmd.Parameters.AddWithValue ("@FileNameOld5_4", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError5_4.Text += "SaveAcademic4 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea4 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                   ,[masterId]
                    ,[projectOfNumber]
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
                                                        
                    FROM [EvaluateAcademicServices5_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError5_4.Text += "SaveAcademic4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditAcademic_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel5_4.Update ();
            popupAddAcademic5_4.Show ();
            hdf_AcademicStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectOfNumber4.Text = ds.Rows[0]["projectOfNumber"].ToString ();

        }

    }

    protected void btnDeleteAcademic_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_AcademicStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateAcademicServices5_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_AcademicStatus4.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-4\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 5_4 ################################################################
    //##################################################################################################################################
    //##################################################################################################################################
    //##########################################################Strat 5_5###############################################################
    protected void SearchData5 () {
        string sql = @"SELECT [id]
                     ,[masterId]
                    ,[projectDescription]
                    ,[dateNumber]
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
                    FROM [EvaluateAcademicServices5_5] 

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

    protected void Add5_5_Click (object sender, EventArgs e) {
        UpdatePanel5_5.Update ();
        popupAddAcademic5_5.Show ();
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
        txtProjectDescription5.Text = "";
        txtdateNumber5.Text = "";

    }
    protected void btnAddAcademic_Click5 (object sender, EventArgs e) {
        UpdatePanel5_5.Update ();
        if (this.SaveAcademic5 (hdf_AcademicStatus5.Value) == true) {
            this.SearchData5 ();
            popupAddAcademic5_5.Hide ();
        }

    }
    protected void btnCancelAcademic_Click5 (object sender, EventArgs e) {
        UpdatePanel5_5.Update ();
        popupAddAcademic5_5.Hide ();
    }

    protected void btnSubmit_Click5 (object sender, EventArgs e) {
        Add5_5.Visible = true;
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
                    FROM [EvaluateAcademicServices5_5] 
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

    protected bool SaveAcademic5 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-5\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-5\\";
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
        string OldFileName = Path.GetFileName (FileUpload5_5.FileName);
        string NewFileName = "Academic5_5_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload5_5.FileName;
        // string NewFileName = FileUpload5_5.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload5_5.HasFile) {
            FileUpload5_5.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateAcademicServices5_5
                    (masterId,  projectDescription, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, dateNumber) 
                    VALUES
                    (@MasterId, @ProjectDescription, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_5, @DateNumber)";
        } else {

            sql = @"UPDATE EvaluateAcademicServices5_5  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateAcademicServices5_5
                    (masterId,  projectDescription, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, dateNumber) 
                    VALUES
                    (@MasterId, @ProjectDescription, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score5_5, @DateNumber)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal number = decimal.Parse (txtdateNumber5.Text);
            decimal totalScore5_5 = number * 2;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);

            cmd.Parameters.AddWithValue ("@ProjectDescription", txtProjectDescription5.Text.Trim ());
            cmd.Parameters.AddWithValue ("@DateNumber", txtdateNumber5.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score5_5", totalScore5_5);

            // cmd.Parameters.AddWithValue ("@FileNameOld5_5", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError5_5.Text += "SaveAcademic5 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea5 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                     ,[masterId]
                    ,[projectDescription]
                    ,[dateNumber]
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
                                                        
                    FROM [EvaluateAcademicServices5_5] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError5_5.Text += "SaveAcademic5 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditAcademic_Click5 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel5_5.Update ();
            popupAddAcademic5_5.Show ();
            hdf_AcademicStatus5.Value = ds.Rows[0]["id"].ToString ();
            txtProjectDescription5.Text = ds.Rows[0]["projectDescription"].ToString ();
            txtdateNumber5.Text = ds.Rows[0]["dateNumber"].ToString ();
        }

    }

    protected void btnDeleteAcademic_Click5 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData5.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea5 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_AcademicStatus5.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateAcademicServices5_5  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_AcademicStatus5.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab5-5\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 5_5 ##################################################################
    //####################################################################################################################################
    //#####################################################################################################################################

}