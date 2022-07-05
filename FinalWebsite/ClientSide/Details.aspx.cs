using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private localhost.Product p = new localhost.Product();
    private static DataTable dtproduct = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["deatails"] == null)
                Response.Redirect("Wrong.aspx");
            dtproduct = (DataTable)Session["deatails"];
            lblid.Text = dtproduct.Rows[0][0].ToString();
            lblname.Text = dtproduct.Rows[0][1].ToString();
            lblmyprice.Text = dtproduct.Rows[0][6].ToString();
            lblcompany.Text = s.GetKindNam(dtproduct.Rows[0][2].ToString());
            imgproduct.ImageUrl = "~/pic/product/" + dtproduct.Rows[0][9].ToString();

        }
    }
}