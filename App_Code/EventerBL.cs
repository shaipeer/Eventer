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


    //=======================================  EVENT  =====================================================

    public List<Event> getEventList()
    {
        return dal.getEventList();
    }

    public void addEvent(Event newEvent)
    {
        dal.addEvent(newEvent);
    }

    public void deleteEvent(int userId, int eventId)
    {
        dal.deleteEvent(userId, eventId);
    }

    public void updateEvent(Event eventToUpdate)
    {
        dal.updateEvent(eventToUpdate);
    }


    //=======================================  GUEST  =====================================================

    public List<Guest> getGuestList()
    {
        return dal.getGuestList();
    }

    public void addGuest(Guest newGuest)
    {
        dal.addGuest(newGuest);
    }

    public void deleteGuest(int userId, int guestId)
    {
        dal.deleteGuest(userId, guestId);
    }

    public void updateGuest(Guest guestToUpdate)
    {
        dal.updateGuest(guestToUpdate);
    }

    //=======================================  USER   =====================================================

    //=======================================  GROUP  =====================================================

    //=======================================  GIFT   =====================================================




}