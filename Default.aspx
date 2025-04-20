<%@ Page Title="HoopHub - Player Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5_CSE445_Group_62._Default" %>
<%@ Register TagPrefix="uc" TagName="PlayerStatsPanel" Src="~/UserControls/PlayerStatsPanel.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>HoopHub - Player Service TryIt Page</h1>

    <hr />
    <h2>Web Methods Testing</h2>

    <h3>TryIt: Get Player Average Points</h3>
    <asp:TextBox ID="txtPlayerAvg" runat="server" />
    <asp:Button ID="btnAvg" runat="server" Text="Get Avg PPG" OnClick="btnAvg_Click" />
    <asp:Label ID="lblAvg" runat="server" /><br /><br />

    <h3>TryIt: Get Total Games Played</h3>
    <asp:TextBox ID="txtPlayerGames" runat="server" />
    <asp:Button ID="btnGames" runat="server" Text="Get Total Games" OnClick="btnGames_Click" />
    <asp:Label ID="lblGames" runat="server" /><br /><br />

    <h3>TryIt: Get Player Stats Summary</h3>
    <asp:TextBox ID="txtPlayerSummary" runat="server" />
    <asp:Button ID="btnSummary" runat="server" Text="Get Summary" OnClick="btnSummary_Click" />
    <asp:Label ID="lblSummary" runat="server" /> 

    <hr />
    <h2>Local Component 1: Session State</h2>
    <p>This demonstrates simulated login using session variables:</p>
    <asp:Label ID="lblSession" runat="server" ForeColor="Blue" />

    <hr />
    <h2>Local Component 2: User Control</h2>
    <p>The control below displays player stats using <code>PlayerService</code> WebMethods:</p>
    <uc:PlayerStatsPanel ID="PlayerStatsPanel1" runat="server" />



    <hr />
    <h2>League Apps</h2>

    <h3>TryIt: Get Top Scorer</h3>
    <asp:Button ID="btnTopScorer" runat="server" Text="Get Top Scorer" OnClick="btnTopScorer_Click" />
    <asp:Label ID="lblTopScorer" runat="server" /><br /><br />

    <h3>TryIt: Get League Standings</h3>
    <asp:Button ID="btnStandings" runat="server" Text="Get Standings" OnClick="btnStandings_Click" />
    <asp:Label ID="lblStandings" runat="server" /><br /><br />

    <h3>TryIt: Get Recent Games</h3>
    <asp:Button ID="btnRecentGames" runat="server" Text="Get Recent Games" OnClick="btnRecentGames_Click" />
    <asp:Label ID="lblRecentGames" runat="server" /><br /><br />



    <hr />
    <h2>Local Component 1: DLL Hashing (CryptoUtils)</h2>
    <p>Hashes any input using SHA-256.</p>

    <asp:TextBox ID="txtInputToHash" runat="server" />
    <asp:Button ID="btnHashInput" runat="server" Text="Hash Input" OnClick="btnHashInput_Click" />
    <asp:Label ID="lblHashResult" runat="server" /><br /><br />

    <hr />
    <h2>Local Component 2: Global.asax — Last Visit Tracker</h2>
    <p>Displays when the most recent visitor started their session:</p>

    <asp:Label ID="lblLastVisit" runat="server" />


    <hr />
    <h2>Service Directory Table</h2>
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



</asp:Content>
