using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class TruckAdd : System.Web.UI.Page
{

    private DataTable dtClient = null;

    private localhost.Service s = new localhost.Service();

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
        if (Session["Client"] == null)
            Response.Redirect("Wrong.aspx");
        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client"))
                Response.Write("<script type='text/javascript'>alert('You are not a Worker!');location.href='Error.aspx'</script>");
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        localhost.Cars c = new localhost.Cars();
        string generate = generateID();
        c.TruckID = generate;
        c.TruckName = txtcaname.Text;
        c.Capacity = txtcarcapacity.Text;
        c.Status = "active";
        c.Picture = "truck.jpg";
        if (FileUpload1.HasFile == true)
        {
            c.Picture = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("pic/") + FileUpload1.FileName);

        }
        s.NewCar(c);
        Response.Write("<script type='text/javascript'>alert('The truck has been added successfully.');location.href='AdminArea.aspx'</script>");


    }
}