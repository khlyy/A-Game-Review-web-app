<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="developmentteams.aspx.cs" Inherits="gamereview.developmentteams" MasterPageFile="~/master.Master" %>

   <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 286px">
    
        <asp:Label ID="Email" runat="server" BorderColor="#3333FF" 
            BorderStyle="Double" Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="preferedgame" runat="server" BorderColor="#3333FF" 
            BorderStyle="Double" Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="teamname" runat="server" BorderColor="#3333FF" 
            BorderStyle="Double" Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="company" runat="server" BorderColor="#3333FF" 
            BorderStyle="Double" Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="dateofformation" runat="server" BorderColor="#3333FF" 
            BorderStyle="Double" Text="Label" Width="200px"></asp:Label>
    
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="search" 
            onclick="Button3_Click" />
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="update" onclick="Button1_Click" />
    
    </div>
  </asp:Content>
