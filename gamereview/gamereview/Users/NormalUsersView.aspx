<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NormalUsersView.aspx.cs" Inherits="gamereview.NormalUsersView" MasterPageFile="~/master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div style="height: 262px">
        <asp:Label ID="Email" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <br />
        <asp:Label ID="firstname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <br />
        <asp:Label ID="lastname" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
<asp:Label ID="preferedgame" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="membershipType" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
        &nbsp;<br />
         
       
        <asp:Label ID="dateofbitrh" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
          <br />
        
        <asp:Label ID="age" runat="server" BorderStyle="Double" ForeColor="#3333FF" 
            Text="Label" Width="200px"></asp:Label>
         
       
    </div>
    </form>
</body>
</html>
</asp:Content>