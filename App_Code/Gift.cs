using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Gift
{
    int userId;

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }
    int eventId;

    public int EventId
    {
        get { return eventId; }
        set { eventId = value; }
    }
    int guestId;

    public int GuestId
    {
        get { return guestId; }
        set { guestId = value; }
    }
    String description;

    public String Description
    {
        get { return description; }
        set { description = value; }
    }
    double cash;

    public double Cash
    {
        get { return cash; }
        set { cash = value; }
    }


	public Gift()
	{
		
	}
}