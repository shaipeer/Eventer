using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RSVPs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7]
            { 
                new DataColumn("id",                typeof(int)),
                new DataColumn("guest_name",        typeof(string)),
                new DataColumn("side",              typeof(string)),
                new DataColumn("num_of_guests",     typeof(string)),
                new DataColumn("phone",             typeof(string)),
                new DataColumn("approved_arrival",  typeof(string)),
                new DataColumn("Notes",             typeof(string))
            });
            dt.Rows.Add(1, "John Hammond", "broom", "4", "054-2276414", "maybe 2", "note note note");
            dt.Rows.Add(2, "Mudassar Khan", "broom", "4", "054-2276414", "maybe 2", "note note note");
            dt.Rows.Add(3, "Suzanne Mathews", "broom", "4", "054-2276414", "maybe 2", "note note note");
            dt.Rows.Add(4, "Robert Schidner", "broom", "4", "054-2276414", "maybe 2", "note note note");
            RSVPs_GridView.DataSource = dt;
            RSVPs_GridView.DataBind();
        }



    }
}