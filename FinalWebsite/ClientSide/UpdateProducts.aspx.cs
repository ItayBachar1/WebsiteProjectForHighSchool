using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UpdateProducts : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();

    private localhost.Product a = new localhost.Product();

    private static DataTable dtstock = null;

    private DataTable dtProductKinds = null;

    private DataTable dtSuppliers = null;

    private DataTable dtbl = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client"))
                Response.Write("<script type='text/javascript'>alert('You are not a worker!');location.href='Wrong.aspx'</script>");

            if (!Page.IsPostBack)
            {
                dtProductKinds = s.GetAllKinds();

                for (int i = 1; i <= dtProductKinds.Rows.Count; i++)
                    Kind.Items.Insert(i, dtProductKinds.Rows[i - 1][1].ToString());

                dtSuppliers = s.GetAllSup();

                for (int i = 1; i <= dtSuppliers.Rows.Count; i++)
                    Supplier.Items.Insert(i, dtSuppliers.Rows[i - 1][1].ToString());


                if (Session["searchproduct"] == null)
                    Response.Redirect("Wrong.aspx");


                dtstock = (DataTable)Session["searchproduct"];
                lblid.Text = dtstock.Rows[0][0].ToString();
                txtname.Text = dtstock.Rows[0][1].ToString();
                Kind.SelectedIndex = int.Parse(dtstock.Rows[0][2].ToString());
                txtminamount.Text = dtstock.Rows[0][3].ToString();
                txtmaxamount.Text = dtstock.Rows[0][4].ToString();
                txtcurrentamount.Text = dtstock.Rows[0][5].ToString();
                txtconsumerprice.Text = dtstock.Rows[0][6].ToString();
                txtcost.Text = dtstock.Rows[0][7].ToString();
                Supplier.SelectedIndex = int.Parse(dtstock.Rows[0][8].ToString());
                pic.ImageUrl = "pic/product/" + dtstock.Rows[0][9].ToString();
                lblstatus.Text = dtstock.Rows[0][10].ToString();




                if (dtstock.Rows[0][10].ToString().Equals("offline"))
                {
                    btndelete.Visible = false;
                    btnrestore.Visible = true;
                }
                else
                {
                    btnrestore.Visible = false;
                    btndelete.Visible = true;
                }

                if (Session["searchproduct"] == null)
                    Response.Redirect("SearchProducts.aspx");
            }
        }
    }




    protected void btndelete_Click(object sender, EventArgs e)
    {
        s.DelResProduct(dtstock.Rows[0][0].ToString(), true);

        Session["searchproduct"] = s.SearchByIdProduct(dtstock.Rows[0][0].ToString());

        Response.Write("<script type='text/javascript'>alert('Deleted Successfully.');location.href='UpdateProducts.aspx'</script>");

    }
    protected void btnrestore_Click(object sender, EventArgs e)
    {
        s.DelResProduct(dtstock.Rows[0][0].ToString(), false);
        Session["searchproduct"] = s.SearchByIdProduct(dtstock.Rows[0][0].ToString());

        Response.Write("<script type='text/javascript'>alert('Restored Successfully.');location.href='UpdateProducts.aspx'</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        dtbl = (DataTable)Session["searchproduct"];
        localhost.Product a = new localhost.Product();

        a.ProductId = lblid.Text;
        a.ProductName = txtname.Text;
        a.KindId = Kind.SelectedIndex.ToString();
        a.MinAmount = txtminamount.Text;
        a.MaxAmount = txtmaxamount.Text;
        a.CurrentAmount = txtcurrentamount.Text;
        a.ConsumerPrice = txtconsumerprice.Text;
        a.Cost = txtcost.Text;
        a.SupId = Supplier.SelectedIndex.ToString();

        if (FileUpload1.HasFile == true)
        {
            a.Pic = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("pic/product/") + FileUpload1.FileName);

        }

        else
            a.Pic = dtbl.Rows[0][9].ToString();

        a.Status = dtbl.Rows[0][10].ToString();

        s.UpdateProduct(a);

        Session["searchproduct"] = s.SearchByIdProduct(lblid.Text);

        Response.Write("<script type='text/javascript'>alert('Successfully Updated!');location.href='SearchProducts.aspx'</script>");

    }
}