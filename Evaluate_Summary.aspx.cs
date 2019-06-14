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
        string sql = @"select M.id ,
				A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName ,
				C.projectYear, C.projectRound , A.Position,  A.Department, ES1_1.createdBy ,
                 convert(varchar, C.dateStart, 106) AS dateStart, convert(varchar, C.dateEnd, 106) as dateEnd,

				'1. งานให้บริการ (ภาควิชาการ, ภาคอุตสาหกรรม)' as Es1_1, 				
				isnull(ES1_1.score1_1,0) AS score1_1 ,isnull(ES1_2.score1_2,0) as score1_2, 
				isnull(ES1_3.score1_3,0) as score1_3,isnull(ES1_4.score1_4,0) as score1_4,
                isnull(ES1_5.score1_5,0) as score1_5,
				(isnull(ES1_1.score1_1,0) + isnull(ES1_2.score1_2,0) + isnull(ES1_3.score1_3,0) + 
                isnull(ES1_4.score1_4,0) + isnull(ES1_5.score1_5,0)) AS sumscore,

                '2. งานพัฒนาและบำรุงรักษาระบบลำเลียงแสง หรือสถานีทดลอง หรือห้องปฏิบัติการต่าง ๆ (Development and Maintenance)' as Es2_1,
                isnull(ES2_1.score2_1,0) AS score2_1,isnull(ES2_2.score2_2,0) AS score2_2, 
                isnull(ES2_3.score2_3,0) AS score2_3, isnull(ES2_4.score2_4,0) AS score2_4,
				 isnull(ES2_5.score2_5,0) AS score2_5, isnull(ES2_6_1.score2_6_1,0) AS score2_6_1, 
                 isnull(ES2_6_2.score2_6_2,0) AS score2_6_2, 
				 isnull(ES2_7.score2_7,0) AS score2_7, isnull(ES2_8.score2_8,0) AS score2_8,    
                 (isnull(ES2_6_1.score2_6_1,0)+ isnull(ES2_6_2.score2_6_2,0)) AS score2_6,       
                (isnull(ES2_1.score2_1,0) +isnull(ES2_2.score2_2,0) + isnull(ES2_3.score2_3,0)+ 
                isnull(ES2_4.score2_4,0)+ isnull(ES2_5.score2_5,0)+ 
				isnull(ES2_6_1.score2_6_1,0)+ isnull(ES2_6_2.score2_6_2,0)+ 
                isnull(ES2_7.score2_7,0)+ isnull(ES2_8.score2_8,0)) AS sumscore2,

                '3. งานวิจัย (ภาควิชาการ, ภาคอุตสาหกรรม)' as Es3_1, 
                isnull(ES3_1.score3_1,0) as score3_1 ,isnull(ES3_2.score3_2,0) as score3_2, 
				isnull(ES3_3.score3_3,0) AS score3_3, isnull(ES3_4.score3_4,0) as score3_4 ,
				isnull(ES3_5.score3_5,0) as score3_5, isnull(ES3_6.score3_6,0) as score3_6 ,
				isnull(Es3_7.score3_7,0) as score3_7 , isnull(ES3_8.score3_8,0) as score3_8 ,
				 isnull(ES3_9.score3_9,0) as score3_9,
                (isnull(ES3_1.score3_1,0) + isnull(ES3_2.score3_2,0) + isnull(ES3_3.score3_3,0)+
				isnull(ES3_4.score3_4,0)+ isnull(ES3_5.score3_5,0) + isnull(ES3_6.score3_6,0) +
				isnull(Es3_7.score3_7,0) + isnull(ES3_8.score3_8,0)+
				 isnull(ES3_9.score3_9,0) ) AS sumscore3,

                '4. งานส่งเสริมการใช้ประโยชน์แสงซินโครตรอน' as Es4_1, 
                isnull(ES4_1.score4_1,0) as score4_1 ,isnull(ES4_2.score4_2,0) as score4_2, 
				isnull(ES4_3.score4_3,0) AS score4_3, isnull(ES4_4.score4_4,0) as score4_4 ,
				isnull(ES4_5.score4_5,0) as score4_5, isnull(ES4_6.score4_6,0) as score4_6 ,
                (isnull(ES4_1.score4_1,0) + isnull(ES4_2.score4_2,0) + isnull(ES4_3.score4_3,0)+
				isnull(ES4_4.score4_4,0)+ isnull(ES4_5.score4_5,0) + isnull(ES4_6.score4_6,0) ) AS sumscore4,

                '5. งานบริการวิชาการ' as Es5_1, 
                isnull(ES5_1.score5_1,0) as score5_1 ,isnull(ES5_2.score5_2,0) as score5_2, 
				isnull(ES5_3.score5_3,0) AS score5_3, isnull(ES5_4.score5_4,0) as score5_4 ,
				isnull(ES5_5.score5_5,0) as score5_5 ,
                (isnull(ES5_1.score5_1,0) + isnull(ES5_2.score5_2,0) + isnull(ES5_3.score5_3,0)+
				isnull(ES5_4.score5_4,0)+ isnull(ES5_5.score5_5,0) ) AS sumscore5,

                '6. งานบริหารจัดการ' as Es6_1, 
                isnull(ES6_1_1.score6_1_1,0) as score6_1_1 ,isnull(ES6_1_2.score6_1_2,0) as score6_1_2, 
				isnull(ES6_2.score6_2,0) AS score6_2, (isnull(ES6_1_1.score6_1_1,0) + isnull(ES6_1_2.score6_1_2,0)) as score6_1,
                (isnull(ES6_1_1.score6_1_1,0) + isnull(ES6_1_2.score6_1_2,0) + isnull(ES6_2.score6_2,0)) AS sumscore6,

                 '7. งานอื่น ๆ' as Es7_1, 
                isnull(ES7_1.score7_1,0) as score7_1 ,isnull(ES7_2.score7_2,0) as score7_2, 
				isnull(ES7_3.score7_3,0) AS score7_3, isnull(ES7_4.score7_4,0) as score7_4 ,
                (isnull(ES7_1.score7_1,0) + isnull(ES7_2.score7_2,0) + isnull(ES7_3.score7_3,0)+
				isnull(ES7_4.score7_4,0)) AS sumscore7,


                (isnull(ES1_1.score1_1,0) + isnull(ES1_2.score1_2,0) + isnull(ES1_3.score1_3,0) + 
                isnull(ES1_4.score1_4,0) + isnull(ES1_5.score1_5,0) + isnull(ES2_1.score2_1,0) +isnull(ES2_2.score2_2,0) + isnull(ES2_3.score2_3,0)+ 
                isnull(ES2_4.score2_4,0)+ isnull(ES2_5.score2_5,0)+ 
				isnull(ES2_6_1.score2_6_1,0)+ isnull(ES2_6_2.score2_6_2,0)+ 
                isnull(ES2_7.score2_7,0)+ isnull(ES2_8.score2_8,0) + isnull(ES3_1.score3_1,0) + isnull(ES3_2.score3_2,0) + isnull(ES3_3.score3_3,0)+
				isnull(ES3_4.score3_4,0)+ isnull(ES3_5.score3_5,0) + isnull(ES3_6.score3_6,0) +
				isnull(Es3_7.score3_7,0) + isnull(ES3_8.score3_8,0)+
				isnull(ES3_9.score3_9,0)  + isnull(ES4_1.score4_1,0) + isnull(ES4_2.score4_2,0) + isnull(ES4_3.score4_3,0)+
				isnull(ES4_4.score4_4,0)+ isnull(ES4_5.score4_5,0) + isnull(ES4_6.score4_6,0) + isnull(ES5_1.score5_1,0) + isnull(ES5_2.score5_2,0) + isnull(ES5_3.score5_3,0)+
				isnull(ES5_4.score5_4,0)+ isnull(ES5_5.score5_5,0) +  isnull(ES6_1_1.score6_1_1,0) + 
                isnull(ES6_1_2.score6_1_2,0) + isnull(ES6_2.score6_2,0) + 
                isnull(ES7_1.score7_1,0) + isnull(ES7_2.score7_2,0) + isnull(ES7_3.score7_3,0)+
				isnull(ES7_4.score7_4,0)) AS SUMALLSORE
				from EvaluateMaster AS M
                
				LEFT JOIN 
				(SELECT DISTINCT M.id, E1_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_1.score1_1, A.Position,  A.Department, E1_1.createdBy
                FROM EvaluateSevice1_1 AS E1_1
                INNER JOIN EvaluateMaster AS M ON M.id = E1_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_1
                    FROM EvaluateSevice1_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_1 ON E1_1.masterId = SUM1_1.masterId
                WHERE M.acountId = E1_1.createdBy AND E1_1.masterId = @MasterId)as ES1_1 on M.id = ES1_1.masterId 

				LEFT JOIN 
				(SELECT DISTINCT M.id, E1_2.masterId, A.Title+' '+ A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_2.score1_2, A.Position,  A.Department, E1_2.createdBy
                FROM EvaluateSevice1_2 AS E1_2
                INNER JOIN EvaluateMaster AS M ON M.id = E1_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_2
                    FROM EvaluateSevice1_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_2 ON E1_2.masterId = SUM1_2.masterId
                WHERE M.acountId = E1_2.createdBy AND E1_2.masterId = @MasterId) as ES1_2 on  M.id = ES1_2.masterId 

				LEFT JOIN 
				(SELECT DISTINCT M.id, E1_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_3.score1_3, A.Position,  A.Department, E1_3.createdBy
                FROM EvaluateSevice1_3 AS E1_3
                INNER JOIN EvaluateMaster AS M ON M.id = E1_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_3
                    FROM EvaluateSevice1_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_3 ON E1_3.masterId = SUM1_3.masterId
                WHERE M.acountId = E1_3.createdBy AND E1_3.masterId = @MasterId)as ES1_3 on  M.id = ES1_3.masterId 


				LEFT JOIN 
				(SELECT DISTINCT M.id, E1_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_4.score1_4, A.Position,  A.Department, E1_4.createdBy
                FROM EvaluateSevice1_4 AS E1_4
                INNER JOIN EvaluateMaster AS M ON M.id = E1_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_4
                    FROM EvaluateSevice1_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_4 ON E1_4.masterId = SUM1_4.masterId
                WHERE M.acountId = E1_4.createdBy AND E1_4.masterId = @MasterId)as ES1_4 on  M.id = ES1_4.masterId 

				LEFT JOIN 
				(SELECT DISTINCT M.id, E1_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM1_5.score1_5, A.Position,  A.Department, E1_5.createdBy
                FROM EvaluateSevice1_5 AS E1_5
                INNER JOIN EvaluateMaster AS M ON M.id = E1_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score1_5
                    FROM EvaluateSevice1_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM1_5 ON E1_5.masterId = SUM1_5.masterId
                WHERE M.acountId = E1_5.createdBy AND E1_5.masterId = @MasterId)as ES1_5 on M.id = ES1_5.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_1.score2_1, A.Position,  A.Department, E2_1.createdBy
                FROM EvaluateDevelopMainten2_1 AS E2_1
                INNER JOIN EvaluateMaster AS M ON M.id = E2_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_1
                    FROM EvaluateDevelopMainten2_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_1 ON E2_1.masterId = SUM2_1.masterId
                WHERE M.acountId = E2_1.createdBy AND E2_1.masterId = @MasterId)as ES2_1 on M.id = ES2_1.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_2.score2_2, A.Position,  A.Department, E2_2.createdBy
                FROM EvaluateDevelopMainten2_2 AS E2_2
                INNER JOIN EvaluateMaster AS M ON M.id = E2_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_2
                    FROM EvaluateDevelopMainten2_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_2 ON E2_2.masterId = SUM2_2.masterId
                WHERE M.acountId = E2_2.createdBy AND E2_2.masterId = @MasterId)as ES2_2 on M.id = ES2_2.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_3.score2_3, A.Position,  A.Department, E2_3.createdBy
                FROM EvaluateDevelopMainten2_3 AS E2_3
                INNER JOIN EvaluateMaster AS M ON M.id = E2_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_3
                    FROM EvaluateDevelopMainten2_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_3 ON E2_3.masterId = SUM2_3.masterId
                WHERE M.acountId = E2_3.createdBy AND E2_3.masterId = @MasterId)as ES2_3 on M.id = ES2_3.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_4.score2_4, A.Position,  A.Department, E2_4.createdBy
                FROM EvaluateDevelopMainten2_4 AS E2_4
                INNER JOIN EvaluateMaster AS M ON M.id = E2_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_4
                    FROM EvaluateDevelopMainten2_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_4 ON E2_4.masterId = SUM2_4.masterId
                WHERE M.acountId = E2_4.createdBy AND E2_4.masterId = @MasterId)as ES2_4 on M.id = ES2_4.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_5.score2_5, A.Position,  A.Department, E2_5.createdBy
                FROM EvaluateDevelopMainten2_5 AS E2_5
                INNER JOIN EvaluateMaster AS M ON M.id = E2_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_5
                    FROM EvaluateDevelopMainten2_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_5 ON E2_5.masterId = SUM2_5.masterId
                WHERE M.acountId = E2_5.createdBy AND E2_5.masterId = @MasterId)as ES2_5 on M.id = ES2_5.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_6_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_6_1.score2_6_1, A.Position,  A.Department, E2_6_1.createdBy
                FROM EvaluateDevelopMainten2_6_1 AS E2_6_1
                INNER JOIN EvaluateMaster AS M ON M.id = E2_6_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_6_1
                    FROM EvaluateDevelopMainten2_6_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_6_1 ON E2_6_1.masterId = SUM2_6_1.masterId
                WHERE M.acountId = E2_6_1.createdBy AND E2_6_1.masterId = @MasterId)as ES2_6_1 on M.id = ES2_6_1.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_6_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_6_2.score2_6_2, A.Position,  A.Department, E2_6_2.createdBy
                FROM EvaluateDevelopMainten2_6_2 AS E2_6_2
                INNER JOIN EvaluateMaster AS M ON M.id = E2_6_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_6_2
                    FROM EvaluateDevelopMainten2_6_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_6_2 ON E2_6_2.masterId = SUM2_6_2.masterId
                WHERE M.acountId = E2_6_2.createdBy AND E2_6_2.masterId = @MasterId)as ES2_6_2 on  M.id = ES2_6_2.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E2_7.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_7.score2_7, A.Position,  A.Department, E2_7.createdBy
                FROM EvaluateDevelopMainten2_7 AS E2_7
                INNER JOIN EvaluateMaster AS M ON M.id = E2_7.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_7
                    FROM EvaluateDevelopMainten2_7
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_7 ON E2_7.masterId = SUM2_7.masterId
                WHERE M.acountId = E2_7.createdBy AND E2_7.masterId = @MasterId)as ES2_7 on M.id = ES2_7.masterId 

                 LEFT JOIN 
				(SELECT DISTINCT M.id, E2_8.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM2_8.score2_8, A.Position,  A.Department, E2_8.createdBy
                FROM EvaluateDevelopMainten2_8 AS E2_8
                INNER JOIN EvaluateMaster AS M ON M.id = E2_8.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score2_8
                    FROM EvaluateDevelopMainten2_8
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM2_8 ON E2_8.masterId = SUM2_8.masterId
                WHERE M.acountId = E2_8.createdBy AND E2_8.masterId = @MasterId)as ES2_8 on M.id = ES2_8.masterId 

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_1.score3_1, A.Position,  A.Department, E3_1.createdBy
                FROM EvaluateResearch3_1 AS E3_1
                INNER JOIN EvaluateMaster AS M ON M.id = E3_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_1
                    FROM EvaluateResearch3_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_1 ON E3_1.masterId = SUM3_1.masterId
                WHERE M.acountId = E3_1.createdBy AND E3_1.masterId = @MasterId)as ES3_1 on  M.id = ES3_1.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_2.score3_2, A.Position,  A.Department, E3_2.createdBy
                FROM EvaluateResearch3_2 AS E3_2
                INNER JOIN EvaluateMaster AS M ON M.id = E3_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_2
                    FROM EvaluateResearch3_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_2 ON E3_2.masterId = SUM3_2.masterId
                WHERE M.acountId = E3_2.createdBy AND E3_2.masterId = @MasterId)as ES3_2 on  M.id = ES3_2.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_3.score3_3, A.Position,  A.Department, E3_3.createdBy
                FROM EvaluateResearch3_3 AS E3_3
                INNER JOIN EvaluateMaster AS M ON M.id = E3_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_3
                    FROM EvaluateResearch3_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_3 ON E3_3.masterId = SUM3_3.masterId
                WHERE M.acountId = E3_3.createdBy AND E3_3.masterId = @MasterId)as ES3_3 on  M.id = ES3_3.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_4.score3_4, A.Position,  A.Department, E3_4.createdBy
                FROM EvaluateResearch3_4 AS E3_4
                INNER JOIN EvaluateMaster AS M ON M.id = E3_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_4
                    FROM EvaluateResearch3_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_4 ON E3_4.masterId = SUM3_4.masterId
                WHERE M.acountId = E3_4.createdBy AND E3_4.masterId = @MasterId)as ES3_4 on  M.id = ES3_4.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_5.score3_5, A.Position,  A.Department, E3_5.createdBy
                FROM EvaluateResearch3_5 AS E3_5
                INNER JOIN EvaluateMaster AS M ON M.id = E3_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_5
                    FROM EvaluateResearch3_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_5 ON E3_5.masterId = SUM3_5.masterId
                WHERE M.acountId = E3_5.createdBy AND E3_5.masterId = @MasterId)as ES3_5 on  M.id = ES3_5.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_6.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_6.score3_6, A.Position,  A.Department, E3_6.createdBy
                FROM EvaluateResearch3_6 AS E3_6
                INNER JOIN EvaluateMaster AS M ON M.id = E3_6.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_6
                    FROM EvaluateResearch3_6
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_6 ON E3_6.masterId = SUM3_6.masterId
                WHERE M.acountId = E3_6.createdBy AND E3_6.masterId = @MasterId)as ES3_6 on  M.id = ES3_6.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_7.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_7.score3_7, A.Position,  A.Department, E3_7.createdBy
                FROM EvaluateResearch3_7 AS E3_7
                INNER JOIN EvaluateMaster AS M ON M.id = E3_7.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_7
                    FROM EvaluateResearch3_7
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_7 ON E3_7.masterId = SUM3_7.masterId
                WHERE M.acountId = E3_7.createdBy AND E3_7.masterId = @MasterId)as ES3_7 on  M.id = ES3_7.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E3_8.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_8.score3_8, A.Position,  A.Department, E3_8.createdBy
                FROM EvaluateResearch3_8 AS E3_8
                INNER JOIN EvaluateMaster AS M ON M.id = E3_8.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_8
                    FROM EvaluateResearch3_8
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_8 ON E3_8.masterId = SUM3_8.masterId
                WHERE M.acountId = E3_8.createdBy AND E3_8.masterId = @MasterId)as ES3_8 on  M.id = ES3_8.masterId

                 LEFT JOIN 
				(SELECT DISTINCT M.id, E3_9.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM3_9.score3_9, A.Position,  A.Department, E3_9.createdBy
                FROM EvaluateResearch3_9 AS E3_9
                INNER JOIN EvaluateMaster AS M ON M.id = E3_9.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score3_9
                    FROM EvaluateResearch3_9
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM3_9 ON E3_9.masterId = SUM3_9.masterId
                WHERE M.acountId = E3_9.createdBy AND E3_9.masterId = @MasterId)as ES3_9 on  M.id = ES3_9.masterId


                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_1.score4_1, A.Position,  A.Department, E4_1.createdBy
                FROM EvaluatePromotionWork4_1 AS E4_1
                INNER JOIN EvaluateMaster AS M ON M.id = E4_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_1
                    FROM EvaluatePromotionWork4_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_1 ON E4_1.masterId = SUM4_1.masterId
                WHERE M.acountId = E4_1.createdBy AND E4_1.masterId = @MasterId)as ES4_1 on  M.id = ES4_1.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_2.score4_2, A.Position,  A.Department, E4_2.createdBy
                FROM EvaluatePromotionWork4_2 AS E4_2
                INNER JOIN EvaluateMaster AS M ON M.id = E4_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_2
                    FROM EvaluatePromotionWork4_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_2 ON E4_2.masterId = SUM4_2.masterId
                WHERE M.acountId = E4_2.createdBy AND E4_2.masterId = @MasterId)as ES4_2 on  M.id = ES4_2.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_3.score4_3, A.Position,  A.Department, E4_3.createdBy
                FROM EvaluatePromotionWork4_3 AS E4_3
                INNER JOIN EvaluateMaster AS M ON M.id = E4_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_3
                    FROM EvaluatePromotionWork4_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_3 ON E4_3.masterId = SUM4_3.masterId
                WHERE M.acountId = E4_3.createdBy AND E4_3.masterId = @MasterId)as ES4_3 on  M.id = ES4_3.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_4.score4_4, A.Position,  A.Department, E4_4.createdBy
                FROM EvaluatePromotionWork4_4 AS E4_4
                INNER JOIN EvaluateMaster AS M ON M.id = E4_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_4
                    FROM EvaluatePromotionWork4_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_4 ON E4_4.masterId = SUM4_4.masterId
                WHERE M.acountId = E4_4.createdBy AND E4_4.masterId = @MasterId)as ES4_4 on  M.id = ES4_4.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_5.score4_5, A.Position,  A.Department, E4_5.createdBy
                FROM EvaluatePromotionWork4_5 AS E4_5
                INNER JOIN EvaluateMaster AS M ON M.id = E4_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_5
                    FROM EvaluatePromotionWork4_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_5 ON E4_5.masterId = SUM4_5.masterId
                WHERE M.acountId = E4_5.createdBy AND E4_5.masterId = @MasterId)as ES4_5 on  M.id = ES4_5.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E4_6.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM4_6.score4_6, A.Position,  A.Department, E4_6.createdBy
                FROM EvaluatePromotionWork4_6 AS E4_6
                INNER JOIN EvaluateMaster AS M ON M.id = E4_6.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score4_6
                    FROM EvaluatePromotionWork4_6
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM4_6 ON E4_6.masterId = SUM4_6.masterId
                WHERE M.acountId = E4_6.createdBy AND E4_6.masterId = @MasterId)as ES4_6 on  M.id = ES4_6.masterId


                LEFT JOIN 
				(SELECT DISTINCT M.id, E5_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM5_1.score5_1, A.Position,  A.Department, E5_1.createdBy
                FROM EvaluateAcademicServices5_1 AS E5_1
                INNER JOIN EvaluateMaster AS M ON M.id = E5_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score5_1
                    FROM EvaluateAcademicServices5_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM5_1 ON E5_1.masterId = SUM5_1.masterId
                WHERE M.acountId = E5_1.createdBy AND E5_1.masterId = @MasterId)as ES5_1 on  M.id = ES5_1.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E5_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM5_2.score5_2, A.Position,  A.Department, E5_2.createdBy
                FROM EvaluateAcademicServices5_2 AS E5_2
                INNER JOIN EvaluateMaster AS M ON M.id = E5_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score5_2
                    FROM EvaluateAcademicServices5_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM5_2 ON E5_2.masterId = SUM5_2.masterId
                WHERE M.acountId = E5_2.createdBy AND E5_2.masterId = @MasterId)as ES5_2 on  M.id = ES5_2.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E5_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM5_3.score5_3, A.Position,  A.Department, E5_3.createdBy
                FROM EvaluateAcademicServices5_3 AS E5_3
                INNER JOIN EvaluateMaster AS M ON M.id = E5_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score5_3
                    FROM EvaluateAcademicServices5_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM5_3 ON E5_3.masterId = SUM5_3.masterId
                WHERE M.acountId = E5_3.createdBy AND E5_3.masterId = @MasterId)as ES5_3 on  M.id = ES5_3.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E5_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM5_4.score5_4, A.Position,  A.Department, E5_4.createdBy
                FROM EvaluateAcademicServices5_4 AS E5_4
                INNER JOIN EvaluateMaster AS M ON M.id = E5_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score5_4
                    FROM EvaluateAcademicServices5_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM5_4 ON E5_4.masterId = SUM5_4.masterId
                WHERE M.acountId = E5_4.createdBy AND E5_4.masterId = @MasterId)as ES5_4 on  M.id = ES5_4.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E5_5.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM5_5.score5_5, A.Position,  A.Department, E5_5.createdBy
                FROM EvaluateAcademicServices5_5 AS E5_5
                INNER JOIN EvaluateMaster AS M ON M.id = E5_5.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score5_5
                    FROM EvaluateAcademicServices5_5
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM5_5 ON E5_5.masterId = SUM5_5.masterId
                WHERE M.acountId = E5_5.createdBy AND E5_5.masterId = @MasterId)as ES5_5 on  M.id = ES5_5.masterId

				
                LEFT JOIN 
				(SELECT DISTINCT M.id, E6_1_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM6_1_1.score6_1_1, A.Position,  A.Department, E6_1_1.createdBy
                FROM EvaluateManagement6_1_1 AS E6_1_1
                INNER JOIN EvaluateMaster AS M ON M.id = E6_1_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score6_1_1
                    FROM EvaluateManagement6_1_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM6_1_1 ON E6_1_1.masterId = SUM6_1_1.masterId
                WHERE M.acountId = E6_1_1.createdBy AND E6_1_1.masterId = @MasterId)as ES6_1_1 on  M.id = ES6_1_1.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E6_1_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM6_1_2.score6_1_2, A.Position,  A.Department, E6_1_2.createdBy
                FROM EvaluateManagement6_1_2 AS E6_1_2
                INNER JOIN EvaluateMaster AS M ON M.id = E6_1_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score6_1_2
                    FROM EvaluateManagement6_1_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM6_1_2 ON E6_1_2.masterId = SUM6_1_2.masterId
                WHERE M.acountId = E6_1_2.createdBy AND E6_1_2.masterId = @MasterId)as ES6_1_2 on  M.id = ES6_1_2.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E6_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM6_2.score6_2, A.Position,  A.Department, E6_2.createdBy
                FROM EvaluateManagement6_2 AS E6_2
                INNER JOIN EvaluateMaster AS M ON M.id = E6_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score6_2
                    FROM EvaluateManagement6_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM6_2 ON E6_2.masterId = SUM6_2.masterId
                WHERE M.acountId = E6_2.createdBy AND E6_2.masterId = @MasterId)as ES6_2 on  M.id = ES6_2.masterId

                
                LEFT JOIN 
				(SELECT DISTINCT M.id, E7_1.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM7_1.score7_1, A.Position,  A.Department, E7_1.createdBy
                FROM EvaluateOther7_1 AS E7_1
                INNER JOIN EvaluateMaster AS M ON M.id = E7_1.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score7_1
                    FROM EvaluateOther7_1
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM7_1 ON E7_1.masterId = SUM7_1.masterId
                WHERE M.acountId = E7_1.createdBy AND E7_1.masterId = @MasterId)as ES7_1 on  M.id = ES7_1.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E7_2.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM7_2.score7_2, A.Position,  A.Department, E7_2.createdBy
                FROM EvaluateOther7_2 AS E7_2
                INNER JOIN EvaluateMaster AS M ON M.id = E7_2.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score7_2
                    FROM EvaluateOther7_2
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM7_2 ON E7_2.masterId = SUM7_2.masterId
                WHERE M.acountId = E7_2.createdBy AND E7_2.masterId = @MasterId)as ES7_2 on  M.id = ES7_2.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E7_3.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM7_3.score7_3, A.Position,  A.Department, E7_3.createdBy
                FROM EvaluateOther7_3 AS E7_3
                INNER JOIN EvaluateMaster AS M ON M.id = E7_3.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score7_3
                    FROM EvaluateOther7_3
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM7_3 ON E7_3.masterId = SUM7_3.masterId
                WHERE M.acountId = E7_3.createdBy AND E7_3.masterId = @MasterId)as ES7_3 on  M.id = ES7_3.masterId

                LEFT JOIN 
				(SELECT DISTINCT M.id, E7_4.masterId, A.Title+' '+A.FirstName + ' ' +A.LastName AS FullName, 
                C.projectYear, C.projectRound, SUM7_4.score7_4, A.Position,  A.Department, E7_4.createdBy
                FROM EvaluateOther7_4 AS E7_4
                INNER JOIN EvaluateMaster AS M ON M.id = E7_4.masterId 
                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                INNER JOIN 
                    (SELECT masterId,sum(projectScore) as score7_4
                    FROM EvaluateOther7_4
                    WHERE projectStatus = 'A'
                    GROUP BY masterId) AS  SUM7_4 ON E7_4.masterId = SUM7_4.masterId
                WHERE M.acountId = E7_4.createdBy AND E7_4.masterId = @MasterId)as ES7_4 on  M.id = ES7_4.masterId


                INNER JOIN Account AS A ON A.id = M.acountId
                INNER JOIN ProjectControl AS C ON C.id = M.roundId
                WHERE M.id = @MasterId";


        con.ConnectionString = con_string;
        con.Open ();
        SqlCommand cmd = new SqlCommand (sql, con);
        string rId = Request.QueryString["nId"];
        cmd.Parameters.AddWithValue ("@MasterId", rId);
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        DataSet ds = new DataSet ();

        SqlDataReader reader = cmd.ExecuteReader ();
        reader.Read ();
      //  int count = (int) command.ExecuteScalar();

        string FullName = reader["FullName"].ToString ();
        string Position = reader["Position"].ToString ();
        string Department = reader["Department"].ToString ();
        string Year = reader["projectYear"].ToString ();
        string Round = reader["projectRound"].ToString (); 
        string DateStart = reader["dateStart"].ToString();
        
        string DateEnd = reader["dateEnd"].ToString ();  
         

        string SUMALLSORE = reader["SUMALLSORE"].ToString ();
        
        string Es1_1 = reader["Es1_1"].ToString ();
        string sumscore = reader["sumscore"].ToString ();
        string score1_1 = reader["score1_1"].ToString ();
        string score1_2 = reader["score1_2"].ToString ();
        string score1_3 = reader["score1_3"].ToString ();
        string score1_4 = reader["score1_4"].ToString ();
        string score1_5 = reader["score1_5"].ToString ();

        string sumscore2 = reader["sumscore2"].ToString ();
        string Es2_1 = reader["Es2_1"].ToString ();
        string score2_1 = reader["score2_1"].ToString ();
        string score2_2 = reader["score2_2"].ToString ();
        string score2_3 = reader["score2_3"].ToString ();
        string score2_4 = reader["score2_4"].ToString ();
        string score2_5 = reader["score2_5"].ToString ();
        string score2_6 = reader["score2_6"].ToString ();
        string score2_6_1 = reader["score2_6_1"].ToString ();
        string score2_6_2 = reader["score2_6_2"].ToString ();
        string score2_7 = reader["score2_7"].ToString ();
        string score2_8 = reader["score2_8"].ToString ();

        string sumscore3 = reader["sumscore3"].ToString ();
        string Es3_1 = reader["Es3_1"].ToString ();
        string score3_1 = reader["score3_1"].ToString ();
        string score3_2 = reader["score3_2"].ToString ();
        string score3_3 = reader["score3_3"].ToString ();
        string score3_4 = reader["score3_4"].ToString ();
        string score3_5 = reader["score3_5"].ToString ();
        string score3_6 = reader["score3_6"].ToString ();
        string score3_7 = reader["score3_7"].ToString ();
        string score3_8 = reader["score3_8"].ToString ();
        string score3_9 = reader["score3_9"].ToString ();

        string sumscore4 = reader["sumscore4"].ToString ();
        string Es4_1 = reader["Es4_1"].ToString ();
        string score4_1 = reader["score4_1"].ToString ();
        string score4_2 = reader["score4_2"].ToString ();
        string score4_3 = reader["score4_3"].ToString ();
        string score4_4 = reader["score4_4"].ToString ();
        string score4_5 = reader["score4_5"].ToString ();
        string score4_6 = reader["score4_6"].ToString ();

        string sumscore5 = reader["sumscore5"].ToString ();
        string Es5_1 = reader["Es5_1"].ToString ();
        string score5_1 = reader["score5_1"].ToString ();
        string score5_2 = reader["score5_2"].ToString ();
        string score5_3 = reader["score5_3"].ToString ();
        string score5_4 = reader["score5_4"].ToString ();
        string score5_5 = reader["score5_5"].ToString ();

        string sumscore6 = reader["sumscore6"].ToString ();
        string Es6_1 = reader["Es6_1"].ToString ();
        string score6_1 = reader["score6_1"].ToString ();
        string score6_1_1 = reader["score6_1_1"].ToString ();
        string score6_1_2 = reader["score6_1_2"].ToString ();
        string score6_2 = reader["score6_2"].ToString ();

        string sumscore7 = reader["sumscore7"].ToString ();
        string Es7_1 = reader["Es7_1"].ToString ();
        string score7_1 = reader["score7_1"].ToString ();
        string score7_2 = reader["score7_2"].ToString ();
        string score7_3 = reader["score7_3"].ToString ();
        string score7_4 = reader["score7_4"].ToString ();

        lbl_FullName.Text = FullName;
        lbl_Position.Text = Position;
        lbl_Department.Text = Department;
        lbl_round.Text = Round;
        lbl_Year.Text = Year;
        lbl_Datestart.Text = DateStart;
        lbl_Dateend.Text = DateEnd;
        lblEs1_1.Text = Es1_1;
        lblSUMALL.Text = SUMALLSORE;

        
        lblsumscore.Text = sumscore;
        lblscore1_1.Text = score1_1;
        lblscore1_2.Text = score1_2;
        lblscore1_3.Text = score1_3;
        lblscore1_4.Text = score1_4;
        lblscore1_5.Text = score1_5;

        lblEs2_1.Text = Es2_1;
        lblsumscore2.Text = sumscore2;
        lblscore2_1.Text = score2_1;
        lblscore2_2.Text = score2_2;
        lblscore2_3.Text = score2_3;
        lblscore2_4.Text = score2_4;
        lblscore2_5.Text = score2_5;
        lblscore2_6.Text = score2_6;
        lblscore2_6_1.Text = score2_6_1;
        lblscore2_6_2.Text = score2_6_2;
        lblscore2_7.Text = score2_7;
        lblscore2_8.Text = score2_8;

        lblEs3_1.Text = Es3_1;
        lblsumscore3.Text = sumscore3;
        lblscore3_1.Text = score3_1;
        lblscore3_2.Text = score3_2;
        lblscore3_3.Text = score3_3;
        lblscore3_4.Text = score3_4;
        lblscore3_5.Text = score3_5;
        lblscore3_6.Text = score3_6;
        lblscore3_9.Text = score3_9;
        lblscore3_7.Text = score3_7;
        lblscore3_8.Text = score3_8;

        lblEs4_1.Text = Es4_1;
        lblsumscore4.Text = sumscore4;
        lblscore4_1.Text = score4_1;
        lblscore4_2.Text = score4_2;
        lblscore4_3.Text = score4_3;
        lblscore4_4.Text = score4_4;
        lblscore4_5.Text = score4_5;
        lblscore4_6.Text = score4_6;

        lblEs5_1.Text = Es5_1;
        lblsumscore5.Text = sumscore5;
        lblscore5_1.Text = score5_1;
        lblscore5_2.Text = score5_2;
        lblscore5_3.Text = score5_3;
        lblscore5_4.Text = score5_4;
        lblscore5_5.Text = score5_5;

        lblEs6_1.Text = Es6_1;
        lblsumscore6.Text = sumscore6;
        lblscore6_1.Text = score6_1;
        lblscore6_1_1.Text = score6_1_1;
        lblscore6_1_2.Text = score6_1_2;
        lblscore6_2.Text = score6_2;

         lblEs7_1.Text = Es7_1;
        lblsumscore7.Text = sumscore7;
        lblscore7_1.Text = score7_1;
        lblscore7_2.Text = score7_2;
        lblscore7_3.Text = score7_3;
        lblscore7_4.Text = score7_4;
        
        con.Close ();

        DataTable blacklistDT = db.ExecuteDataTable (cmd);
    }

}