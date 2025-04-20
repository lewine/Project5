<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayerStatsPanel.ascx.cs" Inherits="Assignment5_CSE445_Group_62.UserControls.PlayerStatsPanel" %>
<h4>Player Stats Panel</h4>
<asp:TextBox ID="txtPlayer" runat="server" placeholder="Enter player name" />
<asp:Button ID="btnGetStats" runat="server" Text="Get Stats" OnClick="btnGetStats_Click" />
<asp:Label ID="lblStats" runat="server" ForeColor="Green" />