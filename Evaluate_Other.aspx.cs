using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ClassLibrary;
//7  EvaluateOther7_1
public partial class Evaluate_Other : System.Web.UI.Page {
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

    }

    protected void report1_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_ServiceWork.aspx?nID=" + rId);

    }
    protected void report3_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Research.aspx?nID=" + rId);

    }
    protected void report2_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Develop_Mainten.aspx?nID=" + rId);

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
    protected void report7_Click(object sender, EventArgs e)
    {
        string rId = Request.QueryString["nId"];
        Response.Redirect("~/Evaluate_Other.aspx?nID=" + rId);

    }
    protected void reportSummary_Click (object sender, EventArgs e) {
        string rId = Request.QueryString["nId"];
        Response.Redirect ("~/Evaluate_Summary.aspx?nID=" + rId);

    }

    protected void SearchData () {
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,[projectDiscription]
                    ,[projectType]
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
                    FROM [EvaluateOther7_1] 

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

    protected void Add7_1_Click (object sender, EventArgs e) {
        UpdatePanel7_1.Update ();
        popupAddOther7_1.Show ();
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
        txtProjectDiscription.Text = "";
        txtProjectType.SelectedValue = "";
        //  txtdateNumber.Text = "";

    }
    protected void btnAddOther_Click (object sender, EventArgs e) {
        UpdatePanel7_1.Update ();
        if (this.SaveOther (hdf_OtherStatus.Value) == true) {
            this.SearchData ();
            popupAddOther7_1.Hide ();
        }

    }
    protected void btnCancelOther_Click (object sender, EventArgs e) {
        UpdatePanel7_1.Update ();
        popupAddOther7_1.Hide ();
    }

    protected void btnSubmit_Click (object sender, EventArgs e) {
        Add7_1.Visible = true;
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
                    FROM [EvaluateOther7_1] 
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

    protected bool SaveOther (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-1\\";
        string pathEdit = "Edit\\" + path;
        // filepathEdit = rootpath + pathEdit;
        filepath = rootpath + path;
        filepathDelete = rootpath + pathDelete;
        // var directoryInfo = new DirectoryInfo (filepath);
        if (!Directory.Exists (filepath) || !Directory.Exists (filepathDelete)) {
            Directory.CreateDirectory (filepath);
            Directory.CreateDirectory (filepathDelete);
            // Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName = Path.GetFileName (FileUpload7_1.FileName);
        string NewFileName = "Other7_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload7_1.FileName;
        // string NewFileName = FileUpload7_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload7_1.HasFile) {
            FileUpload7_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateOther7_1
                    (masterId,  projectDiscription,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectDiscription, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_1)";
        } else {

            sql = @"UPDATE EvaluateOther7_1  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateOther7_1
                    (masterId,  projectDiscription,  projectType, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectDiscription, @ProjectType, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_1)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            double totalScore7_1 = 0;
            string type = txtProjectType.SelectedValue;
            if (type == "กิจกรรม") {
                totalScore7_1 = 2.0;
            } else {
                totalScore7_1 = 0.5;
            }

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectType", txtProjectType.SelectedValue);
            cmd.Parameters.AddWithValue ("@ProjectDiscription", txtProjectDiscription.Text.Trim ());
            // cmd.Parameters.AddWithValue ("@DateNumber", txtdateNumber.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score7_1", totalScore7_1);

            // cmd.Parameters.AddWithValue ("@FileNameOld1_1", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError7_1.Text += "SaveOther = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                        ,[masterId]
                        ,[projectDiscription]
                        ,[projectType]
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
                                        
                    FROM [EvaluateOther7_1] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError7_1.Text += "SaveOther = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditOther_Click (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel7_1.Update ();
            popupAddOther7_1.Show ();
            hdf_OtherStatus.Value = ds.Rows[0]["id"].ToString ();
            txtProjectDiscription.Text = ds.Rows[0]["projectDiscription"].ToString ();
            txtProjectType.SelectedValue = ds.Rows[0]["projectType"].ToString ();
            //txtdateNumber.Text = ds.Rows[0]["dateNumber"].ToString ();
            //txtProjectName.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteOther_Click (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_OtherStatus.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateOther7_1  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_OtherStatus.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 7_1 ###################################################################################
    //####################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 7_2######################################################################################

    protected void SearchData2 () {
        string sql = @"SELECT [id]
                         ,[masterId]
                        ,[projectDescription]
                        ,[projectDate]
                        ,[projectScore]
                        ,[projectStatus]
                        ,[path]
                        ,[fileName]
                        ,[fileNameOld]
                        ,[createdBy]
                        ,[createdDate]
                        ,[updateDate]
                        ,[ipAddressCreate]
                        ,[updatedBy]
                        ,[ipAdressUpdate]
                        ,[projectDateOut]
                        ,[updateDateOut]
                    FROM [EvaluateOther7_2] 

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

    protected void Add7_2_Click (object sender, EventArgs e) {
        UpdatePanel7_2.Update ();
        popupAddOther7_2.Show ();
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
        txtProjectDescription2.Text = "";
        txtProjectDate.Text = "";
        txtProjectDateOut.Text = "";
    }
    protected void btnAddOther_Click2 (object sender, EventArgs e) {
        UpdatePanel7_2.Update ();
        if (this.SaveOther2 (hdf_OtherStatus2.Value) == true) {
            this.SearchData2 ();
            popupAddOther7_2.Hide ();
        }

    }
    protected void btnCancelOther_Click2 (object sender, EventArgs e) {
        UpdatePanel7_2.Update ();
        popupAddOther7_2.Hide ();
    }

    protected void btnSubmit_Click2 (object sender, EventArgs e) {
        Add7_2.Visible = true;
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
                    FROM [EvaluateOther7_2] 
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

    protected bool SaveOther2 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-2\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-2\\";
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
        string OldFileName = Path.GetFileName (FileUpload7_2.FileName);
        string NewFileName = "Other7_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload7_2.FileName;
        // string NewFileName = FileUpload7_2.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload7_2.HasFile) {
            FileUpload7_2.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateOther7_2
                    (masterId,  projectDescription, projectDate, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId,  @ProjectDescription, @ProjectDate, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_2, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";
        } else {

            sql = @"UPDATE EvaluateOther7_2  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateOther7_2
                    (masterId,  projectDescription, projectDate, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, updateDate, updateDateOut, projectDateOut) 
                    VALUES
                    (@MasterId,  @ProjectDescription, @ProjectDate, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_2, @ProjectDate, @ProjectDateOut, @ProjectDateOut)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore7_2 = 1;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectDescription", txtProjectDescription2.Text);

            cmd.Parameters.AddWithValue ("@ProjectDate", txtProjectDate.Text.Trim ());
            cmd.Parameters.AddWithValue ("@ProjectDateOut", txtProjectDateOut.Text.Trim ());
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score7_2", totalScore7_2);

            // cmd.Parameters.AddWithValue ("@FileNameOld7_2", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError7_2.Text += "SaveOther2 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea2 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                   ,[masterId]
                    ,[projectDescription]
                    ,[projectDate]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[path]
                    ,[fileName]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[createdDate]
                    ,[updateDate]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[projectDateOut]
                    ,[updateDateOut]
                                                                                        
                    FROM [EvaluateOther7_2] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError7_2.Text += "SaveOther2 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditOther_Click2 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel7_2.Update ();
            popupAddOther7_2.Show ();
            hdf_OtherStatus2.Value = ds.Rows[0]["id"].ToString ();
            //     txtProjectTopic2.Text = ds.Rows[0]["projectTopic"].ToString ();
            //  txtProjectAcadenicName2.Text = ds.Rows[0]["projectAcadenicName"].ToString ();
            txtProjectDescription2.Text = ds.Rows[0]["projectDescription"].ToString ();
            txtProjectDate.Text = Convert.ToDateTime (ds.Rows[0]["updateDate"]).ToString ("yyyy-MM-dd");
            txtProjectDateOut.Text = Convert.ToDateTime (ds.Rows[0]["updateDateOut"]).ToString ("yyyy-MM-dd");
        }

    }

    protected void btnDeleteOther_Click2 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData2.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea2 (Id);
        string fileSrc;
        string fileDelete;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_OtherStatus2.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateOther7_2  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_OtherStatus2.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-2\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 7_2 ####################################################################################
    //######################################################################################################################################################
    //######################################################################################################################################################
    //##########################################################Strat 7_3###################################################################################

    protected void SearchData3 () {
        string sql = @"SELECT [id]
                   ,[masterId]
                    ,[projectName]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathTor]
                    ,[path]
                    ,[fileNameTor]
                    ,[fileName]
                    ,[fileNameTorOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                    FROM [EvaluateOther7_3]

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

    protected void Add7_3_Click (object sender, EventArgs e) {
        UpdatePanel7_3.Update ();
        popupAddOther7_3.Show ();
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
        txtProjectName3.Text = "";

    }
    protected void btnAddOther_Click3 (object sender, EventArgs e) {
        UpdatePanel7_3.Update ();
        if (this.SaveOther3 (hdf_OtherStatus3.Value) == true) {
            this.SearchData3 ();
            popupAddOther7_3.Hide ();
        }

    }
    protected void btnCancelOther_Click3 (object sender, EventArgs e) {
        UpdatePanel7_3.Update ();
        popupAddOther7_3.Hide ();
    }

    protected void btnSubmit_Click3 (object sender, EventArgs e) {
        Add7_3.Visible = true;
        this.SearchData3 ();
    }

    protected void btnReset_Click3 (object sender, EventArgs e) {
        // ddlArea.SelectedValue = "";
        // txtBuilder.Text = "";
    }

    protected void btnDownload_Click3_1 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,path + fileName AS Pathfile
                    FROM [EvaluateOther7_3] 
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
    protected void btnDownload_Click3_2 (object sender, EventArgs e) {
        SqlCommand com;

        SqlConnection con = new SqlConnection (con_string);
        con.Open ();
        string sql = @"SELECT [id]
                    ,[masterId]
                    ,pathTor + fileNameTor AS Pathfile
                    FROM [EvaluateOther7_3] 
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

    protected bool SaveOther3 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-1\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-1\\";
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
        string OldFileName = Path.GetFileName (FileUpload7_3_1.FileName);
        string NewFileName = "Other7_3_1_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload7_3_1.FileName;
        // string NewFileName = FileUpload7_3_1.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload7_3_1.HasFile) {
            FileUpload7_3_1.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);
        //===================================================================================
        string filepath1;
        string filepathDelete1;
        string filepathEdit1;
        string rootpath1 = Request.PhysicalApplicationPath;
        string path1 = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-2\\";
        string pathDelete1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-2\\";
        string pathEdit1 = "Edit\\" + path1;
        // filepathEdit = rootpath + pathEdit;
        filepath1 = rootpath1 + path1;
        filepathDelete1 = rootpath1 + pathDelete1;
        //  var directoryInfo = new DirectoryInfo (filepath1);
        if (!Directory.Exists (filepath1) || !Directory.Exists (filepathDelete1)) {
            Directory.CreateDirectory (filepath1);
            Directory.CreateDirectory (filepathDelete1);
            //  Directory.CreateDirectory (filepathEdit);
            //directoryInfo.CreateSubdirectory("k");
        }
        string OldFileName1 = Path.GetFileName (FileUpload7_3_2.FileName);
        string NewFileName1 = "Other7_3_2_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload7_3_2.FileName;
        // string NewFileName = FileUpload7_3_2.FileName;

        string InsertFile1 = filepath1 + NewFileName1;
        //InsertFile.SaveAs
        if (FileUpload7_3_2.HasFile) {
            FileUpload7_3_2.SaveAs (InsertFile1);
        }
        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateOther7_3
                    (masterId,  path, ipAddressCreate, fileNameOld, fileName, createdBy, projectScore, 
                    projectName, pathTor, fileNameTor, fileNameTorOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld, @FileName, @CreatedBy, @Score7_3, 
                    @ProjectName, @PathTor, @FileNameTor, @FileNameTorOld)";
        } else {

            sql = @"UPDATE EvaluateOther7_3  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateOther7_3
                    (masterId,  path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore, projectName, pathTor, fileNameTor, fileNameTorOld) 
                    VALUES
                    (@MasterId, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_3, @ProjectName, @PathTor, @FileNameTor, @FileNameTorOld)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            decimal totalScore7_3 = 10;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectName", txtProjectName3.Text);
            cmd.Parameters.AddWithValue ("@PathTor", filepath1);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameTorOld", OldFileName1);
            cmd.Parameters.AddWithValue ("@FileNameTor", NewFileName1);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score7_3", totalScore7_3);

            // cmd.Parameters.AddWithValue ("@FileNameOld7_3", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError7_3.Text += "SaveOther3 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea3 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectName]
                    ,[projectScore]
                    ,[projectStatus]
                    ,[pathTor]
                    ,[path]
                    ,[fileNameTor]
                    ,[fileName]
                    ,[fileNameTorOld]
                    ,[fileNameOld]
                    ,[createdBy]
                    ,[ipAddressCreate]
                    ,[updatedBy]
                    ,[ipAdressUpdate]
                    ,[createdDate]
                                                        
                    FROM [EvaluateOther7_3] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError7_3.Text += "SaveOther3 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditOther_Click3 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel7_3.Update ();
            popupAddOther7_3.Show ();
            hdf_OtherStatus3.Value = ds.Rows[0]["id"].ToString ();
            txtProjectName3.Text = ds.Rows[0]["projectName"].ToString ();

        }

    }

    protected void btnDeleteOther_Click3 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData3.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea3 (Id);
        string fileSrc;
        string fileDelete;
        string fileSrc1;
        string fileDelete1;

        if (ds != null && ds.Rows.Count > 0) {

            hdf_OtherStatus3.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateOther7_3  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_OtherStatus3.Value);
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-1\\";

        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);

        string path1 = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-3-2\\";

        string rootpath1 = Request.PhysicalApplicationPath;
        fileSrc1 = ds.Rows[0]["pathTor"].ToString () + ds.Rows[0]["fileNameTor"].ToString ();
        fileDelete1 = rootpath1 + path1 + ds.Rows[0]["fileNameTor"].ToString ();
        File.Move (fileSrc1, fileDelete1);
        reader.Close ();
        con.Close ();

    }

    //##########################################################end 7_3 ##############################################################
    //################################################################################################################################
    //################################################################################################################################
    //##########################################################Strat 7_4#############################################################

    protected void SearchData4 () {
        string sql = @"SELECT [id]
                  ,[masterId]
                    ,[projectDescription]
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

                    FROM [EvaluateOther7_4] 

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

    protected void Add7_4_Click (object sender, EventArgs e) {
        UpdatePanel7_4.Update ();
        popupAddOther7_4.Show ();
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
        txtProjectDescription4.Text = "";
        txtdateNumber4.Text = "";
    }
    protected void btnAddOther_Click4 (object sender, EventArgs e) {
        UpdatePanel7_4.Update ();
        if (this.SaveOther4 (hdf_OtherStatus4.Value) == true) {
            this.SearchData4 ();
            popupAddOther7_4.Hide ();
        }

    }
    protected void btnCancelOther_Click4 (object sender, EventArgs e) {
        UpdatePanel7_4.Update ();
        popupAddOther7_4.Hide ();
    }

    protected void btnSubmit_Click4 (object sender, EventArgs e) {
        Add7_4.Visible = true;
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
                    FROM [EvaluateOther7_4] 
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

    protected bool SaveOther4 (string ID) {
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
        string path = "File\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-4\\";
        string pathDelete = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-4\\";
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
        string OldFileName = Path.GetFileName (FileUpload7_4.FileName);
        string NewFileName = "Other7_4_" + DateTime.Now.ToString ("yyyyMMddHHmmss") + "_" + FileUpload7_4.FileName;
        // string NewFileName = FileUpload7_4.FileName;

        string InsertFile = filepath + NewFileName;
        //InsertFile.SaveAs
        if (FileUpload7_4.HasFile) {
            FileUpload7_4.SaveAs (InsertFile);
        }
        //hpf.SaveAs(InsertFile);

        //==========================upfile end===============================
        reader.Close ();
        con.Close ();

        string sql = "";
        if (ID == "") {

            sql = @"INSERT INTO EvaluateOther7_4
                    (masterId,  projectDescription, dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectDescription, @dateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_4)";
        } else {

            sql = @"UPDATE EvaluateOther7_4  SET                    
                    ipAdressUpdate = @IpAddress,
                    updatedBy = @CreatedBy,
                    projectStatus = 'I'                   
                    WHERE ID = @Id
                    
                   INSERT INTO EvaluateOther7_4
                    (masterId,  projectDescription, dateNumber, path, ipAddressCreate, fileNameOld,
                    fileName, createdBy, projectScore) 
                    VALUES
                    (@MasterId, @ProjectDescription, @dateNumber, @Path, @IpAddress, @FileNameOld,
                    @FileName, @CreatedBy, @Score7_4)";

        }

        //  db.ConnectionString = con_string;

        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = sql;

        try {
            double totalScore7_4 = 0;
            double number = double.Parse (txtdateNumber4.Text);
            totalScore7_4 = number * 2;

            cmd.Parameters.AddWithValue ("@Id", ID);
            cmd.Parameters.AddWithValue ("@MasterId", rId);
            cmd.Parameters.AddWithValue ("@ProjectDescription", txtProjectDescription4.Text);
            cmd.Parameters.AddWithValue ("@dateNumber", txtdateNumber4.Text);
            cmd.Parameters.AddWithValue ("@Path", filepath);
            cmd.Parameters.AddWithValue ("@IpAddress", ip);
            cmd.Parameters.AddWithValue ("@FileNameOld", OldFileName);
            cmd.Parameters.AddWithValue ("@FileName", NewFileName);
            cmd.Parameters.AddWithValue ("@CreatedBy", AcountId);
            cmd.Parameters.AddWithValue ("@Score7_4", totalScore7_4);

            // cmd.Parameters.AddWithValue ("@FileNameOld7_4", upnameOld);

            db.ExecuteNonQuery (cmd);

            return true;
        } catch (Exception ex) {
            lblInError7_4.Text += "SaveOther4 = " + ex.Message + "<br />";
            return false;
        }
        //finally { con.Close(); 

    }

    protected DataTable SearchOneArea4 (string ID) {
        SqlCommand cmd = new SqlCommand ();
        cmd.CommandText = @"SELECT [id]
                    ,[masterId]
                    ,[projectDescription]
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
                                                                        
                    FROM [EvaluateOther7_4] 

                    WHERE id =  @Id ";

        cmd.Parameters.AddWithValue ("@Id", ID);

        try {
            DataTable blacklistDT = db.ExecuteDataTable (cmd);
            return blacklistDT;
        } catch (Exception ex) {
            lblInError7_4.Text += "SaveOther4 = " + ex.Message + "<br />";
            return null;
        }
    }

    protected void btnEditOther_Click4 (object sender, EventArgs e) {

        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);
        if (ds != null && ds.Rows.Count > 0) {
            UpdatePanel7_4.Update ();
            popupAddOther7_4.Show ();
            hdf_OtherStatus4.Value = ds.Rows[0]["id"].ToString ();
            txtProjectDescription4.Text = ds.Rows[0]["projectDescription"].ToString ();
            txtdateNumber4.Text = ds.Rows[0]["dateNumber"].ToString ();

        }

    }

    protected void btnDeleteOther_Click4 (object sender, EventArgs e) {
        string sql;
        GridViewRow row = ((GridViewRow) ((LinkButton) sender).NamingContainer);
        string Id = gvData4.DataKeys[row.RowIndex]["id"].ToString ();
        DataTable ds = this.SearchOneArea4 (Id);

        if (ds != null && ds.Rows.Count > 0) {

            hdf_OtherStatus4.Value = ds.Rows[0]["id"].ToString ();
            sql = @"UPDATE EvaluateOther7_4  SET
                    projectStatus = 'D' WHERE id =  @Id";
            SqlCommand cmd1 = new SqlCommand ();
            cmd1.CommandText = sql;
            cmd1.Parameters.AddWithValue ("@Id", hdf_OtherStatus4.Value);
            db.ExecuteDataTable (cmd1);
            this.SearchData4 ();
        }
        string fileSrc;
        string fileDelete;
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
        string path = "Delete\\" + projectYear + "\\" + projectRound + "\\" + FullName + "\\tab7-4\\";
        string rootpath = Request.PhysicalApplicationPath;
        fileSrc = ds.Rows[0]["path"].ToString () + ds.Rows[0]["fileName"].ToString ();
        fileDelete = rootpath + path + ds.Rows[0]["fileName"].ToString ();
        File.Move (fileSrc, fileDelete);
        reader.Close ();
        con.Close ();
    }

    //##########################################################end 7_4 ################################################################
    //##################################################################################################################################
    //##################################################################################################################################

}