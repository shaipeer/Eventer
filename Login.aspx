<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Log_In_Content" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id="registration_form">
        <br />
        <h2>Log-In</h2>
        <asp:Label ID="Login_Error_Lable" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <div >

        <table id="registration_table" align="center" style="margin-top: 0px; width: 314px; height: 116px;" aria-dropeffect="none">
            <tr>
                <td style="width: 161px">user name:</td>
                <td>
                        <asp:TextBox ID="User_Name_TextBox" runat="server" Width="148px"></asp:TextBox>
                    </td>
                <td style="width: 55px"></td>
            </tr>
            <tr>
                <td style="height: 17px; width: 161px;">Password:&nbsp;&nbsp; </td>
                <td style="height: 17px">
                        <asp:TextBox ID="Password_TextBox" TextMode="password" runat="server" Width="149px"></asp:TextBox>
                    </td>
                <td style="height: 17px; width: 55px;"></td>
            </tr>
            <tr>
                <td style="height: 18px; width: 161px"></td>
                <td style="height: 18px"></td>
                <td style="height: 18px; width: 55px"></td>
            </tr>
            <tr>
                <td style="width: 161px">&nbsp;</td>
                <td>
                        <asp:Button ID="LogIn_CMD" runat="server" Text="Log-In" OnClick="LogIn_CMD_Click"/>
                    </td>
                <td style="width: 55px"></td>
            </tr>
        </table>
        <br />
        <link rel="stylesheet" type="text/css" href="Registration.aspx">
            <asp:LinkButton ID="NotRegisterd_LBL" runat="server" Font-Size="Small" PostBackUrl="~/Registration.aspx" OnClick="NotRegisterd_LBL_Click">not registered?</asp:LinkButton>
        <br />


        </div>
    </div>

</asp:Content>

