<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verifiedviews.aspx.cs" Inherits="gamereview.verifiedviews" MasterPageFile="~/master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><div>
    <p>Verified reviewerProfile Page </p>
    </div>
    

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
        <br />
        <asp:Label ID="membershipType" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        <br />
       
        
    </div>
    </div>

    
</asp:Content>