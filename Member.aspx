<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5_CSE445_Group_62.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Portal</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="pnlLogin" runat="server">
            <h2>Member Login</h2>
            <asp:Label ID="message" runat="server" ForeColor="Purple" />
            <p>
                Username:
                <asp:TextBox ID="txtUser" runat="server" />
            </p>
            <p>
                Password:
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
            </p>
            <p>
                CAPTCHA - TEMP: What is 2+2?
                <asp:TextBox ID="captcha" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </p>
        </asp:Panel>

        <asp:Panel ID="pnlWelcome" runat="server" Visible="false">
            <h2>Welcome,
                <asp:Label ID="lblWelcomeUser" runat="server" />!</h2>
            <p>You're logged in as a Member.</p>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />

            <hr />
            <h3>Get Player Average Points</h3>
            <asp:TextBox ID="txtPlayerAvg" runat="server" />
            <asp:Button ID="btnAvg" runat="server" Text="Get Avg PPG" OnClick="btnAvg_Click" />
            <asp:Label ID="lblAvg" runat="server" />

            <h3>Get Total Games Played</h3>
            <asp:TextBox ID="txtPlayerGames" runat="server" />
            <asp:Button ID="btnGames" runat="server" Text="Get Total Games" OnClick="btnGames_Click" />
            <asp:Label ID="lblGames" runat="server" />

            <h3>Get Player Stats Summary</h3>
            <asp:TextBox ID="txtPlayerSummary" runat="server" />
            <asp:Button ID="btnSummary" runat="server" Text="Get Summary" OnClick="btnSummary_Click" />
            <asp:Label ID="lblSummary" runat="server" />



            <hr />
            <h3>Hash a String (CryptoUtils)</h3>
            <asp:TextBox ID="txtInputToHash" runat="server" />
            <asp:Button ID="btnHashInput" runat="server" Text="Hash Input" OnClick="btnHashInput_Click" />
            <asp:Label ID="lblHashResult" runat="server" />

            <hr />
            <p>
                Favorite Team:
                <asp:TextBox ID="txtFavoriteTeam" runat="server" />
                <asp:Button ID="btnSaveTeam" runat="server" Text="Save Favorite" OnClick="btnSaveTeam_Click" />
            </p>

            <p>
                <asp:Label ID="lblFavoriteTeam" runat="server" ForeColor="Green" />
            </p>

        </asp:Panel>

    </form>
</body>
</html>
