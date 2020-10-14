<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retrieve.aspx.cs" Inherits="LoginSystem.Retrieve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve Password</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label3" runat="server" Text="E - Mail "></asp:Label>
            &nbsp;<asp:TextBox ID="Emailtb" runat="server"></asp:TextBox>
            <br />
              <asp:Label ID="Label5" runat="server" Text="Secret Question "></asp:Label>
            &nbsp;<asp:TextBox ID="Secretqtb" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label6" runat="server" Text="Secret Answer "></asp:Label>
            &nbsp;<asp:TextBox ID="Secretatb" runat="server"></asp:TextBox>
              <br />
            <asp:Label ID="Warning" runat="server" Visible="False"></asp:Label>
        </div>
         <asp:Button ID="retrieveButton" runat="server" CssClass="loginButton" Text="Retrieve Password" Width="192px" OnClick="retrieveButton_Click" />
        <br />
        <asp:Button ID="return" runat="server" CssClass="loginButton" Text="Login Page" Width="192px" OnClick="return_Click" />
    </form>
        </center>
</body>
</html>
