<%@ Page Title="recover" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recover.aspx.cs" Inherits="Part_4.recover" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;</h2>
    <h2><%: Title %>.</h2>
    <p>&nbsp;</p>
    <p>
        <table id="tc" runat="server" style="width:100%;">
            <tr>
                <td style="width: 137px">Username:</td>
                <td>
                    <input id="un" maxlength="50" type="text" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 137px">Security question:</td>
                <td>
                    <input id="qn" maxlength="254" type="text" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 137px">Security answer:</td>
                <td>
                    <input id="ans" maxlength="254" type="text" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="error" style="width: 137px; height: 22px; color: #FF0000;" runat="server"></td>
                <td style="height: 22px"></td>
                <td style="height: 22px"></td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="check" runat="server" OnClick="Button1_Click" Text="check" />
    </p>
    <p>
        <table id="tp" runat="server" style="width:100%;" Visible="False">
            <tr>
                <td style="width: 141px">New password:</td>
                <td>
                    <input id="pwd" type="password" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 141px">re-type password:</td>
                <td>
                    <input id="rpwd" type="password" runat="server"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="perror" style="width: 141px; color: #FF0000;">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="cp" runat="server" Text="change password" Visible="False" OnClick="cp_Click" />
    </p>
</asp:Content>
