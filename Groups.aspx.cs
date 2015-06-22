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
    }

    protected void Groups_List_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        resetGroupNav();
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
                Group_Nav_Massage_Label.Text = "* Error while deleting group";
            }
        }
        else
        {
            Group_Nav_Massage_Label.Text = "* You have to choose group";
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