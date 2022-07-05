using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Redirect("Home.aspx");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client") || level.Equals("Worker"))
                Response.Redirect("Home.aspx");
        }
    }
}