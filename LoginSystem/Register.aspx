<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LoginSystem.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="Style.css" />
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="E - Mail "></asp:Label>
            &nbsp;<asp:TextBox ID="Emailtb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password "></asp:Label>
            &nbsp;<asp:TextBox ID="Passwordtb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Name "></asp:Label>
            &nbsp;<asp:TextBox ID="Nametb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Surname "></asp:Label>
            &nbsp;<asp:TextBox ID="Surnametb" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label5" runat="server" Text="Secret Question "></asp:Label>
            &nbsp;<asp:TextBox ID="Secretqtb" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label6" runat="server" Text="Secret Answer "></asp:Label>
            &nbsp;<asp:TextBox ID="Secretatb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Warning" runat="server" Visible="False"></asp:Label>
        </div>
           <asp:Button ID="registerButton" runat="server" CssClass="loginButton" OnClick="registerButton_Click" Text="Register" Width="192px" />
    </form>
        </center>
</body>
</html>
