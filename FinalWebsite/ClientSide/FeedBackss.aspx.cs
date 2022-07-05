using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class FeedBackss : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private static DataTable dtFeedback = null;
    private static int number = 0;

    private void Show(DataTable dt)
    {
        GrdFeedbacks.DataSource = dt;

        GrdFeedbacks.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (Session["Client"] == null)
                Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

            if (level.Equals("client") || level.Equals("Worker"))
                Response.Write("<script type='text/javascript'>alert('You are not an Admin!');location.href='Wrong.aspx'</script>");


            else
            {
                dtFeedback = s.SearchFeedbackBy("", "", "Month", dropYear.SelectedValue);

                Show(dtFeedback);

            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        dtFeedback = s.SearchFeedbackBy(txtUsername.Text, txtTrainer.Text, dropMonth.SelectedValue, dropYear.SelectedValue);

        if (dtFeedback.Rows.Count == 0)
            lbldidnt.Visible = true;

        else
        {
            lbldidnt.Visible = false;
            Show(dtFeedback);

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int index = 0;
        int size = 0;

        for (int i = 0; i < GrdFeedbacks.Rows.Count; i++)
        {
            if (GrdFeedbacks.Rows[i].RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = GrdFeedbacks.Rows[i].Cells[0].FindControl("chkbox") as CheckBox;

                if (chkRow.Checked)
                    size++;
            }
        }


        if (size == 0)
            Response.Write(Functions.AlertBox("You did not select anyone!"));

        else
        {
            string[,] names = new string[size, 2];
            for (int i = 0; i < GrdFeedbacks.Rows.Count; i++)
            {
                if (GrdFeedbacks.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = GrdFeedbacks.Rows[i].Cells[0].FindControl("chkbox") as CheckBox;

                    if (chkRow.Checked)
                    {
                        names[index, 0] = GrdFeedbacks.Rows[i].Cells[2].Text;
                        names[index, 1] = GrdFeedbacks.Rows[i].Cells[3].Text;
                        index++;
                    }
                }
            }


            for (int i = 0; i < names.GetLength(0); i++)
                s.DeleteFidback(names[i, 0], names[i, 1]);

            Response.Write(Functions.AlertBox("Deleted successfully!"));

            number = 0;

            dtFeedback = s.SearchFeedbackBy("", "", "Month", dropYear.SelectedValue);

            Show(dtFeedback);



        }
    }

    protected void GrdFeedbacks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdFeedbacks.PageIndex = e.NewPageIndex;

        GrdFeedbacks.DataSource = dtFeedback;

        GrdFeedbacks.DataBind();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        GridViewRow gvr = (GridViewRow)btn.NamingContainer;

        int row = gvr.RowIndex;

        string id = GrdFeedbacks.Rows[row].Cells[1].Text;
        Response.AppendHeader("Refresh", "0;url=ShowFeedback.aspx?id=" + id);
    }
    protected void GrdFeedbacks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable you = (DataTable)Session["Client"];

        string level = you.Rows[0][11].ToString();

        if (level.Equals("client"))
        {
            GrdFeedbacks.Columns[0].Visible = false;
            e.Row.Cells[0].Visible = false;

        }
    }

}