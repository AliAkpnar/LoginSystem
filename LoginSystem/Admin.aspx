<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LoginSystem.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
   <center>
    <form id="form1" runat="server">
            <asp:Label ID="onlineUsers" runat="server" Text="Label"></asp:Label>
        <br />
            <asp:Label ID="registerCount" runat="server" Text="Label"></asp:Label>
        <br />
            <asp:Label ID="notVertified" runat="server" Text="Label"></asp:Label>
        <br />
            <asp:Label ID="registerAverage" runat="server" Text="Label"></asp:Label>
        <br />
        <div>
            <asp:Button ID="logoutButton" runat="server" CssClass="loginButton" Text="Logout" Width="192px" OnClick="logoutButton_Click" />
        </div>
    </form>
        </center>
</body>
</html>
