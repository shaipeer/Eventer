using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class AddEvent : System.Web.UI.Page
{
    private EventerBL bl;
    private int selectedIndex;
    private List<Event> eventList;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null) Response.Redirect("MainPage.aspx");
        bl = new EventerBL();
        
        eventList = bl.getEventList(Session["UserName"].ToString());

        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6]
            { 
                new DataColumn("id",                typeof(int)),
                new DataColumn("event_name",        typeof(string)),
                new DataColumn("event_type",        typeof(string)),
                new DataColumn("event_date",        typeof(string)),
                new DataColumn("number_of_guests",  typeof(string)),
                new DataColumn("event_location",    typeof(string))
            });


            if(eventList.Count > 0)
            {
                int i = 1;
                foreach (Event ev in eventList)
                {
                    dt.Rows.Add(i++, ev.Name, ev.Type, ev.Date, ev.NumOfGuests, ev.Location);
                }
            }
            else
            {
                No_Events_LBL.Text = "No Events To Show!";
            }
            Event_list_GridView.DataSource = dt;
            Event_list_GridView.DataBind();
        }
    }

    protected void Event_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetFields();
        No_Events_LBL.Text = "";
        
    }


    //=========================================================================================================
    //                                      BUTTONS
    //=========================================================================================================

    protected void Choose_Event_CMD_Click(object sender, EventArgs e)
    {
       
    }
    
    protected void Edit_Event_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            Event_Name_TextBox.Text = eventList[selectedIndex].Name;
            Type_DropDownList.SelectedIndex = Type_DropDownList.Items.IndexOf(Type_DropDownList.Items.FindByValue(eventList[selectedIndex].Type));
            Number_Of_Guests_TextBox.Text = eventList[selectedIndex].NumOfGuests;
            Date_TextBox.Text = eventList[selectedIndex].Date;
            Location_TextBox.Text = eventList[selectedIndex].Location;

            Event_Nav_CMD.Text = "Save";
            No_Events_LBL.Text = "";
        }
        else
        {
            No_Events_LBL.Text = "You have to choose event!";
        }
    }

    
    protected void Event_Nav_CMD_Click(object sender, EventArgs e)
    {
        setSelectedIndex();
        Event ev = navToEvent();
        
        if (isValid())
        {
            if (Event_Nav_CMD.Text.Equals("Save"))
            {
                ev.EventId = eventList[selectedIndex].EventId;

                if (bl.updateEvent(ev, Session["UserName"].ToString()))
                {
                    resetFields();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Event_Nav_Eror_Label.Text = "*Error while updating event";
                }
            
            
            }
            else if (Event_Nav_CMD.Text.Equals("Add Event"))
            {
                if(bl.addEvent(ev, Session["UserName"].ToString()))
                {
                    resetFields();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Event_Nav_Eror_Label.Text = "*Error while adding event";
                }

            }
        }
    }

    protected void Delete_Guest_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            if (bl.deleteEvent(Session["UserName"].ToString(), eventList[selectedIndex].EventId))
            {
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Event_Nav_Eror_Label.Text = "*Error while deleting event";
            }
        }
        else
        {
            Event_Nav_Eror_Label.Text = "*You have to choose event";
        }
    }


    //=========================================================================================================
    //                                      FUNCTIONS
    //=========================================================================================================

    private Event navToEvent()
    {
        Event ev = new Event();

        ev.Name = Event_Name_TextBox.Text;
        ev.Type = Type_DropDownList.Text;
        ev.NumOfGuests = Number_Of_Guests_TextBox.Text;
        ev.Date = Date_TextBox.Text;
        ev.Location = Location_TextBox.Text;

        return ev;
    }


    private Boolean setSelectedIndex()
    {
        try
        {
            selectedIndex = Convert.ToInt32(Event_list_GridView.SelectedRow.Cells[1].Text) - 1;
            return true;
        }
        catch (NullReferenceException e)
        {
            return false;
        }
        
    }

    private void resetFields()
    {
        Event_Name_TextBox.Text = "";
        Type_DropDownList.Text = "";
        Number_Of_Guests_TextBox.Text = "";
        Date_TextBox.Text = "";
        Location_TextBox.Text = "";
        Event_Nav_CMD.Text = "Add Event";
    }

    private bool isValid()
    {
        if      (isNumerical(Event_Name_TextBox.Text))          { Event_Nav_Eror_Label.Text = "Event's Name not valid!";     return false; }
        else if (!isNumerical(Number_Of_Guests_TextBox.Text))   { Event_Nav_Eror_Label.Text = "Number of guests not valid!"; return false; }
        else if (Type_DropDownList.Text.Equals("..."))          { Event_Nav_Eror_Label.Text = "Please pick event's type.";   return false; }
        else if (!isValidDate(Date_TextBox.Text))               { Event_Nav_Eror_Label.Text = "Date not valid!";             return false; }
        else if (isNumerical(Location_TextBox.Text))            { Event_Nav_Eror_Label.Text = "Location not valid!";         return false; }

        return true;
    }

    private bool isValidDate(String date)
    {
        DateTime dt;
        var success = DateTime.TryParse(date, out dt);
        if (!success)
            Event_Nav_Eror_Label.Text = "Unvalid Date!"; 
        return success;
    }

    private bool isNumerical(string input)
    {
        double num;
        var success = double.TryParse(input, out num);
        return success;
    }




    
}