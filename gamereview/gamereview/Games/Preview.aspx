<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="Game.Preview" %>

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
            text-align: center;
        }
        .style3
        {
            font-size: x-large;
        }
        .style4
        {
            width: 294px;
            text-align: right;
        }
        .style5
        {
            width: 296px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style2">
    
        &nbsp;<strong><em><span class="style3">Preview review</span></em></strong></div>
    <table class="style1">
        <tr>
            <td class="style4">
                Game name:</td>
            <td>
                <asp:Label ID="Label_Game_Name" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Reviewer profile:</td>
            <td>
                <asp:HyperLink ID="Hyperlink_Reviewer_Profile" runat="server" 
                    NavigateUrl="~/ChooseGame1.aspx">Click here</asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Content of&nbsp; review:</td>
            <td>
                <asp:Label ID="Label_Content" runat="server" Width="1000px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Comments on review:</td>
            <td>
                <asp:GridView ID="GridView_Comments" runat="server" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Add comment<br />
            </td>
            <td>
                <asp:TextBox ID="TextBox_Add_Comment" runat="server" Height="81px" 
                    Width="347px" ontextchanged="TextBox_Add_Comment_TextChanged"></asp:TextBox>
                <asp:Button ID="Button_Delete" runat="server" onclick="Button1_Click" 
                    Text="Done" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td class="style5">
                Delete Comments:</td>
            <td>
                <asp:DropDownList ID="DropDownList_Delete_Comments" runat="server" 
                    onselectedindexchanged="DropDownList_Delete_Comments_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Delete" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
