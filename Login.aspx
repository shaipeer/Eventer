<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Log_In_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="registration_form">
        <br />
        <h2>Log-In</h2>
        <br />
        <div >

        <table id="registration_table" align="center" style="margin-top: 0px">
            <tr>
                <td>user name:</td>
                <td>
                        <asp:TextBox ID="User_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td style="height: 20px">Password:</td>
                <td style="height: 20px">
                        <asp:TextBox ID="Password_TextBox" TextMode="password" runat="server"></asp:TextBox>
                    </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                        <asp:Button ID="LogIn_CMD" runat="server" Text="Log-In"/>
                    </td>
                <td></td>
            </tr>
        </table>

        </div>
    </div>

</asp:Content>

