using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ClassLibrary;

public partial class AdminEvaluted : System.Web.UI.Page {
    Authorize A = new Authorize ();
    SqlConnection con = new SqlConnection ();
    protected string con_string = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;

    DataTable dtShowData;
    SortTable ST = new SortTable ();

    ConnectDB db = new ConnectDB ();

    protected void Page_Load (object sender, EventArgs e) {
        if (Session["AccountId"] == null || Session["AccountId"].ToString () == "" || Session["USERTYPE"].ToString () != "A" ) {
            Response.Redirect ("Account/Login.aspx");
        }

        if (!IsPostBack) {
            A.ActionLog ("ACCOUNTS", "", "View");
            dtShowData = new DataTable ();
            dtShowData = this.CreateTableShowData ();
            ViewState["dtShowData"] = dtShowData;
            this.SearchData ((DataTable) ViewState["dtShowData"]);
        }

    }
    private DataTable CreateTableShowData () {
        DataTable dtShowData = new DataTable ();

        ST.AddColToTable (dtShowData, "id", "System.String");
        ST.AddColToTable (dtShowData, "projectYear", "System.String");
        ST.AddColToTable (dtShowData, "projectRound", "System.String");
        ST.AddColToTable (dtShowData, "projectStatus", "System.String");
        ST.AddColToTable (dtShowData, "FullName", "System.String");
        ST.AddColToTable (dtShowData, "SUMALLSORE", "System.String");

        return dtShowData;
    }

    protected void btSearch_Click (object sender, EventArgs e) {
        //A.ActionLog("Receive", "", "Search");
        //btnSurveyAdd.Visible = true;
        this.SearchData ((DataTable) ViewState["dtShowData"]);
    }

