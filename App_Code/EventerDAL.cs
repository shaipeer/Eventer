using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventerDAL
/// </summary>
public class EventerDAL
{

    private SqlConnection sqlCon;

	public EventerDAL()
	{

        string conectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"D";
        conectionString = conectionString.Remove(conectionString.Length - 1);
        conectionString += AppDomain.CurrentDomain.BaseDirectory;
        conectionString += "\\";
        conectionString = conectionString.Remove(conectionString.Length - 1);
        conectionString += "Eventer.mdf\";Integrated Security=True;Connect Timeout=30";

        sqlCon = new SqlConnection(conectionString);
        try
        {
            sqlCon.Open();
        }
        catch (SqlException)
        {
            
        }
    
    }




    //=======================================  EVENT  =====================================================

    public List<Event> getEventList()
    {
        List<Event> eventList = new List<Event>();





        return eventList;
    }

    public void addEvent(Event newEvent)
    {
        
    }

    public void deleteEvent(int userId, int eventId)
    {
        
    }

    public void updateEvent(Event eventToUpdate)
    {
        
    }



    //=======================================  GUEST  =====================================================


    public List<Guest> getGuestList()
    {
        List<Guest> guestList = new List<Guest>();





        return guestList;
    }

    public void addGuest(Guest newGuest)
    {

    }

    public void deleteGuest(int userId, int guestId)
    {

    }

    public void updateGuest(Guest guestToUpdate)
    {

    }



    //=======================================  USER  =====================================================

    public List<User> getUserList()
    {
        List<User> UserList = new List<User>();





        return UserList;
    }

    public void addUser(User newUser)
    {

    }

    public void deleteUser(int userId, int UserId)
    {

    }

    public void updateUser(User UserToUpdate)
    {

    }

    //=======================================  GROUP  =====================================================

    //=======================================  GIFT   =====================================================








}