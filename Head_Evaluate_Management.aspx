<%@ Page Title="EvaluateManagement" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Management.aspx.cs" Inherits="Evaluate_Management" Async="true" %>
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
                                <asp:LinkButton ID="reportSummary" runat="server" Text='' OnClick="reportSummary_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal"
                                        src="Images/Summary.png" width="16" />
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="report1" runat="server" Text='' OnClick="report1_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n1.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report2" runat="server" Text='' OnClick="report2_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n2.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>


                            <td>
                                <asp:LinkButton ID="report3" runat="server" Text='' OnClick="report3_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n3.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>


                            <td>
                                <asp:LinkButton ID="report4" runat="server" Text='' OnClick="report4_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n4.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report5" runat="server" Text='' OnClick="report5_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n5.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report7" runat="server" Text='' OnClick="report7_Click">
                                    <img id="report" alt="" border="0" height="16" name="popcal" src="Images/n7.png"
                                        width="16" />
                                </asp:LinkButton>
                            </td>
                        </tr>

                    </div>
                </div>



                <div>
                    <tr class="lead">
                        <p colspan="5" align="center" class="txt_title_rewards">6. งานบริหารจัดการ</p>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <h5 class="h5" align="left">1. งาน BLM และรับผิดชอบระบบลำเลียงแสง</h5>
                                <tr>
                                    <h5 class="h5" align="left">การบำรุงรักษา ให้บริการ ดำเนินงานวิจัยและพัฒนา ณ
                                        ระบบลำเลียงแสง โดยพิจารณาจากเอกสาร % Utilization</h5>
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

                                                <asp:BoundField HeaderText="รายละเอียด" DataField="projectDescription"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="% Utilization"
                                                    DataField="projectUtilization" ItemStyle-Width="50px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารคำสั่ง" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_Path" runat="server"
                                                            Value='<%# Bind("path") %>'></asp:HiddenField>
                                                        <asp:LinkButton ID="lnkDownload" runat="server"
                                                            CausesValidation="False" OnClick="btnDownload_Click">
                                                            <img id="DownloadManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text=''>
                                                            <img id="DeletManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditManag" runat="server" Text=''
                                                            OnClick="btnEditManag_Click">
                                                            <img id="editManag" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletManag" runat="server" Text=''
                                                            OnClick="btnDeleteManag_Click">
                                                            <img id="DeletManag" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddManag_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletManag">
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
                                        <asp:Button ID="Add6_1_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add6_1_1_Click" />
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
                <asp:Label ID="lblPopupAddManag6_1_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddManag6_1_1" runat="server" TargetControlID="lblPopupAddManag6_1_1"
                    PopupControlID="panelAddManag6_1_1" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddManag6_1_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel6_1_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">การบำรุงรักษา ให้บริการ
                                            ดำเนินงานวิจัยและพัฒนา</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_ManagStatus" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">รายละเอียด
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectDescription" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectDescriptionAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectDescription"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddManag6_1_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">%
                                                    Utilization
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtProjectUtilization" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectUtilizationAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectUtilization"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddManag6_1_1" style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารคำสั่ง :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:FileUpload ID="FileUpload6_1_1" runat="server" EnableTheming="True"
                                                    style="color: #0d0044" />
                                                <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server"
                                                    ErrorMessage="*โปรดเลือกไฟล์" style="color: #ff0000"
                                                    ControlToValidate="FileUpload6_1_1" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddManag6_1_1">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload6_1_1"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddManag6_1_1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError6_1_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddManag" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddManag_Click" />
                                                <cc1:ConfirmButtonExtender ID="btnAddManag_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddManag">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelManag_Click" />
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

                <%-- //###############################EvaluateManag6_1_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateManag6_1_2 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">จำนวนโครงการที่เข้ามาใช้บริการแสงซินโครตรอน
                                        และเครื่องมือวิเคราะห์</h5>
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

                                                <asp:BoundField HeaderText="Beamline" DataField="projectBeamline"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวนโครงการที่ใช้บริการ "
                                                    DataField="projectOfNumber" ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>




                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบรายชื่อโครงการ"
                                                    ShowHeader="False" ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload6_1_2" runat="server"
                                                            OnClick="btnDownload_Click2">
                                                            <img id="DownloadManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton6_1_2" runat="server" Text=''>
                                                            <img id="DeletManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditManag2" runat="server" Text=''
                                                            OnClick="btnEditManag_Click2">
                                                            <img id="editManag2" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletManag2" runat="server" Text=''
                                                            OnClick="btnDeleteManag_Click2">
                                                            <img id="DeletManag2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddManag2_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletManag2">
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
                                        <asp:Button ID="Add6_1_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add6_1_2_Click" />
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
                <asp:Label ID="lblPopupAddManag6_1_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddManag6_1_2" runat="server" TargetControlID="lblPopupAddManag6_1_2"
                    PopupControlID="panelAddManag6_1_2" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddManag6_1_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel6_1_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">จำนวนโครงการที่เข้ามาใช้บริการแสงซินโครตรอน
                                            และเครื่องมือวิเคราะห์</strong></div>
                                    <table align="center" width="100%" class="gray">


                                        <tr>
                                            <asp:HiddenField ID="hdf_ManagStatus2" runat="server" />
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">Beamline
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectBeamline2" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlBeamline2Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlBeamline2Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Manag6-1-2-Beamline' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqBeamline2Add" runat="server"
                                                    ControlToValidate="txtProjectBeamline2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddManag4_3"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนโครงการที่ใช้บริการ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectNumber2" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectNumber2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectNumber2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddManag6_1_2">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบรายชื่อโครงการ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload6_1_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload6_1_2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddManag6_1_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload6_1_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddManag6_1_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError6_1_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddManag2" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddManag_Click2" />
                                                <cc1:ConfirmButtonExtender ID="btnAddManag2_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddManag2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelManag_Click2" />
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

                <%-- //###############################EvaluateManag6_1_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateManag6_2 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">2. การเป็นหัวหน้าโครงการวิจัย และโครงการอุตสาหกรรม</h5>
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

                                                <asp:BoundField HeaderText="ชื่อโครงการ" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="150px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False"
                                                    ItemStyle-Width="100px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload6_2" runat="server"
                                                            OnClick="btnDownload_Click3">
                                                            <img id="DownloadManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton6_2" runat="server" Text=''>
                                                            <img id="DeletManag" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditManag3" runat="server" Text=''
                                                            OnClick="btnEditManag_Click3">
                                                            <img id="editManag3" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletManag3" runat="server" Text=''
                                                            OnClick="btnDeleteManag_Click3">
                                                            <img id="DeletManag3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddManag3_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletManag3">
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
                                        <asp:Button ID="Add6_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add6_2_Click" />
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
                <asp:Label ID="lblPopupAddManag6_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddManag6_2" runat="server" TargetControlID="lblPopupAddManag6_2"
                    PopupControlID="panelAddManag6_2" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddManag6_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel6_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00"> การเป็นหัวหน้าโครงการวิจัย
                                            และโครงการอุตสาหกรรม</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_ManagStatus3" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อโครงการ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectName3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectName3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddManag6_2"></asp:RequiredFieldValidator>
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
                                                    DataSourceID="sqlClass3Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass3Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Manag6-2-Class' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass3Add" runat="server"
                                                    ControlToValidate="txtProjectClass3" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddManag4_3"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>




                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload6_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload6_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddManag6_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload6_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddManag6_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError6_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddManag3" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddManag_Click3" />
                                                <cc1:ConfirmButtonExtender ID="btnAddManag3_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddManag3">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel3" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelManag_Click3" />
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

                <%-- //###############################EvaluateManag6_2 end####################################
###############################################################################################################
##################################################################################################################
##################################################################################################################
//######################################################################################################## --%>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddManag" />
            <asp:PostBackTrigger ControlID="btnAddManag2" />
            <asp:PostBackTrigger ControlID="btnAddManag3" />




        </Triggers>
    </asp:UpdatePanel>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>