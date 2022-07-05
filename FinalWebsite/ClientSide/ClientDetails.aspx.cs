using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class ClientDetails : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable dtclient = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Session["search"] == null)
                Response.Redirect("Error.aspx");


            dtclient = (DataTable)Session["search"];
            lblidclient.Text = dtclient.Rows[0][0].ToString();
            lblfullname.Text = dtclient.Rows[0][2].ToString();
            lblemail.Text = dtclient.Rows[0][8].ToString();
            lblphone.Text = dtclient.Rows[0][7].ToString();
            lblcity.Text = s.GetCityName(int.Parse(dtclient.Rows[0][4].ToString()));
            lbladdress.Text = dtclient.Rows[0][5].ToString();
            lblnumaddress.Text = dtclient.Rows[0][6].ToString();
        }
    }
}