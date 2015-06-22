using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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
        if (isNumerical(First_Name_TextBox.Text))                                   { Registration_Label.Text = "First Name not valid!";        return false; }
        else if (isNumerical(LastName_TextBox.Text))                                { Registration_Label.Text = "Last Name not valid!";         return false; }
        else if (!isEmail(Mail_TextBox.Text))                                       { Registration_Label.Text = "please insert a valid email."; return false; }
        else if (isPassword(Password_TextBox.Text, Re_Enter_Password_TextBox.Text)) { Registration_Label.Text = "Password not valid!";          return false; }
         
        return true;
    }

    private bool isNumerical(string input)
    {
        double num;
        var success = double.TryParse(input, out num);
        return success;
    }

    private bool isEmail(string email)
    {
        bool success = Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)
                                              |(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        return success;
    }

    private bool isPassword(string password, string Re_Enter_Password)
    {
        bool success = Regex.IsMatch(password, @"^(?![0-9]{6})[0-9a-zA-Z]{8}$");
        
        bool reEnter = password.Equals(Re_Enter_Password);
        
        return success&reEnter;
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