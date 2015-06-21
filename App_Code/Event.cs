using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Event
{
    int eventId;

    public int EventId
    {
        get { return eventId; }
        set { eventId = value; }
    }
    String name;

    public String Name
    {
        get { return name; }
        set { name = value; }
    }
    String type;

    public String Type
    {
        get { return type; }
        set { type = value; }
    }
    String numOfGuests;

    public String NumOfGuests
    {
        get { return numOfGuests; }
        set { numOfGuests = value; }
    }
    String date;

    public String Date
    {
        get { return date; }
        set { date = value; }
    }
    String location;

    public String Location
    {
        get { return location; }
        set { location = value; }
    }

	public Event()
	{
        

	}
}