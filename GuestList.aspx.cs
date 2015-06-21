using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GuestList : System.Web.UI.Page
{

    private int selectedRow;
    private EventerBL bl;
    private int selectedIndex;
    private List<Guest> guestList;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null) Response.Redirect("MainPage.aspx");


        bl = new EventerBL();
        guestList = bl.getGuestList();

        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8]
            { 
                new DataColumn("id",            typeof(int)),
                new DataColumn("first_name",    typeof(string)),
                new DataColumn("last_name",     typeof(string)),
                new DataColumn("phone",         typeof(string)),
                new DataColumn("group",         typeof(string)),
                new DataColumn("side",          typeof(string)),
                new DataColumn("status",        typeof(string)),
                new DataColumn("arriving",      typeof(string))
            });


            if (guestList.Count > 0)
            {
                int i = 1;
                foreach (Guest guest in guestList)
                {
                    dt.Rows.Add(i++, guest.FirstName, guest.LastName, guest.Phone, guest.GroupId, guest.Side, guest.Status, guest.Arriving);
                }
            }
            else
            {
                No_Guest_LBL.Text = "No Guests To Show!";
            }
            Guest_list_GridView.DataSource = dt;
            Guest_list_GridView.DataBind();
        }
    }
    protected void Guest_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        No_Guest_LBL.Text = "";
    }
    protected void Choose_Guest_CMD_Click(object sender, EventArgs e)
    {

    }
    protected void Edit_Guest_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            First_Name_TextBox.Text = guestList[selectedIndex].FirstName;
            Last_Name_TextBox.Text = guestList[selectedIndex].LastName;
            Phone_TextBox.Text = guestList[selectedIndex].Phone;
            Group_TextBox.Text = guestList[selectedIndex].GroupId;
            Side_TextBox.Text = guestList[selectedIndex].Side;
            Status_TextBox.Text = guestList[selectedIndex].Status;
            Arriving_TextBox.Text = guestList[selectedIndex].Arriving;

            Guest_Nav_CMD.Text = "Save";
            No_Guest_LBL.Text = "";
        }
        else
        {
            No_Guest_LBL.Text = "You have to choose a guest!";
        }
    }
    protected void Delete_Guest_CMD_Click(object sender, EventArgs e)
    {

    }
    protected void Guest_Nav_CMD_Click(object sender, EventArgs e)
    { 
        Guest guest = navToGuest();
        
        if (Guest_Nav_CMD.Text.Equals("Save"))
        {
            setSelectedIndex();
            guest.UserId = guestList[selectedIndex].UserId;
            guest.GuestId = guestList[selectedIndex].GuestId;

            if (bl.updateGuest(guest))
            {
                resetGuestNav();

                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Guest_Nav_Eror_Label.Text = "*Error while updating event";
            }

        }
        else if (Guest_Nav_CMD.Text.Equals("Add Event"))
        {
            bl.addGuest(guest);
        }
    }


    private Guest navToGuest()
    {
        Guest guest = new Guest();

        guest.FirstName = First_Name_TextBox.Text;
        guest.LastName  = Last_Name_TextBox.Text;
        guest.Phone     = Phone_TextBox.Text;
        guest.GroupId   = Group_TextBox.Text;
        guest.Side      = Side_TextBox.Text;
        guest.Status    = Status_TextBox.Text;
        guest.Arriving  = Arriving_TextBox.Text;
        return guest;
    }

    private void resetGuestNav()
    {
        First_Name_TextBox.Text = "";
        Last_Name_TextBox.Text  = "";
        Phone_TextBox.Text      = "";
        Group_TextBox.Text      = "";
        Side_TextBox.Text       = "";
        Arriving_TextBox.Text   = "";
        Status_TextBox.Text = "Add Event";
    }

    private Boolean setSelectedIndex()
    {
        
        try
        {
            selectedIndex = Convert.ToInt32(Guest_list_GridView.SelectedRow.Cells[1].Text) - 1;
            return true;
        }
        catch (NullReferenceException e)
        {
            return false;
        }
    }


}