using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class ShowTheOrder : System.Web.UI.Page
{
    private DataTable dtOrder = null;
    private DataTable dtDetails = null;
    private DataTable dtShow = null;
    private string status = "";//סטטוס של הזמנה
    private string id = "";//id של הזמנה
    private localhost.Service s = new localhost.Service();
    private DataTable CreateDtShow(DataTable dtOrder)
    {
        DataTable dtShow = new DataTable();
        DataTable dtProduct = null;
        dtShow.TableName = "Order";//חייבים לתת שם אחרת ייתקע


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
            Response.Redirect("SearchOrder.aspx");
        id = Request.QueryString["id"];
       

        dtOrder = s.SearchOrderId(id);

        if (dtOrder.Rows.Count == 0) // כשמכניסים בקישור מזהה לא קיים או שסתם נכנסים לדף בלי הקישור
            Response.Redirect("SearchOrder.aspx");

        //הדטא טייבל של המשתמש שנכנס
        DataTable you = (DataTable)Session["Client"];

        string level = you.Rows[0][11].ToString();

        if (!level.Equals("Admin"))
        {
            btnSend.Visible = false;
            //ההזמנה היא לא של המשתמש הנוכחי או שאינו מנהל
            if (!dtOrder.Rows[0][1].ToString().Equals(you.Rows[0][0].ToString()))
                Response.Redirect("SearchOrder.aspx");
        }

        else
        {
            status = dtOrder.Rows[0][4].ToString();

            if (!status.Equals("0"))
            {
                btnDelete.Visible = true;
                if (!status.Equals("2"))
                    btnSend.Visible = true;

                else
                    btnSend.Visible = false;
            }

            else
            {
                btnDelete.Visible = false;
                btnSend.Visible = false;
            }

        }


        //שאר המקרים

        if (!Page.IsPostBack)
        {
            dtDetails = s.SearchOrderDetail(dtOrder.Rows[0][0].ToString());
            dtShow = CreateDtShow(dtDetails);
            Show(dtShow);

        }



    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataTable dtProduct = null;

        if (status.Equals("2"))//אי אפשר למחוק מה שנשלח
            Response.Write(Functions.AlertBox("Sorry the order had sent"));

        else
        {
            for (int i = 0; i < GrdOrder.Rows.Count; i++)
            {
                dtDetails = s.SearchOrderDetail(dtOrder.Rows[0][0].ToString());
                dtProduct = s.SearchByIdProduct(dtDetails.Rows[i][1].ToString());


                s.IncreaseCurrentQuantit(dtProduct.Rows[0][0].ToString(), int.Parse(dtDetails.Rows[i][2].ToString()));
            }
            s.UpdateOrderStatu(id, 0);
            // s.

            Response.Write(Functions.AlertRedirect("Order was deleted", "SearchOrder.aspx"));

        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

        s.UpdateOrderStatu(id, 2);

        Response.Write(Functions.AlertRedirect("Order had sent", "SearchOrder.aspx"));
    }
}