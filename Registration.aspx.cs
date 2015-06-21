using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    EventerBL bl;

    protected void Page_Load(object sender, EventArgs e)
    {
        bl = new EventerBL();


    }

    
    protected void Register_CMD_Click(object sender, EventArgs e)
    {
        if(isValid())
        {
            if (bl.addUser(fieldsToUser()))
            {
                Session["UserName"]     = User_Name_TextBox.Text;
                Session["UserFullName"] = First_Name_TextBox.Text + " " + LastName_TextBox.Text;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                Registration_Label.Text = "Error while registering " + First_Name_TextBox.Text + " " + LastName_TextBox.Text;
            }

        }
    }

    protected void User_Name_Exists_CMD_Click(object sender, EventArgs e)
    {

        if (bl.isUserExists(User_Name_TextBox.Text))  Registration_Label.Text = "User Name Already Exists!";
        else                                          Registration_Label.Text = "User Name Is Available!";
    }



    private Boolean isValid()
    {

        /*  FIELDS TO VALIDATE
        
        First_Name_TextBox
        LastName_TextBox
        Mail_TextBox
        User_Name_TextBox
        Password_TextBox
        Re_Enter_Password_TextBox
         
         */
        return true;
    }


    private User fieldsToUser()
    {
        User newUser = new User();

        newUser.FirstName = First_Name_TextBox.Text;
        newUser.LastName  = LastName_TextBox.Text;
        newUser.Mail      = Mail_TextBox.Text;
        newUser.UserName  = User_Name_TextBox.Text;
        newUser.Password  = Password_TextBox.Text;


        return newUser;
    }
}