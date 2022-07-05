using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private string productid;
    private string productname;
    private string kindid;
    private string minamount;
    private string maxamount;
    private string currentamount;
    private string consumerprice;
    private string cost;
    private string supid;
    private string pic;
    private string status = "online";

    public Product()
    {

    }



    public string ProductId
    {
        get { return productid; }
        set { productid = value; }
    }


    public string ProductName
    {
        get { return productname; }
        set { productname = value; }

    }

    public string KindId
    {
        get { return kindid; }
        set { kindid = value; }
    }

    public string MinAmount
    {
        get { return minamount; }
        set { minamount = value; }
    }


    public string MaxAmount
    {
        get { return maxamount; }
        set { maxamount = value; }
    }


    public string CurrentAmount
    {
        get { return currentamount; }
        set { currentamount = value; }
    }


    public string ConsumerPrice
    {
        get { return consumerprice; }
        set { consumerprice = value; }
    }


    public string Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    public string SupId
    {
        get { return supid; }
        set { supid = value; }
    }

    public string Pic
    {
        get { return pic; }
        set { pic = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

}