using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WorkerArea : System.Web.UI.Page
{
    private DataTable dt = null;
    private DataTable dtclient = null;
    private localhost.Service s = new localhost.Service();
    private void Show(DataTable dtbl)
    {
        if (dtbl.Rows.Count != 0)
        {
            delivery.DataSource = dtbl;
            delivery.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Client"] == null)
                Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");
            else
            {
                DataTable check = (DataTable)Session["Client"];

                string level = check.Rows[0][11].ToString();

                if (level.Equals("client"))
                    Response.Write("<script type='text/javascript'>alert('You are not a Worker!');location.href='Wrong.aspx'</script>");
                dt = s.GetOrderByStatus(1);
                DataTable dt2 = s.GetOrderDetailsByStatus(1);


                dt.Columns.Add("ProductID");


                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i][5] = dt2.Rows[i][1].ToString();



                Show(dt);

            }

        }

        /*if (Session["Client"] == null)
            Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client"))
                Response.Write("<script type='text/javascript'>alert('You are not a Worker!');location.href='Error.aspx'</script>");

        }*/
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;



        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int row = gvr.RowIndex;
        string id = delivery.Rows[row].Cells[2].Text;

        Session["search"] = s.SearchById(id);

        Response.AppendHeader("Refresh", "0;url=ClientDetails.aspx");
    }
    protected void btndelivery_Click(object sender, EventArgs e)
    {

        Button btn = (Button)sender;



        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int row = gvr.RowIndex;
        string id = delivery.Rows[row].Cells[3].Text;

        Session["Delivery"] = s.SearchOrderByIdOrder(id);

        Response.AppendHeader("Refresh", "0;url=Delivery.aspx");
    }

    protected void btnshoworder_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;



        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int row = gvr.RowIndex;
        string id = delivery.Rows[row].Cells[3].Text;

        Response.AppendHeader("Refresh", "0;url=Showorderinfo.aspx?id=" + id);
    }

    protected void delivery_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}