using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Update : System.Web.UI.Page
{
    private static DataTable dt = null;
    private static string id = "";
    private static string password = "";
    private static string firstName = "";
    private static string lastName = "";
    private static int city = 0;
    private static string street = "";
    private static string numstreet = "";
    private static string mail = "";
    private static string phone = "";

    private localhost.Service s = new localhost.Service();
    private localhost.Client c = new localhost.Client();

    private DataTable dtCities = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            if (Session["Client"] == null)
                Response.Redirect("Home.aspx");


            dtCities = s.GetAllCities();

            for (int i = 1; i <= dtCities.Rows.Count; i++)
                cities.Items.Insert(i, dtCities.Rows[i - 1][1].ToString());

            dt = (DataTable)Session["Client"];

            id = dt.Rows[0][0].ToString();

            lblid.Text = id;


            password = dt.Rows[0][1].ToString();

            txtnewpass.Text = password;

            firstName = dt.Rows[0][2].ToString();

            txtname.Text = firstName;

            lastName = dt.Rows[0][3].ToString();

            txtlastname.Text = lastName;

            city = int.Parse(dt.Rows[0][4].ToString());

            cities.SelectedIndex = city - 1;

            street = dt.Rows[0][5].ToString();

            txtaddress.Text = street;

            numstreet = dt.Rows[0][6].ToString();

            txtnumaddress.Text = numstreet;

            phone = dt.Rows[0][7].ToString();

            txtphone.Text = phone;

            mail = dt.Rows[0][8].ToString();
            txtemail.Text = mail;

            img.ImageUrl = "~/pic/users/" + dt.Rows[0][10].ToString();
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        bool cont = true;

        if (cont)
        {
            if (txtnewpass.Text.Length != 0)
                password = txtnewpass.Text;

            if (txtname.Text.Length != 0)
                firstName = txtname.Text;

            if (txtlastname.Text.Length != 0)
                lastName = txtlastname.Text;

            city = cities.SelectedIndex + 1;


            if (txtaddress.Text.Length != 0)
                street = txtaddress.Text;

            if (txtnumaddress.Text.Length != 0)
                numstreet = txtnumaddress.Text;

            if (txtemail.Text.Length != 0)
                mail = txtemail.Text;


            if (txtphone.Text.Length != 0)
                phone = txtphone.Text;


            localhost.Client c = new localhost.Client();
            c.Id = id;

            c.Password = password;

            c.FirstName = firstName;

            c.LastName = lastName;

            c.City = city;

            c.Address = street;

            c.Numadress = numstreet;

            c.Mail = mail;

            c.Phone = phone;

            if ((c.Pic != f.FileName) && (f.HasFile))
            {
                
                f.SaveAs(Server.MapPath("~/pic/users/") + f.FileName);
                c.Pic = f.FileName;
              //  dt = s.SearchById(c.Id);
                //c.Pic = dt.Rows[0][10].ToString();
            }
            else
            {
                dt = s.SearchById(c.Id);
                c.Pic = dt.Rows[0][10].ToString();
            }

            c.Level = "client";

            c.Status = "online";

            s.Updateclient(c);

            Session["Client"] = s.SearchById(id);

            Response.Write("<script type='text/javascript'>alert('The update was successful');location.href='Update.aspx'</script>");



        }
    }
}

