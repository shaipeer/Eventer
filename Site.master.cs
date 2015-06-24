using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null && Session["UserFullName"] != null)
        {
            Master_User_Name_Lable.Text = "Hello " + Session["UserFullName"].ToString();
            Master_User_Name_Login_Status_CMD.Text = "Log-Out";

            if (Session["EventId"] != null && Session["EventName"] != null && Session["ShowSelectedEvent"].ToString().Equals("true"))
                Master_Event_Choosen_LABLE.Text = "Selected Event: " + Session["EventName"].ToString();
            else
                Master_Event_Choosen_LABLE.Text = "";
        }
        else
        {
            Master_User_Name_Lable.Text = "";

            Master_User_Name_Login_Status_CMD.Text = "Log-In";

            Master_Event_Choosen_LABLE.Text = "";
        }
    }
    protected void Master_User_Name_Login_Status_CMD_Click(object sender, EventArgs e)
    {
        Session.Clear();

        if (Master_User_Name_Login_Status_CMD.Text.Equals("Log-In"))
        {
            Response.Redirect("Login.aspx");
        }
        else if (Master_User_Name_Login_Status_CMD.Text.Equals("Log-Out"))
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}
