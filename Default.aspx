<%@ Page Title="HoopHub - Player Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5_CSE445_Group_62._Default" %>

<%@ Register TagPrefix="uc" TagName="PlayerStatsPanel" Src="~/UserControls/PlayerStatsPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="LoginControl" Src="~/UserControls/LoginControl.ascx" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>HoopHub - TryIt Page</h1>

    <h1>FOR ASSIGNMENT 6, SCROLL DOWN TO THE MEMBER AND STAFF LOGIN PAGE LINKS TO BE REDIRECTED TO THE PAGE TO SIMULATE THE APPLICATION</h1>

    <hr />
    <h2>Player Apps (Cyler Minkus)</h2>

    <h3>TryIt: Get Player Average Points</h3>
    <asp:TextBox ID="txtPlayerAvg" runat="server" />
    <asp:Button ID="btnAvg" runat="server" Text="Get Avg PPG" OnClick="btnAvg_Click" />
    <asp:Label ID="lblAvg" runat="server" /><br />
    <br />

    <h3>TryIt: Get Total Games Played</h3>
    <asp:TextBox ID="txtPlayerGames" runat="server" />
    <asp:Button ID="btnGames" runat="server" Text="Get Total Games" OnClick="btnGames_Click" />
    <asp:Label ID="lblGames" runat="server" /><br />
    <br />

    <h3>TryIt: Get Player Stats Summary</h3>
    <asp:TextBox ID="txtPlayerSummary" runat="server" />
    <asp:Button ID="btnSummary" runat="server" Text="Get Summary" OnClick="btnSummary_Click" />
    <asp:Label ID="lblSummary" runat="server" />

    <hr />
    <h2>Local Component 1: Session State</h2>
    <p>To simulate a login, log in as one of the following:</p>
    <p>Member Role: Username: jason Password: pass123 </p>
    <p>Admin Role: Username: admin Password: admin123 </p>
    <uc:LoginControl runat="server" ID="LoginControl1" />
    <hr />
    <h2>Local Component 2: User Control</h2>
    <p>The control below displays player stats using <code>PlayerService</code> WebMethods:</p>
    <uc:PlayerStatsPanel ID="PlayerStatsPanel1" runat="server" />



    <hr />
    <h2>League Apps (Lewin Elep)</h2>

    <h3>TryIt: Get Top Scorer</h3>
    <asp:Button ID="btnTopScorer" runat="server" Text="Get Top Scorer" OnClick="btnTopScorer_Click" />
    <asp:Label ID="lblTopScorer" runat="server" /><br />
    <br />

    <h3>TryIt: Get League Standings</h3>
    <asp:Button ID="btnStandings" runat="server" Text="Get Standings" OnClick="btnStandings_Click" />
    <asp:Label ID="lblStandings" runat="server" /><br />
    <br />

    <h3>TryIt: Get Recent Games</h3>
    <asp:Button ID="btnRecentGames" runat="server" Text="Get Recent Games" OnClick="btnRecentGames_Click" />
    <asp:Label ID="lblRecentGames" runat="server" /><br />
    <br />



    <hr />
    <h2>Local Component 1: DLL Hashing (CryptoUtils)</h2>
    <p>Hashes any input using SHA-256.</p>

    <asp:TextBox ID="txtInputToHash" runat="server" />
    <asp:Button ID="btnHashInput" runat="server" Text="Hash Input" OnClick="btnHashInput_Click" />
    <asp:Label ID="lblHashResult" runat="server" /><br />
    <br />

    <hr />
    <h2>Local Component 2: Global.asax — Last Visit Tracker</h2>
    <p>Displays when the most recent visitor started their session:</p>

    <asp:Label ID="lblLastVisit" runat="server" />

    <hr />
    <h2>Team Apps (Christian Schroder)</h2>
    <asp:Label runat="server" Text="Enter Team Name:" />
    <asp:TextBox ID="txtTeam" runat="server" />
    <h3>TryIt: Get Team Record</h3>
    <asp:Button ID="btnRecord" runat="server" Text="Get Team Record" OnClick="btnRecord_Click" />
    <asp:Label ID="lblRecord" runat="server" ForeColor="Blue" Font-Bold="true" />
    <h3>TryIt: Get Team Average Points</h3>
    <asp:Button ID="Button1" runat="server" Text="Get Average Points" OnClick="btnTeamAvg_Click" />
    <asp:Label ID="Label1" runat="server" ForeColor="Green" Font-Bold="true" />
    <h3>TryIt: Get Next 5 Games or Remaining Schedule</h3>
    <asp:Button ID="btnNext" runat="server" Text="Get Next Games" OnClick="btnNext_Click" />
    <asp:Label ID="lblNext" runat="server" />
    <hr />

    <h2>Local Component 1: Favorite Team Cookie</h2>
    <p>Enter Your Favorite Team: </p>
    <asp:TextBox ID="txtFavTeam" runat="server" />
    <asp:Button ID="btnSaveFavTeam" runat="server" Text="Save Favorite" OnClick="btnSaveFavTeam_Click" />
    <asp:Label ID="lblFavTeam" runat="server" ForeColor="Red" />
    <hr />

    <h2>Local Component 2: DLL Win Percentage Calculator</h2>
    <p>Wins:</p>
    <asp:TextBox ID="txtWins" runat="server" />
    <p>Losses:</p>
    <asp:TextBox ID="txtLosses" runat="server" />
    <asp:Button ID="btnCalcWinPct" runat="server" Text="Calculate Win %" OnClick="btnCalcWinPct_Click" />
    <asp:Label ID="lblWinPct" runat="server" ForeColor="Wheat" />




    <h2>Staff Portal</h2>
    <a href="Staff.aspx">Staff Portal</a>

    <h2>Member Portal</h2>
    <a href="Member.aspx">Member Portal</a>
    




    <h2>Service Directory Table/Application and Components Summary Table</h2>
    <p>All group members participated equally in this project (33% contribution from each)</p>
    <p><strong>Deployed URL (Cyler's Webstrar Uploaded Web Services):</strong> <a href="http://webstrar62.fulton.asu.edu/page0/PlayerService.asmx" target="_blank">http://webstrar62.fulton.asu.edu/page0/PlayerService.asmx</a></p>
    <table border="1" style="border-collapse: collapse; text-align: left;">
        <tr>
            <th>Provider</th>
            <th>Type</th>
            <th>Name</th>
            <th>Parameters</th>
            <th>Return</th>
            <th>Description</th>
        </tr>

        <tr>
            <td>Lewin Elep</td>
            <td>Web Service</td>
            <td>GetTopScorer()</td>
            <td>None</td>
            <td>string</td>
            <td>Returns the player with the most total points</td>
        </tr>

        <tr>
            <td>Lewin Elep</td>
            <td>Web Service</td>
            <td>GetLeagueStandings()</td>
            <td>None</td>
            <td>string</td>
            <td>Lists teams and their total number of wins</td>
        </tr>

        <tr>
            <td>Lewin Elep</td>
            <td>Web Service</td>
            <td>GetRecentGames()</td>
            <td>None</td>
            <td>string</td>
            <td>Returns the 3 most recent games and scores</td>
        </tr>

        <tr>
            <td>Lewin Elep</td>
            <td>Local Component</td>
            <td>Global.asax — Last Visit Tracker</td>
            <td>Session_Start</td>
            <td>string</td>
            <td>Tracks and displays when the most recent visitor arrived</td>
        </tr>

        <tr>
            <td>Lewin Elep</td>
            <td>Local Component</td>
            <td>CryptoUtils.HashString()</td>
            <td>string input</td>
            <td>string</td>
            <td>Returns SHA-256 hash of the input using DLL logic</td>
        </tr>
        <tr>
            <td>Chris Schroeder</td>
            <td>Web Service</td>
            <td>GetTeamRecord()</td>
            <td>string team</td>
            <td>string</td>
            <td>Returns the Wins and Losses for a team in a string</td>
        </tr>
        <tr>
            <td>Chris Schroeder</td>
            <td>Web Service</td>
            <td>GetTeamAverage Points()</td>
            <td>string team</td>
            <td>double</td>
            <td>Returns the average points of all games played by a team</td>
        </tr>
        <tr>
            <td>Chris Schroeder</td>
            <td>Web Service</td>
            <td>GetNextGames()</td>
            <td>string team</td>
            <td>string</td>
            <td>Returns the next 5 games or remaining schedule</td>
        </tr>
        <tr>
            <td>Chris Schroeder</td>
            <td>Local Component</td>
            <td>FavoriteTeam()</td>
            <td>string team</td>
            <td>string</td>
            <td>Returns Cookie of Favorite Team for future sessions</td>
        </tr>
        <tr>
            <td>Chris Schroeder</td>
            <td>Local Component</td>
            <td>WinPercentCalc()</td>
            <td>int wins, int losses</td>
            <td>double percent</td>
            <td>Returns the team record percentage using DLL logic</td>
        </tr>
        <tr>
            <td>Cyler Minkus</td>
            <td>Web Service</td>
            <td>GetPlayerAveragePoints()</td>
            <td>string playerName</td>
            <td>double</td>
            <td>Returns the average of a specified player</td>
        </tr>
        <tr>
            <td>Cyler Minkus</td>
            <td>Web Service</td>
            <td>GetTotalGamesPlayed()</td>
            <td>string playerName</td>
            <td>int</td>
            <td>Returns the number of games played by a specified player</td>
        </tr>
        <tr>
            <td>Cyler Minkus</td>
            <td>Web Service</td>
            <td>GetPlayerStatsSummary()</td>
            <td>string playerName</td>
            <td>string</td>
            <td>Returns the stats (points, assists, rebounds) of a specified player</td>
        </tr>
        <tr>
            <td>Cyler Minkus</td>
            <td>Local Component</td>
            <td>Login Simulation (LoginControl.ascx)()</td>
            <td>None</td>
            <td>None</td>
            <td>Simulates the login of a member or an admin/staff and displays who is currently logged in</td>
        </tr>
        <tr>
            <td>Cyler Minkus</td>
            <td>Local Component</td>
            <td>Player Stats Panel (PlayerStatsPanel.ascx)</td>
            <td>None</td>
            <td>None</td>
            <td>On the click of a button, shows the stats of the specified player by calling GetPlayerStatsSummary</td>
        </tr>
    </table>


</asp:Content>
