<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="Part_4.item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>&nbsp;</h2>
    <h2><%: Title %></h2>    
    <div>
        <p id ="itemProfile" runat="server" style="display:inline"></p>
        <p id ="P1" runat="server" style="display:inline">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <h2 id="scoreText" runat="server" style="display:inline"></h2>
    </div>
     <p>&nbsp;</p>
    <h3>Reviews</h3>
    <p>Name:</p>
    <p>&nbsp;<asp:TextBox ID="name" runat="server" MaxLength="50"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>Review: 
    </p>
    <p> <asp:TextBox ID="review" runat="server" Height="125px" Width="437px" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>Score:</p>
    <p>
        <asp:DropDownList ID="score" runat="server">
            <asp:ListItem Value="0.0">0.0</asp:ListItem>
            <asp:ListItem Value="0.5">0.5</asp:ListItem>
            <asp:ListItem Value="1.0">1.0</asp:ListItem>
            <asp:ListItem Value="1.5">1.5</asp:ListItem>
            <asp:ListItem Value="2.0">2.0</asp:ListItem>
            <asp:ListItem Value="2.5">2.5</asp:ListItem>
            <asp:ListItem Value="3.0">3.0</asp:ListItem>
            <asp:ListItem Value="3.5">3.5</asp:ListItem>
            <asp:ListItem Value="4.0">4.0</asp:ListItem>
            <asp:ListItem Value="4.5">4.5</asp:ListItem>
            <asp:ListItem Value="5.0" Selected="True">5.0</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p id="error" runat="server">&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </p>
<p id="debug" runat="server">
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BorderColor="White" CellPadding="25" GridLines="Horizontal" Width="100%" >
            <EditRowStyle BorderColor="#CCCCCC" />
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
</asp:Content>
