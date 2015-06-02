using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddEvent : System.Web.UI.Page
{
    private int selectedRow;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Event_list_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = "Click to select this row.";
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
           // Test_LBL.Text = ">>>> " + "CLICK 2" + " <<<<<";
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Event_list_GridView, "Select$" + e.Row.RowIndex);
            //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(Event_list_GridView, "Select$" + e.Row.RowIndex.ToString()));
            
            Test_LBL.Text = ">>-->> " + e.Row.RowIndex + " <<<<<";
        }

        
    }
    
    protected void Event_list_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedRow = Event_list_GridView.SelectedIndex;

        //Response.Redirect("EventList.aspx");
        Test_LBL.Text = ">>>>" + Event_list_GridView.Rows[selectedRow].Cells[0].Text + ", " + 
                                 Event_list_GridView.SelectedRow.Cells[1].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[2].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[3].Text + ", " +
                                 Event_list_GridView.SelectedRow.Cells[4].Text + ", " ;
    }
    
}