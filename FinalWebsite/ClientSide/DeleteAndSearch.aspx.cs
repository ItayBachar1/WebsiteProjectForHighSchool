using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DeleteAndSearch : System.Web.UI.Page
{

    private localhost.Service service = new localhost.Service();
    private localhost.Client c = new localhost.Client();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Client"] == null)
            Response.Redirect("Home.aspx");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client") || level.Equals("Worker"))
                Response.Redirect("Home.aspx");
        }
    }
    protected void btn_findClient_Click(object sender, EventArgs e)
    {
        if (tb_searchCriteria.Text == "")
        {
            FindAllClients();
        }
        else FindByField(dd_searchType.SelectedValue);

    }
    void FindByField(string FieldName)
    {
        DataTable dtbl = service.GetAllClientsByField(FieldName, tb_searchCriteria.Text);
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
    }
    void FindAllClients()
    {
        DataTable dtbl = service.GetAllClients();
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
    }
    void FlipClientStatus(string id)
    {
        service.FlipClientStatus(id);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
            l.Attributes.Add("onclick", "javascript:return " +
            "confirm('Delete or restore the client status: " +
            DataBinder.Eval(e.Row.DataItem, "Idss") + "')");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            // get the categoryID of the clicked row
            string clientID = Convert.ToString(e.CommandArgument);
            FlipClientStatus(clientID);
            if (tb_searchCriteria.Text == "")
            {
                FindAllClients();
            }
            else FindByField(dd_searchType.SelectedValue);
        }

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
}
