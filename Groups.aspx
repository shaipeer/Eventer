<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>

<asp:Content ID="Groups_Content" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="groups_list">

        <div id="nav">
            <br />
            <h2>Add Group</h2>
            <table style="width: 100%">
           
                <tr>
                    <td>Group Name:<br />
                    </td>
                    <td>
                        <asp:TextBox ID="Group_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                

            </table>
        </div>
    
        <div id="groups">
            <br />
            <h2>Group List</h2>
            <br />
            <div>
                <div id="grid_div">
                    <asp:GridView ID="Groups_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
                            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                            <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>                
                </div>
                <div>
                    <asp:Label ID="Test_LBL" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="Choose_Event_CMD" runat="server" Text="Choose Event" />
                </div>
            </div>
        </div>

        <div id="guests">
            <br />
            <br />
            <br />
            <br />
            <div>
                <div id="grid_div">
                    <asp:GridView ID="Groups_Guests_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />
                            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                            <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                        </Columns>
                    </asp:GridView>                
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Choose Event" />
                </div>
            </div>
        </div>
    </div>




    






</asp:Content>

