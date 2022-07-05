using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class AddOrder : System.Web.UI.Page
{
    private DataTable dtOrders = null;

    private static DataTable dtClient = null;

    // private string username = "";
    private localhost.Service s = new localhost.Service();

    private localhost.Card card = new localhost.Card();

    private localhost.Orders order = new localhost.Orders();

    // private localhost.OrderDetails details = new localhost.OrderDetails();
    private void BindDataCreditCard()
    {

        for (int i = 0; i < 15; i++)
        {
            string year = Convert.ToString(DateTime.Now.Year + i);
            dropYear.Items.Add(new ListItem(year, year));
        }

        for (int i = 1; i <= 12; i++)
        {
            string text = (i < 10) ? "0" + i.ToString() : i.ToString();
            dropMonth.Items.Add(new ListItem(text, i.ToString()));
        }
    }


    private int GetTotal()
    {
        int total = 0;
        for (int i = 0; i < GrdOrder.Rows.Count; i++)
            total += int.Parse(GrdOrder.Rows[i].Cells[4].Text);

        return total;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Client"] == null)
                Response.Redirect("error.aspx");

            else if (Session["orderproduct"] == null)
                Response.Redirect("Order.aspx");
            else
            {
                dtClient = (DataTable)Session["Client"];

                //Response.Write(Functions.AlertBox(dtClient.Rows[0][0].ToString()));
                dtOrders = (DataTable)Session["orderproduct"];
                GrdOrder.DataSource = dtOrders;


                GrdOrder.DataBind();

                BindDataCreditCard();

            }
        }

    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {

        // Response.Write(Functions.AlertBox(dtClient.Rows[0][0].ToString()));
        //Add the credit card
        localhost.Card card = new localhost.Card();


        card.Idss = dtClient.Rows[0][0].ToString();

        card.CardID = txtCode.Text;

        card.ExpiryDate = dropMonth.SelectedValue + "/" + dropYear.SelectedValue;

        card.CVV = int.Parse(txtCvv.Text);


        if (!s.SearchCardCod(txtCode.Text))
            s.AddCreditCarda(card);

        //******************************************************


        //Add the order products

        localhost.Orders order = new localhost.Orders();

        string generate = Functions.generateID();

        while (s.SearchOrderId(generate).Rows.Count != 0)
            generate = Functions.generateID();

        order.OrderID = generate;

        order.Idss = dtClient.Rows[0][0].ToString();

        order.OrderDate = DateTime.Now.ToString("dd/MM/yyyy");

        order.Total = GetTotal().ToString();

        order.Status = 1;
        s.AddNewOrder(order);
        //Add the order details
        string idProduct = "";
        int quantity = 0;


        for (int i = 0; i < GrdOrder.Rows.Count; i++)
        {
            localhost.OrderDetails details = new localhost.OrderDetails();

            idProduct = GrdOrder.Rows[i].Cells[0].Text;
            quantity = int.Parse(GrdOrder.Rows[i].Cells[3].Text);

            details.OrderID = generate;

            details.ProductID = idProduct;

            details.Price = int.Parse(GrdOrder.Rows[i].Cells[2].Text) * quantity;

            details.Amount = quantity;

            s.AddOrderDetails(details);

            //להוריד כמות מוצר!!!!!!!!!
            s.DecreaseCurrentQuantity(idProduct, quantity);
        }



        Session["orderproduct"] = null;//ההזמנה כבר התבצעה


        Response.Write(Functions.AlertRedirect("The order had succecced", "Home.aspx"));


    }
}