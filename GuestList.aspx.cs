using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class GuestList : System.Web.UI.Page
{
    private EventerBL bl;
    private int selectedIndex;
    private List<Guest> guestList;

    protected void Page_Load(object sender, EventArgs e)
    {
        //LOGIN and EVENT SELECT check
        if (Session["UserName"] == null)     Response.Redirect("MainPage.aspx");
        else if (Session["EventId"] == null) Response.Redirect("EventList.aspx");

        bl = new EventerBL();
        guestList = bl.generateEventGuestList(Session["UserName"].ToString(), Convert.ToInt32(Session["EventId"].ToString()));

        if (!this.IsPostBack)
        {
            refreshGroupDropDownList();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7]
            { 
                new DataColumn("id",            typeof(int)),
                new DataColumn("first_name",    typeof(string)),
                new DataColumn("last_name",     typeof(string)),
                new DataColumn("phone",         typeof(string)),
                new DataColumn("group",         typeof(string)),
                new DataColumn("status",        typeof(string)),
                new DataColumn("arriving",      typeof(string))
            });


            if (guestList.Count > 0)
            {
                int i = 1;
                foreach (Guest guestFromList in guestList)
                {
                    dt.Rows.Add(i++, guestFromList.FirstName, guestFromList.LastName, guestFromList.Phone, guestFromList.GroupName, guestFromList.Status, guestFromList.Arriving);
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
        resetGuestNav();
    }

    //=========================================================================================================
    //                                      Buttons
    //=========================================================================================================

    protected void Edit_Guest_CMD_Click(object sender, EventArgs e)
    {
        setSelectedIndex();

        if (setSelectedIndex())
        {
            First_Name_TextBox.Text = guestList[selectedIndex].FirstName;
            Last_Name_TextBox.Text = guestList[selectedIndex].LastName;
            Phone_TextBox.Text = guestList[selectedIndex].Phone;
            Group_DropDownList.SelectedIndex = Group_DropDownList.Items.IndexOf(Group_DropDownList.Items.FindByValue(guestList[selectedIndex].GroupName));
            Status_TextBox.Text = guestList[selectedIndex].Status;
            Arriving_TextBox.Text = guestList[selectedIndex].Arriving;

            Guest_Nav_CMD.Text = "Save";
            No_Guest_LBL.Text = "";
        }
        else
        {
            No_Guest_LBL.Text = "You have to choose event!";
        }


    }
    protected void Delete_Guest_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            if (bl.deleteGuest(Session["UserName"].ToString(), guestList[selectedIndex].GuestId))
            {
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Guest_Nav_Eror_Label.Text = "*Error while deleting Guest";
            }
        }
        else
        {
            Guest_Nav_Eror_Label.Text = "*You have to choose Guest";
        }
    }
    protected void Guest_Nav_CMD_Click(object sender, EventArgs e)
    {
        setSelectedIndex();
        Guest guest = navToGuest();
        
        if (isValid())
        {
            if (Guest_Nav_CMD.Text.Equals("Save"))
            {
                guest.GuestId = guestList[selectedIndex].GuestId ;

                if (bl.updateGuest(guest, Session["UserName"].ToString()))
                {
                    resetGuestNav();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Guest_Nav_Eror_Label.Text = "*Error while updating guest";
                }

            }
            else if (Guest_Nav_CMD.Text.Equals("Add Guest"))
            {
                if (bl.addGuest(guest, Session["UserName"].ToString()))
                {
                    resetGuestNav();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Guest_Nav_Eror_Label.Text = "*Error while adding guest";
                }

            }
        }
    }


    //=========================================================================================================
    //                                      FUNCTIONS
    //=========================================================================================================

    private Guest navToGuest()
    {
        Guest guest = new Guest();

        guest.FirstName = First_Name_TextBox.Text;
        guest.LastName  = Last_Name_TextBox.Text;
        guest.Phone     = Phone_TextBox.Text;
        guest.Status    = Status_TextBox.Text;
        guest.Arriving  = Arriving_TextBox.Text;
        guest.GroupName = Group_DropDownList.SelectedItem.Text;
        
        return guest;
    }

    private void resetGuestNav()
    {
        First_Name_TextBox.Text = "";
        Last_Name_TextBox.Text  = "";
        Phone_TextBox.Text      = "";
        Arriving_TextBox.Text   = "";
        Status_TextBox.Text     = "";
        Guest_Nav_CMD.Text      = "Add Guest";
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
    
    private void refreshGroupDropDownList()
    {
        List<Group> groupList = bl.getGroupList(Session["UserName"].ToString());
        Group_DropDownList.Items.Clear();

        Group_DropDownList.Items.Add("No Group");

        foreach (Group group in groupList)
            Group_DropDownList.Items.Add(group.Name);
    }

    private bool isValid()
    {
        if (isNumerical(First_Name_TextBox.Text))       { Guest_Nav_Eror_Label.Text = "First Name not valid!"; return false; }
        else if (isNumerical(Last_Name_TextBox.Text))   { Guest_Nav_Eror_Label.Text = "Last Name not valid!"; return false; }
        else if (!isPhone(Phone_TextBox.Text))          { Guest_Nav_Eror_Label.Text = "please insert a valid Phone number."; return false; }
        else if (isNumerical(Status_TextBox.Text))      { Guest_Nav_Eror_Label.Text = "Status not valid!"; return false; }
        else if (!isNumerical(Arriving_TextBox.Text))   { Guest_Nav_Eror_Label.Text = "Arriving not valid!"; return false; }
        
        return true;
    }

    private bool isNumerical(string input)
    {
        double num;
        var success = double.TryParse(input, out num);
        return success;
    }

    private bool isPhone(string phone)
    {
        bool success = Regex.IsMatch(phone, @"^(\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)(353)\)?[\s-]?)?\(?0?(?:\)[\s-]?)?([1-9]\d{1,4}\)?[\d\s-]+)((?:x|ext\.?|\#)\d{3,4})?$");
        return success;
    }

    
}