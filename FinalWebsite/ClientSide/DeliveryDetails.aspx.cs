using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class DeliveryDetails : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable dtdelivery = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)

            if (Session["searchdelivery"] == null)
                Response.Redirect("error.aspx");

        dtdelivery = (DataTable)Session["searchdelivery"];
        lbliddelivery.Text = dtdelivery.Rows[0][0].ToString();
        lbliddriver.Text = dtdelivery.Rows[0][1].ToString();
        lblidclient.Text = dtdelivery.Rows[0][5].ToString();
        lblidorder.Text = s.GetIdOrderFromDeliveriesDetails(dtdelivery.Rows[0][0].ToString());
        lblidcar.Text = dtdelivery.Rows[0][2].ToString();
        lbldateofdelivery.Text = dtdelivery.Rows[0][3].ToString();
        lbldeliverystatus.Text = dtdelivery.Rows[0][4].ToString();

    }
}