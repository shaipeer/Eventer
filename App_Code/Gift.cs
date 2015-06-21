using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Gift
{
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