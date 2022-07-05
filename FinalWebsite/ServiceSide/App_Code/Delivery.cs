using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Delivery
/// </summary>
public class Delivery
{
    public Delivery()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string iddelivery;

    public string DeliveryID
    {
        get { return iddelivery; }
        set { iddelivery = value; }
    }

    private string iddriver;

    public string DriverID
    {
        get { return iddriver; }
        set { iddriver = value; }
    }
    private string idcar;

    public string TruckID
    {
        get { return idcar; }
        set { idcar = value; }
    }

    private string dateofdelivery;

    public string DeliveryDate
    {
        get { return dateofdelivery; }
        set { dateofdelivery = value; }
    }
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    private string idClient;

    public string Idss
    {
        get { return idClient; }
        set { idClient = value; }
    }

}