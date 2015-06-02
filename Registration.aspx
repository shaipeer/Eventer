<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Registration_Form_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="registration_form">
        <br />
        <h2>Registration</h2>
        <br />
        <div >

        <table id="registration_table" align="center" style="margin-top: 0px">
            <tr>
                <td>id:</td>
                <td>
                        <asp:TextBox ID="Id_TextBox" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td>first name:</td>
                <td>
                        <asp:TextBox ID="First_Name_TextBox" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td>last name:</td>
                <td>
                        <asp:TextBox ID="LastName_TextBox" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td>mail:</td>
                <td>
                        <asp:TextBox ID="Mail_TextBox" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
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
                <td>Re-Enter Password:</td>
                <td>
                        <asp:TextBox ID="Re_Enter_Password_TextBox" TextMode="password" runat="server"></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                        <asp:Button ID="Register_CMD" runat="server" Text="Register" OnClick="Register_CMD_Click" />
                    </td>
                <td></td>
            </tr>
        </table>

        </div>
    </div>

</asp:Content>

