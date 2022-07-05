using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class Feedback : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable you = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Write("<script type='text/javascript'>alert('Please login first in order to give a feedback!');location.href='Login.aspx'</script>");

        else
            you = (DataTable)Session["Client"];
    }
    protected void btnFeedBack_Click(object sender, EventArgs e)
    {
        if (!s.IsWorker(txtTrainer.Text))
            Response.Write(Functions.AlertBox("This is not a worker!"));


        else if (you.Rows[0][0].ToString().Equals(txtTrainer.Text))
            Response.Write(Functions.AlertBox("You can not feedback yourself!"));

        else
        {
            localhost.Feedback f = new localhost.Feedback();

            string id = Functions.generateID();


            while (s.SearchFeedback("id", id).Rows.Count != 0)
                id = Functions.generateID();
            f.Id = id;
            f.Username = you.Rows[0][0].ToString();

            f.Worker = txtTrainer.Text;

            f.Professionalism = dropPro.SelectedIndex + 1;

            f.Satisfaction = dropSatis.SelectedIndex + 1;

            f.HumanRelation = dropHuman.SelectedIndex + 1;

            f.Comments = txtInformation.Text;
            f.Date = DateTime.Now.ToString("dd/MM/yyyy");


            if (s.GaveFidback(f.Username, f.Worker))
            {
                s.DeleteFidback(f.Username, f.Worker);
                s.AddFeedback(f);
                Response.Write(Functions.AlertRedirect("Feedback repeated - thus the last one is deleted.", "Home.aspx"));

            }

            else
            {
                s.AddFeedback(f);

                Response.Write(Functions.AlertRedirect("The feedback has been sent successfully.", "Home.aspx"));
            }

        }
    }
}