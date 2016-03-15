<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NormalUser.aspx.cs" Inherits="gamereview.NormalUser" MasterPageFile="~/master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <p>Normal User Profile Page&nbsp; </p>
    </div>
    <div>

      <div>
        <asp:Label ID="Email" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
              Text="Friendrequest" Width="102px" />
        <br />
        <asp:Label ID="firstname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
              Text=" send messages" Width="105px" />
        <br />
        <asp:Label ID="lastname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button4" runat="server" Text="view messages" Width="104px" 
              onclick="Button4_Click" />
        <br />
        <asp:Label ID="dateofbitrh" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="search" 
              Width="107px" />
        <br />
        <asp:Label ID="age" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
<asp:Label ID="preferedgame" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="membershipType" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;<br />
          <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update" 
              Width="82px" />
        <br />
       
        
    </div>
    </div>

    </asp:Content>