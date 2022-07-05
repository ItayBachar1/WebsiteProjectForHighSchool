using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Card
/// </summary>
public class Card
{
	public Card()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string idclient;

    public string Idss
    {
        get { return idclient; }
        set { idclient = value; }
    }

    private string idcard;

    public string CardID
    {
        get { return idcard; }
        set { idcard = value; }
    }

    private string carddate;

    public string ExpiryDate
    {
        get { return carddate; }
        set { carddate = value; }
    }

    private int cvv;

    public int CVV
    {
        get { return cvv; }
        set { cvv = value; }
    }
}