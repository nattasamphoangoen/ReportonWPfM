<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpenAuthProviders.ascx.cs" Inherits="OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>ระบบภาระงานนักวิทยาศาสตร์ (BLS/BLM)</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>ระบบภาระงานนักวิทยาศาสตร์ (BLS/BLM) <br>ฝ่ายสถานีวิจัย <br> สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน) </p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>