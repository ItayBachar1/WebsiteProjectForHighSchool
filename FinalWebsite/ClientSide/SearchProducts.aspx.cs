using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class SearchProducts : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private DataTable dt = null;

    private void Show(DataTable dtbl)
    {

        if (dtbl.Rows.Count != 0)
        {
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
                GridView1.Rows[i].Cells[3].Text = s.GetKindNam(GridView1.Rows[i].Cells[3].Text);
            for (int i = 0; i < GridView1.Rows.Count; i++)
                GridView1.Rows[i].Cells[9].Text = s.GetSupplierName(GridView1.Rows[i].Cells[9].Text);

        }


        else
        {
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
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

            if (Page.IsPostBack == false)
            {

                lblmes.Visible = false;
                Show(s.GetAllProducts());


            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Show(s.GetAllProducts());

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmes.Visible = false;
        if (DropDownList1.SelectedIndex == 0)
        {
            dt = s.GetAllProducts();
        }
        if (DropDownList1.SelectedIndex == 1)
        {
            dt = s.SearchByStatusProduct("online");
        }
        if (DropDownList1.SelectedIndex == 2)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }

            dt = s.SearchByIdProduct(txtsearch.Text);
        }

        if (DropDownList1.SelectedIndex == 3)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByNameProduct(txtsearch.Text);
        }
        if (DropDownList1.SelectedIndex == 4)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByCurrentAmountProduct(txtsearch.Text);
        }

        if (DropDownList1.SelectedIndex == 5)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }

            dt = s.SearchByConsumerPrice(txtsearch.Text);

        }

        if (DropDownList1.SelectedIndex == 6)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }

            dt = s.SearchByCostProduct(txtsearch.Text);
        }

        if (dt.Rows.Count == 0)
        {

            lblmes.Visible = true;
            Show(dt);
        }
        else
        {
            lblmes.Visible = false;
            Show(dt);
        }

    }




    protected void btnshow_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        //Get the row that contains this button

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        int row = gvr.RowIndex;

        string id = GridView1.Rows[row].Cells[1].Text;

        Session["searchproduct"] = s.SearchByIdProduct(id);
        Response.AppendHeader("Refresh", "0;url=UpdateProducts.aspx");
    }

    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        lblmes.Visible = false;
        if (DropDownList1.SelectedIndex == 0)
        {
            Show(s.GetAllProducts());
        }
        if (DropDownList1.SelectedIndex == 1)
        {
            Show(s.SearchByStatusProduct("online"));
        }
        if (DropDownList1.SelectedIndex == 2)
        {
            Show(s.SearchByIdProduct(txtsearch.Text));
        }

        if (DropDownList1.SelectedIndex == 3)
        {
            Show(s.SearchByNameProduct(txtsearch.Text));
        }
        if (DropDownList1.SelectedIndex == 4)
        {
            Show(s.SearchByCurrentAmountProduct(txtsearch.Text));
        }

        if (DropDownList1.SelectedIndex == 5)
        {
            Show(s.SearchByConsumerPrice(txtsearch.Text));

        }

        if (DropDownList1.SelectedIndex == 6)
        {
            Show(s.SearchByCostProduct(txtsearch.Text));
        }

    }
}