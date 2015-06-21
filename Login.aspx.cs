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
        if (isValidLogin())
        {
            Session["UserId"] = "1234";
            Response.Redirect("UserPage.aspx");
        }
        else
        {
            //print error
            Response.Redirect("UserPage.aspx");
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