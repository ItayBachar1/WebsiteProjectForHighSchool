using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Showorderinfo : System.Web.UI.Page
{
    private DataTable dtOrder = null;
    private DataTable dtDetails = null;
    private DataTable dtShow = null;
    private string status = "";
    private string id = "";
    private localhost.Service s = new localhost.Service();
    private DataTable CreateDtShow(DataTable dtOrder)
    {
        DataTable dtShow = new DataTable();
        DataTable dtProduct = null;
        dtShow.TableName = "Order";


        if (dtShow.Columns.Count == 0)
        {
            DataColumn dc1 = new DataColumn();

            dc1.ColumnName = "NameProduct";

            dtShow.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn();

            dc2.ColumnName = "Quantity";

            dtShow.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn();

            dc3.ColumnName = "Price";

            dtShow.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "Pic";

            dtShow.Columns.Add(dc4);

        }

        for (int i = 0; i < dtOrder.Rows.Count; i++)
        {
            dtProduct = s.SearchByIdProduct(dtOrder.Rows[i][1].ToString());
            DataRow dr = dtShow.NewRow();
            //Name product
            dr[0] = dtProduct.Rows[0][1].ToString();
            //Quantity
            dr[1] = dtOrder.Rows[i][2].ToString();
            //Price
            dr[2] = dtOrder.Rows[i][3].ToString();

            dr[3] = dtProduct.Rows[0][9].ToString();
            dtShow.Rows.Add(dr);
        }

        return dtShow;
    }
    private void Show(DataTable dt)
    {
        GrdOrder.DataSource = dt;

        GrdOrder.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client"))
                Response.Write("<script type='text/javascript'>alert('You are not a worker!');location.href='Error.aspx'</script>");
        }
        id = Request.QueryString["id"];

        dtOrder = s.SearchOrderId(id);

         if (!Page.IsPostBack)
        {
            dtDetails = s.SearchOrderDetail(dtOrder.Rows[0][0].ToString());
            dtShow = CreateDtShow(dtDetails);
            Show(dtShow);

        }
    }
}