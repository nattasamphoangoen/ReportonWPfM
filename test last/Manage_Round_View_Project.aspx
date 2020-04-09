<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage_Round_View_Project.aspx.cs" Inherits="Manage_Round_View_User" %>

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
                        <table align="center" width="910" class="gray">
                            <tr>
                                <td width="170" class="auto-style1"></td>
                                <td width="200" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="200" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="100" class="auto-style1"></td>
                            </tr>
                            <tr class="lead">
                                <td colspan="6" align="center" class="txt_title_rewards">รายงานสรุปข้อมูลรายละเอียดภาระงานของนักวิทยาศาสตร์</td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div>
                    <asp:UpdatePanel ID="UpdatePanelS" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <td colspan="5">
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <strong>รายงานสรุปภาระนักวิทยาศาสตร์: &nbsp;</strong> 
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData" runat="server" Width="990px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
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
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ProjectId" runat="server" Text='<%# Bind("ProjectId") %>'></asp:Label>
                                                    </ItemTemplate>
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
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="ProjectName" ItemStyle-Width="350px"
                                                    SortExpression="ProjectName">
                                                    <ItemStyle Width="350px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หัวหน้าโครงการ" DataField="FullName" ItemStyle-Width="250px"
                                                    SortExpression="FullName">
                                                    <ItemStyle Width="250px" Font-Size="Small" />
                                                </asp:BoundField>                                                
                                                <asp:BoundField HeaderText="% ที่ร่วมโครงการ" DataField="Percentjoin" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="Percentjoin">
                                                    <ItemStyle Width="150px" Font-Size="Small"  HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField HeaderText="% ภาระงาน" DataField="percentWorkload" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="percentWorkload">
                                                    <ItemStyle Width="120px" Font-Size="Small" HorizontalAlign="Center"/>
                                                </asp:BoundField>--%>
                                               <%-- <asp:BoundField HeaderText="คะแนนที่ได้" DataField="TotalPoint" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="TotalPoint">
                                                    <ItemStyle Width="120px" Font-Size="Small" HorizontalAlign="Center"/>
                                                </asp:BoundField>--%>
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

