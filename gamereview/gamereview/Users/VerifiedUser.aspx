<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifiedUser.aspx.cs" Inherits="gamereview.VerifiedUser" MasterPageFile="~/master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
    <p>Verified reviewerProfile Page </p>
    </div>
    <div>

      <div>
        <asp:Label ID="Email" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="firstname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="lastname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        <br />
        <asp:Label ID="yearsofexperience" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        <br />
       <asp:Label ID="preferedgame" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
              Text="Search" Width="87px" />
        <br />
        <asp:Label ID="membershipType" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
              Text="update" Width="86px" />
        <br />
       
        
    </div>
    </div>
 </asp:Content>