using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Delivery : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable dtclients = null;
    private static DataTable dtorder = null;
    private static DataTable dtcar = null;

    public static string generateID()
    {
        long i = 1;

        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }

        string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

        return number;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["Client"] == null || Session["Delivery"] == null)
                Response.Redirect("Error.aspx");
            else
            {
                DataTable check = (DataTable)Session["Client"];

                string level = check.Rows[0][11].ToString();

                if (level.Equals("client"))
                    Response.Write("<script type='text/javascript'>alert('You are not a Worker!');location.href='Error.aspx'</script>");
            }
            dtorder = (DataTable)Session["Delivery"];
            dtclients = (DataTable)Session["Client"];
            lbldriver.Text = dtclients.Rows[0][0].ToString();
            lblidorder.Text = dtorder.Rows[0][0].ToString();
            lblidclient.Text = dtorder.Rows[0][1].ToString();
            lbldateofdelivery.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        // bool CanContinue = true;

        localhost.DeliveryDetails dde = new localhost.DeliveryDetails();
        dde.OrderID = lblidorder.Text;
        string generate = generateID();
        while (s.SearchDeliveryId(generate))
            generate = generateID();
        dde.DeliveryID = generate;

        localhost.Delivery d = new localhost.Delivery();

        dtcar = s.SearchByCarName(txtcarname.Text);
        if (dtcar.Rows.Count == 0)
        {

            Response.Write("<script type='text/javascript'>alert('The name of the car is Wrong');location.href='Delivery.aspx'</script>");
        }




        else
        {

            d.DeliveryID = dde.DeliveryID;
            d.DriverID = lbldriver.Text;
            d.DeliveryDate = lbldateofdelivery.Text;
            d.TruckID = s.GetCarIdFromCarName(txtcarname.Text);

            /*  if (d.TruckID == "")
              {

                  lblerror.Text += "Wrong Truck Name ";
                  CanContinue = false;

              }
             * */
            d.Status = "not sent";
            d.Idss = lblidclient.Text;
            s.NewDelivery(d);
            s.NewDeliveryDetail(dde);

            lblerror.Text = "";





            //  if (CanContinue)
            //  {
            s.UpdateOrderStatus(lblidorder.Text, "2");
            Session["search"] = s.SearchOrderByIdOrder(lblidorder.Text);
            Response.Write("<script type='text/javascript'>alert('The delivery has been added successfully.');location.href='AdminArea.aspx'</script>");
        }
    }
    }
