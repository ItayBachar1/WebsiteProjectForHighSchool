using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Reg : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private DataTable dtCities = null;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] != null)
            Response.Redirect("Home.aspx");

        else
        {
            if (Page.IsPostBack == false)
            {
                dtCities = s.GetAllCities();

                for (int i = 1; i <= dtCities.Rows.Count; i++)
                    city.Items.Insert(i, dtCities.Rows[i - 1][1].ToString());
            }
        }
    }
    protected void BtnReg_Click(object sender, EventArgs e)
    {
        localhost.Client c = new localhost.Client();

        DataTable dtbl = s.GetAllClients();
        if (dtbl == null)
        {
            return;
        }


        c.Id = id.Text;
        c.Password = pass.Text;
        c.FirstName = name.Text;
        c.LastName = lastname.Text;
        c.City = city.SelectedIndex;
        c.Address = street.Text;
        c.Numadress = num.Text;
        c.Phone = phone.Text;
        c.Mail = txtmail.Text;
        c.Birth = Birth.Text;
        c.Pic = "11.jpg";

        if (image.HasFile == true)
        {
            c.Pic = image.FileName;
            image.SaveAs(Server.MapPath("pic/users/") + image.FileName);
        }
        c.Level = "client";
        c.Status = "online";

        lbl_clientidError.Text = "";
        lbl_cityError.Text = "";

        bool CanContinue = true;
        //check id name
        DataRow[] foundAuthors = dtbl.Select("Idss = '" + c.Id + "'");
        if (foundAuthors.Length != 0)
        {
            lbl_clientidError.Text += "ID already exists. ";
            CanContinue = false;
        }

        if (c.Id == "")
        {
            lbl_clientidError.Text += "Id Client cannot be empty. ";
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

            s.AddNewClient(c);

            Response.Write("<script type='text/javascript'>alert('The registration succeed');location.href='Login.aspx'</script>");


        }


    }

    protected void city_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}