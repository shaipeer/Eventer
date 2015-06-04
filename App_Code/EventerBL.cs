using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventerBL
/// </summary>
public class EventerBL
{
    EventerDAL dal;

	public EventerBL()
	{
	    dal = new EventerDAL();	
	}


    public LinkedList<Event> getEventList()
    {
        return dal.getEventList();
    }

    public void addEvent(Event newEvent)
    {
        dal.addEvent(newEvent);
    }




}