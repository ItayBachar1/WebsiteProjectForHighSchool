using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Redirect("Home.aspx");

        Session["client"] = null;
        Response.Write("<script type='text/javascript'>alert('You logged out.');location.href='Home.aspx'</script>");
    }
}