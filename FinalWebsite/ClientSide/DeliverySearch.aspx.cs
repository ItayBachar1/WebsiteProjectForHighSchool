using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class DeliverySearch : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private DataTable dt = null;

    private DataTable dtclients = null;
    public static string level = "";
    private static string idClient = "";
    private void Show(DataTable dtbl)
    {
        if (dtbl.Rows.Count != 0)
        {
            Delivery.DataSource = dtbl;
            Delivery.DataBind();
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
                DataTable dtclients = (DataTable)Session["Client"];
                idClient = dtclients.Rows[0][0].ToString();
                level = dtclients.Rows[0][11].ToString();

                if (level.Equals("client"))
                {
                    lblmes.Visible = false;
                    dt = s.GetClientDeliveries(idClient);
                    if (dt == null)
                        lblmes.Visible = true;
                    else
                        Show(dt);
                }

                else if (level.Equals("Worker"))
                {
                    lblmes.Visible = false;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                 
                }
                else
                {

                    lblmes.Visible = false;
                    dt = s.GetAllDeliveries();
                    Show(dt);





                }


            }
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmes.Visible = false;

        if (level.Equals("client"))
        {
            if (DropDownList2.SelectedIndex == 0)
            {
                dt = s.GetClientDeliveries(idClient);
                Show(dt);
            }
            if (DropDownList2.SelectedIndex == 1)
            {
                dt = s.GetClientDeliveriesFromStatus(idClient, "on the way");
                if (dt == null)
                {
                    lblmes.Visible = true;
                    dt = s.GetClientDeliveries(idClient);
                    Show(dt);
                }
                else
                    Show(s.GetClientDeliveriesFromStatus(idClient, "on the way"));
            }
            if (DropDownList2.SelectedIndex == 2)
            {
                dt = s.GetClientDeliveriesFromStatus(idClient, "not sent");

                if (dt == null)
                {
                    lblmes.Visible = true;
                    dt = s.GetClientDeliveries(idClient);
                    Show(dt);
                }
                else
                    Show(s.GetClientDeliveriesFromStatus(idClient, "not sent"));
            }

        }

        if (level.Equals("Worker"))
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                dt = s.GetAllDeliveriesByIdClient(idClient);
                Show(dt);
            }
            if (DropDownList1.SelectedIndex == 1)
            {
                dt = s.GetDeliveriesByStatusDriver(idClient, "on the way");
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveriesByIdClient(idClient);
                    Show(dt);
                }
                else
                    Show(s.GetDeliveriesByStatusDriver(idClient, "on the way"));
            }
            if (DropDownList1.SelectedIndex == 3)
            {
                dt = s.GetDeliveriesByStatusDriver(idClient, "not sent");

                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveriesByIdClient(idClient);
                    Show(dt);
                }
                else
                    Show(s.GetDeliveriesByStatusDriver(idClient, "not sent"));
            }
            if (DropDownList1.SelectedIndex == 2)
            {
                if (txtsearch.Text.Length == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveriesByIdClient(idClient);
                    Show(dt);
                }
                else
                    dt = s.SearchByIdDeliveryID(txtsearch.Text, idClient);
                if (dt.Rows.Count == 0)
                    lblmes.Visible = true;
                Show(s.SearchByIdDeliveryID(txtsearch.Text, idClient));

            }
            if (DropDownList1.SelectedIndex == 4)
            {
                if (txtsearch.Text.Length == 0)
                {
                    lblmes.Visible = true;
                }
                dt = s.SearchByCarId(txtsearch.Text, idClient);
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveriesByIdClient(idClient);
                    Show(dt);
                }
                else
                    Show(s.SearchByCarId(txtsearch.Text, idClient));
            }
        }

        else if (level.Equals("Admin"))
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                dt = s.GetAllDeliveries();
                Show(dt);
            }
            if (DropDownList1.SelectedIndex == 1)
            {
                dt = s.SearchByStatusDelivery("on the way");
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }
                else
                    Show(s.SearchByStatusDelivery("on the way"));
            }
            if (DropDownList1.SelectedIndex == 3)
            {
                dt = s.SearchByStatusDelivery("not sent");
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }
                else
                    Show(s.SearchByStatusDelivery("not sent"));

            }
            if (DropDownList1.SelectedIndex == 2)
            {
                if (txtsearch.Text.Length == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }

                dt = s.SearchByIdDelivery(txtsearch.Text);
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }
                else
                    Show(s.SearchByIdDelivery(txtsearch.Text));

            }
            if (DropDownList1.SelectedIndex == 4)
            {
                if (txtsearch.Text.Length == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }
                dt = s.SearchDeliveryByIdCar(txtsearch.Text);
                if (dt.Rows.Count == 0)
                {
                    lblmes.Visible = true;
                    dt = s.GetAllDeliveries();
                    Show(dt);
                }
                Show(s.SearchDeliveryByIdCar(txtsearch.Text));
            }

        }

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (level.Equals("Admin") || level.Equals("Worker"))
        {
            Button btn = (Button)sender;

            //Get the row that contains this button

            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int row = gvr.RowIndex;
            string id = Delivery.Rows[row].Cells[1].Text;

            Session["searchdelivery"] = s.SearchByIdDelivery(id);

            Response.AppendHeader("Refresh", "0;url=UpdateDelivery.aspx");
        }
        else
        {
            Button btn = (Button)sender;

            //Get the row that contains this button

            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int row = gvr.RowIndex;
            string id = Delivery.Rows[row].Cells[1].Text;

            Session["searchdelivery"] = s.SearchByIdDelivery(id);

            Response.AppendHeader("Refresh", "0;url=DeliveryDetails.aspx");
        }

    }

}