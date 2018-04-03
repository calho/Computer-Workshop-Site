<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="Part_4.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>&nbsp;</h2>
    <h2><%: Title %>.</h2>
    <h3>Feel free to leave any feedback.</h3>
    
    <p>&nbsp;</p>
    <p>Name:</p>
    <p>&nbsp;<asp:TextBox ID="name" runat="server" MaxLength="50"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
    <p>Feedback: 
    </p>
    <p> <asp:TextBox ID="fb" runat="server" Height="125px" Width="437px" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
    </p>
    <p>&nbsp;</p>
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
