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
        if (getUser(userName) != null)  return true;
        else                            return false;
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

    public Boolean updateEvent(Event eventToUpdate, String userName)
    {
        return dal.updateEvent(eventToUpdate, userName);
    }



    //=====================================================================================================
    //                                      EVENT GUEST
    //=====================================================================================================

    public List<int> getEventGuestsIdList(String userName, int eventId)
    {
        return dal.getEventGuestsIdList(userName, eventId);
    }

    public Boolean addEventGuest(String userName, int eventId, int guestId)
    {
        return dal.addEventGuest(userName, eventId, guestId);
    }

    public Boolean deleteEventGuest(String userName, int eventId, int guestId)
    {
        return dal.deleteEventGuest(userName, eventId, guestId);
    }

    public Boolean deleteEventGuestEvent(String userName, int eventId)
    {
        return dal.deleteEventGuestEvent(userName, eventId);
    }




    //=====================================================================================================
    //                                           GUEST 
    //=====================================================================================================

    public List<Guest> getGuestList(String userName)
    {
        return dal.getGuestList(userName);
    }

    public Boolean addGuest(Guest newGuest, String userName)
    {
        return dal.addGuest(newGuest, userName);
    }

    public Boolean deleteGuest(String userName, int guestId)
    {
        return dal.deleteGuest(userName, guestId);
    }

    public Boolean updateGuest(Guest guestToUpdate, String userName)
    {
        return dal.updateGuest(guestToUpdate, userName);
    }


    //=====================================================================================================
    //                                           GROUP 
    //=====================================================================================================

    public List<Group> getGroupList(String userName)
    {
        return dal.getGroupList(userName);
    }

    public Boolean addGroup(Group newGroup, String userName)
    {
        return dal.addGroup(newGroup, userName);
    }

    public Boolean deleteEventGroup(String userName, int groupId)
    {
        return dal.deleteGroup(userName, groupId);
    }

    public Boolean updateGroup(Group groupToUpdate)
    {
        return dal.updateGroup(groupToUpdate);
    }



    //=====================================================================================================
    //                                           FUNCTIONS 
    //=====================================================================================================










}