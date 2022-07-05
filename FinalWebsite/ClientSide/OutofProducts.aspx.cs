using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OutOfProducts : System.Web.UI.Page
{
    private DataTable dtProducts;
    private localhost.Service s = new localhost.Service();
    private void Show(DataTable dt)
    {
        grdUnderMin.DataSource = dt;

        grdUnderMin.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Client"] == null)
                Response.Redirect("login.aspx");

            else
            {
                DataTable you = (DataTable)Session["Client"];

                string level = you.Rows[0][11].ToString();

                if (level.Equals("Client"))
                    Response.Redirect("Home.aspx");

                dtProducts = s.SearchUnderMinProduct();

                Show(dtProducts);

            }
        }
    }
    protected void grdUnderMin_SelectedIndexChanged(object sender, EventArgs e)
    {
        int row = grdUnderMin.SelectedIndex;

        string id = grdUnderMin.Rows[row].Cells[1].Text;
        Response.AppendHeader("Refresh", "0;url=SearchProducts.aspx");
    }

    protected void grdUnderMin_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void grdUnderMin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdUnderMin.PageIndex = e.NewPageIndex;

        dtProducts = s.SearchUnderMinProduct();

        grdUnderMin.DataSource = dtProducts;

        grdUnderMin.DataBind();
    }
}