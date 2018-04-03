<%@ Page Title="Components" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="components.aspx.cs" Inherits="Part_4.components" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;</h2>
    <h2><%: Title %></h2>    
    <div style="width:100%">
        <table style="height: 100%; width: 100px; float:left; border:1px solid black; margin-right:50px">
            <tr>
                <td style="border-style: none; border-color: #000000;">    
                     <asp:CheckBox ID="all" runat="server" GroupName="filter" Text="All" Checked="true" OnCheckedChanged="all_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;" >
                    <asp:CheckBox ID="ram" runat="server" Text="RAM" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:CheckBox ID="hd" runat="server" Text="Hard Drive" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:CheckBox ID="cpu" runat="server" Text="CPU" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:CheckBox ID="dis" runat="server" Text="Display" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:CheckBox ID="os" runat="server" Text="OS" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:CheckBox ID="sc" runat="server" Text="Soundcard" OnCheckedChanged="filter_CheckedChanged" AutoPostBack="true"/>
                </td>
            </tr>
        </table>

        <table style="height: 100%; width: 100px; float:left; border:1px solid black; margin-right:50px">
            <tr>
                <td style="border-style: none; border-color: #000000;">    
                    <asp:RadioButton ID="nonebox" runat="server" GroupName="order" Text="None" Checked="true" OnCheckedChanged="order_CheckedChanged" AutoPostBack ="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;" >
                    <asp:RadioButton ID="asce" runat="server" GroupName="order" Text="Price low to high" OnCheckedChanged="order_CheckedChanged" AutoPostBack ="true"/>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:RadioButton ID="desc" runat="server" GroupName="order" Text="Price high to low" OnCheckedChanged="order_CheckedChanged" AutoPostBack ="true" />
                </td>
            </tr>
            <tr>
                <td style="border-style: none; border-color: #000000;">
                    <asp:RadioButton ID="na" runat="server" GroupName="order" Text="Name" OnCheckedChanged="order_CheckedChanged" AutoPostBack ="true"/>
                </td>
            </tr>
        </table>


        <table ID="componentTable" runat="server" style="height: 41px; width: 145px" >

        </table>
    </div>

    <p>&nbsp;</p>
</asp:Content>
