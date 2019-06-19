<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeFile="Evaluate_ServiceWork.aspx.cs" Inherits="Evaluate_ServiceWork" Culture="en-US" Debug="true" %>

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

        .style3 {
            height: 17px;
        }

        .cal_Theme1 .ajax__calendar_container {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_header {
            background-color: #ffffff;
            margin-bottom: 4px;
        }

        .cal_Theme1 .ajax__calendar_title,
        .cal_Theme1 .ajax__calendar_next,
        .cal_Theme1 .ajax__calendar_prev {
            color: #004080;
            padding-top: 3px;
        }

        .cal_Theme1 .ajax__calendar_body {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_dayname {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }

        .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align: center;
        }

        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year,
        .cal_Theme1 .ajax__calendar_active {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }

        .cal_Theme1 .ajax__calendar_today {
            font-weight: bold;
        }

        .cal_Theme1 .ajax__calendar_other,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
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
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/one.png"
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
                        <p colspan="5" align="center" class="txt_title_rewards">1. งานให้บริการ (ภาควิชาการ,
                            ภาคอุตสาหกรรม)</p>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">1. งาน Local contact (Experimental setup, Sample
                                        preparation, and Measurement) งานสอบเทียบเครื่องมือและมาตรฐานการวัด</h5>
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

                                                <asp:BoundField HeaderText="หมายเลขโครงการ" DataField="projectCode"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:templatefield headertext="วันที่ให้บริการ" ItemStyle-Width="120px">
                                                    <itemtemplate>
                                                        <%# Convert.ToDateTime(Eval("updateDate")).ToString("dd/MM/yyyy - ") %>
                                                        <%# Convert.ToDateTime(Eval("updateDateOut")).ToString("dd/MM/yyyy") %>
                                                        <ItemStyle Width="100px" Font-Size="Small" />
                                                    </itemtemplate>
                                                </asp:templatefield>



                                                <asp:BoundField HeaderText="จำนวน shift" DataField="projectShipft"
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
                                                        <asp:LinkButton ID="lnkDownload" runat="server"
                                                            CausesValidation="False" OnClick="btnDownload_Click">
                                                            <img id="DownloadService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text=''>
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditSevice" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditService_Click">
                                                            <img id="editService" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletService" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteService_Click">
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddService_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletService">
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
                                    <td align="Left" width="20">
                                        <asp:FileUpload ID="FileUpload1_1" runat="server" EnableTheming="True"
                                            style="color: #0d0044; font-size: 13px;" />
                                        <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server"
                                            ErrorMessage="*โปรดเลือกไฟล์" style="color: #ff0000; font-size: 13px;"
                                            ControlToValidate="FileUpload1_1" Display="Dynamic" SetFocusOnError="True"
                                            ValidationGroup="AddServeice1_1">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server"
                                            style="color: #ff0000; font-size: 10px;" ControlToValidate="FileUpload1_1"
                                            Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                            SetFocusOnError="True"
                                            ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                            ValidationGroup="AddServeice1_1"></asp:RegularExpressionValidator>
                                        <asp:Button ID="Upload1_1" runat="server"
                                            style="color: #0d0044; font-size: 12px;" Text="Upload"
                                            OnClick="FileUpload1_1_Click" />
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="6" align="right">
                                        <asp:Button ID="Add1_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add1_1_Click" />
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
                <asp:Label ID="lblPopupAddService1_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddService1_1" runat="server" TargetControlID="lblPopupAddService1_1"
                    PopupControlID="panelAddService1_1" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddService1_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel1_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">เพิ่มข้อมูลงาน Local contact</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_SeviceStatus" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หมายเลขโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectCode" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectCodeAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectCode"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectName" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectNameAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="right" valign="top">
                                                <strong style="color: #003359">วันที่ให้บริการ :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtProjectDate" runat="server" CssClass="gray"
                                                    Width="90px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                    TargetControlID="txtProjectDate" Format="yyyy-MM-dd"
                                                    PopupButtonID="CalendarVisitDate" CssClass="cal_Theme1">
                                                </cc1:CalendarExtender>
                                                <img id="CalendarVisitDate" alt="" border="0" height="16" name="popcal"
                                                    src="Images/calendar.png" width="16" />

                                                <asp:Label ID="lbl_cal" runat="server" Text=' - '></asp:Label>
                                                <asp:TextBox ID="txtProjectDateOut" runat="server" CssClass="gray"
                                                    Width="90px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtenderOut" runat="server"
                                                    TargetControlID="txtProjectDateOut" Format="yyyy-MM-dd"
                                                    PopupButtonID="CalendarVisitDateOut" CssClass="cal_Theme1">
                                                </cc1:CalendarExtender>
                                                <img id="CalendarVisitDateOut" alt="" border="0" height="16"
                                                    name="popcal" src="Images/calendar.png" width="16" />
                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">จำนวน
                                                    Shift :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectShift" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectShiftAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectShift"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError1_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddService" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddService_Click" />
                                                <cc1:ConfirmButtonExtender ID="btnAddService_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddService">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelService_Click" />
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


                <%-- //###############################EvaluateSevice1_1 end#####################################################
