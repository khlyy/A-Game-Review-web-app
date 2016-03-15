<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseGame1.aspx.cs" Inherits="Game.ChooseGame1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 235px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    <strong><em>Choose a Game: </em></strong>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList_Choose_Game" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" 
                        style="direction: ltr">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:gameConnectionString %>" 
                        SelectCommand="SELECT [name] FROM [Games]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button_Next" runat="server" onclick="Button1_Click" Text="Next" 
                        Width="308px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
