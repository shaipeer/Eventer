using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddEvent : System.Web.UI.Page
{
    private int selectedRow;
    private EventerBL bl;
    private int selectedIndex;
    List<Event> eventList;

    protected void Page_Load(object sender, EventArgs e)
    {
        bl = new EventerBL();
        eventList =  bl.getEventList();



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

    protected void Choose_Event_CMD_Click(object sender, EventArgs e)
    {
       
    }
    
    protected void Edit_Event_CMD_Click(object sender, EventArgs e)
    {
        selectedIndex = Convert.ToInt32(Event_list_GridView.SelectedRow.Cells[1].Text) - 1;
        Event_Nav_Eror_Label.Text = "" + selectedIndex;
        Event_Name_TextBox.Text          = eventList[selectedIndex].Name;
        Type_TextBox.Text                = eventList[selectedIndex].Type;
        Number_Of_Guests_TextBox.Text    = eventList[selectedIndex].NumOfGuests;
        Date_TextBox.Text                = eventList[selectedIndex].Date;
        Location_TextBox.Text            = eventList[selectedIndex].Location;

        Event_Nav_CMD.Text               = "Save";
       
    }

    protected void Event_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //selectedIndex = Convert.ToInt32(Event_list_GridView.SelectedRow.Cells[1].Text);
        //Event_Name_TextBox.Text = selectedIndex + "";
    }

    protected void Event_Nav_CMD_Click(object sender, EventArgs e)
    {
        Event ev = navToEvent();
        ev.UserId  = eventList[selectedIndex].UserId;
        ev.EventId = eventList[selectedIndex].EventId;
        if(Event_Nav_CMD.Text.Equals("Save"))
        {
            if(bl.updateEvent(ev))
            {
                Event_Name_TextBox.Text = "";
                Type_TextBox.Text = "";
                Number_Of_Guests_TextBox.Text = "";
                Date_TextBox.Text = "";
                Location_TextBox.Text = "";
                Event_Nav_CMD.Text = "Add Event";

                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Event_Nav_Eror_Label.Text = "*Error while updating event";
            }
            
        }
        else if (Event_Nav_CMD.Text.Equals("Add Event"))
        {

        }
    }

    private Event navToEvent()
    {
        Event ev = new Event();

        ev.Name = Event_Name_TextBox.Text;
        ev.Type = Type_TextBox.Text;
        ev.NumOfGuests = Number_Of_Guests_TextBox.Text;
        ev.Date = Date_TextBox.Text;
        ev.Location = Location_TextBox.Text;

        return ev;
    }

}