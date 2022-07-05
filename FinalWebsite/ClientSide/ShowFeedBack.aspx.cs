using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class ShowFeedBack : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (Session["Client"] == null)
                Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

            if (level.Equals("client") || level.Equals("Worker"))
                Response.Write("<script type='text/javascript'>alert('You are not an Admin!');location.href='Error.aspx'</script>");


            string id = Request.QueryString["id"];

            DataTable dtFeedback = s.SearchFeedback("id", id);

            if (dtFeedback.Rows.Count == 0)
                Response.Redirect("FeedBackss.aspx");

            lblId.Text = dtFeedback.Rows[0][0].ToString();
            lblUsername.Text = dtFeedback.Rows[0][1].ToString();
            lblTrainer.Text = dtFeedback.Rows[0][2].ToString();
            lblPro.Text = dtFeedback.Rows[0][3].ToString();
            lblHumanRelation.Text = dtFeedback.Rows[0][4].ToString();
            lblSatisfaction.Text = dtFeedback.Rows[0][5].ToString();
            txtInformation.Text = dtFeedback.Rows[0][6].ToString();
            lblDate.Text = dtFeedback.Rows[0][7].ToString();


        }
    }
}