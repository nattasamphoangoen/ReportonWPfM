<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="User_Join_Add.aspx.cs" Inherits="User_Join_Add" %>

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
                        <table align="center" width="100%" class="gray">
                            <tr>
                                <td width="180"></td>
                                <td width="200"></td>
                                <td width="180"></td>
                                <td width="200"></td>
                                <td width="10"></td>
                            </tr>
                            <tr class="lead">
                                <td colspan="5" align="center" class="txt_title_rewards"><strong>เพิ่มข้อมูล % สัดส่วนที่ร่วมในแต่ละโครงการ</td>
                                </strong>
                            </tr>
                            <tr>
                                <td colspan="5">&nbsp;
                        <asp:HiddenField ID="hdf_AccountId" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td align="right" valign="top">
                                    <strong>ชื่อ : </strong>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lbName" runat="server" CssClass="gray" Width="200px"> </asp:Label>
                                </td>
                                </td>
                   <td align="right" valign="top">
                       <strong>ตำแหน่ง : </strong>
                   </td>
                                <td valign="top">
                                    <asp:Label ID="lbposition" runat="server" CssClass="gray" Width="230px"> </asp:Label>
                                </td>
                                </td>
                    <td valign="top">&nbsp;
                    </td>
                            </tr>

                            <tr>
                                <td align="right" valign="top">
                                    <strong>ฝ่าย : </strong>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lbdepartment" runat="server" CssClass="gray" Width="190px"> </asp:Label>
                                </td>
                                </td>
                    <td align="right" valign="top">
                        <strong>BL :</strong>
                    </td>
                                <td valign="top">
                                    <asp:Label ID="lbsection" runat="server" CssClass="gray" Width="230px"> </asp:Label>
                                </td>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td colspan="5">&nbsp;
                        
                                </td>
                            </tr>
                            <tr>
                                <td align="Center" valign="top" colspan="5">
                                    <strong></strong>
                                    <asp:Button ID="btnDA" runat="server" Text="" Visible="false" CausesValidation="false" />
                                </td>
                            </tr>

                            <tr class="lead">
                                <td align="Center" valign="top" colspan="5">
                                    <span style="color: Red"><strong>% สัดส่วนที่ร่วมในแต่ละโครงการ ต้องผ่านการเห็นชอบจากผู้บังคับบัญชา</strong></span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" valign="top" align="center">
                                    <asp:GridView ID="gvDABrand" runat="server" Width="100%" AutoGenerateColumns="False" BorderColor="White" BorderStyle="None"
                                        DataKeyNames="Id" HeaderStyle-Font-Size="14px" OnRowCommand="gvDABrand_RowCommand" ForeColor="#333333">
                                        <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="Last&amp;gt;&amp;gt;"
                                            NextPageText="Next&amp;gt;" PreviousPageText="&amp;lt;Previous" />
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray" HorizontalAlign="Left" />
                                        <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy" HorizontalAlign="Left" />
                                        <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True" CssClass="txt_howtonav"
                                            HorizontalAlign="Left" ForeColor="#005aa9" />
                                        <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ชื่อโครงการ" ItemStyle-Width="50%">
                                                <ItemTemplate>

                                                    <asp:HiddenField ID="hdf_Id" runat="server" Value="<%# Bind('Id') %>" />
                                                    <asp:Label ID="lbProjectName" runat="server" Text="<%# Bind('ProjectName') %>" CssClass="gray"></asp:Label>

                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="หัวหน้าโครงการ" ItemStyle-Width="30%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbHeaderName" runat="server" Text="<%# Bind('HeaderName') %>" CssClass="gray"></asp:Label>

                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="% สัดส่วนภาระงานแต่ละโครงการ" ItemStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPercentWorkload" runat="server" Text="<%# Bind('PercentWorkload') %>" CssClass="gray"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="vldPasswordCheck" runat="server" ControlToValidate="txtPercentWorkload"
                                                        Display="Dynamic" ErrorMessage="RangeValidator" SetFocusOnError="True" Text="Input 0-9 OR ."
                                                        ValidationExpression="[0-9.,]{0,12}">
                                                    </asp:RegularExpressionValidator>

                                                    <%--<asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" Enabled="false" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Size="12px" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td align="right" colspan="4">
                                    <asp:Panel ID="Panel2" runat="server" Width="99%" HorizontalAlign="Right" Style="padding-right: 90px;">
                                    </asp:Panel>
                                </td>
                                <td width="90"></td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <span>
                                        <asp:Label ID="lblError" runat="server" Style="color: Red" CssClass="red" Font-Bold="True"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">&nbsp;
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

