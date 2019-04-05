<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCD.master" AutoEventWireup="true"
    CodeFile="Builder_Search.aspx.cs" Inherits="Builder_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modalBackground
        {
            background-color: #999999;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        
        .modalPopup
        {
            background-color: #ffffff;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
        }
        .style3
        {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" width="770" class="gray">
        <tr>
            <td width="170">
            </td>
            <td width="120">
            </td>
            <td width="120">
            </td>
            <td width="120">
            </td>
            <td width="120">
            </td>
            <td width="120">
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center" class="txt_title_rewards">
                ค้นหาข้อมูลพื้นที่
            </td>
        </tr>
        <tr>
            <td colspan="6">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="PanelSearch" runat="server">
                    <table align="center" width="760" class="gray">
                        <tr>
                            <td align="right" valign="top">
                                <strong>พื้นที่:</strong>
                            </td>
                            <td colspan="3" valign="top">
                                <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlArea" DataTextField="AREA_NAME" DataValueField="AREA_ID"
                                            Width="180" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlArea" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                                    SelectCommand="SELECT AREA_ID, AREA_NAME FROM MASTER_AREA WHERE AREA_STATUS ='Y'  ORDER BY AREA_ID">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="110">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <strong>อาคาร/ตึก:</strong>
                            </td>
                            <td colspan="3" valign="top">
                                <asp:TextBox ID="txtBuilder" runat="server" CssClass="gray" Width="200px"></asp:TextBox>
                            </td>
                            <td colspan="2" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="110">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style3" valign="top">
                                <strong>Status :</strong>
                            </td>
                            <td colspan="5" valign="top">
                                <asp:RadioButtonList ID="radStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="">All</asp:ListItem>
                                    <asp:ListItem Value="Y">Active</asp:ListItem>
                                    <asp:ListItem Value="N">Inactive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td width="170">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="120">
                            </td>
                            <td width="110">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6" valign="top">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="txt_howtonav" OnClick="btnSubmit_Click"
                                    Text="Search" Width="100px" />
                                <asp:Button ID="btnReset" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                    OnClick="btnReset_Click" Text="Cancel" Width="100px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblPopupAddBuilder" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddBuilder" runat="server" TargetControlID="lblPopupAddBuilder"
        PopupControlID="panelAddBuilder" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddBuilder" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong>เพิ่มข้อมูลอาคาร/ตึก</strong></div>
                        <table align="center" width="100%" class="gray">
                            <tr>
                                <td align="right" valign="top">
                                    <span style="color: Red">*</span><strong>พื้นที่ :</strong>
                                </td>
                                <td colspan="3" valign="top">
                                    <asp:HiddenField ID="hdfBuilderID" runat="server" />
                                     <asp:DropDownList ID="ddlAreaAdd" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlAreaAdd" DataTextField="AREA_NAME" DataValueField="AREA_ID"
                                            Width="180" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlAreaAdd" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                                    SelectCommand="SELECT AREA_ID, AREA_NAME FROM MASTER_AREA WHERE AREA_STATUS ='Y'  ORDER BY AREA_ID">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqAreaAdd" runat="server" ControlToValidate="ddlAreaAdd"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddBuilder"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong>อาคาร/ตึก :</strong>
                                </td>
                                <td valign="top" width="150" colspan="3">
                                    <asp:TextBox ID="txtBuilderAdd" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqBuilderAdd" runat="server" ErrorMessage="*" ControlToValidate="txtBuilderAdd"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddBuilder"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <span style="color: Red">*</span><strong>สถานะ :</strong>
                                </td>
                                <td colspan="3" valign="top">
                                    <asp:RadioButtonList ID="radBuilderStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Y" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="N">Inactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddBuilder" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddBuilder_Click" />
                                    <cc1:ConfirmButtonExtender ID="btnAddBuilder_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddBuilder">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelBuilder_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center" width="900">
                <tr>
                    <td width="160">
                        <%--<asp:Button ID="btnAddNewCompany" runat="server" CssClass="txt_howtonav" Text="Add New Blacklist" Visible="false" />--%>
                        <asp:Button ID="btnAddNewBuilder" runat="server" CssClass="txt_howtonav" OnClick="btnAddNewBuilder_Click"
                            Text="Add New Builder" Visible="false" />
                    </td>
                    <td width="350">
                    </td>
                    <td width="150">
                    </td>
                    <td width="100">
                    </td>
                    <td width="140">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="left">
                        <asp:GridView ID="gvData" runat="server" Width="800px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" DataKeyNames="BUILDER_ID" PageSize="20">
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
                                <asp:TemplateField HeaderText="No" ItemStyle-Width="40px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Builder Name" ItemStyle-Width="240px" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditNewBuilder" runat="server" Text='<%# Eval("BUILDER_NAME")%>'
                                            OnClick="btnEditNewBuilder_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="240px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AreaName">
                                <ItemTemplate>
                                        <asp:Label ID="lbl_AREA_NAME" runat="server" Text='<%# Bind("AREA_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_BUILDER_STATUS" runat="server" Text='<%# Bind("BUILDER_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="180px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BUILDER_ID" SortExpression="AREA_ID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_BUILDER_ID" runat="server" Text='<%# Bind("BUILDER_ID") %>'></asp:Label>
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
</asp:Content>
