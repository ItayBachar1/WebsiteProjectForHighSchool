using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Insert : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private DataTable dtCities = null;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Redirect("Wrong.aspx");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client") || level.Equals("Worker"))
                Response.Redirect("Wrong.aspx");

            if (Page.IsPostBack == false)
            {
                dtCities = s.GetAllCities();

                for (int i = 1; i <= dtCities.Rows.Count; i++)
                    city.Items.Insert(i, dtCities.Rows[i - 1][1].ToString());
            }
        }
    }
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        DataTable dtbl = s.GetAllClients();
        if (dtbl == null)
        {
            return;
        }

        localhost.Client c = new localhost.Client();
        c.Id = txtid.Text;
        c.Password = txtpass.Text;
        c.FirstName = txtname.Text;
        c.LastName = txtlastname.Text;
        c.City = city.SelectedIndex;
        c.Address = txtstreet.Text;
        c.Numadress = txtnum.Text;
        c.Phone = txtphone.Text;
        c.Mail = txtmail.Text;
        c.Birth = txtBirth.Text;
        c.Pic = "11.jpg";

        if (image.HasFile == true)
        {
            c.Pic = image.FileName;
            image.SaveAs(Server.MapPath("pic/users/") + image.FileName);
        }

        lbl_clientidError.Text = "";
       

        bool CanContinue = true;
        //check id name
        DataRow[] foundAuthors = dtbl.Select("Idss = '" + c.Id + "'");
        if (foundAuthors.Length != 0)
        {
            lbl_clientidError.Text += "ID already exists. ";
            CanContinue = false;
        }
         // check city
        if (c.City == 0)
        {
            lbl_cityError.Text += "Please select a city. ";
            CanContinue = false;
        }

        if (CanContinue)
        {
            c.Level = txtlevel.Text;
            c.Status = "online";
            s.Insertnewacc(c);

            Response.Write("<script type='text/javascript'>alert('The registration was successful');location.href='Login.aspx'</script>");

        }



    }
}