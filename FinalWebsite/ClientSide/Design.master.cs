using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Design : System.Web.UI.MasterPage
{
  
        
    private static DataTable dtclient = null;
    public static string level;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] != null)
        {
            dtclient = (DataTable)Session["Client"];
            level = dtclient.Rows[0][11].ToString();

        }
    }
    
}
