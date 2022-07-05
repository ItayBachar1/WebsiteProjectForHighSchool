using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{
    public static string AlertBox(string msg)
    {
        return "<script type='text/javascript'>alert('" + msg + "')</script>";
    }

    public static string AlertRedirect(string msg, string url) //שולח הודעה ואז מעביר לדף אחר
    {
        string show = "<script type='text/javascript'>alert('" + msg + "');location.href='" + url + "'</script>";

        return show;

    }

    public static bool IsInArr(string[] strings, string value)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            if (strings[i].Equals(value))
                return true;
        }

        return false;

    }

    public static string generateID() //יוצר ID ייחודי
    {
        long i = 1;

        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }

        string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

        return number;
 
  }

    public static string GetUrl(string type)
    {
        //For example for http://localhost:1302/TESTERS/Default6.aspx

        if (type.Equals("path"))//return /TESTERS/Default6.aspx
        return HttpContext.Current.Request.Url.AbsolutePath;

        if (type.Equals("host"))//return localhost
            return HttpContext.Current.Request.Url.Host;

        //return http://localhost:1302/TESTERS/Default6.aspx
        return HttpContext.Current.Request.Url.AbsoluteUri;
        
    }

    public static int SearchGridView(GridView grd,int cell,string value)
    {
        for (int i = 0; i < grd.Rows.Count; i++)
            if (grd.Rows[i].Cells[cell].Text.Equals(value))
                return i;
        

        return -1;
    }
   
  


}