<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Report_User_Summary.aspx.cs" Inherits="Report_User_Summary" %>

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
                                <td colspan="6" align="center" class="txt_title_rewards">ค้นหาข้อมูลโครงการ</td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Panel ID="PanelSearch" runat="server">
                                        <table align="center" width="900" class="gray">
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
                                                    <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" class="txt_title_rewards"
                                                        DataSourceID="sqlYear" DataTextField="projectYear" DataValueField="projectYear"
                                                        Width="200px" >
                                                        <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="sqlYear" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                        SelectCommand="SELECT DISTINCT projectYear  FROM ProjectControl ORDER BY projectYear DESC"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="reqMonth" runat="server" ControlToValidate="ddlYear"
                                                        Display="Dynamic" ErrorMessage="*" InitialValue="0" SetFocusOnError="True"><span style="color: Red">*</span></asp:RequiredFieldValidator>
                                                </td>
                                                <td valign="top" align="right">รอบที่ <strong>&nbsp;:</strong>
                                                </td>
                                                <td valign="top">
                                                    <asp:DropDownList  ID="ddlRound" runat="server" AppendDataBoundItems="True" class="txt_title_rewards"
                                                        DataSourceID="sqlRound" DataTextField="projectRound" DataValueField="projectRound"
                                                        Width="200px">
                                                        <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="sqlRound" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                        SelectCommand="SELECT DISTINCT projectRound  FROM ProjectControl ORDER BY projectRound"></asp:SqlDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRound"
                                                        Display="Dynamic" ErrorMessage="*" InitialValue="0" SetFocusOnError="True"><span style="color: Red">*</span></asp:RequiredFieldValidator>
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
                    <asp:UpdatePanel ID="UpdatePanelS" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <td colspan="5">
                                        <asp:Button ID="btnReportDeteil" runat="server" CssClass="btn btn-success" OnClick="btnReportDeteil_Click"
                            Text="ดูรายละเอียดภาระงาน" />
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <strong>รายงานสรุปภาระนักวิทยาศาสตร์ประจำปีงบประมาณ : &nbsp;</strong> 
                                        <asp:Label ID="lbProjectYear" runat="server" CssClass="gray"> </asp:Label>
                                        <strong>&nbsp;&nbsp;รอบที่ : &nbsp;</strong>
                                        <asp:Label ID="lbProjectRound" runat="server" CssClass="gray"> </asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData" runat="server" Width="990px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" DataKeyNames="AccountId" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
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
                                                <asp:TemplateField HeaderText="AccountId" SortExpression="AccountId" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_AccountId" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label>
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
                                                        <asp:Label ID="lbl_AccountId_Id" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ชื่อ - นามสกุล" DataField="FullName" ItemStyle-Width="230px"
                                                    SortExpression="FullName">
                                                    <ItemStyle Width="230px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ฝ่าย" DataField="Department" ItemStyle-Width="200px"
                                                    SortExpression="Department">
                                                    <ItemStyle Width="200px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ส่วน/BL" DataField="Section" ItemStyle-Width="200px"
                                                    SortExpression="Section">
                                                    <ItemStyle Width="200px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ตำแหน่ง" DataField="Position" ItemStyle-Width="200px"
                                                    SortExpression="Position">
                                                    <ItemStyle Width="200px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% ที่ร่วมโครงการ" DataField="Percentjoin" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="Percentjoin">
                                                    <ItemStyle Width="150px" Font-Size="Small"  HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% ภาระงาน" DataField="percentWorkload" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="percentWorkload">
                                                    <ItemStyle Width="120px" Font-Size="Small" HorizontalAlign="Center"/>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="คะแนนที่ได้" DataField="TotalPoint" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right"
                                                    SortExpression="TotalPoint">
                                                    <ItemStyle Width="120px" Font-Size="Small" HorizontalAlign="Center"/>
                                                </asp:BoundField>
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

