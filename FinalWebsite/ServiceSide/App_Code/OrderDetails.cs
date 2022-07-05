using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetails
/// </summary>
public class OrderDetails
{
	public OrderDetails()
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

    private string idproduct;

    public string ProductID
    {
        get { return idproduct; }
        set { idproduct = value; }
    }
    private int priceproduct;

    public int Price
    {
        get { return priceproduct; }
        set { priceproduct = value; }
    }
    private int quantityproduct;

    public int Amount
    {
        get { return quantityproduct; }
        set { quantityproduct = value; }
    }
}