<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Other.aspx.cs" Inherits="Evaluate_Other" Async="true" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style>
                body, html {
                    background: url("./Images/bg-1.png")no-repeat;
                    background-size: cover;
                }
            </style>

            <div class="jumbotron">
                <div class="jumbotron" style="padding: 10px; background-color: #DCDCDC">
                    <h2>แบบรายงานผลการปฏิบัติงาน</h2>
                    <p class="lead">สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</p>
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table align="center" width="768" class="gray">
                            <tr>
                                <td width="170" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="118" class="auto-style1"></td>
                            </tr>
                            <tr class="lead">
                                <td colspan="6" align="center" class="txt_title_rewards">งานอื่น ๆ</td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                        
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </ContentTemplate>  

        </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

