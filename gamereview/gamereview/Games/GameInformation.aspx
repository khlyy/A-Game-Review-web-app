<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameInformation.aspx.cs" Inherits="Game.GameInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            text-align: center;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 488px;
            text-align: center;
        }
        .style4
        {
            width: 355px;
        }
        .style5
        {
            width: 429px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p class="style1">
        <em><strong>Game Information</strong></em></p>
    <p class="style1">
        &nbsp;</p>
    <table class="style2">
        <tr>
            <td class="style3">
                Name:</td>
            <td class="style4">
                <asp:Label ID="Label_Name" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Release date:</td>
            <td class="style4">
                <asp:Label ID="Label_Release" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Age limit:</td>
            <td class="style4">
                <asp:Label ID="Label_Age" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Type of game:</td>
            <td class="style4">
                <asp:Label ID="Label_Type" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Overall rating:</td>
            <td class="style4">
                <asp:Label ID="Label_Rating" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Rate" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                Development team:</td>
            <td class="style4">
                <asp:Label ID="Label_Team" runat="server" Width="350px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Screenshots:</td>
            <td class="style4">
                <asp:GridView ID="GridView_ScreenShots" runat="server">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Videos:</td>
            <td class="style4">
                <asp:GridView ID="GridView_Videos" runat="server">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Reviews titles:</td>
            <td class="style4">
                <asp:DropDownList ID="DropDownList_Show_Review" runat="server" 
                    onselectedindexchanged="DropDownList_Show_Review_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button_Show_Review" runat="server" onclick="Button1_Click" 
                    Text="Show Review" />
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Games/ChooseGame1.aspx">Back to all games</asp:HyperLink>
            </td>
        </tr>
    </table>
    <table class="style2">
        <tr>
            <td class="style5">
                Recommend this game to another user:</td>
            <td>
                <asp:DropDownList ID="DropDownList_Recommend" runat="server" 
                    onselectedindexchanged="DropDownList_Recommend_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Done" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                For Verified reviewer only:</td>
            <td>
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Add Review" Width="187px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
