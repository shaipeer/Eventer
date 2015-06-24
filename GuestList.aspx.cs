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
    private List<Guest> allUserGuestList;

    protected void Page_Load(object sender, EventArgs e)
    {
        //LOGIN and EVENT SELECT check
        if (Session["UserName"] == null)     Response.Redirect("MainPage.aspx");
        else if (Session["EventId"] == null) Response.Redirect("EventList.aspx");

        Session["ShowSelectedEvent"] = "true";

        bl = new EventerBL();
        guestList = bl.generateEventGuestList(Session["UserName"].ToString(), Convert.ToInt32(Session["EventId"].ToString()));
        allUserGuestList = bl.getGuestList(Session["UserName"].ToString());
        if (!this.IsPostBack)
        {
            refreshGroupDropDownList();
            refreshExistGuestDropDownList();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5]
            { 
                new DataColumn("id",            typeof(int)),
                new DataColumn("first_name",    typeof(string)),
                new DataColumn("last_name",     typeof(string)),
                new DataColumn("phone",         typeof(string)),
                new DataColumn("group",         typeof(string))
            });


            if (guestList.Count > 0)
            {
                int i = 1;
                foreach (Guest guestFromList in guestList)
                {
                    dt.Rows.Add(i++, guestFromList.FirstName, guestFromList.LastName, guestFromList.Phone, guestFromList.GroupName);
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

            Guest_Nav_CMD.Text = "Save";
            No_Guest_LBL.Text = "";
            existGuestFildesVisible(false);
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
                    existGuestFildesVisible(true);
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Guest_Nav_Eror_Label.Text = "*Error while updating guest";
                }

            }
            else if (Guest_Nav_CMD.Text.Equals("Add Guest"))
            {
                if (bl.addGuest(guest, Session["UserName"].ToString(), Convert.ToInt32(Session["EventId"].ToString())))
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

    protected void Remove_From_Evemt_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            if (bl.removeGuestFromEvent(Session["UserName"].ToString(), Convert.ToInt32(Session["EventId"].ToString()), guestList[selectedIndex].GuestId))
            {
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                No_Guest_LBL.Text = "Error while removing Guest!";
            }
        }
        else
        {
            No_Guest_LBL.Text = "You have to choose Guest!";
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
        guest.GroupName = Group_DropDownList.SelectedItem.Text;
        
        return guest;
    }

    private void resetGuestNav()
    {
        First_Name_TextBox.Text = "";
        Last_Name_TextBox.Text  = "";
        Phone_TextBox.Text      = "";
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
        if (isNumerical(First_Name_TextBox.Text))       { Guest_Nav_Eror_Label.Text = "First Name not valid!";              return false; }
        else if (isNumerical(Last_Name_TextBox.Text))   { Guest_Nav_Eror_Label.Text = "Last Name not valid!";               return false; }
        else if (!isPhone(Phone_TextBox.Text))          { Guest_Nav_Eror_Label.Text = "please insert a valid Phone number.";return false; }
        
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


    private void resetExistGuestFildes()
    {
        //Type_DropDownList.SelectedIndex = Type_DropDownList.Items.IndexOf(Type_DropDownList.Items.FindByValue(eventList[selectedIndex].Type));


    }

    private void refreshExistGuestDropDownList()
    {
        Exist_Guest_DropDownList.Items.Clear();

        Exist_Guest_DropDownList.Items.Add("Choose Gguest");

        foreach (Guest guest in allUserGuestList)
        {
            
            Exist_Guest_DropDownList.Items.Add(guest.FirstName + " " + guest.LastName);
        }
    }

    private void existGuestFildesVisible(Boolean visible)
    {
        Exist_Guest_LABEL.Visible        = visible;
        Add_Exist_Guest_CMD.Visible      = visible;
        Exist_Guest_DropDownList.Visible = visible;
    }


    protected void Add_Exist_Guest_CMD_Click(object sender, EventArgs e)
    {
        if(Exist_Guest_DropDownList.Text.Equals("Choose Gguest"))
            Guest_Nav_Eror_Label.Text = "Please pick a guest";
        else
        {
            bl.addEventGuest(Session["UserName"].ToString(), Convert.ToInt32(Session["EventId"].ToString()), allUserGuestList[Exist_Guest_DropDownList.SelectedIndex-1].GuestId);
            resetGuestNav();
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
    }
    
}