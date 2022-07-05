using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Login : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private DataTable dtClients = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] != null)
            Response.Redirect("Home.aspx");

    }


    protected void btnlog_Click(object sender, EventArgs e)
    {
        string id = txtuser.Text;
        string pass = txtpass.Text;
        dtClients = s.Login(id, pass);
        if (dtClients.Rows.Count != 0)
        {
            Session["client"] = dtClients;
            string level = dtClients.Rows[0][11].ToString();
            string status = dtClients.Rows[0][12].ToString();

            if (status.Equals("online"))
            {

                if (level.Equals("client"))
                    Response.Redirect("ClientArea.aspx");

                if (level.Equals("Worker"))
                    Response.Redirect("WorkerArea.aspx");

                if (level.Equals("Admin"))
                    Response.Redirect("AdminArea.aspx");
            }
        }

    }

}