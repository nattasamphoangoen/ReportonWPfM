<%--<%@ Page Title="Log in" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<%@ Assembly Name = "System.DirectoryServices, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %>
<%@ Import Namespace = "System.DirectoryServices" %>
<%@ Import Namespace = "System.Security.Cryptography" %>
<%@ Import Namespace = "System.Text" %>

<html>
<head>
<title>SLRI</title>
</head>
 <body>
	<form id="form1" runat="server">
		<asp:TextBox ID="txtUser" runat="server" Width="147px"></asp:TextBox>
		<asp:TextBox ID="txtPwd" runat="server" Width="147px" TextMode="Password"></asp:TextBox>
		<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
		<br />
		<asp:Label ID="lbDisplay" runat="server"></asp:Label>
	</form>
</body>
</HTML>--%>

<%@ Page Title="Log in" Language="C#"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" Async="true" %>
<%@ Assembly Name="System.DirectoryServices, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"%>
<%@ Import Namespace="System.DirectoryServices"%>
<%@ Import Namespace="System.Security.Cryptography"%>
<%@ Import Namespace="System.Text"%>

<HTML>
<head>
<title>SLRI</title>
</head>
 <body>
	<form id="form1" runat="server">
		<asp:TextBox ID="txtUser" runat="server" Width="147px"></asp:TextBox>
		<asp:TextBox ID="txtPwd" runat="server" Width="147px" TextMode="Password"></asp:TextBox>
		<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
		<br />
		<asp:Label ID="lbDisplay" runat="server"></asp:Label>
	</form>
</body>
</HTML>
