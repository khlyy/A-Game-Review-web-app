﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="normaluserupdate.aspx.cs" Inherits="gamereview.updatepages.normaluserupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 331px">
    
        <asp:Label ID="firstnamelabel" runat="server" Text="Label">firstname</asp:Label>
        <asp:TextBox ID="firstnameTextBox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="lastnamelabel" runat="server" Text="Label">last name</asp:Label>
        <asp:TextBox ID="lastnameTextBox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="dateofbirthlabel" runat="server" Text="Label">dateofbirth</asp:Label>
        <asp:TextBox ID="dateofbirthtextbox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />

        <asp:Button ID="update" runat="server" Text="Update" onclick="update_Click" />
        <br />
       
    
    </div>
    </form>
</body>
</html>
