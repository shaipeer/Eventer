<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<asp:Content ID="Main_Page_Content" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="main_page">
        
        <h2> WELCOME </h2>
        
        <p>
            <br />
            eVenter is a smart event manager that will make special event perfect.
        </p>
        
        <table>
            <td>
                
            </td>
        </table>
        
        <asp:Button ID="Register_Main_Page_CMD" runat="server" Text="Registration" BackColor="Transparent" BorderStyle="Solid" BorderWidth="2px" Font-Size="X-Large" BorderColor="#333333" Font-Bold="True" ForeColor="#333333" PostBackUrl="~/Registration.aspx" />

        <asp:Button ID="Login_Main_Page_CMD"    runat="server" Text="Log-In" BackColor="Transparent" BorderStyle="Solid" BorderWidth="2px" Font-Size="X-Large" BorderColor="#333333" Font-Bold="True" ForeColor="#333333" PostBackUrl="~/Login.aspx" />

    </div>
</asp:Content>

