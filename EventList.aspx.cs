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
            //dt.Rows.Add(1, "weading for X and Y", "weading", "07/04/86", "500", "jerusalem");
            //dt.Rows.Add(2, "bar mitzva to shai", "bar mitzva", "09/01/15", "400", "tel aviv");
            //dt.Rows.Add(3, "Suzanne Mathews", "weading", "30/03/33", "900", "nahariya");
            //dt.Rows.Add(4, "Robert Schidner", "weading", "00/00/00", "458", "ashdod");
            Event_list_GridView.DataSource = dt;
            Event_list_GridView.DataBind();
        }



    }

    /*protected void Event_list_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = "Click to select this row.";
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
           // Test_LBL.Text = ">>>> " + "CLICK 2" + " <<<<<";
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Event_list_GridView, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(Event_list_GridView, "Select$" + e.Row.RowIndex.ToString()));
            
            Test_LBL.Text = ">>-->> " + e.Row.RowIndex + " <<<<<";
        }

        
    }
    
    protected void Event_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedRow = Event_list_GridView.SelectedIndex;

        //Response.Redirect("EventList.aspx");
        Test_LBL.Text = ">>>>" + Event_list_GridView.Rows[selectedRow].Cells[0].Text + ", " + 
                                 Event_list_GridView.SelectedRow.Cells[1].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[2].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[3].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[4].Text + ", " ;
    }
    */
    protected void Choose_Event_CMD_Click(object sender, EventArgs e)
    {
       
    }
    
    protected void Edit_Event_CMD_Click(object sender, EventArgs e)
    {
       Event_Name_TextBox.Text          = eventList[selectedIndex].Name;
       Type_TextBox.Text                = eventList[selectedIndex].Type;
       Number_Of_Guests_TextBox.Text    = eventList[selectedIndex].NumOfGuests;
       Date_TextBox.Text                = eventList[selectedIndex].Date;
       Location_TextBox.Text            = eventList[selectedIndex].Location;

       Event_Nav_CMD.Text               = "Save";
       
    }

    protected void Event_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedIndex = Convert.ToInt32(Event_list_GridView.SelectedRow.Cells[1].Text);
        //Event_Name_TextBox.Text = selectedIndex + "";
    }

    protected void Event_Nav_CMD_Click(object sender, EventArgs e)
    {
        if(Event_Nav_CMD.Text.Equals("Save"))
        {

            Event_Name_TextBox.Text = "";
            Type_TextBox.Text = "";
            Number_Of_Guests_TextBox.Text = "";
            Date_TextBox.Text = "";
            Location_TextBox.Text = "";
            Event_Nav_CMD.Text = "Add Event";
        }
        else if (Event_Nav_CMD.Text.Equals("Add Event"))
        {

        }
    }
}