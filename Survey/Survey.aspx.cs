using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ClassLibrary;
using System.Data;


public partial class Survey : Page
{
    ConnectDB db = new ConnectDB();
    FormatText FT = new FormatText();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    

    protected void Next_Click(object sender, EventArgs e)
    {
        string TempId = "0";

        SqlCommand command = new SqlCommand();
        command.CommandText = @"if not exists (SELECT * FROM SurveyTemp WHERE TempId = @TempId)
                                begin
                                    insert into SurveyTemp(Sex, Age, Position, PositionOther, Education)
                                    values(@Sex, @Age, @Position, @PositionOther, @Education);
                                    Select @@Identity ;
                                end
                                else
                                    begin
                                    select (0);
                                end";

        command.Parameters.AddWithValue("@TempId", TempId);
        command.Parameters.AddWithValue("@Sex", FT.CutInvalidChar(radSex.SelectedValue));
        command.Parameters.AddWithValue("@Age", FT.CutInvalidChar(radAge.SelectedValue));
        command.Parameters.AddWithValue("@Position", FT.CutInvalidChar(radPosition.SelectedValue));
        command.Parameters.AddWithValue("@Education", FT.CutInvalidChar(radEducation.SelectedValue));

        object execResult = db.ExecuteScalar(command);

        string SId = execResult.ToString();
        Response.Redirect("Strength.aspx?nID=" + SId);
    }
    
}