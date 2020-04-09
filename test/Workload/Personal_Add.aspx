<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Personal_Add.aspx.cs"
    Inherits="Personal_Add" Culture="en-US" Debug="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" width="770" class="gray">
                <tr>
                    <td width="180">
                    </td>
                    <td width="200">
                    </td>
                    <td width="180">
                    </td>
                    <td width="200">
                    </td>
                    <td width="10">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" class="txt_title_rewards">
                        เพิ่มข้อมูลผู้มาติดต่อโรงงาน
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="right">
                    </td>
                    <td valign="top" colspan="3">
                        <asp:RadioButtonList ID="radSSDType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="radSSDType_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">บัตรประชาชน</asp:ListItem>
                            <asp:ListItem Value="2">ใบขับขี่</asp:ListItem>
                            <asp:ListItem Value="3">หนังสือเดินทาง</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>รหัสประจำตัว :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtSSD" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtSSD_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtSSD" ValidChars="1234567890">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="reqSSD" runat="server" ErrorMessage="*" ControlToValidate="txtSSD"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>คำนำหน้าชื่อ :</strong>
                    </td>
                    <td valign="top" >
                        <asp:RadioButtonList ID="radTitle" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="radTitle_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">นาย</asp:ListItem>
                            <asp:ListItem Value="2">นาง</asp:ListItem>
                            <asp:ListItem Value="3">นาวสาว</asp:ListItem>
                            <asp:ListItem Value="4">อื่นๆ</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="gray" Width="180px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>ชื่อ :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqFirstname" runat="server" ErrorMessage="*" ControlToValidate="txtFirstname"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>นามสกุล :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtLastname" runat="server" CssClass="gray" Width="180"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqLastname" runat="server" ControlToValidate="txtLastname"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <%--<tr>
                    <td align="right" valign="top">
                        <strong>ศาสนา :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtReligion" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td align="right" valign="top">
                        <strong>สถานที่เกิด :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtBirthplace" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td valign="top">
                    </td>
                </tr>--%>
                <tr>
                    <td align="right" valign="top">
                        <strong>วัน/เดือน/ปี เกิด :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtBirthday" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBirthday_CalendarExtender" runat="server" Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtBirthday">
                        </cc1:CalendarExtender>
                    </td>
                    <td align="right" valign="top">
                        &nbsp;</td>
                    <td valign="top">
                        &nbsp;</td>                                        
                    <td valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>ตำแหน่งงาน :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtPosition" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td align="right" valign="top">
                        <strong>วุฒิการศึกษา :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtEducation" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>กลุ่มงาน :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlWorkgroup" runat="server" AppendDataBoundItems="True" CssClass="gray"
                            DataSourceID="sqlWorkgroup" DataTextField="WORKGROUP_NAME" DataValueField="WORKGROUP_ID"
                            Width="180px" Height="16px" >
                            <asp:ListItem Value="-">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlWorkgroup" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT WORKGROUP_ID, WORKGROUP_NAME FROM MASTER_WORKGROUP WHERE WORKGROUP_STATUS ='Y'  ORDER BY WORKGROUP_ID">
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="reqCountry0" runat="server" ControlToValidate="ddlWorkgroup" Display="Dynamic" ErrorMessage="*" InitialValue="-" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="top">
                        <strong>สังกัดผู้รับเหมา :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlContracter" runat="server" AppendDataBoundItems="True" CssClass="gray"
                            DataSourceID="sqlContracter" DataTextField="CONTRACTOR_NAME" DataValueField="CONTRACTOR_ID"
                            Width="180" >
                            <asp:ListItem Value="-">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlContracter" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT CONTRACTOR_ID, CONTRACTOR_NAME FROM MASTER_CONTRACTOR WHERE CONTRACTOR_STATUS ='Y'  ORDER BY CONTRACTOR_NAME">
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="reqCountry1" runat="server" ControlToValidate="ddlContracter" Display="Dynamic" ErrorMessage="*" InitialValue="-" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>เวลาการทำงาน :</strong>
                    </td>
                    <td valign="top" colspan="3">
                        <asp:RadioButtonList ID="radWorkTimeType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Day Time</asp:ListItem>
                            <asp:ListItem Value="2">เป็นกะ</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="txtWorkTimeDetail" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
                <%--<tr>
                    <td align="right" valign="top">
                        <strong>ผลการประเมินเกรด :</strong>
                    </td>
                    <td valign="top" colspan="3">
                        <asp:RadioButtonList ID="radGrade" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem Value="A">ดีเยี่ยม</asp:ListItem>
                            <asp:ListItem Value="B">ดี</asp:ListItem>
                            <asp:ListItem Value="C">ปานกลาง</asp:ListItem>
                            <asp:ListItem Value="F">แย่มาก</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td valign="top">
                    </td>
                </tr>--%>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>ที่อยู่/เลขที่ :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqAddress" runat="server" ErrorMessage="*" ControlToValidate="txtAddress"
                            Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="top">
                        <strong>
                            <%--<span style="color: Red">*</span>--%>ถนน :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="gray" Width="180"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="reqStreet" runat="server" ControlToValidate="txtStreet"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>อาคาร/หมู่บ้าน :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtBuilding" runat="server" CssClass="gray" Width="180"></asp:TextBox>
                    </td>
                    <td align="right" valign="top">
                        <strong>ชั้น :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtFloor" runat="server" CssClass="gray" Width="180"></asp:TextBox>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>ประเทศ :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="True" CssClass="gray"
                            DataSourceID="sqlCountry" DataTextField="COUNTRY_NAME" DataValueField="COUNTRY_ID"
                            Width="185px" Enabled="False" Height="16px">
                            <asp:ListItem Value="-">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="ddlCountry"
                            Display="Dynamic" ErrorMessage="*" InitialValue="-" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="sqlCountry" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT COUNTRY_ID, COUNTRY_NAME FROM MASTER_COUNTRY ORDER BY COUNTRY_NAME">
                        </asp:SqlDataSource>
                    </td>
                    <td align="right" valign="top">
                        <strong><span>
                            <asp:Label ID="lbRegion" runat="server" Style="color: Red" Text="*"></asp:Label></span>ภูมิภาค
                            :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="gray" Width="180px" AutoPostBack="True"
                            AppendDataBoundItems="True" DataSourceID="sqlRegion" DataTextField="REGION_NAME_TH"
                            DataValueField="REGION_ID" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            <asp:ListItem Value="0">-เลือก -</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlRegion" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT [REGION_ID], [REGION_NAME_TH] FROM [MASTER_REGION]"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="reqRegion" runat="server" ControlToValidate="ddlRegion"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>จังหวัด :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="gray" Width="180px" AutoPostBack="True"
                            AppendDataBoundItems="True" DataSourceID="sqlState" DataTextField="PROVINCE_NAME_TH"
                            DataValueField="PROVINCE_ID" Enabled="False" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="0">-เลือก -</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlState" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT [PROVINCE_ID], [PROVINCE_NAME_TH] FROM [MASTER_PROVINCE] WHERE ([REGION_ID] = @RegionID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlRegion" Name="RegionID" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="reqState" runat="server" ControlToValidate="ddlState"
                            Display="Dynamic" ErrorMessage="*" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="top">
                        <strong><span style="color: Red">*</span>เขต/อำเภอ :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="gray" Width="180px" AutoPostBack="True"
                            AppendDataBoundItems="True" DataSourceID="sqlCity" DataTextField="AMPHUR_NAME_TH"
                            DataValueField="AMPHUR_ID" Enabled="False" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            <asp:ListItem Value="0">-เลือก -</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlCity" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT [AMPHUR_ID], [AMPHUR_NAME_TH] FROM [MASTER_AMPHUR] WHERE ([PROVINCE_ID] = @ProvinceID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlState" Name="ProvinceID" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="reqCity" runat="server" ControlToValidate="ddlCity"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong><span>
                            <asp:Label ID="lbTumbon" runat="server" Style="color: Red" Text="*"></asp:Label></span>แขวง/ตำบล
                            :</strong>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlTumbon" runat="server" CssClass="gray" Width="180px" AppendDataBoundItems="True"
                            DataSourceID="sqlTumbon" DataTextField="DISTRICT_NAME_TH" DataValueField="DISTRICT_ID"
                            Enabled="False">
                            <asp:ListItem Value="0">-เลือก -</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="sqlTumbon" runat="server" ConnectionString="<%$ ConnectionStrings:CDConnectionString %>"
                            SelectCommand="SELECT [DISTRICT_ID], [DISTRICT_NAME_TH] FROM [MASTER_DISTRICT] WHERE ([AMPHUR_ID] = @AmphurID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlCity" Name="AmphurID" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td align="right" valign="top">
                        <strong>รหัสไปรษณีย์ :</strong>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtPostcode" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        &nbsp;
                    </td>
                    <td valign="top" colspan="3">
                        
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>Note :</strong>
                    </td>
                    <td colspan="3" valign="top">
                        <asp:TextBox ID="txtNote" runat="server" Rows="3" TextMode="MultiLine" CssClass="gray"
                            Width="300px"></asp:TextBox>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td align="right" valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <%--<tr>
                    <td align="right" valign="top">
                        <strong>เบอร์สำนักงาน :</strong>
                    </td>
                    <td colspan="2" valign="top">
                        <asp:GridView ID="gvOfficeTel" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            GridLines="None" ShowHeader="False" Width="290px">
                            <Columns>
                                <asp:TemplateField HeaderText="TelNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOfficeTelNo" runat="server" CssClass="gray" MaxLength="20" Text="<%# Bind('TelNo') %>"
                                            Width="90px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldOfficeTelNo" runat="server" FilterType="Numbers"
                                            TargetControlID="txtOfficeTelNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TelTo">
                                    <ItemTemplate>
                                        To&nbsp;
                                        <asp:TextBox ID="txtOfficeTelTo" runat="server" CssClass="gray" MaxLength="20" Text="<%# Bind('TelTo') %>"
                                            Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldOfficeTelTo" runat="server" FilterType="Numbers"
                                            TargetControlID="txtOfficeTelTo">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TelExt">
                                    <ItemTemplate>
                                        Ext&nbsp;
                                        <asp:TextBox ID="txtOfficeTelExt" runat="server" CssClass="gray" MaxLength="10" Text="<%# Bind('TelExt') %>"
                                            Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldOfficeTelExt" runat="server" FilterType="Numbers"
                                            TargetControlID="txtOfficeTelExt">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="90px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddOfficeTel" runat="server" CssClass="txt_howtonav" OnClick="btnAddOfficeTel_Click"
                            Text="+" ValidationGroup="Office" />
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>โทรสาร(Fax) :</strong>
                    </td>
                    <td colspan="2" valign="top">
                        <asp:GridView ID="gvFaxTel" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            GridLines="None" ShowHeader="False" Width="200px">
                            <Columns>
                                <asp:TemplateField HeaderText="TelNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFaxTelNo" runat="server" CssClass="gray" MaxLength="20" Text="<%# Bind('TelNo') %>"
                                            Width="90px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldFaxTelNo" runat="server" FilterType="Numbers"
                                            TargetControlID="txtFaxTelNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TelTo">
                                    <ItemTemplate>
                                        To&nbsp;
                                        <asp:TextBox ID="txtFaxTelTo" runat="server" CssClass="gray" MaxLength="20" Text="<%# Bind('TelTo') %>"
                                            Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldFaxTelTo" runat="server" FilterType="Numbers"
                                            TargetControlID="txtFaxTelTo">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddFaxTel" runat="server" CssClass="txt_howtonav" OnClick="btnAddFaxTel_Click"
                            Text="+" ValidationGroup="Fax" />
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>โทรศัพท์เคลื่อนที่ :</strong>
                    </td>
                    <td colspan="2" valign="top">
                        <asp:GridView ID="gvMobileTel" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            GridLines="None" ShowHeader="False" Width="120px">
                            <Columns>
                                <asp:TemplateField HeaderText="TelNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMobileTelNo" runat="server" CssClass="gray" MaxLength="20" Text="<%# Bind('TelNo') %>"
                                            Width="90px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="vldMobileTelNo" runat="server" FilterType="Numbers"
                                            TargetControlID="txtMobileTelNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnAddMobileTel" runat="server" CssClass="txt_howtonav" OnClick="btnAddMobileTel_Click"
                            Text="+" ValidationGroup="Mobile" />
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>--%>
                <tr>
                    <td align="right" valign="top">
                        <strong>รูปภาพ :</strong>
                    </td>
                    <td valign="top" colspan="3">
                        <asp:Label ID="lblWarnDeparture" runat="server" CssClass="gray" Text="ขนาดไฟล์ไม่เกิน 300k. (เฉพาะไฟล์ jpg, jpeg)"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddl_img_type" runat="server" CssClass="gray">
                            <asp:ListItem Value="-1">- เลือก -</asp:ListItem>
                            <asp:ListItem Value="1">รูปประจำตัว</asp:ListItem>
                            <asp:ListItem Value="2">รูปบัตรประจำตัว</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:TextBox ID="txtUploadDescription" runat="server" CssClass="gray" Rows="3" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        <br />
                        <asp:FileUpload ID="fuUploadImg" runat="server" CssClass="txt_howtonav" EnableTheming="True" />
                        <asp:Button ID="ButtonUploadImg" runat="server" CssClass="txt_howtonav" OnClick="ButtonUploadDeparture_Click" Text="Upload" ValidationGroup="Departure" />
                        <asp:RequiredFieldValidator ID="reqUploadDeparture" runat="server" ControlToValidate="fuUploadImg" Display="Dynamic" ErrorMessage="โปรดเลือกใช้ไฟล์ภาพตามที่กำหนด" SetFocusOnError="True" ValidationGroup="Departure"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server" ControlToValidate="fuUploadImg" Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (.jpg, .jpeg)!!" SetFocusOnError="True" ValidationExpression="^.+\.((jpg)|(JPG)|(jpeg)|(JPEG))$" ValidationGroup="Departure"></asp:RegularExpressionValidator>
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                    </td>
                    <td valign="top" colspan="3">
                        <asp:Label ID="lblUploadStatus" runat="server" CssClass="gray" Text="ขนาดไฟล์ไม่เกิน 300k. (เฉพาะไฟล์ jpg, jpeg)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">&nbsp;</td>
                    <td colspan="3" valign="top">
                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvData_RowCommand" Width="510px">
                            <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="Last&amp;gt;&amp;gt;" NextPageText="Next&amp;gt;" PreviousPageText="&amp;lt;Previous" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#FFFFFF" CssClass="gray" ForeColor="#333333" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#DEDEFF" CssClass="gray" HorizontalAlign="Center" Wrap="True" />
                            <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#ABCDEF" CssClass="txt_howtonav" Font-Bold="True" Font-Size="Small" ForeColor="#005aa9" HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray" HorizontalAlign="Left" />
                            <Columns>
                                <asp:TemplateField HeaderText="No." ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image" ItemStyle-Width="220px">
                                    <ItemTemplate>
                                        <asp:Image ID="imgUploadPic" runat="server" ImageUrl='<%# "./" + Eval("FilePath") %>' Width="220px" />
                                    </ItemTemplate>
                                    <ItemStyle Width="220px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image Info." ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" CssClass="gray" Text='<%# Eval("FileName", "FileName : {0}") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblMediaType" runat="server" CssClass="gray" Text='<%# Eval("MediaType", "Upload Type : {0}") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblDescription" runat="server" CssClass="gray" Text='<%# Eval("Description", "Description : {0}") %>'></asp:Label>
                                        <br />
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnAddCart" runat="server" AlternateText="remove" BorderWidth="0" CausesValidation="False" CommandArgument=" <%# Container.DataItemIndex %>" CommandName="RemoveImg" ImageUrl="./images/bnt_close.png" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Label ID="lblError" runat="server" CssClass="red" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:Button ID="btnSubmit1" runat="server" CssClass="txt_howtonav" OnClick="btnSubmit1_Click"
                            Text="Submit" Width="100px" />
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                            OnClick="btnCancel_Click" Text="Cancel" Width="100px" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonUploadImg" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
