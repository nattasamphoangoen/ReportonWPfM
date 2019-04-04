using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for ConnectDB
/// </summary>
public class ConnectDB
{
    private SqlConnection SQLConnect = new SqlConnection();
    private SqlTransaction transaction;
    private string ConnectionString = string.Empty;
    private bool UseTransaction;

    public ConnectDB()
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;
        UseTransaction = false;
    }

    public ConnectDB(string ConnectionString)
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
        UseTransaction = false;
    }

    public ConnectDB(bool UseTransaction, string TransactionName)
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings["SLRIConnectionString"].ConnectionString;
        UseTransaction = true;

        SQLConnect.ConnectionString = ConnectionString;

        SQLConnect.Open();
        transaction = SQLConnect.BeginTransaction(TransactionName);
    }

    public ConnectDB(bool UseTransaction, string TransactionName, string ConnectionString)
    {
        ConnectionString = WebConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
        UseTransaction = true;

        SQLConnect.ConnectionString = ConnectionString;
        transaction = SQLConnect.BeginTransaction(TransactionName);
    }

    public DataTable ExecuteDataTable(SqlCommand command)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        SQLConnect.ConnectionString = ConnectionString;
        command.Connection = SQLConnect;

        if (!UseTransaction)
        {
            if (SQLConnect.State == ConnectionState.Open)
            {
                SQLConnect.Close();
            }
            SQLConnect.Open();
        }

        try
        {
            da.SelectCommand = command;
            da.Fill(dt);
        }
        catch { if (!UseTransaction) { this.RollbackTransaction(); } }
        finally
        {
            if (!UseTransaction)
            { SQLConnect.Close(); }
        }

        return dt;
    }

    public int ExecuteNonQuery(SqlCommand command)
    {
        object ReturnResult;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        SQLConnect.ConnectionString = ConnectionString;
        command.Connection = SQLConnect;

        if (!UseTransaction)
        {
            if (SQLConnect.State == ConnectionState.Open)
            {
                SQLConnect.Close();
            }
            SQLConnect.Open();
        }

        try
        {
            ReturnResult = (object)command.ExecuteNonQuery();
        }
        catch { ReturnResult = -1; if (!UseTransaction) { this.RollbackTransaction(); } }
        finally
        {
            if (!UseTransaction)
            { SQLConnect.Close(); }
        }

        return int.Parse(ReturnResult.ToString());
    }

    public object ExecuteScalar(SqlCommand command)
    {
        object ReturnResult;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        SQLConnect.ConnectionString = ConnectionString;
        command.Connection = SQLConnect;

  
            if (SQLConnect.State == ConnectionState.Open)
            {
                SQLConnect.Close();
            }
            SQLConnect.Open();
        

        try
        {
            ReturnResult = (object)command.ExecuteScalar();
        }
        catch (Exception ex) { ReturnResult = -1; }
        finally
        {
      
     SQLConnect.Close(); 
        }

        return ReturnResult;
    }

    public bool CommitTransaction()
    {
        bool returnResult;
        try
        {
            transaction.Commit();
            returnResult = true;
        }
        catch (Exception ex)
        {
            //Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
            //Console.WriteLine("  Message: {0}", ex.Message);

            this.RollbackTransaction();

            returnResult = false;
        }

        if (SQLConnect.State == ConnectionState.Open)
        {
            SQLConnect.Close();
        }
        return returnResult;
    }

    public void RollbackTransaction()
    {
        try
        {
            transaction.Rollback();
        }
        catch (Exception ex2)
        {
            //Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
            //Console.WriteLine("  Message: {0}", ex2.Message);
        }
        finally
        {
            if (SQLConnect.State == ConnectionState.Open)
            {
                SQLConnect.Close();
            }
        }
    }
}