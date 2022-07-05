using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliveryDetails
/// </summary>
public class DeliveryDetails
{
    public DeliveryDetails()
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

    private string idorder;

    public string OrderID
    {
        get { return idorder; }
        set { idorder = value; }
    }
}