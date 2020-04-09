<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Project_Search.aspx.cs" Inherits="Project_Search" %>

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
                                                    <asp:TextBox ID="txtProjectName" runat="server" CssClass="gray" Width="149px" OnTextChanged="txtProjectName_TextChanged"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">ปีงบประมาณ
                                        <strong>&nbsp;:</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtYear" runat="server" CssClass="gray" Width="149px" OnTextChanged="txtYear_TextChanged"></asp:TextBox>
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
                                                 <asp:Button ID="btReset" runat="server" CssClass="btn btn-primary-pre" OnClick="btReset_Click"
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
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>

                            <table align="center" width="100%">
                                <tr>
                                    <td colspan="5">
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <%--<asp:Button ID="btnSurveyAdd" runat="server" CssClass="btn btn-survey-add" OnClick="btnSurveyAdd_Click"
                            Text="เพิ่มรอบประเมิน" Visible="false" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound"
                                            ForeColor="#333333" GridLines="None" DataKeyNames="ProjectId" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
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
                                                <asp:TemplateField HeaderText="ProjectId" SortExpression="ProjectId" Visible="False">
                                                        <itemtemplate>
                                                        <asp:Label ID="lbl_ProjectId" runat="server" Text='<%# Bind("ProjectId") %>'></asp:Label>
                                                    </itemtemplate>
                                                    </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small"></asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Receive" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ProjectId_Id" runat="server" Text='<%# Bind("ProjectId") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdf_ProjectStatus" runat="server" Value='<%# Bind("projectStatus") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="ProjectName" ItemStyle-Width="300px"
                                                    SortExpression="ProjectName">
                                                    <ItemStyle Width="300px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ปีงบ" DataField="ProjectYear" ItemStyle-Width="80px"
                                                    SortExpression="ProjectYear">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="รอบประเมิน" DataField="ProjectRound" ItemStyle-Width="80px"
                                                    SortExpression="ProjectRound">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หัวหน้าโครงการ" DataField="FullName" ItemStyle-Width="200px"
                                                    SortExpression="FullName">
                                                    <ItemStyle Width="200px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% ที่ร่วมโครงการ" DataField="Percentjoin" ItemStyle-Width="150px"
                                                    SortExpression="Percentjoin">
                                                    <ItemStyle Width="150px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText=" " ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_ProjectJoin" runat="server" CssClass="txt_howtonav" OnClick="bt_ProjectJoin_Click"
                                                            Text="เพิ่ม % ที่ร่วมโครงการ" Font-Size="Small" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord" runat="server" Font-Bold="true" CssClass="gray"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblError0" runat="server" Font-Bold="False" CssClass="red"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" runat="Server">
</asp:Content>

