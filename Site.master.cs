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
            Master_User_Name_Login_Status_Lable.Text = "Log-Out";
        }
        else
        {
            Master_User_Name_Lable.Text = "";
            Master_User_Name_Login_Status_Lable.Text = "Log-In";
        }
    }
}
