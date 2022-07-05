using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client
{
  private string id;
    private string password;
    private string firstname;
    private string lastname;
    private string email;
    private string phone;
    private int city;
    private string address;
    private string numadress;
    private string birth;
    private string level;
    private string status;
    private string pic;
    
	public Client()
	{

	}

  

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
   

    public string Password
    {
        get { return password; }
        set { password = value; }

    }

    public string FirstName
    {
        get { return firstname; }
        set { firstname = value; }
    }

    public string LastName
    {
        get { return lastname; }
        set { lastname = value; }
    }
 

    public string Mail
    {
        get { return email; }
        set { email = value; }
    }

    public string Birth
    {
        get { return birth; }
        set { birth = value; }
    }


    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
   

    public int City
    {
        get { return city; }
        set { city = value; }
    }
    

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    

    public string Numadress
    {
        get { return numadress; }
        set { numadress = value; }
    }
    public string Pic
    {
        get { return pic; }
        set { pic = value; }
    } 

    public string Level
    {
        get { return level; }
        set { level = value; }
    }
    

    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    
}