using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups : System.Web.UI.Page
{
    private EventerBL bl;
    private int selectedIndex;
    private List<Group> groupList;

    protected void Page_Load(object sender, EventArgs e)
    {
        //LOGIN and GROUP SELECT check
        if (Session["UserName"] == null) Response.Redirect("MainPage.aspx");

        bl = new EventerBL();
        groupList = bl.getGroupList(Session["UserName"].ToString());

        if (!this.IsPostBack)
        {
            createGroupTable();
        }
    }

    //=========================================================================================================
    //                                      TABLES
    //=========================================================================================================

    private void createGroupTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2]
        { 
            new DataColumn("id",    typeof(int)),
            new DataColumn("name",  typeof(string))
        });


        if (groupList.Count > 0)
        {
            int i = 1;
            foreach (Group group in groupList)
            {
                dt.Rows.Add(i++, group.Name);
            }
        }
        else
        {
            Group_List_Massage_LBL.Text = "No Groups To Show!";
        }
        Groups_List_GridView.DataSource = dt;
        Groups_List_GridView.DataBind();
    }


    private void createGuestTable()
    {
        List<Guest> guestList = bl.getGuestList(Session["UserName"].ToString());
        
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4]
        { 
            new DataColumn("id",         typeof(int)),
            new DataColumn("First_Name", typeof(string)),
            new DataColumn("Last_Name",  typeof(string)),
            new DataColumn("Phone",      typeof(string))
        });


        if (guestList.Count > 0)
        {
            int i = 1;
            
            foreach(Guest guest in guestList)
            {
                if (guest.GroupName.Equals(groupList[selectedIndex].Name))
                    dt.Rows.Add(i++, guest.FirstName, guest.LastName, guest.Phone);
            }
        }
        else
        {
            Gruop_List_Guest_Massege_LBL.Text = "No Groups To Show!";
        }
        Groups_To_Guest_GridView.DataSource = dt;
        Groups_To_Guest_GridView.DataBind();
    }



    protected void Groups_List_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        Group_Nav_Massage_Label.Text = "";
        Group_List_Massage_LBL.Text  = "";
        Gruop_List_Guest_Massege_LBL.Text = "";

        setSelectedIndex();
        Group_Name_TextBox.Text = selectedIndex + "";
        createGuestTable();
        //resetGroupNav();
    }



    //=========================================================================================================
    //                                      Buttons
    //=========================================================================================================

    protected void Edit_Group_CMD_Click(object sender, EventArgs e)
    {
        setSelectedIndex();

        if (setSelectedIndex())
        {
            Group_Name_TextBox.Text = groupList[selectedIndex].Name;

            Group_Nav_CMD.Text = "Save";
            Group_List_Massage_LBL.Text = "";
        }
        else
        {
            Group_List_Massage_LBL.Text = "You have to choose group!";
        }
    }

    protected void Delete_Group_CMD_Click(object sender, EventArgs e)
    {
        if (setSelectedIndex())
        {
            if (bl.deleteGroup(Session["UserName"].ToString(), groupList[selectedIndex].Id))
            {
                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
            else
            {
                Group_List_Massage_LBL.Text = "Error while deleting group!";
            }
        }
        else
        {
            Group_List_Massage_LBL.Text = "You have to choose group!";
        }
    }

    protected void Group_Nav_CMD_Click(object sender, EventArgs e)
    {
        setSelectedIndex();
        Group group = navToGroup();

        if (isValid())
        {
            if (Group_Nav_CMD.Text.Equals("Save"))
            {
                group.Id = groupList[selectedIndex].Id;

                if (bl.updateGroup(group, Session["UserName"].ToString()))
                {
                    resetGroupNav();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Group_Nav_Massage_Label.Text = "*Error while updating group";
                }

            }
            else if (Group_Nav_CMD.Text.Equals("Add Group"))
            {
                if (bl.addGroup(group, Session["UserName"].ToString() ))
                {
                    resetGroupNav();
                    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                }
                else
                {
                    Group_Nav_Massage_Label.Text = "*Error while adding group";
                }

            }
        }
    }
    
        //=========================================================================================================
        //                                      FUNCTIONS
        //=========================================================================================================

        private Group navToGroup()
        {
            Group group = new Group();

            group.Name = Group_Name_TextBox.Text;

            return group;
        }

        private void resetGroupNav()
        {
            Group_Name_TextBox.Text = "";
            Group_Nav_CMD.Text = "Add Group";
        }
        
        private Boolean setSelectedIndex()
        {
            try
            {
                selectedIndex = Convert.ToInt32(Groups_List_GridView.SelectedRow.Cells[1].Text) - 1;
                return true;
            }
            catch (NullReferenceException e)
            {
                return false;
            }

        }

        private bool isValid()
        {
         
            return true;
        }
        
}