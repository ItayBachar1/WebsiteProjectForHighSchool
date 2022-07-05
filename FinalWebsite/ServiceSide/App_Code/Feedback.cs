using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    private string id;
    private string username;
    private string trainer;
    private int professionalism;
    private int humanRelation;
    private int satisfaction;
    private string comments;
    private string date;
    public Feedback()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }



    public string Worker
    {
        get { return trainer; }
        set { trainer = value; }
    }

    public int Professionalism
    {
        get { return professionalism; }
        set { professionalism = value; }
    }

    public int HumanRelation
    {
        get { return humanRelation; }
        set { humanRelation = value; }
    }

    public int Satisfaction
    {
        get { return satisfaction; }
        set { satisfaction = value; }
    }

    public string Comments
    {
        get { return comments; }
        set { comments = value; }
    }

    public string Date
    {
        get { return date; }
        set { date = value; }
    }

}