//###############################EvaluateSevice1_2 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">2. งานให้บริการภาคอุตสาหกรรม</h5>
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

                                                <asp:BoundField HeaderText="หมายเลขโครงการ" DataField="projectCode"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:templatefield headertext="วันที่ให้บริการ" ItemStyle-Width="120px">
                                                    <itemtemplate>
                                                        <%# Convert.ToDateTime(Eval("updateDate")).ToString("dd/MM/yyyy - ") %>
                                                        <%# Convert.ToDateTime(Eval("updateDateOut")).ToString("dd/MM/yyyy") %>
                                                        <ItemStyle Width="100px" Font-Size="Small" />
                                                    </itemtemplate>
                                                </asp:templatefield>

                                                <asp:BoundField HeaderText="จำนวน shift" DataField="projectShipft"
                                                    ItemStyle-Width="80px">
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
                                                        <asp:LinkButton ID="lnkDownload1_2" runat="server"
                                                            OnClick="btnDownload_Click2">
                                                            <img id="DownloadService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton1_2" runat="server" Text=''>
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditSevice2" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditService_Click2">
                                                            <img id="editService2" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletService2" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteService_Click2">
                                                            <img id="DeletService2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddService2_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletService2">
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
                                        <asp:Button ID="Add1_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add1_2_Click" />
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
                <asp:Label ID="lblPopupAddService1_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddService1_2" runat="server" TargetControlID="lblPopupAddService1_2"
                    PopupControlID="panelAddService1_2" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddService1_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel1_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">เพิ่มข้อมูลงานให้บริการภาคอุตสาหกรรม</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_SeviceStatus2" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หมายเลขโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectCode2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectCode2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectCode2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectName2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <strong style="color: #003359">วันที่ให้บริการ :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtProjectDate2" runat="server" CssClass="gray"
                                                    Width="90px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                                    TargetControlID="txtProjectDate2" Format="yyyy-MM-dd"
                                                    PopupButtonID="CalendarVisitDate2" CssClass="cal_Theme1">
                                                </cc1:CalendarExtender>
                                                <img id="CalendarVisitDate2" alt="" border="0" height="16" name="popcal"
                                                    src="Images/calendar.png" width="16" />

                                                <asp:Label ID="lbl_cal2" runat="server" Text=' - '></asp:Label>
                                                <asp:TextBox ID="txtProjectDateOut2" runat="server" CssClass="gray"
                                                    Width="90px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtenderOut2" runat="server"
                                                    TargetControlID="txtProjectDateOut2" Format="yyyy-MM-dd"
                                                    PopupButtonID="CalendarVisitDateOut2" CssClass="cal_Theme1">
                                                </cc1:CalendarExtender>
                                                <img id="CalendarVisitDateOut2" alt="" border="0" height="16"
                                                    name="popcal" src="Images/calendar.png" width="16" />
                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">จำนวน
                                                    Shift :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectShift2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectShift2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectShift2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_2"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">

                                                <asp:FileUpload ID="FileUpload1_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload1_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddServeice1_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload1_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddServeice1_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError1_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddService2" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddService_Click2" />
                                                <cc1:ConfirmButtonExtender ID="btnAddService2_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddService2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelService_Click2" />
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


                <%-- //###############################EvaluateSevice1_2 end#####################################################
//###############################EvaluateSevice1_3 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">3. งานเป็นที่ปรึกษาให้กับผู้ใช้บริการแสงซินโครตรอน /
                                        ภาคอุตสาหกรรม</h5>
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

                                                <asp:BoundField HeaderText="หมายเลขโครงการ" DataField="projectCode"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="รายละเอียด/ผลลัพธ์ที่ให้บริการ"
                                                    DataField="projectDescription" ItemStyle-Width="80px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload1_3" runat="server"
                                                            OnClick="btnDownload_Click3">
                                                            <img id="DownloadService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton1_3" runat="server" Text=''>
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditSevice3" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditService_Click3">
                                                            <img id="editService3" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletService3" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteService_Click3">
                                                            <img id="DeletService3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddService3_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletService3">
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
                                        <asp:Button ID="Add1_3" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add1_3_Click" />
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
                <asp:Label ID="lblPopupAddService1_3" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddService1_3" runat="server" TargetControlID="lblPopupAddService1_3"
                    PopupControlID="panelAddService1_3" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddService1_3" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel1_3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong
                                            style="color: #593b00">เพิ่มข้อมูลงานเป็นที่ปรึกษาให้กับผู้ใช้บริการแสงซินโครตรอน
                                            / ภาคอุตสาหกรรม</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_SeviceStatus3" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">หมายเลขโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectCode3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectCode3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectCode3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_3"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectName3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_3"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Class
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectClass3" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlClassAdd" DataTextField="ddlDisplay"
                                                    DataValueField="ddlValue" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClassAdd" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Sevice1-3-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClassAdd" runat="server"
                                                    ControlToValidate="txtProjectClass3" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_3"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <strong style="color: #003359">รายละเอียด/ผลลัพธ์ที่ให้บริการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectDescription3" runat="server" CssClass="gray"
                                                    Width="180px" Height="50px" Font-Overline="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:FileUpload ID="FileUpload1_3" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload1_3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddServeice1_3">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload1_3"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddServeice1_3"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError1_3" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddService3" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddService_Click3" />
                                                <cc1:ConfirmButtonExtender ID="btnAddService3_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddService3">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel3" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelService_Click3" />
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



                <%-- //###############################EvaluateSevice1_3 end#####################################################
