<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Part_4.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;</h2>
    <h2><%: Title %>.</h2>
    <p>&nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 142px">Username:</td>
                <td>
                    <input id="un" type="text" runat="server" maxlength="50" /></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 142px">Password:</td>
                <td>
                    <input id="pwd" type="password" runat="server" maxlength="50"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 142px">re-type Password:</td>
                <td>
                    <input id="rpwd" type="password" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 142px">Security Question:</td>
                <td>
                    <input id="qn" type="text" runat="server" maxlength="254"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 142px">Security Answer:</td>
                <td>
                    <input id="ans" type="text" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="error" style="width: 142px; color: #FF0000;" runat="server">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 142px">
                    <asp:Button ID="su" runat="server" Text="Sign up" OnClick="su_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>

</asp:Content>
