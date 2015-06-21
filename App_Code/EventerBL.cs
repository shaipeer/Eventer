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
    public User getUser(String userName)
    {
        return dal.getUser(userName);
    }

    public Boolean addUser(User newUser)
    {
        return dal.addUser(newUser);
    }

    public Boolean isUserValid(String userName, String password)
    {
        User userToValidate = getUser(userName);

        if(userToValidate != null)
            if(userToValidate.Password.Equals(password))
                return true;

        return false;
    }

    public Boolean isUserExists(String userName)
    {
        User userToValidate = getUser(userName);

        if (userToValidate != null)
            return true;

        return false;
    }


    //=====================================================================================================
    //                                           EVENT 
    //=====================================================================================================

    public List<Event> getEventList(String userName)
    {
        return dal.getEventList(userName);
    }

    public Boolean addEvent(Event newEvent, String userName)
    {
        return dal.addEvent(newEvent, userName);
    }

    public Boolean deleteEvent(String userName, int eventId)
    {
        return dal.deleteEvent(userName, eventId);
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

    public Boolean addGuest(Guest newGuest, String userName)
    {
        return dal.addGuest(newGuest, userName);
    }

    public Boolean deleteGuest(String userName, int guestId)
    {
        return dal.deleteGuest(userName, guestId);
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