using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
	public Orders()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string idorder;

    public string OrderID
    {
        get { return idorder; }
        set { idorder = value; }
    }

    private string idclient;

    public string Idss
    {
        get { return idclient; }
        set { idclient = value; }
    }
    private string dateorder;

    public string OrderDate
    {
        get { return dateorder; }
        set { dateorder = value; }
    }
    private string numbercard;

    public string CardNumber
    {
        get { return numbercard; }
        set { numbercard = value; }
    }
    private string datecard;

    public string CardDate
    {
        get { return datecard; }
        set { datecard = value; }
    }
    private string cvv;

    public string CVV
    {
        get { return cvv; }
        set { cvv = value; }
    }
    private string totalprice;

    public string Total
    {
        get { return totalprice; }
        set { totalprice = value; }
    }
    private int status;

    public int Status
    {
        get { return status; }
        set { status = value; }
    }

    private OrderDetails details;

    public OrderDetails Details
    {
        get { return details; }
        set { details = value; }
    }
}