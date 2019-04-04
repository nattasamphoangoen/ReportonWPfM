<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Project_Join_Select.aspx.cs" Inherits="Project_Join_Select" %>

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
                                <td colspan="6" align="center" class="txt_title_rewards">เลือกผู้ร่วมข้อมูลโครงการ</td>
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
                                                <td valign="top" align="right">ชื่อ<strong> :</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">
                                                    <strong>&nbsp;นามสกุล :</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="right">ฝ่าย<strong> :</strong>
                                                <td>
                                                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td valign="top" align="right">ส่วน<strong> :</strong>
                                                <td>
                                                    <asp:TextBox ID="txtSection" runat="server" CssClass="gray" Width="149px"></asp:TextBox>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
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
                                                 <asp:Button ID="btBack" runat="server" CssClass="btn btn-primary-back" OnClick="btBack_Click"
                                                     Text="Back" Width="100px" />
                                                    &nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btReset" runat="server" CssClass="btn btn-primary-pre" OnClick="btReset_Click"
                                                     Text="Cancel" Width="100px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6">
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>&nbsp;
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>--%>
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
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData" runat="server" Width="95%" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" DataKeyNames="Id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
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
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_AccountId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small"></asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Receive" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_AccountId_Id" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ชื่อ" DataField="FirstName" ItemStyle-Width="15%"
                                                    SortExpression="FirstName">
                                                    <ItemStyle Width="15%" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="นามสกุล" DataField="LastName" ItemStyle-Width="15%"
                                                    SortExpression="LastName">
                                                    <ItemStyle Width="15%" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ฝ่าย" DataField="Department" ItemStyle-Width="20%"
                                                    SortExpression="Depaetment">
                                                    <ItemStyle Width="20%" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ส่วน" DataField="Section" ItemStyle-Width="20%"
                                                    SortExpression="Section">
                                                    <ItemStyle Width="20%" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText=" " ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_ProjectJoin" runat="server" CssClass="txt_howtonav" OnClick="bt_ProjectJoin_Click"
                                                            Text="เลือก" Font-Size="Small" />
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


