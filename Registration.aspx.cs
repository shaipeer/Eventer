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

        //if (Session["UserName"] == null)

    }


    protected void Register_CMD_Click(object sender, EventArgs e)
    {

    }
    protected void User_Name_Exists_CMD_Click(object sender, EventArgs e)
    {

        if (bl.isUserExists(User_Name_TextBox.Text))  Registration_Label.Text = "User Name Already Exists!";
        else                                          Registration_Label.Text = "User Name Is Available!";
    }
}