<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Gifts.aspx.cs" Inherits="Gifts" %>

<asp:Content ID="Gifts_Content" ContentPlaceHolderID="MainContent" Runat="Server">


    <div id="gifts_list">
        <div id="nav">
            <br />
            <h2>Edit Gifts</h2>
            <table style="width: 100%">
                <tr>
                    <td>Gift Description:<br />
                    </td>
                    <td>
                        <asp:TextBox ID="Event_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Cash:</td>
                    <td>
                        <asp:TextBox ID="Type_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Update_Gift_CMD" runat="server" Text="Update Gift"/>    
                    </td>
                </tr>

            </table>
        </div>
    
        <div id="section">
            <br />
            <h2>Gifts List</h2>
            <br />
            <div>
                <div id="grid_div">
                      <asp:GridView ID="Gifts_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                            <RowStyle HorizontalAlign="center" />
                            <Columns>
                                <asp:BoundField DataField="id"                  HeaderText="Id"                 ItemStyle-Width="30" />
                                <asp:BoundField DataField="guest_first_name"    HeaderText="First Name"         ItemStyle-Width="150" />
                                <asp:BoundField DataField="guest_last_name"     HeaderText="Last Name"          ItemStyle-Width="150" />
                                <asp:BoundField DataField="group"               HeaderText="Group"              ItemStyle-Width="150" />
                                <asp:BoundField DataField="gift_description"    HeaderText="Gift Description"   ItemStyle-Width="150" />
                                <asp:BoundField DataField="cash"                HeaderText="Cash"               ItemStyle-Width="150" />
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

