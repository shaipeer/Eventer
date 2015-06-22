<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs" Inherits="Groups" %>

<asp:Content ID="Groups_Content" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="groups_list">

        <div id="nav">
            <br />
            <h2>Add Group</h2>
            <table style="width: 100%">
           
                <tr>
                    <td colspan="2">

                        <asp:Label ID="Group_Nav_Massage_Label" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>Group Name:<br />
                    </td>
                    <td>
                        <asp:TextBox ID="Group_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Group_Nav_CMD" runat="server" Text="Add Group" OnClick="Group_Nav_CMD_Click" />
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
                    <table style="width: 100%">
           
                        <tr>
                            <td>
                                <asp:GridView ID="Groups_List_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" 
                                        runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Groups_List_GridView_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" >
                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" >
                                            <ItemStyle Width="200px"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>

                                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                    <SelectedRowStyle BackColor="#CCFFFF" />
                                </asp:GridView>
                            </td>


                            <td>
                                <asp:GridView ID="Groups_To_Guest_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" 
                                        runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="Groups_List_GridView_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" >
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="First_Name" HeaderText="First Name" ItemStyle-Width="30" >
                                            <ItemStyle Width="200px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Last_Name" HeaderText="Last Name" ItemStyle-Width="150" >
                                            <ItemStyle Width="200px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="150" >
                                            <ItemStyle Width="200px"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>

                                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>

                    <asp:Label ID="Group_List_Massage_LBL" runat="server"></asp:Label>

                            </td>
                            <td>

                                <asp:Label ID="Gruop_List_Guest_Massege_LBL" runat="server"></asp:Label>

                            </td>
                        </tr>
                    </table>
                    
                                    
                </div>
                <div>
                    <br />
                    <asp:Button ID="Edit_Group_CMD" runat="server" Text="Edit Group" OnClick="Edit_Group_CMD_Click" />
                    <asp:Button ID="Delete_Group_CMD" runat="server" Text="Delete Group" OnClick="Delete_Group_CMD_Click" />
                </div>
            </div>
        </div>
    </div>
        


    






</asp:Content>

