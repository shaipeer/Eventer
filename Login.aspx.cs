using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    EventerBL bl;



    protected void Page_Load(object sender, EventArgs e)
    {
        bl = new EventerBL();
    }




    protected void LogIn_CMD_Click(object sender, EventArgs e)
    {
        User user;
        if (bl.isUserValid(User_Name_TextBox.Text, Password_TextBox.Text) )
        {
            user = bl.getUser(User_Name_TextBox.Text);
            Session["UserName"] = user.UserName;
            Session["UserFullName"] = user.FirstName + " " + user.LastName;
            Response.Redirect("EventList.aspx");
        }
        else
        {
            Login_Error_Lable.Text = "* Username or password are incorrect!";
            //Response.Redirect("UserPage.aspx");
        }
    }


    protected void NotRegisterd_LBL_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    private Boolean isValidLogin()
    {
        


        return true;
    }



}