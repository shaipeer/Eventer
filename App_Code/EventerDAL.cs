using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


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


    //=====================================================================================================
    //                                           USER 
    //=====================================================================================================
    public User getUser(String userName)
    {
        User user = new User();

        string commandString = "SELECT * FROM User WHERE user_name=" + userName;
        SqlCommand command = new SqlCommand(commandString, sqlCon);

        try
        {

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (reader != null)
            {
                user.FirstName  = reader[0].ToString();
                user.LastName   = reader[1].ToString();
                user.Mail       = reader[2].ToString();
                user.UserName   = reader[3].ToString();
                user.Password   = reader[4].ToString();
            }
            else
            {
                user = null;
            }

            reader.Close();
        }
        catch(SqlException e)
        {
            return null;
        }

        return user;
    }

    public Boolean addUser(User newUser)
    {
        string commandString = "INSERT INTO User (first_name, last_name, mail, user_name, password) " +
                               "VALUES ('" + newUser.FirstName + "', '" + newUser.LastName + "', '" + newUser.Mail + "', '" + newUser.UserName + "', '" + newUser.Password + "')";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }



    //=====================================================================================================
    //                                           EVENT
    //=====================================================================================================

    public List<Event> getEventList(String userName)
    {
        List<Event> eventList = new List<Event>();
        Event ev;

        string commandString = "SELECT * FROM Event WHERE user_name='" + userName+"'";
        SqlCommand command = new SqlCommand(commandString, sqlCon);
        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            ev = new Event();

            ev.EventId      = Convert.ToInt32(reader[1].ToString());
            ev.Name         = reader[2].ToString();
            ev.Type         = reader[3].ToString();
            ev.NumOfGuests  = reader[4].ToString();
            ev.Date         = reader[5].ToString();
            ev.Location     = reader[6].ToString();
            
            eventList.Add(ev);
        }
       
        reader.Close();

        
        return eventList;
    }

    public Boolean addEvent(Event newEvent, String userName)
    {
        string commandString = "INSERT INTO Event (user_name, event_id, event_name, type, number_of_guests, date, location) " +
                               "VALUES ('" + userName + "', '" + newEvent.EventId + "', '" + newEvent.Name + "', '" + newEvent.Type + "', '" + newEvent.NumOfGuests + "', '" + newEvent.Date + "', '" + newEvent.Location + "')";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean deleteEvent(String userName, int eventId)
    {

        String commandString = "DELETE FROM Event WHERE user_name='" + userName + "' AND event_id='" + eventId + "';";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean updateEvent(Event eventToUpdate)
    {
        String commandString = "UPDATE Event SET event_name='"       + eventToUpdate.Name        + "', " +
                                                "type='"             + eventToUpdate.Type        + "', " +
                                                "number_of_guests='" + eventToUpdate.NumOfGuests + "', " +
                                                "date='"             + eventToUpdate.Date        + "', " +
                                                "location='"         + eventToUpdate.Location    + "' " +
                                                "WHERE event_id='"   + eventToUpdate.EventId     + "';";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }


    //=====================================================================================================
    //                                         GUEST
    //=====================================================================================================
    public List<Guest> getGuestList()
    {
        List<Guest> guestList = new List<Guest>();
        Guest guest;

        string commandString = "SELECT * FROM Guest";
        SqlCommand command = new SqlCommand(commandString, sqlCon);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            guest = new Guest();

            guest.GuestId   = Convert.ToInt32(reader[1].ToString());
            guest.FirstName = reader[2].ToString();
            guest.LastName  = reader[3].ToString();
            guest.Phone     = reader[4].ToString();
            guest.GroupName   = reader[5].ToString();
            guest.Status    = reader[6].ToString();
            guest.Arriving  = reader[7].ToString();

            guestList.Add(guest);
        }

        reader.Close();


        return guestList;
    }

    public Boolean addGuest(Guest newGuest, String userName)
    {
        string commandString = "INSERT INTO Event (user_name, guest_id, first_name, last_name, phone, group_name, status, arriving) " +
                                 "VALUES ('" + userName             + "', '" +
                                               newGuest.GuestId     + "', '" + 
                                               newGuest.FirstName   + "', '" + 
                                               newGuest.LastName    + "', '" + 
                                               newGuest.Phone       + "', '" + 
                                               newGuest.GroupName     + "', '" +
                                               newGuest.Status      + "', '" +
                                               newGuest.Arriving    + "')";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean deleteGuest(String userName, int guestId)
    {
        String commandString = "DELETE FROM Guest WHERE user_name='" + userName + "' AND guest_id='" + guestId + "';";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean updateGuest(Guest guestToUpdate)
    {
        String commandString = "UPDATE Guest SET first_name='"  + guestToUpdate.FirstName   + "', " +
                                                "last_name='"   + guestToUpdate.LastName    + "', " +
                                                "phone='"       + guestToUpdate.Phone       + "', " +
                                                "group_name='"  + guestToUpdate.GroupName   + "', " +
                                                "status='"      + guestToUpdate.Status      + "', " +
                                                "arriving='"    + guestToUpdate.Arriving    + "' "  +
                                                "WHERE guest_id='"  + guestToUpdate.GuestId + "';"  ;

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    


    //=====================================================================================================
    //                                           GROUP
    //=====================================================================================================



    public List<Group> getGroupList(String userName)
    {
        List<Group> groupList = new List<Group>();
        Group group;

        string commandString = "SELECT * FROM [Group] WHERE user_name='" + userName + "'";
        SqlCommand command = new SqlCommand(commandString, sqlCon);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            group = new Group();

            group.Name = reader[2].ToString();
            

            groupList.Add(group);
        }

        reader.Close();


        return groupList;
    }

    public Boolean addGroup(Group newGroup, String userName)
    {
        string commandString = "INSERT INTO Group (user_name, name) " +
                               "VALUES ('" + userName + "', '" + newGroup.Name + "')";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean deleteGroup(String userName, int groupName)
    {

        String commandString = "DELETE FROM Group WHERE user_name='" + userName + "' AND group_name='" + groupName + "';";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean updateGroup(Group groupToUpdate)
    {
        String commandString = "UPDATE Group SET group_name='" + groupToUpdate.Name + "' " +
                                                "WHERE event_id='" + groupToUpdate.Id + "';";

        try
        {
            SqlCommand cmd = new SqlCommand(commandString, sqlCon);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }




    //=====================================================================================================
    //                                           GIFT 
    //=====================================================================================================







}