<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Part_4.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;</h2>
    <h2><%: Title %>.</h2>
    <p>&nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 157px">Username:</td>
                <td style="width: 171px">
                    <input id="un" type="text" runat="server"/></td>
                <td id="uerror" runat="server">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 157px">Password:</td>
                <td style="width: 171px">
                    <input id="pwd" type="password" runat="server"/></td>
                <td id="perror" runat="server">&nbsp;</td>
            </tr>
            <tr>
                <td id="error" style="width: 157px; color: #FF0000;" runat="server">&nbsp;</td>
                <td style="width: 171px">
                    &nbsp;</td>
                <td runat="server">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 28px; width: 157px;">
                    <asp:Button ID="log" runat="server" Text="Login" OnClick="log_Click" />
                </td>
                <td style="height: 28px; width: 171px;"></td>
                <td style="height: 28px"></td>
            </tr>
            <tr>
                <td style="width: 157px">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/signup">Sign up</asp:HyperLink>
                </td>
                <td style="width: 171px">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/recover">forgot password</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>


</asp:Content>
