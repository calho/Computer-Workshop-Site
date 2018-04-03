<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Part_4.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>&nbsp;</h2>
    <h2><%: Title %></h2>
    <h3>Summary of your cart:</h3>
    <p>&nbsp;</p>
    <p>
        <table id="ordersTable" style="width:100%;" runat="server">
            <tr>
                <td>computer:</td>
                <td id="comp">&nbsp;</td>
                <td id="compp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>RAM:</td>
                <td id="r">&nbsp;</td>
                <td id="rp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Hard Drive:</td>
                <td id="h">&nbsp;</td>
                <td id="hp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>CPU:</td>
                <td id="c">&nbsp;</td>
                <td id="cp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Display:</td>
                <td id="d">&nbsp;</td>
                <td id="dp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>OS:</td>
                <td id="o">&nbsp;</td>
                <td id="op">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Soundcard:</td>
                <td id="s">&nbsp;</td>
                <td id="sp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Total</td>
                <td id="tp">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
        <p>
            <table id="uOrdertable" style="width:100%;" runat="server">

            </table>
    </p>

</asp:Content>