//###############################EvaluateSevice1_4 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">4. Technical manual</h5>
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

                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
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
                                                        <asp:LinkButton ID="lnkDownload1_4" runat="server"
                                                            OnClick="btnDownload_Click4">
                                                            <img id="DownloadService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton1_4" runat="server" Text=''>
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditSevice4" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditService_Click4">
                                                            <img id="editService4" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletService4" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteService_Click4">
                                                            <img id="DeletService4" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddService4_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletService4">
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
                                        <asp:Button ID="Add1_4" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add1_4_Click" />
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
                <asp:Label ID="lblPopupAddService1_4" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddService1_4" runat="server" TargetControlID="lblPopupAddService1_4"
                    PopupControlID="panelAddService1_4" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddService1_4" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel1_4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Technical manual</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_SeviceStatus4" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="4">
                                                <asp:TextBox ID="txtProjectName4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName4"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_4"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Class
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectClass4" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlClass4Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlValue" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">คณะกรรมการเป็นผู้พิจารณา</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass4Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'test' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass4Add" runat="server"
                                                    ControlToValidate="txtProjectClass4" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_4"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="4">
                                                <asp:FileUpload ID="FileUpload1_4" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload1_4" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddServeice1_4">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture4" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload1_4"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddServeice1_4"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError1_4" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddService4" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddService_Click4" />
                                                <cc1:ConfirmButtonExtender ID="btnAddService4_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddService4">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel4" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelService_Click4" />
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






                <%-- //###############################EvaluateSevice1_4 end#####################################################
//###############################EvaluateSevice1_5 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">5. Standard protocol (คู่มือกระบวนการดำเนินงาน)</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData5" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging5" AllowSorting="True"
                                            OnSorting="gvData_Sorting5" AutoGenerateColumns="False" CellPadding="4"
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

                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
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
                                                        <asp:LinkButton ID="lnkDownload1_5" runat="server"
                                                            CausesValidation="False" OnClick="btnDownload_Click5">
                                                            <img id="DownloadService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton1_5" runat="server" Text=''>
                                                            <img id="DeletService" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditSevice5" runat="server" Text=''
                                                            Visible="true" OnClick="btnEditService_Click5">
                                                            <img id="editService5" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletService5" runat="server" Text=''
                                                            Visible="true" OnClick="btnDeleteService_Click5">
                                                            <img id="DeletService5" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddService5_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletService5">
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
                                        <asp:Button ID="Add1_5" runat="server" CssClass="btn btn-success" Text="Add"
                                            Visible="true" OnClick="Add1_5_Click" />
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
                <asp:Label ID="lblPopupAddService1_5" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddService1_5" runat="server" TargetControlID="lblPopupAddService1_5"
                    PopupControlID="panelAddService1_5" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddService1_5" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel1_5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">Technical manual (*มีเอกสาร contribution
                                            ด้วย)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_SeviceStatus5" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="4">
                                                <asp:TextBox ID="txtProjectName5" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName5"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_5"></asp:RequiredFieldValidator>
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
                                                    DataValueField="ddlValue" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">คณะกรรมการเป็นผู้พิจารณา</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass5Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'test' AND ddlStatus = 'A' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass5Add" runat="server"
                                                    ControlToValidate="txtProjectClass5" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddServeice1_5"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>



                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="4">
                                                <asp:FileUpload ID="FileUpload1_5" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload1_5" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddServeice1_5">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload1_5"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddServeice1_5"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError1_5" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddService5" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddService_Click5" />
                                                <cc1:ConfirmButtonExtender ID="btnAddService5_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddService5">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel5" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelService_Click5" />
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





        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Upload1_1" />
            <asp:PostBackTrigger ControlID="btnAddService" />
            <asp:PostBackTrigger ControlID="btnAddService2" />
            <asp:PostBackTrigger ControlID="btnAddService3" />
            <asp:PostBackTrigger ControlID="btnAddService4" />
            <asp:PostBackTrigger ControlID="btnAddService5" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>