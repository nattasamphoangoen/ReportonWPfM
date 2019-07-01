<%@ Page Title="Evaluate_Develop_Mainten" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Develop_Mainten.aspx.cs" Inherits="Evaluate_Develop_Mainten" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: #ffffff;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .modalPopup {
            background-color: #ffffff;
            border-width: 3px;
            border-style: solid;
            border-color: #8cedff;
        }

        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>



            <style>
                body,
                html {
                    background: url("./Images/bg-1.png")no-repeat;
                    background-size: cover;
                }
            </style>

            <div class="jumbotron">
                <div class="jumbotron" style="padding: 10px; background-color: #DCDCDC">
                    <h2>แบบรายงานผลการปฏิบัติงาน</h2>
                    <p class="lead">สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</p>

                    <div colspan="2" align="right">
                        <tr>
                            <td>
                                <asp:LinkButton ID="reportSummary" runat="server" Text='' title="Summary"
                                    OnClick="reportSummary_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/file.png"
                                        width="20" />

                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report1" runat="server" Text='' title="งานให้บริการ"
                                    OnClick="report1_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n1.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report2" runat="server" Text='' title="งานพัฒนาและบำรุงรักษา"
                                    OnClick="report2_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/two.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report3" runat="server" Text='' title="งานวิจัย"
                                    OnClick="report3_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n3.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report4" runat="server" Text='' title="งานส่งเสริมการใช้แสง"
                                    OnClick="report4_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n4.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report5" runat="server" Text='' title="งานบริการวิชาการ"
                                    OnClick="report5_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n5.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report6" runat="server" Text='' title="งานบริหารจัดการ"
                                    OnClick="report6_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n6.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report7" runat="server" Text='' title="งานอื่น ๆ"
                                    OnClick="report7_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n7.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>
                        </tr>

                    </div>
                </div>



                <div>
                    <tr class="lead">
                        <p colspan="5" align="center" class="txt_title_rewards">2. งานพัฒนาและบำรุงรักษาระบบลำเลียงแสง
                            หรือสถานีทดลอง หรือห้องปฏิบัติการต่าง ๆ (Development and Maintenance)</p>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">1. Journal publication (ISI/Scopus)</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging" AllowSorting="True"
                                            OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="gvData_RowDataBound" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="Q" DataField="projectQ"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_Path" runat="server"
                                                            Value='<%# Bind("path") %>'></asp:HiddenField>
                                                        <asp:LinkButton ID="lnkDownload" runat="server"  Visible="False"
                                                            CausesValidation="False" OnClick="btnDownload_Click">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click">
                                                            <img id="editDevelMaint" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click">
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_1_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lblError0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_1" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_1" PopupControlID="panelAddDevelMaint2_1" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Journal publication (ISI/Scopus)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectTopic" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectTopicAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ประเภท
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectType" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlTypeAdd" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlTypeAdd" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-1-Type' AND ddlStatus = 'A' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqTypeAdd" runat="server"
                                                    ControlToValidate="txtProjectType" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_1"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Q
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectQ" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray" DataSourceID="sqlQAdd"
                                                    DataTextField="ddlDisplay" DataValueField="ddlDisplay" Width="180"
                                                    AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlQAdd" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-1-Q' AND ddlStatus = 'A' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqQAdd" runat="server"
                                                    ControlToValidate="txtProjectQ" Display="Dynamic" ErrorMessage="*"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_1">
                                                </asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:FileUpload ID="FileUpload2_1" runat="server" EnableTheming="True"
                                                    style="color: #0d0044" />
                                                <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server"
                                                    ErrorMessage="*โปรดเลือกไฟล์" style="color: #ff0000"
                                                    ControlToValidate="FileUpload2_1" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_1">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_1"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddDevelMaint_Click" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click" />
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
                <!-- ========================popup========================================================== -->

                <%-- //###############################EvaluateDevelMaint2_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_2 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">2. Conference proceeding</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData2" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging2" AllowSorting="True"
                                            OnSorting="gvData_Sorting2" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="gvData_RowDataBound2" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged2">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id2" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus2" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_2" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click2">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_2" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint2" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click2">
                                                            <img id="editDevelMaint2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint2" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click2">
                                                            <img id="DeletDevelMaint2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint2_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint2">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_2_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord2" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl2Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_2" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_2" PopupControlID="panelAddDevelMaint2_2" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Conference proceeding</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus2" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ประเภท
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectType2" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlType2Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlType2Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-2-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType2Add" runat="server"
                                                    ControlToValidate="txtProjectType2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint2" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click2" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint2_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click2" />
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

                <%-- //###############################EvaluateDevelMaint2_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_3 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">3. ยื่นขอจดสิทธิบัตร (ปตท. / ไทย) /
                                         ยื่นขอจดอนุสิทธิบัตร</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData3" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging3" AllowSorting="True"
                                            OnSorting="gvData_Sorting3" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="gvData_RowDataBound3" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged3">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id3" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus3" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่อขอจดสิทธิบัตร/อนุสิทธิบัตร" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารยื่นจดสิทธิบัตร" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_3" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click3">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_3" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint3" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click3">
                                                            <img id="editDevelMaint3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint3" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click3">
                                                            <img id="DeletDevelMaint3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint3_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint3">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_3" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_3_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord3" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl3Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_3" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_3" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_3" PopupControlID="panelAddDevelMaint2_3" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_3" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">ยื่นขอจดสิทธิบัตร (ปตท. / ไทย) /
                                             ยื่นขอจดอนุสิทธิบัตร</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus3" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ชื่อขอจดจดสิทธิบัตร/อนุสิทธิบัตร
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_3"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ประเภท
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectType3" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlType3Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlType3Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-3-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType3Add" runat="server"
                                                    ControlToValidate="txtProjectType3" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_3"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารยื่นจดสิทธิบัตร/ตอบรับ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_3" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_3">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_3"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_3"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_3" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint3" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click3" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint3_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint3">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel3" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click3" />
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

                <%-- //###############################EvaluateDevelMaint2_3 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_4 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">4. Oral (ตปท./ไทย) / Poster Presentation (ตปท./ไทย)</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData4" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging4" AllowSorting="True"
                                            OnSorting="gvData_Sorting4" AutoGenerateColumns="False" CellPadding="4"
                                            OnRowDataBound="gvData_RowDataBound4" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged4">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id4" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus4" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หน่วยงานที่จัด" DataField="projectAgency"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ระดับการจัดงาน" DataField="projectLevel"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="120px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_4" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click4">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_4" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint4" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click4">
                                                            <img id="editDevelMaint4" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint4" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click4">
                                                            <img id="DeletDevelMaint4" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint4_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint4">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_4" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_4_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord4" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl4Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_4" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_4" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_4" PopupControlID="panelAddDevelMaint2_4" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_4" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Oral (ตปท./ไทย) / Poster Presentation
                                            (ตปท./ไทย)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus4" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic4"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_4"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หน่วยงานที่จัด :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectAgency4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectAgency4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectAgency4"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_4"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ระดับการจัดงาน :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectLevel4" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlLevel4Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlLevel4Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-4-Level' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqLevel4Add" runat="server"
                                                    ControlToValidate="txtProjectLevel4" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_4"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ประเภท
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectType4" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlType4Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlType4Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-4-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType4Add" runat="server"
                                                    ControlToValidate="txtProjectType4" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_4"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_4" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_4" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_4">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture4" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_4"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_4"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_4" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint4" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click4" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint4_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint4">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel4" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click4" />
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

                <%-- //###############################EvaluateDevelMaint2_4 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_5 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">5. Technical report</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData5" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging5" AllowSorting="True"
                                            OnSorting="gvData_Sorting5" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound5" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged5">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id5" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus5" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    Visible="False" ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารTechnical report"
                                                    ShowHeader="False" ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_5" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click5">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_5" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint5" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click5">
                                                            <img id="editDevelMaint5" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint5" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click5">
                                                            <img id="DeletDevelMaint5" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint5_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint5">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_5" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_5_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord5" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl5Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_5" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_5" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_5" PopupControlID="panelAddDevelMaint2_5" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_5" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Technical report </strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus5" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic5" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic5"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_5"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <!-- <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ประเภท
                                                    :</strong>
                                            </td> -->
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectType5" runat="server" Visible="False"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlType5Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlType5Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-5-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType5Add" runat="server"
                                                    ControlToValidate="txtProjectType5" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_5"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Class
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectClass5" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlClass5Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">คณะกรรมการเป็นผู้พิจารณา</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass5Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'test' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass5Add" runat="server"
                                                    ControlToValidate="txtProjectClass5" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_5"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารTechnical report :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_5" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_5" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_5">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_5"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_5"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_5" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint5" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click5" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint5_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint5">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel5" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click5" />
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

                <%-- //###############################EvaluateDevelMaint2_5 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_6_1 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel6_1" runat="server">
                        <ContentTemplate>
                            <h5 class="h5" align="left">6. ผลงานการพัฒนาที่นำไปใช้จริง</h5>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">6.1. ออกแบบระบบลำเลียงแสง / ออกแบบสถานีทดลอง
                                        /ติดตั้งและทดสอบระบบลำเลียงแสง</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData6_1" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging6_1" AllowSorting="True"
                                            OnSorting="gvData_Sorting6_1" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound6_1" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged6_1">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id6_1" runat="server"
                                                            Text='<%# Bind("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus6_1" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อผลงาน" DataField="projectName"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% แผนที่ตั้งไว้" DataField="projectPlan"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% การดำเนินงาน"
                                                    DataField="projectInProgress" ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_6_1" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click6_1">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_6_1" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint6_1" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click6_1">
                                                            <img id="editDevelMaint6_1" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint6_1" runat="server"
                                                            Text='' OnClick="btnDeleteDevelMaint_Click6_1">
                                                            <img id="DeletDevelMaint6_1" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint6_1_ConfirmButtonExtender"
                                                            runat="server" ConfirmText="ยืนยันการลบข้อมูล"
                                                            Enabled="True" TargetControlID="btnDeletDevelMaint6_1">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_6_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_6_1_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord6_1" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl6_1Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_6_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_6_1" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_6_1" PopupControlID="panelAddDevelMaint2_6_1"
                    DropShadow="false" BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_6_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_6_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">ออกแบบระบบลำเลียงแสง / ออกแบบสถานีทดลอง
                                            /ติดตั้งและทดสอบระบบลำเลียงแสง </strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus6_1" runat="server" />
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectTopic6_1" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlTopic6_1Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlTopic6_1Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-6-1-Topic' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqTopic6_1Add" runat="server"
                                                    ControlToValidate="txtProjectTopic6_1" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_1"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อผลงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectName6_1" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName6_1Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName6_1"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">%
                                                    แผนที่ตั้งไว้ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectPlan6_1" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectPlan6_1Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectPlan6_1"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">%
                                                    การดำเนินงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectInProgress6_1" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectInProgress6_1Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectInProgress6_1" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_6_1">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_6_1" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile6_1Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_6_1"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_1"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture6_1"
                                                    runat="server" style="color: #ff0000"
                                                    ControlToValidate="FileUpload2_6_1" Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_6_1">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_6_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint6_1" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click6_1" />
                                                <cc1:ConfirmButtonExtender
                                                    ID="btnAddDevelMaint6_1_ConfirmButtonExtender" runat="server"
                                                    ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint6_1">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel6_1" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click6_1" />
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

                <%-- //###############################EvaluateDevelMaint2_6_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_6_2 Strat##################################################### --%>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel6_2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">6.2. ออกแบบเครื่องมือตรวจวัดและอุปกรณ์ต่างๆ /
                                        ปรับปรุงระบบทัศนศาสตร์ของระบบลำเลียงแสง</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData6_2" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging6_2" AllowSorting="True"
                                            OnSorting="gvData_Sorting6_2" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound6_2" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged6_2">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id6_2" runat="server"
                                                            Text='<%# Bind("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus6_2" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="160px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อผลงาน" DataField="projectName"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% แผนที่ตั้งไว้" DataField="projectPlan"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="40px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="% การดำเนินงาน"
                                                    DataField="projectInProgress" ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="30px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_6_2" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click6_2">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_6_2" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint6_2" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click6_2">
                                                            <img id="editDevelMaint6_2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint6_2" runat="server"
                                                            Text='' OnClick="btnDeleteDevelMaint_Click6_2">
                                                            <img id="DeletDevelMaint6_2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint6_2_ConfirmButtonExtender"
                                                            runat="server" ConfirmText="ยืนยันการลบข้อมูล"
                                                            Enabled="True" TargetControlID="btnDeletDevelMaint6_2">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_6_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_6_2_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord6_2" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl6_2Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_6_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_6_2" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_6_2" PopupControlID="panelAddDevelMaint2_6_2"
                    DropShadow="false" BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_6_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_6_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">ออกแบบเครื่องมือตรวจวัดและอุปกรณ์ต่างๆ /
                                            ปรับปรุงระบบทัศนศาสตร์ของระบบลำเลียงแสง </strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus6_2" runat="server" />
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectTopic6_2" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlTopic6_2Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlTopic6_2Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-6-2-Topic' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqTopic6_2Add" runat="server"
                                                    ControlToValidate="txtProjectTopic6_2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อผลงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectName6_2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName6_2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName6_2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Class
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectClass6_2" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlClass6_2Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass6_2Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop2-6-2-Class' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass6_2Add" runat="server"
                                                    ControlToValidate="txtProjectClass6_2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">%
                                                    แผนที่ตั้งไว้ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectPlan6_2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectPlan6_2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectPlan6_2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">%
                                                    การดำเนินงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectInProgress6_2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectInProgress6_2Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectInProgress6_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_6_2">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_6_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile6_2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_6_2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_6_2"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture6_2"
                                                    runat="server" style="color: #ff0000"
                                                    ControlToValidate="FileUpload2_6_2" Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_6_2">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_6_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint6_2" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click6_2" />
                                                <cc1:ConfirmButtonExtender
                                                    ID="btnAddDevelMaint6_2_ConfirmButtonExtender" runat="server"
                                                    ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint6_2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel6_2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click6_2" />
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

                <%-- //###############################EvaluateDevelMaint2_6_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_7 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">7. วิทยานิพนธ์
                                        (ที่เป็นอาจารย์ที่ปรึกษา/อาจารย์ที่ปรึกษาร่วม) (Claim ได้ครั้งเดียว)</h5>
                                    <span class="h5" style="color: Red">หมายเหตุต้องสำเร็จการศึกษา</span>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData7" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging7" AllowSorting="True"
                                            OnSorting="gvData_Sorting7" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound7" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged7">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id7" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus7" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่อนักศึกษา" DataField="projectStudentName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หัวข้อวิทยานิพนธ์"
                                                    DataField="projectThesisTopic" ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="สถาบัน" DataField="projectInstitute"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ(หนังสือสำเร็จการศึกษา) "
                                                    ShowHeader="False" ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_7" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click7">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_7" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint7" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click7">
                                                            <img id="editDevelMaint7" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint7" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click7">
                                                            <img id="DeletDevelMaint7" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint7_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint7">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_7" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_7_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord7" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl7Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_7" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_7" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_7" PopupControlID="panelAddDevelMaint2_7" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_7" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_7" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">วิทยานิพนธ์
                                            (ที่เป็นอาจารย์ที่ปรึกษา/อาจารย์ที่ปรึกษาร่วม) (Claim
                                            ได้ครั้งเดียว)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus7" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อนักศึกษา :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectStudentName7" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectStudentName7Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectStudentName7" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_7">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หัวข้อวิทยานิพนธ์ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectThesisTopic7" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectThesisTopic7Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectThesisTopic7" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_7">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">สถาบัน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectInstitute7" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectInstitute7Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectInstitute7"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_7"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ(หนังสือสำเร็จการศึกษา) :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_7" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile7Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_7" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_7">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture7" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_7"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_7"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_7" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint7" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click7" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint7_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint7">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel7" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click7" />
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

                <%-- //###############################EvaluateDevelMaint2_7 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateDevelMaint2_8 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">8.
                                        การเข้าร่วมประชุมเชิงปฏิบัติการและฝึกอบรมทั้งในและต่างประเทศ
                                        ที่เกี่ยวข้องกับการพัฒนาและบำรุงรักษาระบบลำเลียงแสง หรือสถานีทดลอง
                                        หรือห้องปฏิบัติการต่าง ๆ (Technical training, training on the job)</h5>

                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData8" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging8" AllowSorting="True"
                                            OnSorting="gvData_Sorting8" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound8" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged8">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id8" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus8" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่องาน" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวนวัน (อย่างเป็นทางการ)" DataField="dateNumber"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField
                                                    HeaderText="เอกสารอนุมัติการเข้าร่วมงานและรายงานการปฏิบัติงาน "
                                                    ShowHeader="False" ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_8" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click8">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_8" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint8" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click8">
                                                            <img id="editDevelMaint8" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint8" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click8">
                                                            <img id="DeletDevelMaint8" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint8_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint8">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_8" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_8_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord8" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl8Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_8" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_8" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_8" PopupControlID="panelAddDevelMaint2_8" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_8" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_8" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">(Technical training, training on the
                                            job)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus8" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ชื่องาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectName8" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjecttName8Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName8"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_8"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนวัน (อย่างเป็นทางการ):</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtDateNumber8" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqDateNumber8Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtDateNumber8"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_8"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารอนุมัติการเข้าร่วมงานและรายงานการปฏิบัติงาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_8" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile8Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_8" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_8">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture8" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_8"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_8"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_8" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint8" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click8" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint8_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint8">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel8" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click8" />
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

                <%-- //###############################EvaluateDevelMaint2_8 end#####################################################
    ###############################################################################################################
    ################################################################################################################
    ###################################################################################################################
    ###############################EvaluateDevelMaint2_9 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server" Visible="False">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">9. งานดูแล ซ่อม บำรุงรักษา (Routine Work)
                                        และงานทดสอบเครื่องมือและมาตรฐานการวัด</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData9" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging9" AllowSorting="True"
                                            OnSorting="gvData_Sorting9" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound9" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged9">
                                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First"
                                                LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;"
                                                PreviousPageText="&amp;lt;Previous" />
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF"
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                                HorizontalAlign="Left" />
                                            <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                                CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray"
                                                HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id9" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus9" runat="server"
                                                            Value='<%# Bind("id") %>'></asp:HiddenField>
                                                        <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                            Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                                        </asp:Label>
                                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่องาน" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวนวัน" DataField="dateNumber"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="110px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารตารางการทำงาน " ShowHeader="False"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload2_9" runat="server"  Visible="False"
                                                            OnClick="btnDownload_Click9">
                                                            <img id="DownloadDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2_9" runat="server" Text=''>
                                                            <img id="DeletDevelMaint" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditDevelMaint9" runat="server" Text=''
                                                            OnClick="btnEditDevelMaint_Click9">
                                                            <img id="editDevelMaint9" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_edit_16x16_9821.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletDevelMaint9" runat="server" Text=''
                                                            OnClick="btnDeleteDevelMaint_Click9">
                                                            <img id="DeletDevelMaint9" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddDevelMaint9_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletDevelMaint9">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add2_9" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add2_9_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord9" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl9Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddDevelMaint2_9" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddDevelMaint2_9" runat="server"
                    TargetControlID="lblPopupAddDevelMaint2_9" PopupControlID="panelAddDevelMaint2_9" DropShadow="false"
                    BackgroundCssClass="modalBackground" Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddDevelMaint2_9" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel2_9" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">งานดูแล ซ่อม บำรุงรักษา (Routine Work)
                                            และงานทดสอบเครื่องมือและมาตรฐานการวัด</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_DevelMaintStatus9" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ชื่องาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectName9" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjecttName9Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName9"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_9"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนวัน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtDateNumber9" runat="server" CssClass="gray"
                                                    Width="190px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqDateNumber9Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtDateNumber9"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddDevelMaint2_9"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารตารางการทำงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload2_9" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile9Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload2_9" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddDevelMaint2_9">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture9" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload2_9"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddDevelMaint2_9"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError2_9" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddDevelMaint9" runat="server"
                                                    CssClass="txt_howtonav" Text="Submit" Width="100px"
                                                    ValidationGroup="AddColor" OnClick="btnAddDevelMaint_Click9" />
                                                <cc1:ConfirmButtonExtender ID="btnAddDevelMaint9_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddDevelMaint9">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel9" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelDevelMaint_Click9" />
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

                <%-- //###############################EvaluateDevelMaint2_8 end#####################################################
    ###############################################################################################################
    ################################################################################################################
    ################################################################################################################### --%>














        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddDevelMaint" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint2" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint3" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint4" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint5" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint6_1" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint6_2" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint7" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint8" />
            <asp:PostBackTrigger ControlID="btnAddDevelMaint9" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>