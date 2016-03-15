<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConferenceReviews.aspx.cs" Inherits="Game.Conferences.ConferenceReviews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 339px; margin-left: 212px">
    
        <asp:Label ID="ReviewTitleLabel" runat="server" Text="Review Title"></asp:Label>
    
    </div>
    <div style="height: 204px; direction: ltr;">
        <br />
        <asp:HyperLink ID="ReviewerNameLable" runat="server">Reviewer Name</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="ReviewContentLabel" runat="server" Text="Review Content"></asp:Label>
    </div>
    <div style="height: 100px" id="CommentDiv">
        <asp:Label ID="AddCommentLabel" runat="server" Text="Add a Comment:  "></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="CommentTextBox" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="CommentButton" runat="server" onclick="CommentButton_Click" 
            Text="Comment" />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
