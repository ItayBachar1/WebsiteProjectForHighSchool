using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    private static DataTable dt = null;

    private localhost.Service s = new localhost.Service();

    private void Show(DataTable dtbl)
    {
        if (dtbl.Rows.Count != 0)
        {
            shopcart.DataSource = dtbl;
            shopcart.DataBind();
            //   for (int i = 0; i < shopcart.Rows.Count; i++)
            //     shopcart.Rows[i].Cells[7].Text = s.GetCityName(int.Parse(shopcart.Rows[i].Cells[7].Text));

        }

        else
        {
            shopcart.DataSource = dtbl;
            shopcart.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["orderproduct"] != null)
            {
                dt = (DataTable)Session["orderproduct"];

                Show(dt);
            }
        }
    }
    protected void shopcart_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt.Rows.RemoveAt(shopcart.SelectedIndex);

        shopcart.DataSource = dt;

        shopcart.DataBind();
    }
    protected void shopcart_cancelcommand(object sender, GridViewCancelEditEventArgs e)
    {

    }
}