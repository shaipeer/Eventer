using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gifts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6]
            { 
                new DataColumn("id",                typeof(int)),
                new DataColumn("guest_first_name",  typeof(string)),
                new DataColumn("guest_last_name",   typeof(string)),
                new DataColumn("group",             typeof(string)),
                new DataColumn("gift_description",  typeof(string)),
                new DataColumn("cash",              typeof(string))
            });
            dt.Rows.Add(1, "John", "Hammond",   "freinds", "fsfsbtrgbtrbtrbtr erbfsfv", "100");
            dt.Rows.Add(2, "Mudassar", "Khan",  "test group", "gtbrbnttrb gr btgrbtreve", "450");
            dt.Rows.Add(3, "Suzanne", "Mathews","test group", "rbtr4btrgbrbtrbgtrbbb4", "900");
            dt.Rows.Add(4, "Robert", "Schidner","family", "grfbt4bgrbr4br4b44b4tb", "550");
            Gifts_GridView.DataSource = dt;
            Gifts_GridView.DataBind();

        }
    }
}