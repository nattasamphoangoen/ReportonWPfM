<%@ Page Title="EvaluatePromotionWork" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Promotion_work.aspx.cs" Inherits="Evaluate_Promotion_work" Async="true" %>
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
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/four.png"
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
                        <p colspan="5" align="center" class="txt_title_rewards">4.
                            งานส่งเสริมการใช้ประโยชน์แสงซินโครตรอน</p>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <h5 class="h5" align="left">1. การจัดการประชุมเชิงปฏิบัติการและการฝึกอบรม (Workshop,
                                    Training) </h5>
                                <tr>
                                    <h5 class="h5" align="left">การร่วมเตรียมงาน (ทั้งประธานและคณะทำงาน)</h5>
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
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="จำนวนวันที่ร่วมงาน" DataField="dataNumber"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="เอกสารแต่งตั้ง" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_Path" runat="server"
                                                            Value='<%# Bind("path") %>'></asp:HiddenField>
                                                        <asp:LinkButton ID="lnkDownload" runat="server" Visible="False" 
                                                            CausesValidation="False" OnClick="btnDownload_Click">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click">
                                                            <img id="editPromot" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click">
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot">
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
                                        <asp:Button ID="Add4_1" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_1_Click" />
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
                <asp:Label ID="lblPopupAddPromot4_1" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_1" runat="server" TargetControlID="lblPopupAddPromot4_1"
                    PopupControlID="panelAddPromot4_1" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_1" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">การร่วมเตรียมงาน (ทั้งประธานและคณะทำงาน)</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus" runat="server" />
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
                                                    ValidationGroup="AddPromot4_1" style="color: #ff0000">
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
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-1-Type' AND ddlStatus = 'A' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqTypeAdd" runat="server"
                                                    ControlToValidate="txtProjectType" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_1"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">จำนวนวันที่ร่วมงาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:TextBox ID="txtdateNumber" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqdateNumberAdd" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtdateNumber" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_1"
                                                    style="color: #ff0000">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแต่งตั้ง :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="3">
                                                <asp:FileUpload ID="FileUpload4_1" runat="server" EnableTheming="True"
                                                    style="color: #0d0044" />
                                                <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server"
                                                    ErrorMessage="*โปรดเลือกไฟล์" style="color: #ff0000"
                                                    ControlToValidate="FileUpload4_1" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_1">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload4_1"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_1"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_1" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click" />
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

                <%-- //###############################EvaluatePromot4_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluatePromot4_2 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">2. งานเขียนบทความ (Annual report, Research Highlight,
                                        Annual review, Poster นิทรรศการ)</h5>
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
                                                <asp:BoundField HeaderText="Class" DataField="projectClass"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ/Ref." ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_2" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click2">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_2" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot2" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click2">
                                                            <img id="editPromot2" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot2" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click2">
                                                            <img id="DeletPromot2" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot2_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot2">
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
                                        <asp:Button ID="Add4_2" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_2_Click" />
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
                <asp:Label ID="lblPopupAddPromot4_2" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_2" runat="server" TargetControlID="lblPopupAddPromot4_2"
                    PopupControlID="panelAddPromot4_2" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_2" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">งานเขียนบทความ</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus2" runat="server" />
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
                                                    ValidationGroup="AddPromot4_2"></asp:RequiredFieldValidator>
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
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-2-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType2Add" runat="server"
                                                    ControlToValidate="txtProjectType2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong style="color: #003359">Class
                                                    :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectClass2" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlClass2Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlClass2Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-2-Class' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqClass2Add" runat="server"
                                                    ControlToValidate="txtProjectClass2" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ/Ref. :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_2" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload4_2"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_2"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_2" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot2" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click2" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot2_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot2">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel2" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click2" />
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

                <%-- //###############################EvaluatePromot4_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluatePromot4_3 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">3. การเป็นวิทยากรรับเชิญ (Invited lecturer) (โดยสถาบัน /
                                        หน่วยงานในประเทศ / หน่วยงานต่างประเทศ)</h5>
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

                                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="150px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="60px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ/Ref." ShowHeader="False"
                                                    ItemStyle-Width="100px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_3" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click3">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_3" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot3" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click3">
                                                            <img id="editPromot3" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot3" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click3">
                                                            <img id="DeletPromot3" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot3_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot3">
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
                                        <asp:Button ID="Add4_3" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_3_Click" />
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
                <asp:Label ID="lblPopupAddPromot4_3" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_3" runat="server" TargetControlID="lblPopupAddPromot4_3"
                    PopupControlID="panelAddPromot4_3" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_3" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">การเป็นวิทยากรรับเชิญ (Invited lecturer)</strong>
                                    </div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus3" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic3" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic3"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_3"></asp:RequiredFieldValidator>
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
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-3-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType3Add" runat="server"
                                                    ControlToValidate="txtProjectType3" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_3"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ/Ref. :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_3" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_3" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_3">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload4_3"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_3"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_3" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot3" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click3" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot3_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot3">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel3" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click3" />
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

                <%-- //###############################EvaluatePromot4_3 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluatePromot4_4 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">4. การให้สัมภาษณ์ผ่านสื่อต่าง ๆ เช่น รายการโทรทัศน์
                                        วิทยุ หนังสือพิมพ์ (หากเป็นผลงานกลุ่ม ให้ทีมงานได้คะแนนด้วย)</h5>
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
                                                    ItemStyle-Width="100px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ช่องทางที่นำเสนอ" DataField="projectPresent"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ประเภท" DataField="projectType"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="130px" Font-Size="Small" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="จำนวนสื่อ" DataField="mediaNumber"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="50px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ/Ref." ShowHeader="False"
                                                    ItemStyle-Width="100px">
                                                    <ItemStyle Width="69px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_4" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click4">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_4" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่อผู้ร่วมผลงาน"
                                                    DataField="projectNameJoint" ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot4" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click4">
                                                            <img id="editPromot4" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot4" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click4">
                                                            <img id="DeletPromot4" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot4_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot4">
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
                                        <asp:Button ID="Add4_4" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_4_Click" />
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
                <asp:Label ID="lblPopupAddPromot4_4" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_4" runat="server" TargetControlID="lblPopupAddPromot4_4"
                    PopupControlID="panelAddPromot4_4" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_4" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">การให้สัมภาษณ์ผ่านสื่อต่าง ๆ เช่น รายการโทรทัศน์
                                            วิทยุ หนังสือพิมพ์ (หากเป็นผลงานกลุ่ม ให้ทีมงานได้คะแนนด้วย)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus4" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectTopic4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic4"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_4"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="right" valign="top">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ช่องทางที่นำเสนอ :</strong>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="txtProjectPresent4" runat="server"
                                                    AppendDataBoundItems="True" CssClass="gray"
                                                    DataSourceID="sqlPresent4Add" DataTextField="ddlDisplay"
                                                    DataValueField="ddlDisplay" Width="180" AutoPostBack="False">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="sqlPresent4Add" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-4-Present' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqPresent4Add" runat="server"
                                                    ControlToValidate="txtProjectPresent4" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_4"></asp:RequiredFieldValidator>

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
                                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Promot4-4-Type' ORDER BY id">
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="reqType4Add" runat="server"
                                                    ControlToValidate="txtProjectType4" Display="Dynamic"
                                                    ErrorMessage="*" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_4"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red"></span> <strong
                                                    style="color: #003359">จำนวนสื่อ :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtMediaNumber4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ/Ref. :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_4" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile4Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_4" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_4">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture4" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload4_4"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_4"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td valign="top" align="right">
                                                <span style="color: Red"></span> <strong
                                                    style="color: #003359">ชื่อผู้ร่วมผลงาน :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectNameJoint4" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_4" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot4" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click4" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot4_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot4">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel4" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click4" />
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

                <%-- //###############################EvaluatePromot4_4 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluatePromot4_5 Strat##################################################### --%>


                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">5.
                                        การประสานความร่วมมือเพื่อให้เกิดบันทึกความเข้าใจระหว่างสถาบันกับหน่วยงานอื่น ๆ
                                        (MOU initiation)</h5>
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

                                                <asp:BoundField HeaderText="ชื่อหน่วยงาน" DataField="projectName"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="120px" Font-Size="Small" />
                                                </asp:BoundField>


                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบ/Ref." ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_5" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click5">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_5" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot5" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click5">
                                                            <img id="editPromot5" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot5" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click5">
                                                            <img id="DeletPromot5" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot5_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot5">
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
                                        <asp:Button ID="Add4_5" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_5_Click" />
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
                <asp:Label ID="lblPopupAddPromot4_5" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_5" runat="server" TargetControlID="lblPopupAddPromot4_5"
                    PopupControlID="panelAddPromot4_5" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_5" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong
                                            style="color: #593b00">การประสานความร่วมมือเพื่อให้เกิดบันทึกความเข้าใจระหว่างสถาบันกับหน่วยงานอื่น
                                            ๆ</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus5" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">ชื่อหน่วยงาน
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic5" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectName5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic5"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_5"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>





                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ/Ref. :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_5" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_5" Display="Dynamic"
                                                    SetFocusOnError="True" ValidationGroup="AddPromot4_5">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server"
                                                    style="color: #ff0000" ControlToValidate="FileUpload4_5"
                                                    Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_5"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_5" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot5" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click5" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot5_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot5">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel5" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click5" />
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

                <%-- //###############################EvaluatePromot4_5 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluatePromot4_6 Strat##################################################### --%>

                <div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>

                            <table align="center" width="100%">
                                <tr>
                                    <h5 class="h5" align="left">6.  ข้อเสนอโครงการเพื่องานวิจัยภาคอุตสาหกรรม
                                        (ลงนามสัญญาจ้าง)</h5>
                                </tr>
                                <tr>
                                    <td colspan="6" align="Left">
                                        <asp:GridView ID="gvData6" runat="server" Width="900px" AllowPaging="True"
                                            OnPageIndexChanging="gvData_PageIndexChanging6" AllowSorting="True"
                                            OnSorting="gvData_Sorting6" AutoGenerateColumns="False" CellPadding="5"
                                            OnRowDataBound="gvData_RowDataBound6" ForeColor="#333333" GridLines="None"
                                            DataKeyNames="id" PageSize="50"
                                            OnSelectedIndexChanged="gvData_SelectedIndexChanged6">
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
                                                        <asp:Label ID="lbl_id6" runat="server" Text='<%# Bind("id") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdf_ProjectStatus6" runat="server"
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
                                                <asp:BoundField HeaderText="%ที่ร่วม" DataField="projectJoint"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="80px" Font-Size="Small" />
                                                </asp:BoundField>




                                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore"
                                                    ItemStyle-Width="80px">
                                                    <ItemStyle Width="50px" Font-Size="Small" />
                                                </asp:BoundField>



                                                <asp:TemplateField HeaderText="เอกสารแนบแบ่ง %" ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_6_1" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click6_1">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_6_1" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="เอกสารแนบ/Ref." ShowHeader="False"
                                                    ItemStyle-Width="150px">
                                                    <ItemStyle Width="100px" Font-Size="Small" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload4_6_2" runat="server" Visible="False"
                                                            OnClick="btnDownload_Click6_2">
                                                            <img id="DownloadPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/Dowload.gif" width="16" />
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4_6_2" runat="server" Text=''>
                                                            <img id="DeletPromot" alt="" border="0" height="16"
                                                                name="popcal" src="Images/viwe.gif" width="16" />
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="ชื่อผู้ร่วมผลงาน"
                                                    DataField="projectNameJoint" ItemStyle-Width="80px">
                                                    <ItemStyle Width="90px" Font-Size="Small" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-VerticalAlign="Middle">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditPromot6" runat="server" Text=''
                                                            OnClick="btnEditPromot_Click6">
                                                            <img id="editPromot6" alt="" border="0" height="16"
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
                                                        <asp:LinkButton ID="btnDeletPromot6" runat="server" Text=''
                                                            OnClick="btnDeletePromot_Click6">
                                                            <img id="DeletPromot6" alt="" border="0" height="16"
                                                                name="popcal"
                                                                src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                                                width="16" />
                                                        </asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender
                                                            ID="btnAddPromot6_ConfirmButtonExtender" runat="server"
                                                            ConfirmText="ยืนยันการลบข้อมูล" Enabled="True"
                                                            TargetControlID="btnDeletPromot6">
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
                                        <asp:Button ID="Add4_6" runat="server" CssClass="btn btn-success" Text="Add"
                                            OnClick="Add4_6_Click" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblRecord6" runat="server" Font-Bold="true" CssClass="gray">
                                        </asp:Label>

                                        <br />
                                        <asp:Label ID="lbl6Error0" runat="server" Font-Bold="False" CssClass="red">
                                        </asp:Label>
                                        <br />
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



                <!-- ========================popup========================================================== -->
                <asp:Label ID="lblPopupAddPromot4_6" runat="server" Height="100%" Width="100%"></asp:Label>
                <cc1:ModalPopupExtender ID="popupAddPromot4_6" runat="server" TargetControlID="lblPopupAddPromot4_6"
                    PopupControlID="panelAddPromot4_6" DropShadow="false" BackgroundCssClass="modalBackground"
                    Drag="True">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="panelAddPromot4_6" runat="server" CssClass="gray">
                    <%--style="display:none;"--%>
                    <asp:UpdatePanel ID="UpdatePanel4_6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modalPopup" style="padding: 10px;">
                                <div class="com_address">
                                    <div class="headline" style="text-align: center">
                                        <strong style="color: #593b00">ข้อเสนอโครงการเพื่องานวิจัยภาคอุตสาหกรรม
                                            (ลงนามสัญญาจ้าง)</strong></div>
                                    <table align="center" width="100%" class="gray">

                                        <tr>
                                            <asp:HiddenField ID="hdf_PromotStatus6" runat="server" />
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ
                                                    :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectTopic6" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectTopic6Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectTopic6"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_6"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">%ที่ร่วม :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectJoint6" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqProjectJoint6Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="txtProjectJoint6"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_6"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบแบ่ง % :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_6_1" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile6_1Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_6_1"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_6_1">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture6_1"
                                                    runat="server" style="color: #ff0000"
                                                    ControlToValidate="FileUpload4_6_1" Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_6">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red">*</span> <strong
                                                    style="color: #003359">เอกสารแนบ/Ref. :</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:FileUpload ID="FileUpload4_6_2" runat="server" />
                                                <asp:RequiredFieldValidator ID="reqProjectFile6_2Add" runat="server"
                                                    ErrorMessage="*" ControlToValidate="FileUpload4_6_2"
                                                    Display="Dynamic" SetFocusOnError="True"
                                                    ValidationGroup="AddPromot4_6_2">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="vldUploadDeparture6_2"
                                                    runat="server" style="color: #ff0000"
                                                    ControlToValidate="FileUpload4_6_2" Display="Dynamic"
                                                    ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!"
                                                    SetFocusOnError="True"
                                                    ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$"
                                                    ValidationGroup="AddPromot4_6">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="top" align="right">
                                                <span style="color: Red"></span> <strong
                                                    style="color: #003359">ชื่อผู้ร่วมผลงาน (ถ้ามี):</strong>
                                            </td>
                                            <td valign="top" width="150" colspan="2">
                                                <asp:TextBox ID="txtProjectNameJoint6" runat="server" CssClass="gray"
                                                    Width="180px"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Label ID="lblInError4_6" runat="server" Text="" ForeColor="Red">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6" valign="top">
                                                <asp:Button ID="btnAddPromot6" runat="server" CssClass="txt_howtonav"
                                                    Text="Submit" Width="100px" ValidationGroup="AddColor"
                                                    OnClick="btnAddPromot_Click6" />
                                                <cc1:ConfirmButtonExtender ID="btnAddPromot6_ConfirmButtonExtender"
                                                    runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True"
                                                    TargetControlID="btnAddPromot6">
                                                </cc1:ConfirmButtonExtender>
                                                <asp:Button ID="btnCancel6" runat="server" CausesValidation="False"
                                                    CssClass="txt_howtonav" Text="Cancel" Width="100px"
                                                    OnClick="btnCancelPromot_Click6" />
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

                <%-- //###############################EvaluatePromot4_6 end#####################################################
###############################################################################################################
######################################################################################################################################
######################################################################################################################################## --%>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddPromot" />
            <asp:PostBackTrigger ControlID="btnAddPromot2" />
            <asp:PostBackTrigger ControlID="btnAddPromot3" />
            <asp:PostBackTrigger ControlID="btnAddPromot4" />
            <asp:PostBackTrigger ControlID="btnAddPromot5" />
            <asp:PostBackTrigger ControlID="btnAddPromot6" />


        </Triggers>
    </asp:UpdatePanel>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>