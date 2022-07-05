using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class UpdateDelivery : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private localhost.Delivery d = new localhost.Delivery();
    private localhost.DeliveryDetails dde = new localhost.DeliveryDetails();
    private static DataTable dtclient = null;
    private static DataTable dtdelivery = null;
    private static DataTable dtcar = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["searchdelivery"] == null)
                Response.Redirect("Wrong.aspx");
            else
            {
                dtclient = (DataTable)Session["client"];
                if (!dtclient.Rows[0][11].Equals("Admin") && !dtclient.Rows[0][11].Equals("Worker"))
                    Response.Redirect("Wrong.aspx");
            }
            dtdelivery = (DataTable)Session["searchdelivery"];
            lbliddelivery.Text = dtdelivery.Rows[0][0].ToString();
            lblidorder.Text = s.GetIdOrderFromDeliveriesDetails(dtdelivery.Rows[0][0].ToString());
            lbliddriver.Text = dtdelivery.Rows[0][1].ToString();
            lblidclient.Text = dtdelivery.Rows[0][5].ToString();
            txtcarname.Text = s.GetNameCarFromIdCar(dtdelivery.Rows[0][2].ToString());
            lbldate.Text = dtdelivery.Rows[0][3].ToString();
            if (dtdelivery.Rows[0][4].ToString().Equals("on the way"))
                DropDownList4.SelectedIndex = 0;

            else if (dtdelivery.Rows[0][4].ToString().Equals("not sent"))
                DropDownList4.SelectedIndex = 1;

            else if (dtdelivery.Rows[0][4].ToString().Equals("arrived"))
                DropDownList4.SelectedIndex = 2;

        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        dtcar = s.SearchByCarName(txtcarname.Text);
        if (dtcar.Rows.Count == 0)
        {

            Response.Write("<script type='text/javascript'>alert('The name of the car Is Wrong');location.href='UpdateDelivery.aspx'</script>");
        }

        else
        {
            localhost.Delivery d = new localhost.Delivery();
            d.DeliveryID = lbliddelivery.Text;
            d.DriverID = lbliddriver.Text;
            d.TruckID = s.GetCarIdFromCarName(txtcarname.Text);
            d.Idss = lblidclient.Text;
            d.DeliveryDate = lbldate.Text;
            d.Status = DropDownList4.SelectedItem.Text;
            s.UpdateDelivery(d);
            Session["searchdelivery"] = s.SearchByIdDelivery(lbliddelivery.Text);

            Response.Write("<script type='text/javascript'>alert('The Update Was Successful');location.href='Deliverysearch.aspx'</script>");
        }

    }
}