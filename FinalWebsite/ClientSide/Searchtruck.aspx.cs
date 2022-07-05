using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Searchtruck : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable dt = null;
    private static DataTable dtclients = null;


    private void Show(DataTable dtbl)
    {
        if (dtbl.Rows.Count != 0)
        {
            cars.DataSource = dtbl;
            cars.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["Client"] == null)
                Response.Redirect("Wrong.aspx");
            else
            {
                dtclients = (DataTable)Session["Client"];

                if (dtclients.Rows[0][11].Equals("client"))
                    Response.Redirect("Wrong.aspx");

                else
                {
                    lblmes.Visible = false;
                    Show(s.GetAllCars());
                }
            }
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmes.Visible = false;

        if (DropDownList1.SelectedIndex == 0)
        {
            dt = s.GetAllCars();
        }
        if (DropDownList1.SelectedIndex == 1)
        {
            dt = s.SearchByStatuscar("active");
            if (dt.Rows.Count == 0)
                lblmes.Visible = true;

        }
        if (DropDownList1.SelectedIndex == 3)
        {
            dt = s.SearchByStatuscar("not active");

            if (dt.Rows.Count == 0)
                lblmes.Visible = true;

        }
        if (DropDownList1.SelectedIndex == 2)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByIdCar(txtsearch.Text);
            if (dt.Rows.Count == 0)
                lblmes.Visible = true;

        }
        if (DropDownList1.SelectedIndex == 4)
        {
            if (txtsearch.Text.Length == 0)
            {
                lblmes.Visible = true;
            }
            dt = s.SearchByCarName(txtsearch.Text);
            if (dt.Rows.Count == 0)
                lblmes.Visible = true;
        }
        Show(dt);

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (dtclients.Rows[0][11].Equals("Worker"))
        {
            Button btn = (Button)sender;



            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int row = gvr.RowIndex;

            string id = cars.Rows[row].Cells[1].Text;

            Session["searchcar"] = s.SearchByIdCar(id);
            Response.AppendHeader("Refresh", "0;url=Showtruck.aspx");
        }
        else
        {
            Button btn = (Button)sender;



            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int row = gvr.RowIndex;

            string id = cars.Rows[row].Cells[1].Text;

            Session["searchcar"] = s.SearchByIdCar(id);
            Response.AppendHeader("Refresh", "0;url=TruckUpdate.aspx");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}