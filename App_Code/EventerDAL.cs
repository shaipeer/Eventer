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




    //=======================================  EVENT  =====================================================

    public List<Event> getEventList()
    {
        List<Event> eventList = new List<Event>();
        Event ev;

        string commandString = "SELECT * FROM Event";
        SqlCommand command = new SqlCommand(commandString, sqlCon);
        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            ev = new Event();

            ev.UserId       = Convert.ToInt32(reader[0].ToString());
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

    public Boolean addEvent(Event newEvent)
    {
        string commandString = "INSERT INTO Event (user_id, event_id, event_name, type, number_of_guests, date, location) " +
                               "VALUES ('" + newEvent.UserId + "', '" + newEvent.EventId + "', '" + newEvent.Name + "', '" + newEvent.Type + "', '" + newEvent.NumOfGuests + "', '" + newEvent.Date + "', '" + newEvent.Location + "')";

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

    public Boolean deleteEvent(int userId, int eventId)
    {

        return false;
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



    //=======================================  GUEST  =====================================================

    public List<Guest> getGuestList()
    {
        List<Guest> guestList = new List<Guest>();
        Guest guest;

        String commandString = "SELECT * FROM Guest";
        SqlCommand command = new SqlCommand(commandString, sqlCon);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            guest = new Guest();

           /* ev.UserId = Convert.ToInt32(reader[0].ToString());
            ev.EventId = Convert.ToInt32(reader[1].ToString());
            ev.Name = reader[2].ToString();
            ev.Type = reader[3].ToString();
            ev.NumOfGuests = reader[4].ToString();
            ev.Date = reader[5].ToString();
            ev.Location = reader[6].ToString();
            */
            guestList.Add(guest);
        }

        reader.Close();


        return guestList;
    }

    public Boolean addGuest(Guest newGuest)
    {
      //  string commandString = "INSERT INTO Event (user_id, event_id, event_name, type, number_of_guests, date, location) " +
        //                       "VALUES ('" + newEvent.UserId + "', '" + newEvent.EventId + "', '" + newEvent.Name + "', '" + newEvent.Type + "', '" + newEvent.NumOfGuests + "', '" + newEvent.Date + "', '" + newEvent.Location + "')";

        try
        {
          //  SqlCommand cmd = new SqlCommand(commandString, sqlCon);
          //  cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException)
        {
            return false;
        }

        return true;
    }

    public Boolean deleteGuest(int userId, int guestId)
    {

        return false;
    }

    public Boolean updateGuest(Guest guestToUpdate)
    {
        String commandString = "UPDATE Guest SET first_name='', last_name='', phone='', group_id='', side='', status='', arriving='' WHERE user_id='1111';";
        
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


    //=======================================  USER  =====================================================

    

    //=======================================  GROUP  =====================================================



    //=======================================  GIFT   =====================================================








}