<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GuestList.aspx.cs" Inherits="GuestList" %>

<asp:Content ID="Guest_List_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="guest_list">
        <div id="nav">
            <br />
            <h2>Add Guest</h2>
            <table style="width: 100%">
           
                <caption>
                    <asp:Label ID="Guest_Nav_Eror_Label" runat="server" Text="" ForeColor="Red" ></asp:Label>
                </caption>
           
                <tr>
                    <td>First Name:<br />
                    </td>
                    <td>
                        <asp:TextBox ID="First_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td>
                        <asp:TextBox ID="Last_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="Phone_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Group:</td>
                    <td>
                        <asp:DropDownList ID="Group_DropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Status:</td>
                    <td>
                        <asp:TextBox ID="Status_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Arriving:</td>
                    <td>
                        <asp:TextBox ID="Arriving_TextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Guest_Nav_CMD" runat="server" Text="Add Guest" OnClick="Guest_Nav_CMD_Click"/>    
                    </td>
                </tr>

            </table>
        </div>
    
        <div id="section">
            <br />
            <h2>Guest List</h2>
            <br />
            <div>
                <div id="grid_div" >
                    <asp:GridView ID="Guest_list_GridView" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Guest_list_GridView_SelectedIndexChanged">

                            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

                            <RowStyle HorizontalAlign="center" />
                            <Columns>
                                <asp:BoundField DataField="id"              HeaderText="Id"             ItemStyle-Width="30" >
                                    <ItemStyle Width="30px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="first_name"      HeaderText="First Name"     ItemStyle-Width="250" >
                                    <ItemStyle Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="last_name"       HeaderText="Last Name"      ItemStyle-Width="200" >
                                    <ItemStyle Width="200px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="phone"           HeaderText="Phone"          ItemStyle-Width="200" >
                                    <ItemStyle Width="200px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="group"           HeaderText="Group"          ItemStyle-Width="150" >
                                    <ItemStyle Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="status"          HeaderText="Status"         ItemStyle-Width="150" >
                                    <ItemStyle Width="150px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="arriving"        HeaderText="Arriving"       ItemStyle-Width="150" >
                                    <ItemStyle Width="150px"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle BackColor="#CCFFFF" />
                    </asp:GridView>
                    
                    
                
                </div>
                <div>
                    <br />
                    <asp:Label ID="No_Guest_LBL" runat="server"></asp:Label>
                    <br />
                    <br />
                    
                    <asp:Button ID="Choose_Guest_CMD"   runat="server" Text="Choose Guest" OnClick="Choose_Guest_CMD_Click" />

                    <asp:Button ID="Edit_Guest_CMD"     runat="server" Text="Edit Guest" OnClick="Edit_Guest_CMD_Click" />

                    <asp:Button ID="Delete_Guest_CMD"   runat="server" Text="Delete Guest" OnClick="Delete_Guest_CMD_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

