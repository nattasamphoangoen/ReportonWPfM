<%@ Page Title="Log in" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Account_Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <br>
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <br>
                        <asp:Label runat="server" CssClass="col-md-2 control-label">E-mail :</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtMemberID"></asp:TextBox>
                            <br>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMemberID"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                        
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Password :</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"/>
                            <br>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="ButtonLogin_Click" Text="Log in" CssClass="btn btn-default" />
                            <br>
                            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:openauthproviders runat="server" id="OpenAuthLogin" />
            </section>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

