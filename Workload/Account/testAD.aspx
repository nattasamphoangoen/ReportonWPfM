<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="testAD.aspx.cs" Inherits="Account_testAD" %>
<%@ Assembly Name="System.DirectoryServices, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"%>
<%@ Import Namespace="System.DirectoryServices"%>
<%@ Import Namespace="System.Security.Cryptography"%>
<%@ Import Namespace="System.Text"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtPassw" runat="server"></asp:TextBox>
    <asp:Button ID="btClick" runat="server" Text="Button" OnClick="bt_Click" />
    <asp:Label ID="lbEror" runat="server" Text="Label"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

