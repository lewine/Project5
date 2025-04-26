<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5_CSE445_Group_62.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Member Login</h2>
        <asp:Label ID ="message" runat="server" ForeColor="Purple" />
        <p>
            Username: <asp:TextBox ID="txtUser" runat="server" />
        </p>
        <p>
            Password: <asp:TextBox ID="txtPass" runat="server" />
        </p>
        <p>
            CAPTCHA - TEMP: What is 2+2?
            <asp:TextBox ID="captcha" runat="server" />
        </p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </p>
    </form>
</body>
</html>
