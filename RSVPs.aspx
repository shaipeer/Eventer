<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RSVPs.aspx.cs" Inherits="RSVPs" %>

<asp:Content ID="RSVPs_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="rsvps_list">
        <div id="nav">
            <br />
            <h2>Edit RSVP</h2>
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
            <h2>RSVP List</h2>
            <br />
            <div>
                <div id="grid_div">
                      <asp:GridView ID="RSVPs_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                            <RowStyle HorizontalAlign="center" />
                            <Columns>
                                <asp:BoundField DataField="id"                  HeaderText="Id"                 ItemStyle-Width="30" />
                                <asp:BoundField DataField="guest_name"          HeaderText="guest_name"         ItemStyle-Width="150" />
                                <asp:BoundField DataField="side"                HeaderText="Side"               ItemStyle-Width="150" />
                                <asp:BoundField DataField="num_of_guests"       HeaderText="Number Of Guests"   ItemStyle-Width="150" />
                                <asp:BoundField DataField="phone"               HeaderText="Phone"              ItemStyle-Width="150" />
                                <asp:BoundField DataField="approved_arrival"    HeaderText="Approved Arrival"   ItemStyle-Width="150" />
                                <asp:BoundField DataField="Notes"               HeaderText="Notes"              ItemStyle-Width="150" />
                            </Columns>
                    </asp:GridView>

                    
                </div>
                <div>
                    <br />
                    <asp:Button ID="Choose_Event_CMD" runat="server" Text="Choose Event" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

