<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="developmentTeamsUpdate.aspx.cs" Inherits="gamereview.updatepages.developmentTeamsUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="teamnamelabel" runat="server" Text="Label">team name</asp:Label>
        <asp:TextBox ID="teamnameTextBox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="companynamelabel" runat="server" Text="Label">company name</asp:Label>
        <asp:TextBox ID="companynameTextBox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="dateofformationlabel" runat="server" Text="Label">dateofformation</asp:Label>
        <asp:TextBox ID="dateofformationtextbox" runat="server" 
            style="margin-left: 28px; margin-top: 6px" Width="200px"></asp:TextBox>
        <br />

        <asp:Button ID="update" runat="server" Text="Update" onclick="update_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>
