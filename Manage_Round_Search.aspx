<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage_Round_Search.aspx.cs" Inherits="Manage_Round_Search" %>

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
                    <h2>ภาระงานนักวิทยาศาสตร์</h2>
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
                                <td colspan="6" align="center" class="txt_title_rewards">ค้นหาข้อมูลรอบประเมิน</td>
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
                                                <td valign="top" align="right"><strong>ปีงบประมาณ &nbsp;:</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtYear" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">รอบที่ <strong>&nbsp;:</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtRound" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
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
                        <asp:Button ID="btnSurveyAdd" runat="server" CssClass="btn btn-success" OnClick="btnSurveyAdd_Click"
                            Text="เพิ่มรอบประเมิน" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound"
                            ForeColor="#333333" GridLines="None" DataKeyNames="RoundId" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
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
                                <asp:TemplateField HeaderText="RoundId" SortExpression="RoundId" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_RoundId" runat="server" Text='<%# Bind("RoundId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus" runat="server" Value='<%# Bind("projectStatus") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>                                
                                <asp:BoundField HeaderText="ปีงบประมาณ" DataField="projectYear" ItemStyle-Width="100px"
                                    SortExpression="projectYear">
                                    <ItemStyle Width="100px"  Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="รอบที่" DataField="projectRound" ItemStyle-Width="80px"
                                    SortExpression="projectRound">
                                    <ItemStyle Width="80px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="สถานะ" DataField="projectStatusDetail" ItemStyle-Width="200px"
                                    SortExpression="projectStatusDetail">
                                    <ItemStyle Width="200px" Font-Size="Small" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText=" " ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Button ID="bt_ProjectDetail" runat="server" CssClass="txt_howtonav" OnClick="bt_ProjectDetail_Click"
                                            Text="% Project" Font-Size="Small" Visible="true"/> 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" " ItemStyle-Width="80px">
                                    <ItemTemplate >
                                        <asp:Button ID="bt_UserDetail" runat="server" CssClass="txt_howtonav" OnClick="bt_UserDetail_Click"
                                            Text="% Workload" Font-Size="Small" Visible="true"/> 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" " ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Button ID="bt_EditRound" runat="server" CssClass="txt_howtonav" OnClick="bt_EditRound_Click"
                                            Text="Edit Data" Font-Size="Small" Visible="true"/> 
                                        <asp:Button ID="bt_ViewRound" runat="server" CssClass="txt_howtonav" OnClick="bt_ViewData_Click"
                                            Text="View Data" Font-Size="Small" Visible="false"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" " ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Button ID="bt_ProjectCompleted" runat="server" CssClass="txt_howtonav" OnClick="bt_ProjectCompleted_Click"
                                            Text="% Completed" Font-Size="Small" Visible="true"/> 
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

