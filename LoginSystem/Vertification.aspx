<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vertification.aspx.cs" Inherits="LoginSystem.Vertification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <center>
              <asp:Label ID="Label1" runat="server" Text="Please check your e-mail and enter vertification code below. "></asp:Label>
    <form id="form1" runat="server">
        <div>
              <asp:Label ID="Label3" runat="server" Text="E - Mail "></asp:Label>
            &nbsp;<asp:TextBox ID="Emailtb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Vertification "></asp:Label>
            &nbsp;<asp:TextBox ID="Vertiftb" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="vertifyButton" runat="server" CssClass="loginButton" Text="Confirm" Width="192px" OnClick="vertifyButton_Click" />

        </div>
    </form>
        </center>
</body>
</html>
