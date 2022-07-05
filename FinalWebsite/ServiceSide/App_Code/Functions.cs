using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{
    //לוקח מערך תווים ושם טבלה ומכין מזה דטא טייבל עם אותם עמודות שבמערך תווים
    public static DataTable CreateDataTalbe(string[] names, string nameDt)
    {
        DataTable dt = new DataTable();

        dt.TableName = nameDt;

        for (int i = 0; i < names.Length; i++)
        {
            DataColumn dc = new DataColumn();


            dc.ColumnName = names[i];

            dt.Columns.Add(dc);
        }

        return dt;
    }

    public static DataTable AddDataRow(DataTable dt, string[] values)
    {
        DataTable dtReturn = dt;
        DataRow dr = dt.NewRow();

        for (int i = 0; i < values.Length; i++)
            dr[i] = values[i];


        dtReturn.Rows.Add(dr);

        return dtReturn;
    }

    public static string AlertBox(string msg)
    {
        return "<script type='text/javascript'>alert('" + msg + "')</script>";
    }

    public static string AlertRedirect(string msg, string url)
    {
        string show = "<script type='text/javascript'>alert('" + msg + "');location.href='" + url + "'</script>";

        return show;

    }

    public static int MonthsSpan(DateTime date1, DateTime date2)
    {
        return ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;

    }
}