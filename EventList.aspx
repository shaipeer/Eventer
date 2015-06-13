<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EventList.aspx.cs" Inherits="AddEvent" EnableEventValidation="false"%>

<asp:Content ID="Event_list_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="event_list">
        <div id="nav">
            <br />
            <h2>Add Event</h2>
            <table style="width: 100%">
           
                <tr>
                    <td>Event Name:<br />
                    </td>
                    <td>
                        <asp:TextBox ID="Event_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Type:</td>
                    <td>
                        <asp:TextBox ID="Type_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Number Of Guests:</td>
                    <td>
                        <asp:TextBox ID="Number_Of_Guests_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Date:</td>
                    <td>
                        <asp:TextBox ID="Date_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Location:</td>
                    <td>
                        <asp:TextBox ID="Location_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Add_Event_CMD" runat="server" Text="Add Event"/>    
                    </td>
                </tr>

            </table>
        </div>
    
        <div id="section">
            <br />
            <h2>Event List</h2>
            <br />
            <div>
                <div id="grid_div">
                    <asp:GridView ID="Event_list_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                            <RowStyle HorizontalAlign="center" />
                            <Columns>
                                <asp:BoundField DataField="id"                  HeaderText="Id"                 ItemStyle-Width="30" />
                                <asp:BoundField DataField="event_name"          HeaderText="Event Name"         ItemStyle-Width="250" />
                                <asp:BoundField DataField="event_type"          HeaderText="Event Type"         ItemStyle-Width="200" />
                                <asp:BoundField DataField="event_date"          HeaderText="Event Date"         ItemStyle-Width="100" />
                                <asp:BoundField DataField="number_of_guests"    HeaderText="Number Of Guests"   ItemStyle-Width="150" />
                                <asp:BoundField DataField="event_location"      HeaderText="Event Location"     ItemStyle-Width="150" />
                            </Columns>
                    </asp:GridView>
                    
                    <asp:SqlDataSource ID="Eventer" runat="server" ConnectionString="<%$ ConnectionStrings:EventerConnectionString %>" SelectCommand="SELECT * FROM [Event]"></asp:SqlDataSource>
                
                </div>
                <div>
                    <br />
                    <asp:Label ID="No_Events_LBL" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Choose_Event_CMD" runat="server" Text="Choose Event" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