    protected void SearchData (DataTable myTable) {
        string sql = @"Select M.id,C.projectYear, C.projectRound, C.projectStatus						,
						A.Title + A.FirstName+' '+A.LastName As FullName, E.SUMALLSORE
						From EvaluateMaster as M
						INNER JOIN ProjectControl as C ON C.id = M.roundId 
						INNER JOIN Account as A ON A.id = M.acountId 
						LEFT JOIN (select M.id , C.projectRound ,
                        (isnull(ES1_1.score1_1,0) + isnull(ES1_2.score1_2,0) + 
                        isnull(ES1_3.score1_3,0) + isnull(ES1_4.score1_4,0) + 
                        isnull(ES1_5.score1_5,0) + isnull(ES2_1.score2_1,0) +
                        isnull(ES2_2.score2_2,0) + isnull(ES2_3.score2_3,0) + 
                        isnull(ES2_4.score2_4,0) + isnull(ES2_5.score2_5,0) + 
                        isnull(ES2_6_1.score2_6_1,0) + isnull(ES2_6_2.score2_6_2,0)+ 
                        isnull(ES2_7.score2_7,0) + isnull(ES2_8.score2_8,0) + 
                        isnull(ES3_1.score3_1,0) + isnull(ES3_2.score3_2,0) + 
                        isnull(ES3_3.score3_3,0) + isnull(ES3_4.score3_4,0) + 
                        isnull(ES3_5.score3_5,0) + isnull(ES3_6.score3_6,0) +
                        isnull(Es3_7.score3_7,0) + isnull(ES3_8.score3_8,0) +
                        isnull(ES3_9.score3_9,0) + isnull(ES4_1.score4_1,0) + 
                        isnull(ES4_2.score4_2,0) + isnull(ES4_3.score4_3,0) +
                        isnull(ES4_4.score4_4,0) + isnull(ES4_5.score4_5,0) + 
                        isnull(ES4_6.score4_6,0) + isnull(ES5_1.score5_1,0) + 
                        isnull(ES5_2.score5_2,0) + isnull(ES5_3.score5_3,0) +
                        isnull(ES5_4.score5_4,0) + isnull(ES5_5.score5_5,0) + 
                        isnull(ES6_1_1.score6_1_1,0) + isnull(ES6_1_2.score6_1_2,0) + 
                        isnull(ES6_2.score6_2,0) + isnull(ES7_1.score7_1,0) + 
                        isnull(ES7_2.score7_2,0) + isnull(ES7_3.score7_3,0) +
                        isnull(ES7_4.score7_4,0)) AS SUMALLSORE
                        from EvaluateMaster AS M
                        
                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E1_1.masterId, SUM1_1.score1_1
                        FROM EvaluateSevice1_1 AS E1_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E1_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score1_1
                            FROM EvaluateSevice1_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM1_1 ON E1_1.masterId = SUM1_1.masterId
                        WHERE M.acountId = E1_1.createdBy)as ES1_1 on M.id = ES1_1.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E1_2.masterId, SUM1_2.score1_2
                        FROM EvaluateSevice1_2 AS E1_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E1_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score1_2
                            FROM EvaluateSevice1_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM1_2 ON E1_2.masterId = SUM1_2.masterId
                        WHERE M.acountId = E1_2.createdBy) as ES1_2 on  M.id = ES1_2.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E1_3.masterId, SUM1_3.score1_3
                        FROM EvaluateSevice1_3 AS E1_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E1_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score1_3
                            FROM EvaluateSevice1_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM1_3 ON E1_3.masterId = SUM1_3.masterId
                        WHERE M.acountId = E1_3.createdBy)as ES1_3 on  M.id = ES1_3.masterId 


                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E1_4.masterId, SUM1_4.score1_4
                        FROM EvaluateSevice1_4 AS E1_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E1_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score1_4
                            FROM EvaluateSevice1_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM1_4 ON E1_4.masterId = SUM1_4.masterId
                        WHERE M.acountId = E1_4.createdBy)as ES1_4 on  M.id = ES1_4.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E1_5.masterId, SUM1_5.score1_5
                        FROM EvaluateSevice1_5 AS E1_5
                        INNER JOIN EvaluateMaster AS M ON M.id = E1_5.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score1_5
                            FROM EvaluateSevice1_5
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM1_5 ON E1_5.masterId = SUM1_5.masterId
                        WHERE M.acountId = E1_5.createdBy)as ES1_5 on M.id = ES1_5.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_1.masterId, SUM2_1.score2_1
                        FROM EvaluateDevelopMainten2_1 AS E2_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_1
                            FROM EvaluateDevelopMainten2_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_1 ON E2_1.masterId = SUM2_1.masterId
                        WHERE M.acountId = E2_1.createdBy )as ES2_1 on M.id = ES2_1.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_2.masterId, SUM2_2.score2_2
                        FROM EvaluateDevelopMainten2_2 AS E2_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_2
                            FROM EvaluateDevelopMainten2_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_2 ON E2_2.masterId = SUM2_2.masterId
                        WHERE M.acountId = E2_2.createdBy )as ES2_2 on M.id = ES2_2.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_3.masterId, SUM2_3.score2_3
                        FROM EvaluateDevelopMainten2_3 AS E2_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_3
                            FROM EvaluateDevelopMainten2_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_3 ON E2_3.masterId = SUM2_3.masterId
                        WHERE M.acountId = E2_3.createdBy)as ES2_3 on M.id = ES2_3.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_4.masterId, SUM2_4.score2_4
                        FROM EvaluateDevelopMainten2_4 AS E2_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_4
                            FROM EvaluateDevelopMainten2_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_4 ON E2_4.masterId = SUM2_4.masterId
                        WHERE M.acountId = E2_4.createdBy)as ES2_4 on M.id = ES2_4.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_5.masterId, SUM2_5.score2_5
                        FROM EvaluateDevelopMainten2_5 AS E2_5
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_5.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_5
                            FROM EvaluateDevelopMainten2_5
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_5 ON E2_5.masterId = SUM2_5.masterId
                        WHERE M.acountId = E2_5.createdBy)as ES2_5 on M.id = ES2_5.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_6_1.masterId, SUM2_6_1.score2_6_1
                        FROM EvaluateDevelopMainten2_6_1 AS E2_6_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_6_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_6_1
                            FROM EvaluateDevelopMainten2_6_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_6_1 ON E2_6_1.masterId = SUM2_6_1.masterId
                        WHERE M.acountId = E2_6_1.createdBy)as ES2_6_1 on M.id = ES2_6_1.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_6_2.masterId, SUM2_6_2.score2_6_2
                        FROM EvaluateDevelopMainten2_6_2 AS E2_6_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_6_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_6_2
                            FROM EvaluateDevelopMainten2_6_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_6_2 ON E2_6_2.masterId = SUM2_6_2.masterId
                        WHERE M.acountId = E2_6_2.createdBy )as ES2_6_2 on  M.id = ES2_6_2.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_7.masterId, SUM2_7.score2_7
                        FROM EvaluateDevelopMainten2_7 AS E2_7
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_7.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_7
                            FROM EvaluateDevelopMainten2_7
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_7 ON E2_7.masterId = SUM2_7.masterId
                        WHERE M.acountId = E2_7.createdBy)as ES2_7 on M.id = ES2_7.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E2_8.masterId,SUM2_8.score2_8
                        FROM EvaluateDevelopMainten2_8 AS E2_8
                        INNER JOIN EvaluateMaster AS M ON M.id = E2_8.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score2_8
                            FROM EvaluateDevelopMainten2_8
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM2_8 ON E2_8.masterId = SUM2_8.masterId
                        WHERE M.acountId = E2_8.createdBy)as ES2_8 on M.id = ES2_8.masterId 

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_1.masterId, SUM3_1.score3_1
                        FROM EvaluateResearch3_1 AS E3_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_1
                            FROM EvaluateResearch3_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_1 ON E3_1.masterId = SUM3_1.masterId
                        WHERE M.acountId = E3_1.createdBy )as ES3_1 on  M.id = ES3_1.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_2.masterId, SUM3_2.score3_2
                        FROM EvaluateResearch3_2 AS E3_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_2
                            FROM EvaluateResearch3_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_2 ON E3_2.masterId = SUM3_2.masterId
                        WHERE M.acountId = E3_2.createdBy)as ES3_2 on  M.id = ES3_2.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_3.masterId, SUM3_3.score3_3
                        FROM EvaluateResearch3_3 AS E3_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_3
                            FROM EvaluateResearch3_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_3 ON E3_3.masterId = SUM3_3.masterId
                        WHERE M.acountId = E3_3.createdBy)as ES3_3 on  M.id = ES3_3.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_4.masterId, SUM3_4.score3_4
                        FROM EvaluateResearch3_4 AS E3_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_4
                            FROM EvaluateResearch3_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_4 ON E3_4.masterId = SUM3_4.masterId
                        WHERE M.acountId = E3_4.createdBy)as ES3_4 on  M.id = ES3_4.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_5.masterId, SUM3_5.score3_5
                        FROM EvaluateResearch3_5 AS E3_5
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_5.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_5
                            FROM EvaluateResearch3_5
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_5 ON E3_5.masterId = SUM3_5.masterId
                        WHERE M.acountId = E3_5.createdBy)as ES3_5 on  M.id = ES3_5.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_6.masterId, SUM3_6.score3_6
                        FROM EvaluateResearch3_6 AS E3_6
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_6.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_6
                            FROM EvaluateResearch3_6
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_6 ON E3_6.masterId = SUM3_6.masterId
                        WHERE M.acountId = E3_6.createdBy)as ES3_6 on  M.id = ES3_6.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_7.masterId, SUM3_7.score3_7
                        FROM EvaluateResearch3_7 AS E3_7
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_7.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_7
                            FROM EvaluateResearch3_7
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_7 ON E3_7.masterId = SUM3_7.masterId
                        WHERE M.acountId = E3_7.createdBy)as ES3_7 on  M.id = ES3_7.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_8.masterId, SUM3_8.score3_8
                        FROM EvaluateResearch3_8 AS E3_8
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_8.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_8
                            FROM EvaluateResearch3_8
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_8 ON E3_8.masterId = SUM3_8.masterId
                        WHERE M.acountId = E3_8.createdBy )as ES3_8 on  M.id = ES3_8.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E3_9.masterId, SUM3_9.score3_9
                        FROM EvaluateResearch3_9 AS E3_9
                        INNER JOIN EvaluateMaster AS M ON M.id = E3_9.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score3_9
                            FROM EvaluateResearch3_9
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM3_9 ON E3_9.masterId = SUM3_9.masterId
                        WHERE M.acountId = E3_9.createdBy)as ES3_9 on  M.id = ES3_9.masterId


                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_1.masterId,  SUM4_1.score4_1
                        FROM EvaluatePromotionWork4_1 AS E4_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_1
                            FROM EvaluatePromotionWork4_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_1 ON E4_1.masterId = SUM4_1.masterId
                        WHERE M.acountId = E4_1.createdBy)as ES4_1 on  M.id = ES4_1.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_2.masterId,SUM4_2.score4_2
                        FROM EvaluatePromotionWork4_2 AS E4_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_2
                            FROM EvaluatePromotionWork4_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_2 ON E4_2.masterId = SUM4_2.masterId
                        WHERE M.acountId = E4_2.createdBy)as ES4_2 on  M.id = ES4_2.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_3.masterId, SUM4_3.score4_3
                        FROM EvaluatePromotionWork4_3 AS E4_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_3
                            FROM EvaluatePromotionWork4_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_3 ON E4_3.masterId = SUM4_3.masterId
                        WHERE M.acountId = E4_3.createdBy)as ES4_3 on  M.id = ES4_3.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_4.masterId, SUM4_4.score4_4
                        FROM EvaluatePromotionWork4_4 AS E4_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_4
                            FROM EvaluatePromotionWork4_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_4 ON E4_4.masterId = SUM4_4.masterId
                        WHERE M.acountId = E4_4.createdBy)as ES4_4 on  M.id = ES4_4.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_5.masterId, SUM4_5.score4_5
                        FROM EvaluatePromotionWork4_5 AS E4_5
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_5.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_5
                            FROM EvaluatePromotionWork4_5
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_5 ON E4_5.masterId = SUM4_5.masterId
                        WHERE M.acountId = E4_5.createdBy)as ES4_5 on  M.id = ES4_5.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E4_6.masterId,SUM4_6.score4_6
                        FROM EvaluatePromotionWork4_6 AS E4_6
                        INNER JOIN EvaluateMaster AS M ON M.id = E4_6.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score4_6
                            FROM EvaluatePromotionWork4_6
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM4_6 ON E4_6.masterId = SUM4_6.masterId
                        WHERE M.acountId = E4_6.createdBy)as ES4_6 on  M.id = ES4_6.masterId


                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E5_1.masterId, SUM5_1.score5_1
                        FROM EvaluateAcademicServices5_1 AS E5_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E5_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score5_1
                            FROM EvaluateAcademicServices5_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM5_1 ON E5_1.masterId = SUM5_1.masterId
                        WHERE M.acountId = E5_1.createdBy )as ES5_1 on  M.id = ES5_1.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E5_2.masterId, SUM5_2.score5_2
                        FROM EvaluateAcademicServices5_2 AS E5_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E5_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score5_2
                            FROM EvaluateAcademicServices5_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM5_2 ON E5_2.masterId = SUM5_2.masterId
                        WHERE M.acountId = E5_2.createdBy )as ES5_2 on  M.id = ES5_2.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E5_3.masterId, SUM5_3.score5_3
                        FROM EvaluateAcademicServices5_3 AS E5_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E5_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score5_3
                            FROM EvaluateAcademicServices5_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM5_3 ON E5_3.masterId = SUM5_3.masterId
                        WHERE M.acountId = E5_3.createdBy)as ES5_3 on  M.id = ES5_3.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E5_4.masterId,  SUM5_4.score5_4
                        FROM EvaluateAcademicServices5_4 AS E5_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E5_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score5_4
                            FROM EvaluateAcademicServices5_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM5_4 ON E5_4.masterId = SUM5_4.masterId
                        WHERE M.acountId = E5_4.createdBy )as ES5_4 on  M.id = ES5_4.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E5_5.masterId, SUM5_5.score5_5
                        FROM EvaluateAcademicServices5_5 AS E5_5
                        INNER JOIN EvaluateMaster AS M ON M.id = E5_5.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score5_5
                            FROM EvaluateAcademicServices5_5
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM5_5 ON E5_5.masterId = SUM5_5.masterId
                        WHERE M.acountId = E5_5.createdBy)as ES5_5 on  M.id = ES5_5.masterId

                        
                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E6_1_1.masterId, SUM6_1_1.score6_1_1
                        FROM EvaluateManagement6_1_1 AS E6_1_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E6_1_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score6_1_1
                            FROM EvaluateManagement6_1_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM6_1_1 ON E6_1_1.masterId = SUM6_1_1.masterId
                        WHERE M.acountId = E6_1_1.createdBy)as ES6_1_1 on  M.id = ES6_1_1.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E6_1_2.masterId, SUM6_1_2.score6_1_2
                        FROM EvaluateManagement6_1_2 AS E6_1_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E6_1_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score6_1_2
                            FROM EvaluateManagement6_1_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM6_1_2 ON E6_1_2.masterId = SUM6_1_2.masterId
                        WHERE M.acountId = E6_1_2.createdBy)as ES6_1_2 on  M.id = ES6_1_2.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E6_2.masterId, SUM6_2.score6_2
                        FROM EvaluateManagement6_2 AS E6_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E6_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score6_2
                            FROM EvaluateManagement6_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM6_2 ON E6_2.masterId = SUM6_2.masterId
                        WHERE M.acountId = E6_2.createdBy )as ES6_2 on  M.id = ES6_2.masterId

                        
                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E7_1.masterId,SUM7_1.score7_1
                        FROM EvaluateOther7_1 AS E7_1
                        INNER JOIN EvaluateMaster AS M ON M.id = E7_1.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score7_1
                            FROM EvaluateOther7_1
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM7_1 ON E7_1.masterId = SUM7_1.masterId
                        WHERE M.acountId = E7_1.createdBy )as ES7_1 on  M.id = ES7_1.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E7_2.masterId,  SUM7_2.score7_2
                        FROM EvaluateOther7_2 AS E7_2
                        INNER JOIN EvaluateMaster AS M ON M.id = E7_2.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score7_2
                            FROM EvaluateOther7_2
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM7_2 ON E7_2.masterId = SUM7_2.masterId
                        WHERE M.acountId = E7_2.createdBy )as ES7_2 on  M.id = ES7_2.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E7_3.masterId, SUM7_3.score7_3
                        FROM EvaluateOther7_3 AS E7_3
                        INNER JOIN EvaluateMaster AS M ON M.id = E7_3.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score7_3
                            FROM EvaluateOther7_3
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM7_3 ON E7_3.masterId = SUM7_3.masterId
                        WHERE M.acountId = E7_3.createdBy )as ES7_3 on  M.id = ES7_3.masterId

                        LEFT JOIN 
                        (SELECT DISTINCT M.id, E7_4.masterId,  SUM7_4.score7_4
                        FROM EvaluateOther7_4 AS E7_4
                        INNER JOIN EvaluateMaster AS M ON M.id = E7_4.masterId 
                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        INNER JOIN 
                            (SELECT masterId,sum(projectScore) as score7_4
                            FROM EvaluateOther7_4
                            WHERE projectStatus = 'A'
                            GROUP BY masterId) AS  SUM7_4 ON E7_4.masterId = SUM7_4.masterId
                        WHERE M.acountId = E7_4.createdBy )as ES7_4 on  M.id = ES7_4.masterId


                        INNER JOIN Account AS A ON A.id = M.acountId
                        INNER JOIN ProjectControl AS C ON C.id = M.roundId
                        ) as E ON E.projectRound = C.projectRound

                        where M.evaluateStatus = 'W' AND C.projectStatus = 'A'";

        string prefix = " AND ";

        if (txtRound.Text != "") {
            sql += prefix + "projectRound LIKE @projectRound ";
            prefix = " AND ";
        }
        if (txtYear.Text != "") {
            sql += prefix + "projectYear LIKE @ProjectYear ";
            prefix = " AND ";
        }

        sql += "ORDER BY projectYear DESC ";

        con.ConnectionString = con_string;
        SqlCommand cmd = new SqlCommand (sql, con);

        try {
            if (txtRound.Text != "") {
                cmd.Parameters.AddWithValue ("@projectRound", "%" + txtRound.Text.Trim () + "%");
            }
            if (txtYear.Text != "") {
                cmd.Parameters.AddWithValue ("@ProjectYear", "%" + txtYear.Text.Trim () + "%");
            }

            if (con.State == ConnectionState.Open) {
                con.Close ();
            }
            con.Open ();

            SqlDataAdapter da = new SqlDataAdapter (cmd);
            DataSet ds = new DataSet ();
            da.Fill (ds, "Data");
            con.Close ();
            myTable.Rows.Clear ();

            for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++) {
                
                string id = ds.Tables["Data"].Rows[i]["id"].ToString ();
                string projectYear = ds.Tables["Data"].Rows[i]["projectYear"].ToString ();
                string projectRound = ds.Tables["Data"].Rows[i]["projectRound"].ToString ();
                string projectStatus = ds.Tables["Data"].Rows[i]["projectStatus"].ToString ();
                string FullName = ds.Tables["Data"].Rows[i]["FullName"].ToString ();
                string SUMALLSORE = ds.Tables["Data"].Rows[i]["SUMALLSORE"].ToString ();

                DataRow row = myTable.NewRow ();

                row["id"] = id;
                row["projectYear"] = projectYear;
                row["projectRound"] = projectRound;
                row["projectStatus"] = projectStatus;
                row["FullName"] = FullName;
                row["SUMALLSORE"] = SUMALLSORE;

                myTable.Rows.Add (row);
            }

            gvData.DataSource = myTable.DefaultView;
            gvData.DataBind ();
            lblRecord.Text = "<span Font-Size='Small' class='tex12b'>Search Result :</span><span style='color:Red'> " + ds.Tables["Data"].Rows.Count.ToString ("#,###") + " Record(s)</span>";
        } catch (Exception ex) {
            lblError.Text += "SearchData = " + ex.Message + "<br />";
        } finally { con.Close (); }
    }

    protected void btReset_Click (object sender, EventArgs e) {
        txtYear.Text = "";
        txtRound.Text = "";
        UpdatePanel.Visible = false;
        Response.Redirect ("Manage_Round_Search.aspx");
    }

    protected void bt_ViewData_Click (object sender, EventArgs e) {
        GridViewRow row = ((GridViewRow) ((Button) sender).NamingContainer);
        string rId = gvData.DataKeys[row.RowIndex]["id"].ToString ();
        //string rId = Request.QueryString["nId"];
        Response.Redirect ("Evaluate_Summary.aspx?nID=" + rId);
    }

    protected void gvData_Sorting (object sender, GridViewSortEventArgs e) {
        SortDirection SD = GridviewSortDirection;
        GridviewSortDirection = ST.GridviewSorting (sender, e, (DataTable) ViewState["dtShowData"], SD);
    }

    protected void gvData_PageIndexChanging (object sender, GridViewPageEventArgs e) {
        gvData.DataSource = ((DataTable) ViewState["dtShowData"]).DefaultView;
        gvData.PageIndex = e.NewPageIndex;
        gvData.DataBind ();
    }
    protected void gvData_SelectedIndexChanged (object sender, EventArgs e) {

    }

    protected void gvData_RowDataBound (object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String ProjectStatus = Convert.ToString (((HiddenField) e.Row.FindControl ("hdf_ProjectStatus")).Value);

            if (ProjectStatus == "C") {
                e.Row.FindControl ("bt_EditRound").Visible = false;
                e.Row.FindControl ("bt_ViewRound").Visible = true;
            } else {

            }
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

    protected void txtProjectName_TextChanged (object sender, EventArgs e) {

    }

    protected void txtYear_TextChanged (object sender, EventArgs e) {

    }

    protected void btnSurveyAdd_Click (object sender, EventArgs e) {
        Response.Redirect ("Manage_Round_Add.aspx");
    }
}