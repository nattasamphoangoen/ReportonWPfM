<%@ Page Title="EvaluateAcademicServices" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_AcademicServices.aspx.cs" Inherits="Evaluate_AcademicServices" Async="true" %>
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
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n2.png"
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
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/five.png"
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
                        <p colspan="5" align="center" class="txt_title_rewards">5. งานบริการวิชาการและสังคม</p>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">

                                <tr>
                                    <h5 class="h5" align="left">1. คณะกรรมการงานประชุมวิชาการระดับนานาชาติ-ระดับชาติ
                                        (วันจัดงานอย่างเป็นทางการ)</h5>
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

                                                <asp:BoundField HeaderText="ชื่องาน" DataField="projectName"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวน(วัน)" DataField="dateNumber"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="ระดับการจัดงาน" DataField="projectLocation"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารคำสั่ง/หนังสือปะหน้า"
                                                    ShowHeader="False" ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_Path" runat="server"
                                                            Value='<%# Bind("path") %>'></asp:HiddenField>
                                                        <asp:LinkButton ID="lnkDownload" runat="server" Visible="False"
                                                            CausesValidation="False" OnClick="btnDownload_Click">
                                                            <img id="DownloadAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text=''>
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditAcademic" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditAcademic_Click">
                                                            <img id="editAcademic" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletAcademic" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteAcademic_Click">
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddAcademic_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletAcademic">
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
                                        <asp:Button ID="Add5_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add5_1_Click" />
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
                <asp:Label ID="lblPopupAddAcademic5_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddAcademic5_1" runat="server" TargetControlID="lblPopupAddAcademic5_1"
                    PopupControlID="panelAddAcademic5_1" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddAcademic5_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel5_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong
                                            style="color: #593b00">คณะกรรมการงานประชุมวิชาการระดับนานาชาติ-ระดับชาติ</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_AcademicStatus" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">ชื่องาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectName" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectNameAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddAcademic5_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวน(วัน)
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtdateNumber" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqdateNumberAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtdateNumber" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_1"
                                                    style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ระดับการจัดงาน
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectLocation" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlLocationAdd" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlLocationAdd" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Academic5-1-Location' AND ddlStatus = 'A' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqLocationAdd" runat="server"
                                                    ControlToValidate="txtProjectLocation" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddAcademic5_1"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>



                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารคำสั่ง/หนังสือปะหน้า :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:FileUpload ID="FileUpload5_1" runat="server" EnableTheming="True"
                                                    style="color: #0d0044" />
                                                <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server"
                                                    ErrorMessage="*โปรดเลือกไฟล์" style="color: #ff0000"
                                                    ControlToValidate="FileUpload5_1" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_1">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload5_1"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddAcademic5_1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError5_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddAcademic" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddAcademic_Click" />
                                                <cc1:ConfirmButtonExtender ID="btnAddAcademic_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddAcademic">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelAcademic_Click" />
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

                <%-- //###############################EvaluateAcademic5_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateAcademic5_2 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">2. การเป็นอาจารย์ที่ปรึกษาร่วม</h5>
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

                                                <asp:BoundField HeaderText="ชื่อสถานศึกษา"
                                                    DataField="projectAcadenicName" ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อนักศึกษา "
                                                    DataField="projectStudentName" ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>




                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารอ้างอิง" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload5_2" runat="server"
                                                            Visible="False" OnClick="btnDownload_Click2">
                                                            <img id="DownloadAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton5_2" runat="server" Text=''>
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditAcademic2" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditAcademic_Click2">
                                                            <img id="editAcademic2" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletAcademic2" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteAcademic_Click2">
                                                            <img id="DeletAcademic2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddAcademic2_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletAcademic2">
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
                                        <asp:Button ID="Add5_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add5_2_Click" />
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
                <asp:Label ID="lblPopupAddAcademic5_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddAcademic5_2" runat="server" TargetControlID="lblPopupAddAcademic5_2"
                    PopupControlID="panelAddAcademic5_2" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddAcademic5_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel5_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">การเป็นอาจารย์ที่ปรึกษาร่วม</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_AcademicStatus2" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อสถานศึกษา
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectAcadenicName2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectAcadenicName2Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectAcadenicName2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_2">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อนักศึกษา
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectStudentName2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectStudentName2Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectStudentName2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_2">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารอ้างอิง :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload5_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload5_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload5_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddAcademic5_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError5_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddAcademic2" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddAcademic_Click2" />
                                                <cc1:ConfirmButtonExtender ID="btnAddAcademic2_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddAcademic2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelAcademic_Click2" />
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

                <%-- //###############################EvaluateAcademic5_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateAcademic5_3 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">3. งานสอบวิทยานิพนธ์
                                        (ทั้งที่เป็นกรรมการและถูกเชิญเข้าร่วม โดยมีหนังสืออย่างเป็นทางการ)</h5>
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

                                                <asp:BoundField HeaderText="ชื่อสถานศึกษา"
                                                    DataField="projectAcademicName" ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อนักศึกษา" DataField="projectStudentName"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="150px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หัวข้อวิทยานิพนธ์"
                                                    DataField="projectThesisTopic" ItemStyle-Width="80px">
                                                    <ItemStyle Width="150px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารอ้างอิง" ShowHeader="False"
                                                    ItemStyle-Width="100px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload5_3" runat="server"
                                                            Visible="False" OnClick="btnDownload_Click3">
                                                            <img id="DownloadAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton5_3" runat="server" Text=''>
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditAcademic3" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditAcademic_Click3">
                                                            <img id="editAcademic3" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletAcademic3" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteAcademic_Click3">
                                                            <img id="DeletAcademic3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddAcademic3_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletAcademic3">
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
                                        <asp:Button ID="Add5_3" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add5_3_Click" />
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
                <asp:Label ID="lblPopupAddAcademic5_3" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddAcademic5_3" runat="server" TargetControlID="lblPopupAddAcademic5_3"
                    PopupControlID="panelAddAcademic5_3" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddAcademic5_3" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel5_3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">งานสอบวิทยานิพนธ์</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_AcademicStatus3" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อสถานศึกษา
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectAcademicName3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectAcademicName3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddAcademic5_3"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อนักศึกษา
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectStudentName3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectStudentName3Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectStudentName3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_3">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หัวข้อวิทยานิพนธ์
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectThesisTopic3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectThesisTopic3Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectThesisTopic3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_3">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>



                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารอ้างอิง :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload5_3" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload5_3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_3">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload5_3"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddAcademic5_3"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError5_3" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddAcademic3" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddAcademic_Click3" />
                                                <cc1:ConfirmButtonExtender ID="btnAddAcademic3_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddAcademic3">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel3" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelAcademic_Click3" />
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

                <%-- //###############################EvaluateAcademic5_3 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateAcademic5_4 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">4. ประเมินโครงการใช้แสงซินโครตรอน (BLM และ BLS)</h5>
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

                                                <asp:BoundField HeaderText="จำนวนโครงการที่ประเมิน"
                                                    DataField="projectOfNumber" ItemStyle-Width="100px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารแนบรายชื่อโครงการ"
                                                    ShowHeader="False" ItemStyle-Width="100px">
                                                    <ItemStyle Width="69px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload5_4" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click4">
                                                            <img id="DownloadAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton5_4" runat="server" Text=''>
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditAcademic4" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditAcademic_Click4">
                                                            <img id="editAcademic4" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletAcademic4" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteAcademic_Click4">
                                                            <img id="DeletAcademic4" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddAcademic4_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletAcademic4">
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
                                        <asp:Button ID="Add5_4" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add5_4_Click" />
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
                <asp:Label ID="lblPopupAddAcademic5_4" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddAcademic5_4" runat="server" TargetControlID="lblPopupAddAcademic5_4"
                    PopupControlID="panelAddAcademic5_4" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddAcademic5_4" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel5_4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">ประเมินโครงการใช้แสงซินโครตรอน (BLM และ
                                            BLS)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_AcademicStatus4" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนโครงการที่ประเมิน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectOfNumber4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectOfNumber4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectOfNumber4"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddAcademic5_4"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบรายชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload5_4" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload5_4" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_4">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture4" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload5_4"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddAcademic5_4"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>



                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError5_4" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddAcademic4" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddAcademic_Click4" />
                                                <cc1:ConfirmButtonExtender ID="btnAddAcademic4_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddAcademic4">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel4" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelAcademic_Click4" />
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

                <%-- //###############################EvaluateAcademic5_4 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateAcademic5_5 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">5. งานบริการวิชาการและสังคม (กรณีไม่มีค่าตอบแทน)</h5>
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

                                                <asp:BoundField HeaderText="รายละเอียด" DataField="projectDescription"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวนวันทำงาน" DataField="dateNumber"
                                                    ItemStyle-Width="150px">
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
                                                        <asp:LinkButton ID="lnkDownload5_5" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click5">
                                                            <img id="DownloadAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton5_5" runat="server" Text=''>
                                                            <img id="DeletAcademic" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditAcademic5" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditAcademic_Click5">
                                                            <img id="editAcademic5" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletAcademic5" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteAcademic_Click5">
                                                            <img id="DeletAcademic5" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddAcademic5_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletAcademic5">
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
                                        <asp:Button ID="Add5_5" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add5_5_Click" />
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
                <asp:Label ID="lblPopupAddAcademic5_5" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddAcademic5_5" runat="server" TargetControlID="lblPopupAddAcademic5_5"
                    PopupControlID="panelAddAcademic5_5" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddAcademic5_5" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel5_5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">งานบริการวิชาการและสังคม</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_AcademicStatus5" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">รายละเอียด
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectDescription5" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectDescription5Add"
                                                    runat="server" ErrorMessage="*"
                                                    ControlToValidate="txtProjectDescription5" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_5">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนวันทำงาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtdateNumber5" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqdateNumber5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtdateNumber5"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddAcademic5_5"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>





                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload5_5" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload5_5" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddAcademic5_5">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload5_5"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddAcademic5_5"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError5_5" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddAcademic5" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddAcademic_Click5" />
                                                <cc1:ConfirmButtonExtender ID="btnAddAcademic5_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddAcademic5">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel5" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelAcademic_Click5" />
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

                <%-- //###############################EvaluateAcademic5_5 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//#############################################################3##################################################### --%>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddAcademic" />
            <asp:PostBackTrigger ControlID="btnAddAcademic2" />
            <asp:PostBackTrigger ControlID="btnAddAcademic3" />
            <asp:PostBackTrigger ControlID="btnAddAcademic4" />
            <asp:PostBackTrigger ControlID="btnAddAcademic5" />



        </Triggers>
    </asp:UpdatePanel>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>