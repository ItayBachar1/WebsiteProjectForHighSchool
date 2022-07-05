using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class SearchOrder : System.Web.UI.Page
{
    public string level = "";
    private DataTable dtClients = null;
    private DataTable dtOrders = null;
    private DataTable you = null;
    private localhost.Service s = new localhost.Service();

    private void AllowSearch(bool allow)
    {
        if (allow)
        {
            txtuser.ReadOnly = false;
            txtfname.ReadOnly = false;
            txtlname.ReadOnly = false;
            btnSearch.Visible = true;
        }

        else
        {
            txtuser.ReadOnly = true;
            txtfname.ReadOnly = true;
            txtlname.ReadOnly = true;

            btnSearch.Visible = false;
        }
    }




    private string Status(int status)
    {
        switch (status)
        {
            case 0:
                return "Deleted";

            case 1:
                return "Didn't sent";

            case 2:
                return "Sent";

            default://לא מקרה שייקרה
                return "";
        }
    }
    private void Show(DataTable dtClient, DataTable dtOrders)
    {

        if (dtClient.Rows.Count == 0)
        {
            lbldidnt.Visible = true;
       
        }

        else
        {
            lbldidnt.Visible = false;
            txtuser.Text = dtClient.Rows[0][0].ToString();
            txtfname.Text = dtClient.Rows[0][2].ToString();
            txtlname.Text = dtClient.Rows[0][3].ToString();

    

            GrdOrders.DataSource = dtOrders;

            GrdOrders.DataBind();

            for (int i = 0; i < GrdOrders.Rows.Count; i++)
                GrdOrders.Rows[i].Cells[4].Text = Status(int.Parse(GrdOrders.Rows[i].Cells[4].Text));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Client"] != null)
        {
            you = (DataTable)Session["Client"];

            level = you.Rows[0][11].ToString();

            if (!Page.IsPostBack)
            {
                if (level.Equals("Admin"))
                {
                    AllowSearch(level.Equals("Admin"));
                    dtClients = s.SearchById(you.Rows[0][0].ToString());

                    dtOrders = s.GetAllOrders();
                    Show(dtClients, dtOrders);
                }
                else
                {
                    AllowSearch(level.Equals("Admin"));
                    dtClients = s.SearchById(you.Rows[0][0].ToString());

                    dtOrders = s.SearchOrdersUse(you.Rows[0][0].ToString());
                    Show(dtClients, dtOrders);
                }

            }

        }

        else
            Response.Redirect("login.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtuser.Text.Length == 0 && txtfname.Text.Length == 0 && txtlname.Text.Length == 0)
        {
            dtClients = s.SearchById(you.Rows[0][0].ToString());
            dtOrders = s.SearchOrdersUse(you.Rows[0][0].ToString());
        }

        else
        {
            dtClients = s.SearchClientBasi(txtuser.Text, txtfname.Text, txtlname.Text);


            dtOrders = s.SearchOrdersUse(txtuser.Text);

        }
        Show(dtClients, dtOrders);
    }
    protected void GrdOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        int row = GrdOrders.SelectedIndex;

        string id = GrdOrders.Rows[row].Cells[1].Text;
        //לעשות בעמוד שזה שולח בדיקה שאם זו לא ההזמנה שלו שיעביר דף
        Response.AppendHeader("Refresh", "0;url=ShowTheOrder.aspx?id=" + id);
    }
}