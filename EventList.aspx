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
                    <asp:GridView ID="Event_list_GridView" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="user_id,event_id" 
                        DataSourceID="Eventer"  
                        Width="1000px" 
                        OnSelectedIndexChanged="Event_list_GridView_SelectedIndexChanged"
                        GridLines="None"
                        AllowPaging="true"
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnRowDataBound="Event_list_GridView_RowDataBound">

                        <PagerStyle CssClass="pgr"></PagerStyle>

                        <RowStyle HorizontalAlign="center" />
                        <AlternatingRowStyle HorizontalAlign="Center" />
                        
                            <Columns>
                                <asp:TemplateField HeaderText="Event Name" SortExpression="event_name">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("event_name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="EventName_Event_List_Label" runat="server" Text='<%# Bind("event_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type" SortExpression="type">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="Type_Event_List_Grid_DropDownList" runat="server">
                                            <asp:ListItem>Select Event Type</asp:ListItem>
                                            <asp:ListItem>Wedding</asp:ListItem>
                                            <asp:ListItem>Civil Wedding</asp:ListItem>
                                            <asp:ListItem>Silver wedding</asp:ListItem>
                                            <asp:ListItem>Golden wedding</asp:ListItem>
                                            <asp:ListItem>Bar Mitzvah</asp:ListItem>
                                            <asp:ListItem>Henna</asp:ListItem>
                                            <asp:ListItem>Brit</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number Of Guests" SortExpression="number_of_guests">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="Num_Of_Guests_Event_List_TextBox" runat="server" Text='<%# Bind("number_of_guests") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("number_of_guests") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="Date_Event_List_extBox" runat="server" Text='<%# Bind("date") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location" SortExpression="location">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="Location_Event_List_TextBox" runat="server" Text='<%# Bind("location") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("location") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                        <asp:SqlDataSource ID="Eventer" runat="server" ConnectionString="<%$ ConnectionStrings:EventerConnectionString %>" SelectCommand="SELECT * FROM [Event]"></asp:SqlDataSource>
                


                    
                </div>
                <div>
                    <asp:Label ID="Test_LBL" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="Choose_Event_CMD" runat="server" Text="Choose Event" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

