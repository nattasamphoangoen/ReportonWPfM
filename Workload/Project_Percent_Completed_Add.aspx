<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Project_Percent_Completed_Add.aspx.cs" Inherits="Project_Percent_Completed_Add" %>

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
                                <td colspan="5" align="center" class="txt_title_rewards"><strong>เพิ่มข้อมูล % ความสำเร็จของโครงการ</td>
                                </strong>
                            </tr>

                            <tr>
                                <td colspan="5">&nbsp;
                        
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                </td>
                                <td colspan="4" valign="top">
                                    <asp:Button ID="btnDA" runat="server" Text="" Visible="false" CausesValidation="false" />
                                </td>
                                <tr>
                                    <td colspan="5" valign="top" align="center">
                                        <asp:GridView ID="gvDABrand" runat="server" AutoGenerateColumns="False" BorderColor="White" BorderStyle="None"
                                            DataKeyNames="Id"  OnRowCommand="gvDABrand_RowCommand" Width="900px" ForeColor="#333333">


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
                                                <asp:TemplateField HeaderText="ชื่อโครงการ">
                                                    <ItemTemplate>

                                                        <asp:HiddenField ID="hdf_Id" runat="server" Value="<%# Bind('Id') %>" />
                                                        <asp:Label ID="lbProjectName" runat="server" Text="<%# Bind('ProjectName') %>" Width="400" CssClass="gray"></asp:Label>

                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="หัวหน้าโครงการ">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbHeaderName" runat="server" Text="<%# Bind('Fullname') %>" Width="200px" CssClass="gray"></asp:Label>

                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="% Completed">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPercentCompleted" runat="server" Text="<%# Bind('PercentCompleted') %>" Width="120" CssClass="gray"></asp:TextBox>

                                                        <%--<asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" Enabled="false" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                    <asp:Label ID="lblError" runat="server" span Style="color: Red" CssClass="red" Font-Bold="True"></asp:Label></span>
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

