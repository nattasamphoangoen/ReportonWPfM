<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage_Round_Edit.aspx.cs" Inherits="Manage_Round_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
                    <h2>ภาระงานนักวิทยาศาสตร์</h2>
                    <p class="lead">สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</p>
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table align="center" width="960" class="gray">
                            <tr>
                                <td width="180"></td>
                                <td width="200"></td>
                                <td width="180"></td>
                                <td width="200"></td>
                                <td width="10"></td>
                            </tr>
                            <tr class="lead">
                                <td colspan="5" align="center" class="txt_title_rewards"><strong>เพิ่มข้อมูลรอบการประเมิน</td>
                                </strong>
                            </tr>
                            <tr>
                                <td colspan="5" class="auto-style1">&nbsp;
                                    <asp:HiddenField ID="hdf_RoundId" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td align="right" valign="top">
                                    <strong>ปีงบประเมิน : </strong>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lbProjectYear" runat="server" CssClass="gray" Width="160px"> </asp:Label>
                                </td>
                                <td align="right" valign="top">
                                    <strong>รอบประเมิน : </strong>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lbProjectRound" runat="server" CssClass="gray">
                                    </asp:Label>
                                </td>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <strong><span style="color: Red">*</span>สถานะ : </strong>
                                </td>
                                <td valign="top">
                                   <asp:DropDownList ID="ddlProjectStatus" runat="server" CssClass="gray" Enabled ="true">
                                        <asp:ListItem Value="">-- Please Select --</asp:ListItem>
                                        <asp:ListItem Value="A">หัวหน้าโครงการเพิ่มข้อมูล %</asp:ListItem>
                                        <asp:ListItem Value="W">BLS เพิ่ม % Workload</asp:ListItem>
                                        <asp:ListItem Value="C">ปิดรอบประเมิน</asp:ListItem>
                                        <asp:ListItem Value="I">ยกเลิกรอบประเมิน</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqProjectStatus" runat="server" ControlToValidate="ddlProjectStatus" Display="Dynamic" ErrorMessage="*" InitialValue="" ValidationGroup="save">*</asp:RequiredFieldValidator>

                                </td>
                                <td align="right" valign="top">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                   &nbsp;
                                </td>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Label ID="lblError" runat="server" span Style="color: Red" CssClass="red" Font-Bold="True"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit1_Click"
                                        Text="Submit" Width="100px" Visible="true" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-primary-pre"
                                        OnClick="btnCancel_Click" Text="Cancel" Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" runat="Server">
</asp:Content>

