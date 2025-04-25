<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="Assignment5_CSE445_Group_62.StaffPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>Staff Dashboard</title></head>
<body>
    <form runat="server">
        <hr />
        <h3>Add New Game</h3>

        <p>Date: <asp:TextBox ID="txtDate" runat="server" /></p>
        <p>League: <asp:TextBox ID="txtLeague" runat="server" /></p>
        <p>Team 1: <asp:TextBox ID="txtTeam1" runat="server" /></p>
        <p>Team 2: <asp:TextBox ID="txtTeam2" runat="server" /></p>
        <p>Score 1: <asp:TextBox ID="txtScore1" runat="server" /></p>
        <p>Score 2: <asp:TextBox ID="txtScore2" runat="server" /></p>

        <!-- Optional player data -->
        <p>Player Name (Team 1): <asp:TextBox ID="txtPlayer1" runat="server" /></p>
        <p>Points: <asp:TextBox ID="txtPts1" runat="server" /></p>
        <p>Rebounds: <asp:TextBox ID="txtReb1" runat="server" /></p>
        <p>Assists: <asp:TextBox ID="txtAst1" runat="server" /></p>

        <p>Player Name (Team 2): <asp:TextBox ID="txtPlayer2" runat="server" /></p>
        <p>Points: <asp:TextBox ID="txtPts2" runat="server" /></p>
        <p>Rebounds: <asp:TextBox ID="txtReb2" runat="server" /></p>
        <p>Assists: <asp:TextBox ID="txtAst2" runat="server" /></p>

        <asp:Button ID="btnAddGame" runat="server" Text="Add Game" OnClick="btnAddGame_Click" />
        <asp:Label ID="lblAddGameStatus" runat="server" ForeColor="Green" />

    </form>
</body>
</html>
