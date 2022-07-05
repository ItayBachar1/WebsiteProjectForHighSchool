using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class AddProduct : System.Web.UI.Page
{
    private localhost.Service s = new localhost.Service();
    private localhost.Product p = new localhost.Product();

    private DataTable dtStock = null;

    private DataTable dtProductKinds = null;

    private DataTable dtSuppliers = null;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Client"] == null)
            Response.Write("<script type='text/javascript'>alert('Please login first!');location.href='Login.aspx'</script>");

        else
        {
            DataTable check = (DataTable)Session["Client"];

            string level = check.Rows[0][11].ToString();

            if (level.Equals("client"))
                Response.Write("<script type='text/javascript'>alert('You are not a worker!');location.href='Error.aspx'</script>");

            if (Page.IsPostBack == false)
            {
                dtProductKinds = s.GetAllKinds();

                for (int i = 1; i <= dtProductKinds.Rows.Count; i++)
                    kind.Items.Insert(i, dtProductKinds.Rows[i - 1][1].ToString());

                dtSuppliers = s.GetAllSup();

                for (int i = 1; i <= dtSuppliers.Rows.Count; i++)
                    supid.Items.Insert(i, dtSuppliers.Rows[i - 1][1].ToString());

            }
        }
    }
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        DataTable dtbl = s.GetAllProducts();
        if (dtbl == null)
        {
            return;
        }

        localhost.Product p = new localhost.Product();
        p.ProductId = txtid.Text;
        p.ProductName = txtname.Text;
        p.KindId = kind.SelectedIndex.ToString();
        p.MinAmount = txtminamount.Text;
        p.MaxAmount = txtmaxamount.Text;
        p.CurrentAmount = txtcurrent.Text;
        p.ConsumerPrice = txtconsumerprice.Text;
        p.Cost = txtcost.Text;
        p.SupId = supid.SelectedIndex.ToString();
        p.Pic = "11.jpg";

        if (image.HasFile == true)
        {
            p.Pic = image.FileName;
            image.SaveAs(Server.MapPath("pic/product/") + image.FileName);
        }

        bool CanContinue = true;
        //check id name
        DataRow[] foundAuthors = dtbl.Select("ProductID = '" + p.ProductId + "'");
        if (foundAuthors.Length != 0)
        {
            lbl_pidError.Text += "ID already exists. ";
            CanContinue = false;
        }


        if (CanContinue)
        {

            p.Status = "online";
            s.AddProduct(p);

            Response.Write("<script type='text/javascript'>alert('The product has been added successfully!');location.href='WorkerArea.aspx'</script>");
        }
    }
}