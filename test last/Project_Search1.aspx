<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Project_Search.aspx.cs" Inherits="Project_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <style>
                body, html {
                    background: url("/Images/bg-1.png")no-repeat;
                    background-size: cover;
                }
            </style>




            <div class="jumbotron">
                <div class="jumbotron" style="padding: 10px; background-color: #DCDCDC">
                    <h2>ภาระงานนักวิทยาศาสตร์</h2>
                    <p class="lead">สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</p>
                </div>

                <%--<p class="parts">ค้นหาข้อมูล </p>
                <div>
                    <p class="questions">ปีงบประมาณ :
                        <asp:TextBox runat="server" ID="txtYear" CssClass="form-control" /></p>

                    <asp:Button runat="server" OnClick="btSearch" Text="Search" CssClass="btn btn-primary btn-lg" />
                    <asp:Button runat="server" OnClick="btCancel" Text="Cancel" CssClass="btn btn-primary btn-lg" />

                </div>--%>

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
                                <td colspan="6" align="center" class="txt_title_rewards">ค้นหาข้อมูลโครงการ</td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Panel ID="PanelSearch" runat="server">
                                        <table align="center" width="768" class="gray">
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="right">ชื่อโครงการ<strong> :</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtRound" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">ปีงบประมาณ
                                        <strong>&nbsp;:</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtYear" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" valign="top">
                                                    <asp:Button ID="btSearch" runat="server" CssClass="btn btn-primary" OnClick="btSearch_Click"
                                                        Text="Search" Width="100px" />
                                                    &nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btReset" runat="server" CssClass="btn btn-primary" OnClick="btReset_Click"
                                                        Text="Cancel" Width="100px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div>
                
                
            <div class="form-group">
                <div class="col-md-offset-1">
                    <asp:Button runat="server" OnClick="Next_Click" Text="Submit" CssClass="btn btn-primary btn-lg" />
                </div>
            </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

