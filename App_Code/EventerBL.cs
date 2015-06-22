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
        if (dal.deleteEvent(userName, eventId))
            return dal.deleteEventGuestEvent(userName, eventId);
        return false;
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

    public Boolean removeGuestFromEvent(String userName, int eventId, int guestId)
    {
        return dal.removeGuestFromEvent(userName, eventId, guestId);
    }

    public Boolean deleteEventGuest(String userName, int GuestId)
    {
        return dal.deleteEventGuest(userName, GuestId);
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

    public Boolean addGuest(Guest newGuest, String userName, int eventId)
    {
        if (dal.addGuest(newGuest, userName))
            return addEventGuest(userName, eventId, getGuestId(newGuest, userName));
        return false;
    }

    public int getGuestId(Guest guest, String userName)
    {
        return dal.getGuestId(guest, userName);
    }

    public Boolean deleteGuest(String userName, int guestId)
    {
        if (dal.deleteGuest(userName, guestId))
            return dal.deleteEventGuest(userName, guestId);
        return false;
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

    public Boolean deleteGroup(String userName, int groupId)
    {
        return dal.deleteGroup(userName, groupId);
    }

    public Boolean updateGroup(Group groupToUpdate, String userName)
    {
        return dal.updateGroup(groupToUpdate, userName);
    }



    //=====================================================================================================
    //                                           FUNCTIONS 
    //=====================================================================================================


    public List<Guest> generateEventGuestList(String userName, int eventId)
    {
        List<Guest> guestList = new List<Guest>();
        List<int> eventGuestIdList = getEventGuestsIdList(userName, eventId);

        if (guestList != null)
        {
            foreach (Guest guest in getGuestList(userName))
            {
                if (isGuestInIdList(eventGuestIdList, guest))
                    guestList.Add(guest);
            }
        }
        return guestList;
    }

    private Boolean isGuestInIdList(List<int> eventGuestIdList, Guest guest)
    {
        foreach(int guestId in eventGuestIdList)
            if (guest.GuestId == guestId)
                return true;
        return false;
    }







}