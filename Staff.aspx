<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment5_CSE445_Group_62.Staff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Staff Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" /><br /><br />

            Username:
            <asp:TextBox ID="txtUsername" runat="server" /><br /><br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />

            <hr />
            <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                <h3>Admin Section</h3>
                <asp:Label ID="lblAdminWelcome" runat="server" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
