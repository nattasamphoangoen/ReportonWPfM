<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Project_Join_Add - Copy.aspx.cs" Inherits="Project_Join_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table align="center" width="770" class="gray">
                <tr>
                    <td width="180"></td>
                    <td width="200"></td>
                    <td width="180"></td>
                    <td width="200"></td>
                    <td width="10"></td>
                </tr>
                <tr class="lead">
                    <td colspan="5" align="center" class="txt_title_rewards">เพิ่มข้อมูลผู้ร่วมโครงการ</td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;
                        <asp:HiddenField ID="hdf_ProjectId" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td align="right" valign="top" Width="200px>
                        <strong>ชื่อโครงการ : </strong>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lbProjectName" runat="server" CssClass="gray" Width="160px"> </asp:Label>
                    </td>
                    </td>
                    <td align="right" valign="top">
                        <strong> ปีงบประมาณ :</strong>
                    </td>
                    <td valign="top">
                        <asp:Label ID="lbProjectYear" runat="server" CssClass="gray" Width="160px"> </asp:Label>
                    </td>
                    <td valign="top">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>หัวหน้าโครงการ :</strong>
                    </td>
                    <td colspan="4" valign="top">
                        <asp:Label ID="lbFullName" runat="server" CssClass="red" Font-Bold="True"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="5">&nbsp;
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>เพิ่มข้อมูลผู้ร่วมโครงการ :</strong>
                    </td>
                    <td colspan="4" valign="top">
                        <asp:Button ID="btnDA" runat="server" Text="" Visible="false" CausesValidation="false" />
                    </td>
                <tr>
                    <td></td>
                    <td colspan="3" valign="top" align="center">
                        <asp:GridView ID="gvDABrand" runat="server" AutoGenerateColumns="False" BorderColor="White" BorderStyle="None"
                            DataKeyNames="Id" HeaderStyle-Font-Size="11px" OnRowCommand="gvDABrand_RowCommand" Width="590px" ForeColor="#333333">
                            <Columns>
                                <asp:TemplateField HeaderText="ชื่อ">
                                    <ItemTemplate>
                                        
                                        <asp:HiddenField ID="hdf_Id" runat="server" Value="<%# Bind('Id') %>" />
                                        <asp:Label ID="lbFirstname" runat="server" Text="<%# Bind('FirstName') %>" Width="130" CssClass="gray"></asp:Label>
                                       
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="นามสกุล">
                                    <ItemTemplate>
                                        <asp:Label ID="lbLastname" runat="server" AutoPostBack="true" OnTextChanged="txtLastname_TextChanged" Text="<%# Bind('LastName') %>" Width="130px" CssClass="gray"></asp:Label>
                                     
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="%ร่วมโครงการ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPercentjoin" runat="server" Text="<%# Bind('Percentjoin') %>" Width="130" CssClass="gray"></asp:TextBox>
                                        
                                        <%--<asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" Enabled="false" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete_gvDABrand" runat="server" CausesValidation="false" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Delete_gvDABrand" ImageUrl="Images/bnt_close.png" Width="20" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Font-Size="11px" />
                        </asp:GridView>
                    </td>
                </tr>

               <tr>
                    <td align="right" colspan="4">
                        <asp:Panel ID="Panel2" runat="server" Width="99%" HorizontalAlign="Right" Style="padding-right: 90px;">
                            <asp:Button ID="btnAdd_DABrand" CssClass="btn btn-primary-pre" runat="server" Text="เพิ่มข้อมูล"
                                OnClick="btnAdd_DABrand_Click" ValidationGroup="Mulct" />
                        </asp:Panel>
                    </td>
                    <td width="90"></td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="lblError" runat="server" CssClass="red" Font-Bold="True"></asp:Label>
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

                <div>  
                </div>

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

