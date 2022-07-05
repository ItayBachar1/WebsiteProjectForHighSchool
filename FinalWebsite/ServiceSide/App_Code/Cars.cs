using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cars
/// </summary>
public class Cars
{
    public Cars()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string idcar;

    public string TruckID
    {
        get { return idcar; }
        set { idcar = value; }
    }

    private string namecar;

    public string TruckName
    {
        get { return namecar; }
        set { namecar = value; }
    }
    private string capacitycar;

    public string Capacity
    {
        get { return capacitycar; }
        set { capacitycar = value; }
    }

    private string piccar;

    public string Picture
    {
        get { return piccar; }
        set { piccar = value; }
    }
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

}