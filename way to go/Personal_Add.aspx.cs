using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using ClassLibrary;

public partial class Personal_Add : System.Web.UI.Page
{
    Authorize A = new Authorize();
    tipFormatText FT = new tipFormatText();
    ConnectDB db = new ConnectDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT_ID"] == null || Session["ACCOUNT_ID"].ToString() == "")
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            ddlCountry.SelectedValue = "156";
            ViewState["dtImageData"] = this.CreateTableImage();
        }
    }

    private DataTable CreateTableImage()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("FileName", typeof(string));
        dt.Columns.Add("FilePath", typeof(string));
        dt.Columns.Add("MediaID", typeof(string));
        dt.Columns.Add("MediaType", typeof(string));
        dt.Columns.Add("Description", typeof(string));
        return dt;
    }


    protected void SaveAllImages(DataTable myTable, string PERSON_ID)
    {
        PersonalIdentity_DataSetTableAdapters.IMAGETableAdapter img_dta = new PersonalIdentity_DataSetTableAdapters.IMAGETableAdapter();
        string rootpath = Request.PhysicalApplicationPath;
        string pathSrc = rootpath + "database\\upload_files\\temp\\";
        string pathDes = rootpath + "database\\upload_files\\profile_pic\\";
        string fileSrc = "";
        string fileDes = "";
        string NewFileName;

        for (int i = 0; i < myTable.Rows.Count; i++)
        {
            NewFileName = PERSON_ID + "_" + myTable.Rows[i]["FileName"];
            fileSrc = pathSrc + myTable.Rows[i]["FileName"];
            fileDes = pathDes + NewFileName;
            File.Move(fileSrc, fileDes);
            img_dta.Insert(int.Parse(PERSON_ID), int.Parse(myTable.Rows[i]["MediaID"].ToString()), "database\\upload_files\\profile_pic\\", NewFileName, "Y", int.Parse(Session["ACCOUNT_ID"].ToString()));
        }
    }

    protected void ButtonUploadDeparture_Click(object sender, EventArgs e)
    {
        string rootpath = Request.PhysicalApplicationPath;
        string path = rootpath + "database\\upload_files\\temp\\";
        bool CheckLength = true;
        bool CheckType = true;
        bool CheckExist = true;

        lblUploadStatus.Text = "";

        if (fuUploadImg.HasFile)
        {
            //Check File length not over than 300k
            if (fuUploadImg.PostedFile.ContentLength >= 307200)
            {
                lblUploadStatus.Text += "File (" + fuUploadImg.FileName + "[" + (fuUploadImg.PostedFile.ContentLength / 1024).ToString() + "Kbyte.]) size over than 300Kbyte!!<br />";
                CheckLength = false;
            }

            //Check File extention must be (.jpg, .jpeg)
            if (fuUploadImg.PostedFile.ContentType != "image/pjpeg" && fuUploadImg.PostedFile.ContentType != "image/jpeg")
            {
                lblUploadStatus.Text += "File (" + fuUploadImg.FileName + ") extention must be (.jpg, .jpeg)!!<br />";
                CheckType = false;
            }

            //Check File name already exist
            if (File.Exists(path + fuUploadImg.FileName))
            {
                lblUploadStatus.Text += "File (" + fuUploadImg.FileName + ") name already exist!! Please, rename your file.<br />";
                CheckExist = false;
            }

            bool CheckFileName = false;
            //Check File name
            if (FT.CheckFileNameSpace(fuUploadImg.FileName, lblUploadStatus))
            {
                CheckFileName = true;
            }
            else
            {
                //lblUploadStatusDeparture.Text += "File name not allow { ! @ # $ % ^ & = , ' ; space }!!<br/> Please, rename your file.<br />";
                CheckFileName = false;
            }

            //All Check complete
            if (CheckLength == true && CheckType == true && CheckExist == true && CheckFileName == true)
            {
                string NewName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fuUploadImg.FileName.Replace(" ", "-");
                string PicP = path + NewName;
                fuUploadImg.SaveAs(PicP);
                lblUploadStatus.Text = "File (" + fuUploadImg.FileName + ") uploaded.";

                this.AddImage((DataTable)ViewState["dtImageData"], NewName, txtUploadDescription.Text.Trim().Replace(Environment.NewLine, " "), ddl_img_type.SelectedValue.ToString(), ddl_img_type.SelectedItem.ToString());
            }
        }
        else
        {
            lblUploadStatus.Text = "";
        }

    }

    protected void AddImage(DataTable myTable, string FileName, string Description, string mediaID, string mediatype)
    {
        DataRow row;
        row = myTable.NewRow();

        row["FileName"] = FileName;
        row["FilePath"] = "database/upload_files/temp/" + FileName;
        row["MediaID"] = mediaID;
        row["MediaType"] = mediatype;
        row["Description"] = Description;

        myTable.Rows.Add(row);
        this.BindImage(myTable, gvData);
    }

    protected void BindImage(DataTable myTable, GridView gv)
    {
        gv.DataSource = myTable.DefaultView;
        gv.DataBind();

        if (myTable.Rows.Count > 0)
        {
            btnSubmit1.Enabled = true;
        }
        else
        {
            btnSubmit1.Enabled = false;
        }
    }


    protected void SetDDLYear(DropDownList ddl, int StartYear, int EndYear)
    {
        ddl.Items.Add(new ListItem("- เลือก -", "-"));
        if (StartYear < EndYear)
        {
            for (int i = StartYear; i <= EndYear; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
            }
        }
        else if (StartYear > EndYear)
        {
            for (int i = StartYear; i >= EndYear; i--)
            {
                ddl.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
            }
        }
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem list = new ListItem("- เลือก -", "0");

        if (ddlRegion.SelectedValue != "0")
        {
            ddlState.Items.Clear();
            ddlState.Items.Add(list);
            ddlState.DataBind();
            ddlState.Enabled = true;

            ddlCity.Items.Clear();
            ddlCity.Items.Add(list);
            ddlCity.Enabled = false;

            ddlTumbon.Items.Clear();
            ddlTumbon.Items.Add(list);
            ddlTumbon.Enabled = false;
        }
        else
        {
            ddlState.Items.Clear();
            ddlState.Items.Add(list);
            ddlState.Enabled = false;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem list = new ListItem("- เลือก -", "0");

        if (ddlState.SelectedValue != "0")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add(list);
            ddlCity.DataBind();
            ddlCity.Enabled = true;

            ddlTumbon.Items.Clear();
            ddlTumbon.Items.Add(list);
            ddlTumbon.Enabled = false;
        }
        else
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add(list);
            ddlCity.Enabled = false;
        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem list = new ListItem("- เลือก -", "0");

        if (ddlCity.SelectedValue != "0")
        {
            ddlTumbon.Items.Clear();
            ddlTumbon.Items.Add(list);
            ddlTumbon.DataBind();
            ddlTumbon.Enabled = true;
        }
        else
        {
            ddlTumbon.Items.Clear();
            ddlTumbon.Items.Add(list);
            ddlTumbon.Enabled = false;
        }
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.DataSource = ((DataTable)ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind();
    }

    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            char[] arr = (DataBinder.Eval(e.Row.DataItem, "IsDup").ToString()).ToCharArray();

            if (arr[0] == '1')
            {
                e.Row.Cells[1].ForeColor = Color.Red;
                e.Row.Cells[1].Font.Bold = true;
            }

            if (arr[1] == '1')
            {
                e.Row.Cells[4].ForeColor = Color.Red;
                e.Row.Cells[4].Font.Bold = true;
            }

            if (arr[2] == '1')
            {
                e.Row.Cells[5].ForeColor = Color.Red;
                e.Row.Cells[5].Font.Bold = true;
            }

            if (arr[3] == '1')
            {
                e.Row.Cells[6].ForeColor = Color.Red;
                e.Row.Cells[6].Font.Bold = true;
            }

            if (arr[4] == '1')
            {
                e.Row.Cells[7].ForeColor = Color.Red;
                e.Row.Cells[7].Font.Bold = true;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Personal_Search.aspx");
    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        if (radSSDType.SelectedValue == "1" && !this.CheckPID(FT.CutInvalidChar(txtSSD.Text)))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_InsertSuccess", "alert('ข้อมูลเลขบัตร ปชช. ไม่ถูกต้อง กรุณาตรวจสอบความถูกต้องอีกครั้ง');", true);
        }
        else
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"if not exists (SELECT * FROM PERSONALS WHERE PERSON_SSD = @PERSON_SSD)
begin
INSERT INTO [dbo].[PERSONALS]
           ([PERSION_SSD_TYPE]
           ,[PERSON_SSD]
           ,[TITLE_ID]
           ,[TITLE_OTHER]
           ,[FIRSTNAME]
           ,[LASTNAME]
           ,[BIRTHDAY]
           ,[EDUCATION]
           ,[WORKGROUP_ID]
           ,[POSITION]
           ,[WORKTIME_TYPE]
           ,[WORKTIME_DETAIL]
           ,[CONTRACTOR_ID]
           ,[CREATED_DATE]
           ,[CREATED_BY])
     VALUES
           (@PERSION_SSD_TYPE
           ,@PERSON_SSD
           ,@TITLE_ID
           ,@TITLE_OTHER
           ,@FIRSTNAME
           ,@LASTNAME
           ,@BIRTHDAY
           ,@EDUCATION
           ,@WORKGROUP_ID
           ,@POSITION
           ,@WORKTIME_TYPE
           ,@WORKTIME_DETAIL
           ,@CONTRACTOR_ID
           ,GETDATE()
           ,@CREATED_BY);
SELECT SCOPE_IDENTITY();
end
else
begin
select(0);
end";

            command.Parameters.AddWithValue("PERSION_SSD_TYPE", radSSDType.SelectedValue);
            command.Parameters.AddWithValue("PERSON_SSD", txtSSD.Text);
            command.Parameters.AddWithValue("TITLE_ID", radTitle.SelectedValue);
            command.Parameters.AddWithValue("TITLE_OTHER", txtTitle.Text);
            command.Parameters.AddWithValue("FIRSTNAME", txtFirstname.Text);
            command.Parameters.AddWithValue("LASTNAME", txtLastname.Text);
            command.Parameters.AddWithValue("BIRTHDAY", txtBirthday.Text);
            command.Parameters.AddWithValue("EDUCATION", txtEducation.Text);
            command.Parameters.AddWithValue("WORKGROUP_ID", int.Parse(ddlWorkgroup.SelectedValue));
            command.Parameters.AddWithValue("POSITION", txtPosition.Text);
            command.Parameters.AddWithValue("WORKTIME_TYPE", radWorkTimeType.SelectedValue);
            command.Parameters.AddWithValue("WORKTIME_DETAIL", txtWorkTimeDetail.Text);
            command.Parameters.AddWithValue("CONTRACTOR_ID", int.Parse(ddlContracter.SelectedValue));
            command.Parameters.AddWithValue("CREATED_BY", int.Parse(Session["ACCOUNT_ID"].ToString()));

            object execResult = db.ExecuteScalar(command);
            if (execResult.ToString() == "0")
            {
                //ข้อมูลซ้ำ
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('ข้อมูลซ้ำ');", true);
            }
            else if (execResult.ToString() == "-1")
            {
                //error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('ไม่สามารถบันทึกข้อมูลได้');", true);
            }
            else
            {
                command.Parameters.Clear();
                command.CommandText = @"
INSERT INTO [dbo].[PERSONAL_ADDRESS]
           ([PERSON_ID]
           ,[ADDRESS]
           ,[STREET]
           ,[BUILDING]
           ,[FLOOR]
           ,[DISTRICT_ID]
           ,[AMPHUR_ID]
           ,[PROVINCE_ID]
           ,[REGION_ID]
           ,[POSTCODE]
           ,[COUNTRY_ID]
           ,[ADDRESS_TYPE])
     VALUES
           (@PERSON_ID
           ,@ADDRESS
           ,@STREET
           ,@BUILDING
           ,@FLOOR
           ,@DISTRICT_ID
           ,@AMPHUR_ID
           ,@PROVINCE_ID
           ,@REGION_ID
           ,@POSTCODE
           ,@COUNTRY_ID
           ,1)";

                command.Parameters.AddWithValue("@PERSON_ID", int.Parse(execResult.ToString()));
                command.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);
                command.Parameters.AddWithValue("@STREET", txtStreet.Text);
                command.Parameters.AddWithValue("@BUILDING", txtBuilding.Text);
                command.Parameters.AddWithValue("@FLOOR", txtFloor.Text);
                command.Parameters.AddWithValue("@DISTRICT_ID", int.Parse(ddlTumbon.SelectedValue));
                command.Parameters.AddWithValue("@AMPHUR_ID", int.Parse(ddlCity.SelectedValue));
                command.Parameters.AddWithValue("@PROVINCE_ID", int.Parse(ddlState.SelectedValue));
                command.Parameters.AddWithValue("@REGION_ID", int.Parse(ddlRegion.SelectedValue));
                command.Parameters.AddWithValue("@POSTCODE", txtPostcode.Text);
                command.Parameters.AddWithValue("@COUNTRY_ID", int.Parse(ddlCountry.SelectedValue));

                db.ExecuteNonQuery(command);

                this.SaveAllImages((DataTable)ViewState["dtImageData"], execResult.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('บันทึกสำเร็จ'); location.href='Report_Search.aspx';", true);
            }
        }
    }

    protected void SavePersonPic(string PERSON_ID, string IMAGE_PATH, string IMAGE_NAME)
    {
        string sql = @"UPDATE PERSONALS SET IMAGE_PATH = @IMAGE_PATH, IMAGE_NAME = @IMAGE_NAME WHERE PERSON_ID = @PERSON_ID";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@PERSON_ID", int.Parse(PERSON_ID));
        cmd.Parameters.AddWithValue("@IMAGE_PATH", IMAGE_PATH);
        cmd.Parameters.AddWithValue("@IMAGE_NAME", IMAGE_NAME);
        db.ExecuteNonQuery(cmd);
    }

    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveImg")
        {
            int RowNo = Convert.ToInt32(e.CommandArgument);
            this.DeleteImage((DataTable)ViewState["dtImageData"], RowNo);
        }
    }

    protected void DeleteImage(DataTable myTable, int RowNo)
    {
        string FilePath = myTable.Rows[RowNo]["FilePath"].ToString();
        myTable.Rows[RowNo].Delete();
        File.Delete(Request.PhysicalApplicationPath + FilePath);

        this.BindImage(myTable, gvData);
    }

    protected bool CheckPID(string pid)
    {
        if (pid[0].ToString() != "9")
        {
            int sum = 0;

            /* x13, x12, x11, ... */
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(pid[i].ToString()) * (13 - i);
            }

            /* complements(12, sum mod 11) */
            return int.Parse(pid[12].ToString()) == ((11 - (sum % 11)) % 10);
        }
        else
        {
            return false;
        }
    }

    protected void radTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radTitle.SelectedValue == "4")
        {
            txtTitle.Enabled = true;
        }
        else
        {
            txtTitle.Enabled = false;
        }
    }

    protected void radSSDType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radSSDType.SelectedValue == "1" || radSSDType.SelectedValue == "2")
        {
            txtSSD_FilteredTextBoxExtender.Enabled = true;
        }
        else
        {
            txtSSD_FilteredTextBoxExtender.Enabled = false;
        }
    }
}