<%@ Page Title="Build A PC" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="build.aspx.cs" Inherits="Part_4.build" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>&nbsp;</h2>
    <h2><%: Title %>.</h2>
    <h3>select one of our pre-configured computers and/or feel free to customize it.</h3>
    <p>&nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td>
    <p>Computers:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" ClientIDMode="Static">
        </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
    <p>RAM:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="ram" runat="server">ram</td>
                <td id="ramp" runat="server">ramp</td>
            </tr>
            <tr>
                <td>
    <p>Hard Drive:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="hd" runat="server">hd</td>
                <td id="hdp" runat="server">hdp</td>
            </tr>
            <tr>
                <td>
    <p>CPU:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="cpu" runat="server">cpu</td>
                <td id="cpup" runat="server">cpup</td>
            </tr>
            <tr>
                <td>
    <p>Display:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="d" runat="server">d</td>
                <td id="dp" runat="server">dp</td>
            </tr>
            <tr>
                <td>
    <p>OS:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="os" runat="server">os</td>
                <td id="osp" runat="server">osp</td>
            </tr>
            <tr>
                <td>
    <p>Soundcard:</p>
                </td>
                <td>
        <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True">

        </asp:DropDownList>
                </td>
                <td id="sc" runat="server">sc</td>
                <td id="scp" runat="server">scp</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Total:</td>
                <td id="tot" runat="server">$</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Add to Cart" UseSubmitBehavior="False" />
                </td>
                <td runat="server">&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>&nbsp;</p>
    

</asp:Content>
