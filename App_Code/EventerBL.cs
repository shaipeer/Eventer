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


    //=====================================================================================================
    //                                           USER 
    //=====================================================================================================




    //=====================================================================================================
    //                                           EVENT 
    //=====================================================================================================

    public List<Event> getEventList()
    {
        return dal.getEventList();
    }

    public Boolean addEvent(Event newEvent)
    {
        return dal.addEvent(newEvent);
    }

    public Boolean deleteEvent(int userId, int eventId)
    {
        return dal.deleteEvent(userId, eventId);
    }

    public Boolean updateEvent(Event eventToUpdate)
    {
        return dal.updateEvent(eventToUpdate);
    }


    //=====================================================================================================
    //                                           GUEST 
    //=====================================================================================================

    public List<Guest> getGuestList()
    {
        return dal.getGuestList();
    }

    public Boolean addGuest(Guest newGuest)
    {
        return dal.addGuest(newGuest);
    }

    public Boolean deleteGuest(int userId, int guestId)
    {
        return dal.deleteGuest(userId, guestId);
    }

    public Boolean updateGuest(Guest guestToUpdate)
    {
        return dal.updateGuest(guestToUpdate);
    }


    //=====================================================================================================
    //                                           GROUP 
    //=====================================================================================================




    //=====================================================================================================
    //                                           GIFT 
    //=====================================================================================================






}