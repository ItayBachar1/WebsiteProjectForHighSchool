using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Order : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private static int choice = 0;

    private static DataTable dt = null;

    private static DataTable dtOrders = null; //לקלוט מה שאני בוחר בדטא ליסט ולהוסיף שורה כל פעם


    public static int SearchDataTable(DataTable dt, int cell, string value)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
            if (dt.Rows[i][cell].ToString().Equals(value))
                return i;

        return -1;



    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["Client"] == null)
                Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

            if (Session["orderproduct"] == null)
                dtOrders = new DataTable();

            else

                dtOrders = (DataTable)Session["orderproduct"];
            dtOrders.TableName = "Orders";//חייבים לתת שם אחרת ייתקע

            if (dtOrders.Columns.Count == 0) //שאם נכנס עוד פעם שלא ייקרה מצב שיוסיף עוד שדות
            {
                DataColumn dc1 = new DataColumn();

                dc1.ColumnName = "Product's Id";

                dtOrders.Columns.Add(dc1);

                DataColumn dc2 = new DataColumn();

                dc2.ColumnName = "Product's Name";

                dtOrders.Columns.Add(dc2);

                DataColumn dc3 = new DataColumn();

                dc3.ColumnName = "Product's Price";

                dtOrders.Columns.Add(dc3);

                DataColumn dc4 = new DataColumn();

                dc4.ColumnName = "Quantity";

                dtOrders.Columns.Add(dc4);

                DataColumn dc5 = new DataColumn();

                dc5.ColumnName = "Total Price";

                dtOrders.Columns.Add(dc5);

                DataColumn dc6 = new DataColumn();

                dc6.ColumnName = "Image";

                dtOrders.Columns.Add(dc6);
            }



            dtlProd.DataSource = s.GetAllProducts();

            dtlProd.DataBind();
        }
    }

    protected void dtlProd_UpdateCommand(object source, DataListCommandEventArgs e)
    {


        Image img = ((Image)dtlProd.Items[e.Item.ItemIndex].FindControl("img"));

        string imgName = img.ImageUrl.Substring(img.ImageUrl.LastIndexOf("/") + 1);

        string id = ((Label)dtlProd.Items[e.Item.ItemIndex].FindControl("lblid")).Text;

        string name = ((Label)dtlProd.Items[e.Item.ItemIndex].FindControl("lblName")).Text;

        int quantity = int.Parse(((DropDownList)dtlProd.Items[e.Item.ItemIndex].FindControl("quantity1")).SelectedValue);

        int price = int.Parse(((Label)dtlProd.Items[e.Item.ItemIndex].FindControl("lblprice")).Text);

        int currenct = int.Parse(((Label)dtlProd.Items[e.Item.ItemIndex].FindControl("lblCurCap")).Text);

        int total = price * quantity;

        int row_find = SearchDataTable(dtOrders, 1, name);


        if (quantity > currenct)
            Response.Write("<script type='text/javascript'>alert('You Cannt Order This Quantity')</script>");



        else if (row_find != -1)
        {
            int updatequa = int.Parse(dtOrders.Rows[row_find][3].ToString()) + quantity;
            if (updatequa > currenct)
                Response.Write("<script type='text/javascript'>alert('You Cannt Order This Quantity')</script>");

            else
            {
                //   Response.Write("<script type='text/javascript'>alert('" + id + "')</script>");


                dtOrders.Rows[row_find][3] = (int.Parse(dtOrders.Rows[row_find][3].ToString()) + quantity).ToString();

                dtOrders.Rows[row_find][4] = (int.Parse(dtOrders.Rows[row_find][4].ToString()) + total).ToString();
            }



            //if(quantity>currenct)
            //     Response.Write("<script type='text/javascript'>alert('You Cannt Order This Quantity')</script>");

        }
        else
        {
            DataRow dr = dtOrders.NewRow();

            dr[0] = id;

            dr[1] = name;

            dr[2] = price;

            dr[3] = quantity;

            dr[4] = total;

            dr[5] = imgName;


            dtOrders.Rows.Add(dr);

        }
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Session["orderproduct"] = dtOrders;

        Response.Redirect("ShoppingCart.aspx");
    }



    protected void dtlProd_EditCommand(object source, DataListCommandEventArgs e)
    {

        string id = ((Label)dtlProd.Items[e.Item.ItemIndex].FindControl("lblid")).Text;

        Session["deatails"] = s.SearchByIdProduct(id);
        Response.Redirect("Details.aspx");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmes.Visible = false;
        if (catgorie.SelectedIndex == 0)
        {
            dt = s.GetAllProducts();
        }
        if (catgorie.SelectedIndex == 1)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);
        }
        if (catgorie.SelectedIndex == 2)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);
        }

        if (catgorie.SelectedIndex == 3)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);
        }
        if (catgorie.SelectedIndex == 4)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 5)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 6)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 7)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 8)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 9)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }
        if (catgorie.SelectedIndex == 10)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);

        }

        if (dt.Rows.Count == 0)
        {

            lblmes.Visible = true;


        }
        else
        {
            lblmes.Visible = false;
            dtlProd.DataSource = dt;
            dtlProd.DataBind();
        }
    }
    protected void catgorie_SelectedIndexChanged(object sender, EventArgs e)
    {
        localhost.Service s = new localhost.Service();

        choice = catgorie.SelectedIndex;

        DataTable dt = s.GetAllProductsByKind(choice);

        dtlProd.DataSource = dt;

        dtlProd.DataBind();
    }
    protected void dtlProd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}