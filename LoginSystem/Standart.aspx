<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Standart.aspx.cs" Inherits="LoginSystem.Standart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Logged In</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="logoutButton" runat="server" CssClass="loginButton" Text="Logout" Width="192px" OnClick="logoutButton_Click" />
        </div>
    </form>
        </center>
</body>
</html>
