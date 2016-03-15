<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConferenceProfile.aspx.cs" Inherits="Game.Conferences.ConferenceProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            height: 1001px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="ConferenceNameLabel" style="width: 465px; margin-left: 158px">
    
        &nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Label ID="ConferenceNameLable" runat="server" Height="63px" 
            style="margin-left: 28px; margin-top: 0px" Text="Conference Name" Width="411px"></asp:Label>
    
    </div>
    <asp:Label ID="ConferenceInfoLabel" runat="server" Text="Conference Info:"></asp:Label>
        <br />
        <br />
    <asp:Label ID="DateLabel" runat="server" Text="      -Date:"></asp:Label>
        <br />
    <asp:Label ID="DurationLabel" runat="server" Text="-Duration:"></asp:Label>
        <br />
    <asp:Label ID="LocationLabel" runat="server" Text="-Location:"></asp:Label>
        <br />
        <br />
        <asp:Button ID="AttendButton" runat="server" onclick="AttendButton_Click" 
            Text="Attend" />
        <br />
        <br />
        <asp:Label ID="DebuteLabel" runat="server" Text="Debute a game!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="GameNameLabel" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:TextBox ID="GameNameTextBox" runat="server" Height="20px" Width="90px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="AgeLimitLabel" runat="server" Text="Age limit:"></asp:Label>
        <br />
        <asp:TextBox ID="AgeLimitTextBox" runat="server" Width="90px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DebuteButton" runat="server" onclick="DebuteButton_Click" 
            Text="Debute" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" 
            Text="Or present one that you have developed before"></asp:Label>
        <br />
        <br />
        <asp:Label ID="GameNameLabel2" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:TextBox ID="GameNameTextBox2" runat="server" Width="90px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="PresentButton" runat="server" onclick="PresentButton_Click" 
            Text="Present" />
        <br />
        <br />
        <br />
        <asp:Label ID="AddReviewLabel" runat="server" Text="Add a review:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLabel" runat="server" Text="Title: "></asp:Label>
        <br />
&nbsp;<asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="ReviewLabel" runat="server" Text="Review:"></asp:Label>
        <br />
&nbsp;<asp:TextBox ID="ReviewTextBox" runat="server" Height="115px" Width="229px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="AddReviewButton" runat="server" onclick="AddReviewButton_Click" 
            style="margin-left: 0px" Text="Add" />
   
    <br />
    <br />
    <br />
   
    </form>
</body>
</html>
