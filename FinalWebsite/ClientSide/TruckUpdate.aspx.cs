using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class TruckUpdate : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private localhost.Cars c = new localhost.Cars();

    private static DataTable dtcar = null;

    private static DataTable dtbl = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["searchcar"] == null)
                Response.Redirect("Wrong.aspx");

            dtcar = (DataTable)Session["searchcar"];
            lblidcar.Text = dtcar.Rows[0][0].ToString();
            txtname.Text = dtcar.Rows[0][1].ToString();

            txtcapa.Text = dtcar.Rows[0][2].ToString();
            piccar.ImageUrl = "pic/" + dtcar.Rows[0][3].ToString();
            if (dtcar.Rows[0][4].ToString().Equals("active"))
                DropDownList4.SelectedIndex = 0;

            else if (dtcar.Rows[0][4].ToString().Equals("not active"))
                DropDownList4.SelectedIndex = 1;

            else if (dtcar.Rows[0][4].ToString().Equals("sold"))
                DropDownList4.SelectedIndex = 3;


        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        dtbl = (DataTable)Session["searchcar"];
        localhost.Cars c = new localhost.Cars();
        c.TruckID = lblidcar.Text;
        c.TruckName = txtname.Text;


        c.Capacity = txtcapa.Text;

        if (FileUpload1.HasFile == true)
        {
            c.Picture = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("pic/") + FileUpload1.FileName);
        }

        else
            c.Picture = dtbl.Rows[0][3].ToString();
        c.Status = DropDownList4.SelectedItem.Text;
        s.UpdateCars(c);
        Session["searchcar"] = s.SearchByIdCar(lblidcar.Text);



        Response.Write("<script type='text/javascript'>alert('The truck has been updated sucessfully.');location.href='Searchtruck.aspx'</script>");
    }
}