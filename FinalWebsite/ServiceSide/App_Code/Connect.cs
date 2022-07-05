using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class Connect
{
    private static OleDbConnection my_con;
    private string p;

    public Connect(string p)
    {
        // TODO: Complete member initialization
        this.p = p;
    }
    //------------------------------------------------------------------

    private static void ConnectMe(string path)
    {
        string mypath = @"Provider=microsoft.jet.oledb.4.0;Data Source=" + path;

        my_con = new OleDbConnection(mypath);
    }
    //------------------------------------------------------------------
    public static DataTable DownloadData(string my_sql, string tableName, string NameAndPathDb)
    {
        ConnectMe(NameAndPathDb);

        DataSet ds = new DataSet();

        OleDbCommand cmmd = new OleDbCommand(my_sql, my_con);

        OleDbDataAdapter da = new OleDbDataAdapter(cmmd);

        da.Fill(ds, tableName);

        DataTable dt = ds.Tables[0];

        return (dt);
    }
    //------------------------------------------------------------------
    public static void TakeAction(OleDbCommand cmmd, string NameAndPathDb)
    {
        ConnectMe(NameAndPathDb);

        cmmd.Connection = my_con;

        my_con.Open();

        cmmd.ExecuteNonQuery();

        my_con.Close();
    }
    //------------------------------------------------------------------
    public static int ReturnValue(string sql, string NameAndPathDb)
    {
        ConnectMe(NameAndPathDb);

        OleDbCommand cmmd = new OleDbCommand(sql, my_con);

        my_con.Open();

        int result = (int)cmmd.ExecuteScalar();

        my_con.Close();

        return (result);
    }

}
