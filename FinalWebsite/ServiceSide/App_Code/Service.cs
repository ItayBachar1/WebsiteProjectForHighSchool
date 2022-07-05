using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    private string GetPath()
    {
        string path = Server.MapPath("App_Data/Clients.mdb");

        return path;

    }

    [WebMethod]
    public DataTable GetAllCities()
    {
        string sql = "Select * from City";
        return (Connect.DownloadData(sql, "City", GetPath()));

    }
    [WebMethod]
    public void NewCar(Cars ca)
    {
        string sql = "Insert into Trucks values(@p1,@p2,@p3,@p4,@p5)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = ca.TruckID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = ca.TruckName;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = ca.Capacity;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = ca.Picture;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));

        cmd.Parameters["@p5"].Value = ca.Status;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public string GetIdOrderFromDeliveriesDetails(string iddelivry)
    {
        string sql = "Select * from Deliveries Where [DeliveryID]='" + iddelivry + "'";
        DataTable dt = Connect.DownloadData(sql, "Deliveries", GetPath());
        string sql2 = " Select * from DeliveriesDetails WHERE [DeliveryID]='" + dt.Rows[0][0].ToString() + "'";
        DataTable dtDetails = Connect.DownloadData(sql2, "DeliveriesDetails", GetPath());
        return dtDetails.Rows[0][1].ToString();

    }
    [WebMethod]
    public string GetNameCarFromIdCar(string idcar)
    {
        string sql = "Select * from Deliveries Where [TruckID]='" + idcar + "'";
        DataTable dt = Connect.DownloadData(sql, "Deliveries", GetPath());
        string sql2 = " Select * from Trucks WHERE [TruckID]='" + dt.Rows[0][2].ToString() + "'";
        DataTable dtcars = Connect.DownloadData(sql2, "Trucks", GetPath());
        return dtcars.Rows[0][1].ToString();

    }

    [WebMethod]
    public void UpdateDelivery(Delivery d)
    {
        string sql = "UPDATE Deliveries SET [TruckID]=@p1,[DeliveryDate]=@p2,[Status]=@p3 WHERE [DeliveryID]=@p4";

        OleDbCommand cmd = new OleDbCommand(sql);


        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = d.TruckID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = d.DeliveryDate;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = d.Status;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = d.DeliveryID;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public bool IsWorker(string username)
    {
        string sql = "SELECT * FROM Clients WHERE Idss='" + username + "'";

        DataTable dt = Connect.DownloadData(sql, "Clients", GetPath());

        if (dt.Rows.Count == 0)
            return false;
        string level = dt.Rows[0][11].ToString();

        return level.Equals("Admin") || level.Equals("Worker");
    }

    [WebMethod]
    public void AddFeedback(Feedback f)
    {
        string sql = "INSERT INTO Feedback values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = f.Id; ;


        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = f.Username;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = f.Worker;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = f.Professionalism;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = f.HumanRelation;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
        cmd.Parameters["@p6"].Value = f.Satisfaction;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
        cmd.Parameters["@p7"].Value = f.Comments;


        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));
        cmd.Parameters["@p8"].Value = f.Date;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public DataTable SearchFeedback(string by, string value)
    {
        string sql = "";
        if (by.Equals("id"))
            sql = "SELECT * FROM Feedback WHERE [IdFeedback]='" + value + "'";

        return Connect.DownloadData(sql, "Feedback", GetPath());
    }

    [WebMethod]
    public bool GaveFidback(string username, string trainer)
    {

        string sql = "SELECT * FROM Feedback WHERE [Idss]='" + username + "' AND [Worker]='" + trainer + "'";

        return Connect.DownloadData(sql, "Feedback", GetPath()).Rows.Count != 0;
    }

    [WebMethod]
    public void DeleteFidback(string username, string trainer)
    {
        string sql = "DELETE FROM Feedback WHERE [Idss]='" + username + "' AND [Worker]='" + trainer + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());

    }

    [WebMethod]
    public DataTable SearchFeedbackBy(string username, string trainer, string month, string year)
    {
        string sql = "SELECT * FROM Feedback WHERE MID(DateFeedback,7,4)='" + year + "'";

        if (username.Length != 0)
            sql += " AND [Idss]='" + username + "'";

        if (trainer.Length != 0)
            sql += " AND Worker='" + trainer + "'";

        if (!month.Equals("Month"))
            sql += " AND MID(DateFeedback,4,2)='" + month + "'";

        return Connect.DownloadData(sql, "Feedback", GetPath());
    }

    [WebMethod]
    public void UpdateCars(Cars c)
    {
        string sql = "UPDATE Trucks SET [TruckName]=@p1,[Capacity]=@p2,[Picture]=@p3,[Status]=@p4 WHERE [TruckID]=@p5";

        OleDbCommand cmd = new OleDbCommand(sql);


        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = c.TruckName;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = c.Capacity;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = c.Picture;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = c.Status;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = c.TruckID;


        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public DataTable GetAllCars()
    {
        string sql = "Select* from Trucks";
        return (Connect.DownloadData(sql, "Trucks", GetPath()));
    }

    [WebMethod]
    public DataTable SearchByStatuscar(string status)
    {
        string sql = "Select * from Trucks Where [Status]='" + status + "'";

        return Connect.DownloadData(sql, "Trucks", GetPath());
    }
    [WebMethod]
    public DataTable SearchByCarName(string name)
    {
        string sql = "Select * from Trucks Where [TruckName]='" + name + "'";

        return Connect.DownloadData(sql, "Trucks", GetPath());
    }
    /*   [WebMethod]
   public bool SearchCarId(string id)
   {
       string sql = "SELECT * FROM Trucks WHERE TruckID='" + id + "'";

       DataTable dt = Connect.DownloadData(sql, "Trucks", GetPath());

       return dt.Rows.Count != 0;

   }*/
    [WebMethod]
    public DataTable SearchByIdCar(string idcar)
    {
        string sql = "Select * from Trucks Where [TruckID]='" + idcar + "'";

        return Connect.DownloadData(sql, "Trucks", GetPath());
    }


    [WebMethod]
    public void NewDelivery(Delivery d)
    {
        string sql = "Insert into Deliveries values(@p1,@p2,@p3,@p4,@p5,@p6)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = d.DeliveryID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = d.DriverID;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = d.TruckID;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = d.DeliveryDate;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));

        cmd.Parameters["@p5"].Value = d.Status;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));

        cmd.Parameters["@p6"].Value = d.Idss;
         

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public void NewDeliveryDetail(DeliveryDetails dde)
    {
        string sql = "Insert into DeliveriesDetails values(@p1,@p2)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = dde.DeliveryID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = dde.OrderID;

        Connect.TakeAction(cmd, GetPath());
    }
    [WebMethod]
    public bool SearchDeliveryId(string id)
    {
        string sql = "SELECT * FROM Deliveries WHERE DeliveryID='" + id + "'";

        DataTable dt = Connect.DownloadData(sql, "Deliveries", GetPath());

        return dt.Rows.Count != 0;

    }


    [WebMethod]
    public string GetCarIdFromCarName(string Name)
    {
        string sql = "Select * from Trucks Where [TruckName]='" + Name + "'";
        DataTable dt = Connect.DownloadData(sql, "Trucks", GetPath());
        return (dt.Rows[0][0].ToString());
     
    }

    [WebMethod]
    public void UpdateOrderStatus(string id, string status)
    {
        string sql;
        sql = "UPDATE Orders SET [Status]=@p1 WHERE [OrderID]=@p2";

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = status;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = id;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public DataTable SearchOrderByIdOrder(string id)
    {
        string sql = "Select * from Orders Where [OrderID]='" + id + "'";

        return Connect.DownloadData(sql, "Orders", GetPath());
    }

    [WebMethod]
    public string GetCityName(int q)
    {
        string sql = "Select * from City where IdCity=" + q;
        DataTable z = Connect.DownloadData(sql, "City", GetPath());
        return z.Rows[0][1].ToString();
    }

    [WebMethod]
    public DataTable GetOrderByStatus(int status)
    {
        string sql = "Select * from Orders Where [Status]=" + status;
        DataTable dt = Connect.DownloadData(sql, "Orders", GetPath());
        return dt;

    }
    [WebMethod]
    public DataTable GetClientDeliveries(string idclient)
    {

        string sql = " Select * from Deliveries WHERE [Idss]='" + idclient + "'";
        return Connect.DownloadData(sql, "Orders", GetPath());

    }
    [WebMethod]
    public DataTable GetClientDeliveriesFromStatus(string idclient, string status)
    {

        string sql = "Select * from Deliveries Where [Idss]='" + idclient + "' AND [Status]='" + status + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());

    }

    [WebMethod]
    public DataTable GetAllDeliveries()
    {
        string sql = "Select* from Deliveries";
        return (Connect.DownloadData(sql, "Deliveries", GetPath()));
    }
    [WebMethod]
    public DataTable SearchByIdDeliveryID(string iddelivery, string idclient)
    {
        string sql = "Select * from Deliveries Where [DeliveryID]='" + iddelivery + "' AND [DriverID]='" + idclient + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }
    [WebMethod]
    public DataTable SearchDeliveryByIdCar(string idcar)
    {
        string sql = "Select * from Deliveries Where [TruckID]='" + idcar + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }

    [WebMethod]
    public DataTable SearchByIdDelivery(string iddelivery)
    {
        string sql = "Select * from Deliveries Where [DeliveryID]='" + iddelivery + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }

    [WebMethod]
    public DataTable SearchByCarId(string car, string idclient)
    {
        string sql = "Select * from Deliveries Where [TruckID]='" + car + "' AND [DriverID]='" + idclient + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }

    [WebMethod]
    public DataTable SearchByStatusDelivery(string status)
    {
        string sql = "Select * from Deliveries Where [Status]='" + status + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }

    [WebMethod]
    public DataTable GetDeliveriesByStatusDriver(string iddriver, string status)
    {
        string sql = "Select * from Deliveries Where [DriverID]='" + iddriver + "' AND [Status]='" + status + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }
    [WebMethod]
    public DataTable GetAllDeliveriesByIdClient(string id)
    {
        string sql = "Select * from Deliveries Where [Idss]='" + id + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());
    }
    [WebMethod]
    public DataTable GetClientDeliveriesFromDeliveryId(string idclient, string iddelivery)
    {

        string sql = "Select * from Deliveries Where [DriverID]='" + idclient + "' AND [DeliveryID]='" + iddelivery + "'";

        return Connect.DownloadData(sql, "Deliveries", GetPath());

    }

    [WebMethod]
    public DataTable GetOrderDetailsByStatus(int status)
    {
        string sql = "Select * from Orders Where [Status]=" + status;
        DataTable dt = Connect.DownloadData(sql, "Orders", GetPath());

        string[] names = { "OrderID", "ProdctID", "Amount", "Price" };

        DataTable dtReturn = Functions.CreateDataTalbe(names, "OrderDetails");


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string sql2 = "Select * from OrderDetails WHERE [OrderID]='" + dt.Rows[i][0].ToString() + "'";
            DataTable dtDetails = Connect.DownloadData(sql2, "OrderDetails", GetPath());

            for (int j = 0; j < dtDetails.Rows.Count; j++)
                dtReturn.ImportRow(dtDetails.Rows[j]);
        }

        return dtReturn;                                                                                 


    }

    [WebMethod]
    public void AddNewClient(Client c)
    {
        string sql = "Insert into Clients values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = c.Id;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = c.Password;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = c.FirstName;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = c.LastName;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.Integer));

        cmd.Parameters["@p5"].Value = c.City;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));

        cmd.Parameters["@p6"].Value = c.Address;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));

        cmd.Parameters["@p7"].Value = c.Numadress;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));

        cmd.Parameters["@p8"].Value = c.Phone;

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));

        cmd.Parameters["@p9"].Value = c.Mail;

        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));

        cmd.Parameters["@p10"].Value = c.Birth;

        cmd.Parameters.Add(new OleDbParameter("@p11", OleDbType.VarChar));

        cmd.Parameters["@p11"].Value = c.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p12", OleDbType.VarChar));

        cmd.Parameters["@p12"].Value = c.Level;

        cmd.Parameters.Add(new OleDbParameter("@p13", OleDbType.VarChar));

        cmd.Parameters["@p13"].Value = c.Status;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public void Insertnewacc(Client c)
    {
        string sql = "Insert into Clients values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = c.Id;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = c.Password;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = c.FirstName;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = c.LastName;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.Integer));

        cmd.Parameters["@p5"].Value = c.City;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));

        cmd.Parameters["@p6"].Value = c.Address;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));

        cmd.Parameters["@p7"].Value = c.Numadress;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));

        cmd.Parameters["@p8"].Value = c.Phone;

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));

        cmd.Parameters["@p9"].Value = c.Mail;

        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));

        cmd.Parameters["@p10"].Value = c.Birth;

        cmd.Parameters.Add(new OleDbParameter("@p11", OleDbType.VarChar));

        cmd.Parameters["@p11"].Value = c.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p12", OleDbType.VarChar));

        cmd.Parameters["@p12"].Value = c.Level;

        cmd.Parameters.Add(new OleDbParameter("@p13", OleDbType.VarChar));

        cmd.Parameters["@p13"].Value = c.Status;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public DataTable Login(string id, string pass)
    {
        string sql = "Select * from Clients where [Idss]='" + id + "' and [Password]='" + pass + "'";
        return (Connect.DownloadData(sql, "Clients", GetPath()));

    }
    [WebMethod]
    public void Updateclient(Client c)
    {
        string sql = "Update Clients set [Password]=@p1,[Firstname]=@p2,[Lastname]=@p3,[City]=@p4,[Street]=@p5,[Numstreet]=@p6,[Phone]=@p7,[Mail]=@p8,[Pic]=@p9 Where [Idss]=@p10";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = c.Password;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = c.FirstName;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = c.LastName;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Integer));

        cmd.Parameters["@p4"].Value = c.City;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));

        cmd.Parameters["@p5"].Value = c.Address;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));

        cmd.Parameters["@p6"].Value = c.Numadress;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));

        cmd.Parameters["@p7"].Value = c.Phone;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));

        cmd.Parameters["@p8"].Value = c.Mail;

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));
        cmd.Parameters["@p9"].Value = c.Pic;
        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));
        cmd.Parameters["@p10"].Value = c.Id;

        Connect.TakeAction(cmd, GetPath());

    }

    [WebMethod]
    public bool HasClient(string username)
    {
        string sql = "SELECT * FROM Clients WHERE [Idss]='" + username + "'";
        DataTable dt = (Connect.DownloadData(sql, "Clients", GetPath()));

        return dt.Rows.Count != 0;
    }


    //Search datatables


    [WebMethod]
    public DataTable SearchById(string id)
    {
        string sql = "SELECT * FROM Clients WHERE Idss='" + id + "'";

        return Connect.DownloadData(sql, "Clients", GetPath());
    }


    [WebMethod]
    public DataTable SearchBySql(string sql)
    {
        return Connect.DownloadData(sql, "Clients", GetPath());
    }

    [WebMethod]
    public DataTable SearchByaSql(string sql, string table)
    {
        return Connect.DownloadData(sql, table, GetPath());
    }

    [WebMethod]
    public DataTable GetAllWorker()
    {
        string sql = "SELECT * FROM Clients WHERE [Level]='Worker' OR [Level]='Admin' AND [Status]='online'";
        return Connect.DownloadData(sql, "Clients", GetPath());
    }


    [WebMethod]
    public string Citynam(int id) //מקבל את האיידי של העיר ומחזיר את שם העיר
    {
        string sql = "select * from City where IdCity=" + id;

        DataTable dtbl = Connect.DownloadData(sql, "City", GetPath());
        if (dtbl == null || dtbl.Rows[0][1] == null)
        {
            return "";
        }
        return dtbl.Rows[0][1].ToString();
    }

    //*********************************************

    [WebMethod]
    public void Delet_Client(string username)
    {
        string sql = "UPDATE Clients SET [Status]='offline' WHERE [Idss]='" + username + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public void Restor_Client(string username)
    {
        string sql = "UPDATE Clients SET [Status]='online' WHERE [Idss]='" + username + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());
    }


    [WebMethod]
    public DataTable GetAllClientsByField(string FieldName, string SearchCriteria)
    {
        string sql;
        if (FieldName == "City")
        {
            sql = "Select * from [Clients] where [" + FieldName + "]=" + SearchCriteria + "";
        }
        else
        {
            sql = "Select * from [Clients] where [" + FieldName + "]='" + SearchCriteria + "'";
        }
        return Connect.DownloadData(sql, "Clients", GetPath());
    }

    [WebMethod]
    public DataTable GetAllClients()
    {
        string sql = "Select * from Clients";
        return Connect.DownloadData(sql, "Clients", GetPath());
    }

    [WebMethod]
    public void FlipClientStatus(string ClientID)
    {
        DataTable dtbl = GetAllClientsByField("Idss", ClientID);
        if (dtbl == null || dtbl.Rows.Count == 0)
        {
            return;
        }

        string sql = "Update Clients set [Status]=@p1 where [Idss]='" + ClientID + "'";
        OleDbCommand cmd = new OleDbCommand(sql);

        //---------------------------------------------------------------//
        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = dtbl.Rows[0][12].ToString() == "online" ? "offline" : "online";

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public string GetKindNam(string q)
    {
        string sql = "Select * from ProductKinds Where [KindID]='" + q + "'";
        DataTable z = Connect.DownloadData(sql, "ProductKinds", GetPath());
        return z.Rows[0][1].ToString();

        
    }

    [WebMethod]
    public DataTable GetAllProductsByKind(int typecode)// Return Products By Type
    {
        Connect c = new Connect(Server.MapPath("App_Data/Clients.mdb"));

        string sql = "";

        if ((typecode == -1) || (typecode == 0))

            sql = "select * from Stock where [Status]='online'";

        else

            sql = "select * from Stock where [Status]='online' and [KindID]='" + typecode + "'";

        return Connect.DownloadData(sql, "Stock", GetPath());

    }

    [WebMethod]
    public string GetSupplierName(string q)
    {
        string sql = "Select * from Suppliers where SupID='" + q + "'";
        DataTable z = Connect.DownloadData(sql, "Suppliers", GetPath());
        return z.Rows[0][1].ToString();
    }


    [WebMethod]
    public DataTable GetViewOrders(string sql)// Return Orders for client or for admin
    {
        Connect c = new Connect(Server.MapPath("App_Data/Clients.mdb"));

        DataTable dt = Connect.DownloadData(sql, "Stock", GetPath());

        return (dt);
    }

    [WebMethod]
    public DataTable GetAllProducts()
    {
        string sql = "Select * from Stock";
        return Connect.DownloadData(sql, "Stock", GetPath());
    }

    [WebMethod]
    public DataTable SearchByIdProduct(string idproduct)
    {
        string sql = "Select * from Stock Where [ProductID]='" + idproduct + "'";

        return Connect.DownloadData(sql, "Stock", GetPath());
    }


    [WebMethod]
    public DataTable GetAllKinds()
    {
        string sql = "Select * from ProductKinds";
        return (Connect.DownloadData(sql, "ProductKinds", GetPath()));

    }

    [WebMethod]
    public DataTable GetAllSup()
    {
        string sql = "Select * from Suppliers";
        return (Connect.DownloadData(sql, "Suppliers", GetPath()));

    }

      [WebMethod]
      public DataTable SearchByStatusProduct(string Status)
      {
          string sql = "Select * from Stock Where [Status]='" + Status + "'";

          return Connect.DownloadData(sql, "Stock", GetPath());
      }

      [WebMethod]
      public DataTable SearchByNameProduct(string NameProduct)
      {
          string sql = "Select * from Stock Where [ProductName]='" + NameProduct + "'";

          return Connect.DownloadData(sql, "Stock", GetPath());
      }

      [WebMethod]
      public DataTable SearchByCurrentAmountProduct(string CurrentAmount)
      {
          string sql = "Select * from Stock Where [CurrentAmount]='" + CurrentAmount + "'";

          return Connect.DownloadData(sql, "Stock", GetPath());
      }

      [WebMethod]
      public DataTable SearchByCostProduct(string CostProduct)
      {
          string sql = "Select * from Stock Where [Cost]='" + CostProduct + "'";

          return Connect.DownloadData(sql, "Stock", GetPath());
      }

      [WebMethod]
      public DataTable SearchByConsumerPrice(string ConsumerPrice)
      {
          string sql = "Select * from Stock Where [ConsumerPrice]='" + ConsumerPrice + "'";

          return Connect.DownloadData(sql, "Stock", GetPath());
      }



    //------------------------------------------------------------------------


      [WebMethod]
      public void AddProduct(Product p)
      {
          string sql = "Insert into Stock values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";

          OleDbCommand cmd = new OleDbCommand(sql);

          cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

          cmd.Parameters["@p1"].Value = p.ProductId;

          cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

          cmd.Parameters["@p2"].Value = p.ProductName;

          cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

          cmd.Parameters["@p3"].Value = p.KindId;

          cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

          cmd.Parameters["@p4"].Value = p.MinAmount;

          cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));

          cmd.Parameters["@p5"].Value = p.MaxAmount;

          cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));

          cmd.Parameters["@p6"].Value = p.CurrentAmount;
          
          cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));

          cmd.Parameters["@p7"].Value = p.ConsumerPrice;

          cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));

          cmd.Parameters["@p8"].Value = p.Cost;

          cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));

          cmd.Parameters["@p9"].Value = p.SupId;

          cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));

          cmd.Parameters["@p10"].Value = p.Pic;

          cmd.Parameters.Add(new OleDbParameter("@p11", OleDbType.VarChar));

          cmd.Parameters["@p11"].Value = p.Status;


          Connect.TakeAction(cmd, GetPath());
      }

          //-----------------------------------------------------------------------

          [WebMethod]
    public void UpdateProduct(Product p)
    {
        string sql = "UPDATE Stock SET [ProductName]=@p1,[KindID]=@p2,[MinAmount]=@p3,[MaxAmount]=@p4,[CurrentAmount]=@p5,[ConsumerPrice]=@p6,[Cost]=@p7,[SupID]=@p8,[Picture]=@p9, [Status]=@p10 WHERE [ProductID]=@p11";

        OleDbCommand cmd = new OleDbCommand(sql);


        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = p.ProductName;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = p.KindId;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = p.MinAmount;


        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = p.MaxAmount;


        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = p.CurrentAmount;


        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
        cmd.Parameters["@p6"].Value = p.ConsumerPrice;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
        cmd.Parameters["@p7"].Value = p.Cost;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));
        cmd.Parameters["@p8"].Value = p.SupId; 

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));
        cmd.Parameters["@p9"].Value = p.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));
        cmd.Parameters["@p10"].Value = p.Status;

        cmd.Parameters.Add(new OleDbParameter("@p11", OleDbType.VarChar));
        cmd.Parameters["@p11"].Value = p.ProductId;


        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public void DelResProduct(string id, bool delete)
    {
        string sql;
        if (delete)
            sql = "UPDATE Stock SET [Status]='offline' WHERE [ProductID]='" + id + "'";

        else
            sql = "UPDATE Stock SET [Status]='online' WHERE [ProductID]='" + id + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());

    }

    [WebMethod]
    public void AddNewOrder(Orders o)
    {
        string sql = "Insert into Orders values(@p1,@p2,@p3,@p4,@p5)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = o.OrderID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = o.Idss;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = o.OrderDate;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = o.Total;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));

        cmd.Parameters["@p5"].Value = o.Status;

        Connect.TakeAction(cmd, GetPath());
    }

    [WebMethod]
    public void NewOrder(OrderDetails od)
    {
        string sql = "Insert into OrderDetalis values(@p1,@p2,@p3,@p4)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));

        cmd.Parameters["@p1"].Value = od.OrderID;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));

        cmd.Parameters["@p2"].Value = od.ProductID;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));

        cmd.Parameters["@p3"].Value = od.Price;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));

        cmd.Parameters["@p4"].Value = od.Amount;

        Connect.TakeAction(cmd, GetPath());
    }
    [WebMethod]
    public DataTable SearchOrdersUse(string username)
    {
        string sql = "SELECT * FROM Orders WHERE Idss='" + username + "'";

        DataTable dt = SearchByaSql(sql, "Orders");

        return dt;
    }

    [WebMethod]
    public DataTable GetAllOrders()
    {
        string sql = "Select * from Orders";
        return (Connect.DownloadData(sql, "Orders", GetPath()));
    }
    [WebMethod]
    public DataTable SearchUnderMinProduct()
    {

        string sql = "SELECT * FROM Stock WHERE MinAmount>=CurrentAmount";

        return SearchByaSql(sql, "Stock");
    }
    [WebMethod]
    public DataTable SearchOrderDetail(string id)
    {
        string sql = "SELECT * FROM OrderDetails WHERE OrderID='" + id + "'";

        return Connect.DownloadData(sql, "OrderDetails", GetPath());
    }
    [WebMethod]
    public void IncreaseCurrentQuantit(string id, int inc)
    {
        int current = int.Parse(SearchByIdProduct(id).Rows[0][5].ToString());


        int newPrice = current + inc;
        string sql = "";
        if (current != 0)
            sql = "UPDATE Stock SET CurrentAmount=" + newPrice + " WHERE ProductID='" + id + "'";


        else
            sql = "UPDATE Stock SET CurrentAmount=" + newPrice + ",[Status]=1 WHERE ProductID='" + id + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());

    }

    [WebMethod]
    public void UpdateOrderStatu(string id, int status)
    {//0,1,2-status
        string sql;
        sql = "UPDATE Orders SET [Status]=@p1 WHERE [OrderID]=@p2";

        OleDbCommand cmd = new OleDbCommand(sql);
        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.Integer));
        cmd.Parameters["@p1"].Value = status;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = id;

        Connect.TakeAction(cmd, GetPath());
    }


    [WebMethod]
    public DataTable SearchClientBasi(string username, string first, string last)
    {
        string sql = "SELECT * FROM Clients";

        //Username לא ריק
        if (!username.Equals(string.Empty))
        {
            sql += " WHERE [Idss]='" + username + "'";

            if (!first.Equals(string.Empty))
                sql += " AND [FirstName]='" + first + "'";

            if (!last.Equals(string.Empty))
                sql += " AND [LastName]='" + last + "'";
        }

        else if (!first.Equals(string.Empty))
        {
            sql += " WHERE [FirstName]='" + first + "'";

            if (!last.Equals(string.Empty))
                sql += " AND [LastName]='" + last + "'";
        }

        else if (!last.Equals(string.Empty))
            sql += " WHERE [LastName]='" + last + "'";


        //אחרת הכל ריק
        return Connect.DownloadData(sql, "Clients", GetPath());
    }
    [WebMethod]
    public void AddCreditCarda(Card c)
    {
        string sql = "INSERT INTO CreditCards values(@p1,@p2,@p3,@p4)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = c.CardID;


        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = c.Idss;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = c.ExpiryDate;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Integer));
        cmd.Parameters["@p4"].Value = c.CVV;

        Connect.TakeAction(cmd, GetPath());
    }
    [WebMethod]
    public void AddOrderDetails(OrderDetails details)
    {
        string sql = "INSERT INTO OrderDetails values(@p1,@p2,@p3,@p4)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = details.OrderID;


        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = details.ProductID;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.Integer));
        cmd.Parameters["@p3"].Value = details.Amount;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Integer));
        cmd.Parameters["@p4"].Value = details.Price;

        Connect.TakeAction(cmd, GetPath());
    }


    [WebMethod]
    public void DecreaseCurrentQuantity(string id, int dec)
    {
        int current = int.Parse(SearchByIdProduct(id).Rows[0][5].ToString());


        int newPrice = current - dec;
        string sql = "";
        if (newPrice != 0)
            sql = "UPDATE Stock SET CurrentAmount=" + newPrice + " WHERE ProductID='" + id + "'";


        else
            sql = "UPDATE Stock SET CurrentAmount=" + newPrice + " AND [Status]=0 WHERE ProductID='" + id + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, GetPath());

    }

    [WebMethod]
    public DataTable SearchOrderId(string id)
    {
        string sql = "SELECT * FROM Orders WHERE OrderID='" + id + "'";

        return SearchByaSql(sql, "Orders");
    }

    [WebMethod]
    public bool SearchCardCod(string code)
    {
        string sql = "SELECT * FROM CreditCards WHERE CardID='" + code + "'";

        DataTable dt = SearchByaSql(sql, "CreditCards");

        //If true-found
        return dt.Rows.Count != 0;

    }


/*    [WebMethod]
    public DataTable GetOrderByFiled(string FieldName, string SearchCriteria)
    {
        string sql;

        sql = "Select * from [Orders] where [" + FieldName + "]='" + SearchCriteria + "'";

        return Connect.DownloadData(sql, "Orders", GetPath());
    }
  */   
}