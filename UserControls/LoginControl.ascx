<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="Assignment5_CSE445_Group_62.LoginControl" %>

<h3>Simulated Login</h3>
<asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" /><br />
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" /><br />
<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br /><br />

<asp:Label ID="lblResult" runat="server" ForeColor="Red" />
<asp:Label ID="lblSessionStatus" runat="server" ForeColor="Green" />
