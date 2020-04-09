<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage_Round_Add.aspx.cs" Inherits="Manage_Round_Add" %>

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

                <%--<p class="parts">ค้นหาข้อมูล </p>
                <div>
                    <p class="questions">ปีงบประมาณ :
                        <asp:TextBox runat="server" ID="txtYear" CssClass="form-control" /></p>

                    <asp:Button runat="server" OnClick="btSearch" Text="Search" CssClass="btn btn-primary btn-lg" />
                    <asp:Button runat="server" OnClick="btCancel" Text="Cancel" CssClass="btn btn-primary btn-lg" />

                </div>--%>

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
                                <td colspan="5">&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td align="right" valign="top">
                                    <strong><span style="color: Red">*</span>ปีงบประเมิน : </strong>
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtprojectYear" runat="server" CssClass="gray" Width="160px"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqprojectYear" runat="server" ControlToValidate="txtprojectYear"
                                        Display="Dynamic" ErrorMessage="*" Text="Numeric Only!" SetFocusOnError="True" ValidationExpression="[0-9]{4,4}">*</asp:RequiredFieldValidator>
                                </td>
                                <td align="right" valign="top">
                                    <strong><span style="color: Red">*</span>รอบประเมิน : </strong>
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlProjectRound" runat="server" CssClass="gray">
                                        <asp:ListItem Value="">-- Please Select --</asp:ListItem>
                                        <asp:ListItem Value="1">รอบที่ 1</asp:ListItem>
                                        <asp:ListItem Value="2">รอบที่ 2</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqProjectRound" runat="server" ControlToValidate="ddlProjectRound" Display="Dynamic" ErrorMessage="*" InitialValue="" ValidationGroup="save">*</asp:RequiredFieldValidator>

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
                                        Text="Submit" Width="100px" />
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

