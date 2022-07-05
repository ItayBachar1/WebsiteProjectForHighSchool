using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Showtruck : System.Web.UI.Page
{
    private static DataTable dtcar = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["searchcar"] == null)
            Response.Redirect("Error.aspx");

        dtcar = (DataTable)Session["searchcar"];
        lblidcar.Text = dtcar.Rows[0][0].ToString();
        lblnamecar.Text = dtcar.Rows[0][1].ToString();
        lblcarcapacity.Text = dtcar.Rows[0][2].ToString();
        pic.ImageUrl = "pic/" + dtcar.Rows[0][3].ToString();
        lblcarstatus.Text = dtcar.Rows[0][4].ToString();

    }
}