<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="gamereview.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                      <asp:ValidationSummary ID="RegisterUserValidationSummary" 
        runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup" 
        ForeColor="Red"/>
    <div class="accountInfo" style="direction: ltr">
    <p>Sign Up</p>
        <asp:Label ID="LabelEmail" runat="server"  Text="Label"> EMAIL</asp:Label> <br />
        <asp:TextBox ID="TextBoxEmail" runat="server"  Width="200px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="TextBoxEmail" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="Email is required." 
                                     ValidationGroup="RegisterUserValidationGroup">Email cannot be empty</asp:RequiredFieldValidator>
                          <br />
        
        <asp:Label ID="LabelPassword" runat="server"   Text="Label">Password</asp:Label> <br />
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" Width="200px"></asp:TextBox> <br />
             <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="TextBoxPassword" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">Password cannot be empty</asp:RequiredFieldValidator>
                                     <br />
        
        <asp:Label ID="LabelConfirmPassword" runat="server"  Text="Label">Confirm Password</asp:Label><br />
        <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox><br />
                 <asp:RequiredFieldValidator ID="ConfirmPasswordvalidator" runat="server" ControlToValidate="TextBoxConfirmPassword" 
                                     CssClass="failureNotification" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">Confirm Password Cannot be empty</asp:RequiredFieldValidator>
                                     <br />
         <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">The Password and Confirmation Password must match.</asp:CompareValidator>
                                     <br />        
        <asp:Label ID="LabelPreferedGame" runat="server"   Text="Label">Prefered Game</asp:Label><br />
        <asp:TextBox ID="TextBoxPreferedGame" runat="server" Width="200px"></asp:TextBox><br />

        <asp:Label ID="LabelMembershiptype" runat="server"  Text="Label">Membership Type</asp:Label><br />

        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Development Teams</asp:ListItem>
            <asp:ListItem>Verified Reviewer</asp:ListItem>
            <asp:ListItem>Normal User</asp:ListItem>
        </asp:DropDownList>
        <br />
       
        <asp:Button ID="register" runat="server" Text="Register" 
            onclick="register_Click" />
        
        </div>
       <div>
          <p> LogIn </p>
        <asp:Label ID="Labellogin" runat="server"  Text="Label">Email</asp:Label><br />
        <asp:TextBox ID="TextBoxlogin" runat="server" Width="200px"></asp:TextBox><br />
         <asp:RequiredFieldValidator ID="LoginEmail" runat="server" ControlToValidate="TextBoxlogin" 
                                     CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                     <br />
   
        <asp:Label ID="LabelloginPassword" runat="server"   Text="Label">Password</asp:Label><br />
        <asp:TextBox ID="TextBoxLoginPassword" runat="server" TextMode="Password"  Width="200px"></asp:TextBox><br />
         <asp:RequiredFieldValidator ID="loginPassword" runat="server" ControlToValidate="TextBoxLoginPassword" 
                                     CssClass="failureNotification" ErrorMessage=" Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                     <br />
               <asp:Button ID="login1" runat="server" Text="login" 
            onclick="login_Click" style="height: 26px" />
            

       </div>
    <p style="direction: ltr">
        &nbsp;</p>
    </form>
</body>
</html>
