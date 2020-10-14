<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExpenseApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
   <center>
       <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="E - Mail "></asp:Label>
            <input runat="server" type="text" id="Email" />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password "></asp:Label>
            <input runat="server" type="password" id="Password" />
            <br />
            <asp:Label ID="Warning" runat="server" Visible="False"></asp:Label>
        </div>
            <asp:Button CssClass="loginButton" runat="server" ID="loginButton" Text="Login" OnClick="loginButton_Click" Width="192px" />
           <br />
           <asp:Button ID="registerButton" runat="server" CssClass="loginButton" OnClick="registerButton_Click" Text="Register" Width="192px" />
           <asp:Button ID="verify" runat="server" CssClass="loginButton"  Text="Verify Account" Width="192px" OnClick="verify_Click" />
           <br />
           <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forgot Your Password?</asp:LinkButton>
    </form>
       </center>
</body>
</html>
