<%@ Page Title="Evaluate_Research" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Research.aspx.cs" Inherits="Evaluate_Research" Async="true" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .modalBackground
        {
            background-color: ##f8b1cf;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        
        .modalPopup
        {
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
                body, html {
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
                        <asp:LinkButton ID="report1" runat="server" Text='' OnClick="report1_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n1.png" width="16" /> 
                        </asp:LinkButton>
                    </td> 

                    <td>
                        <asp:LinkButton ID="report2" runat="server" Text='' OnClick="report2_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n2.png" width="16" /> 
                        </asp:LinkButton>
                    </td> 
                    
                    <td>
                        <asp:LinkButton ID="report4" runat="server" Text='' OnClick="report4_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n4.png" width="16" /> 
                        </asp:LinkButton>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="report5" runat="server" Text='' OnClick="report5_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n5.png" width="16" /> 
                        </asp:LinkButton>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="report6" runat="server" Text='' OnClick="report6_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n6.png" width="16" /> 
                        </asp:LinkButton>
                    </td>
                    
                    <td>
                        <asp:LinkButton ID="report7" runat="server" Text='' OnClick="report7_Click">
                        <img id="report" alt="" border="0" height="16" name="popcal"
                         src="Images/n7.png" width="16" /> 
                        </asp:LinkButton>
                    </td>
                    </tr>
    
                </div>
            </div>

                

    <div>
        <tr class="lead">
            <p colspan="5" align="center" class="txt_title_rewards">3. งานวิจัย (ภาควิชาการ, ภาคอุตสาหกรรม)</p>
        </tr>
         <tr>
            <td>&nbsp;</td>                                               
         </tr>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <h5 class = "h5" align="left" >1. Journal publication (ISI/Scopus)</h5>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging"
                            AllowSorting="True" OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
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
                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus" runat="server" Value='<%# Bind("id") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>   
                                                             
                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic" ItemStyle-Width="80px" >
                                    <ItemStyle Width="60px"  Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="projectType" ItemStyle-Width="80px" >
                                    <ItemStyle Width="120px" Font-Size="Small"/>
                                </asp:BoundField>

                               
                                <asp:BoundField HeaderText="Q" DataField="projectQ" ItemStyle-Width="50px" >
                                    <ItemStyle Width="60px" Font-Size="Small" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore" ItemStyle-Width="80px" >
                                    <ItemStyle Width="60px" Font-Size="Small" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False" ItemStyle-Width="150px">
                                <ItemStyle Width="100px" Font-Size="Small" />
                                <ItemTemplate>
                                        <asp:HiddenField ID="hdf_Path" runat="server" Value='<%# Bind("path") %>'></asp:HiddenField>
                                        <asp:LinkButton ID="lnkDownload" runat="server"  CausesValidation="False" OnClick="btnDownload_Click">
                                            <img id="DownloadResearch" alt="" border="0" height="16" name="popcal" src="Images/Dowload.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton3" runat="server" Text='' >
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/viwe.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                </ItemTemplate>
                                </asp:TemplateField>

                              
                               <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditResearch" runat="server" Text=''
                                            OnClick="btnEditResearch_Click">
                                            <img id="editResearch" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_edit_16x16_9821.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="2px" />
                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletResearch" runat="server" Text=''
                                            OnClick="btnDeleteResearch_Click">
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                        <cc1:ConfirmButtonExtender  ID="btnAddResearch_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการลบข้อมูล" Enabled="True" 
                                        TargetControlID="btnDeletResearch" >
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
                        <asp:Button ID="Add3_1" runat="server" CssClass="btn btn-success" 
                            Text="Add" OnClick="Add3_1_Click"/>
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



<!-- ========================popup========================================================== -->
<asp:Label ID="lblPopupAddResearch3_1" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddResearch3_1" runat="server" TargetControlID="lblPopupAddResearch3_1"
        PopupControlID="panelAddResearch3_1" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddResearch3_1" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel3_1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong style="color: #593b00">Journal publication (ISI/Scopus)</strong></div>
                        <table align="center" width="100%" class="gray">
                            
                            <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="3">
                                    <asp:TextBox ID="txtProjectTopic" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectTopicAdd" runat="server" ErrorMessage="*" ControlToValidate="txtProjectTopic"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_1" style="color: #ff0000"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                             <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ประเภท :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectType" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlTypeAdd" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlTypeAdd" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-1-Type' AND ddlStatus = 'A' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqTypeAdd" runat="server" ControlToValidate="txtProjectType"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_1"></asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
      
                             <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">Q :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectQ" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlQAdd" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlQAdd" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-1-Q' AND ddlStatus = 'A' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqQAdd" runat="server" ControlToValidate="txtProjectQ"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_1"></asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
 
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารแนบ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="3">
                                    <asp:FileUpload ID="FileUpload3_1" runat="server" EnableTheming="True" style="color: #0d0044"/>
                                    <asp:RequiredFieldValidator ID="reqProjectFileAdd" runat="server" ErrorMessage="*โปรดเลือกไฟล์"  style="color: #ff0000" ControlToValidate="FileUpload3_1"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_1"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="vldUploadDeparture" runat="server" style="color: #ff0000" ControlToValidate="FileUpload3_1" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_1"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError3_1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddResearch" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddResearch_Click" />
                                    <cc1:ConfirmButtonExtender ID="btnAddResearch_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddResearch" >
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelResearch_Click" />
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

<%-- //###############################EvaluateResearch3_1 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateResearch3_2 Strat##################################################### --%>


<div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <h5 class = "h5" align="left" >2. Conference proceeding</h5>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData2" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging2"
                            AllowSorting="True" OnSorting="gvData_Sorting2" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound2"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged2">
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
                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id2" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus2" runat="server" Value='<%# Bind("id") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>   
                                                             
                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic" ItemStyle-Width="150px">
                                    <ItemStyle Width="120px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="projectType" ItemStyle-Width="80px">
                                    <ItemStyle Width="50px" Font-Size="Small" />
                                </asp:BoundField>

                              

                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore" ItemStyle-Width="80px">
                                    <ItemStyle Width="60px" Font-Size="Small" />
                                </asp:BoundField>

                               
                               
                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False" ItemStyle-Width="150px">
                                <ItemStyle Width="100px" Font-Size="Small" />
                                <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload3_2" runat="server" OnClick="btnDownload_Click2">
                                            <img id="DownloadResearch" alt="" border="0" height="16" name="popcal" src="Images/Dowload.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton3_2" runat="server" Text='' >
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/viwe.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                </ItemTemplate>
                                </asp:TemplateField>
                               
                               <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditResearch2" runat="server" Text=''
                                            OnClick="btnEditResearch_Click2">
                                            <img id="editResearch2" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_edit_16x16_9821.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="2px" />
                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletResearch2" runat="server" Text=''
                                            OnClick="btnDeleteResearch_Click2">
                                            <img id="DeletResearch2" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                        <cc1:ConfirmButtonExtender  ID="btnAddResearch2_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการลบข้อมูล" Enabled="True" 
                                        TargetControlID="btnDeletResearch2" >
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
                        <asp:Button ID="Add3_2" runat="server" CssClass="btn btn-success" 
                            Text="Add" OnClick="Add3_2_Click"/>
                    </td>
                </tr>

               <tr>
                    <td colspan="6" align="center">
                        <asp:Label ID="lblRecord2" runat="server" Font-Bold="true" CssClass="gray"></asp:Label>
                        
                        <br />
                        <asp:Label ID="lbl2Error0" runat="server" Font-Bold="False" CssClass="red"></asp:Label>
                        <br />
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>    
    </div> 



<!-- ========================popup========================================================== -->
<asp:Label ID="lblPopupAddResearch3_2" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddResearch3_2" runat="server" TargetControlID="lblPopupAddResearch3_2"
        PopupControlID="panelAddResearch3_2" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddResearch3_2" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel3_2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong style="color: #593b00">Conference proceeding</strong></div>
                        <table align="center" width="100%" class="gray">
                            
                            <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus2" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectTopic2" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectName2Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectTopic2"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>      

                           <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ประเภท :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectType2" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlType2Add" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlType2Add" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-2-Type' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqType2Add" runat="server" ControlToValidate="txtProjectType3"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_2"></asp:RequiredFieldValidator>
                                    
                                </td>
                                </tr>

                          
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารแนบ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:FileUpload ID="FileUpload3_2" runat="server"  />
                                    <asp:RequiredFieldValidator ID="reqProjectFile2Add" runat="server" ErrorMessage="*" ControlToValidate="FileUpload3_2"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_2"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="vldUploadDeparture2" runat="server" style="color: #ff0000" ControlToValidate="FileUpload3_2" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_2"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError3_2" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddResearch2" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddResearch_Click2" />
                                    <cc1:ConfirmButtonExtender ID="btnAddResearch2_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddResearch2">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel2" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelResearch_Click2" />
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

    <%-- //###############################EvaluateResearch3_2 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateResearch3_3 Strat##################################################### --%>

<div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <h5 class = "h5" align="left" >3. ยื่นขอจดสิทธิบัตร (ปตท. / ไทย) /  ยื่นขอจดอนุสิทธิบัตร</h5>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData3" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging3"
                            AllowSorting="True" OnSorting="gvData_Sorting3" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound3"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged3">
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
                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id3" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus3" runat="server" Value='<%# Bind("id") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>   
                                                             
                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic" ItemStyle-Width="150px">
                                    <ItemStyle Width="120px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="projectType" ItemStyle-Width="80px">
                                    <ItemStyle Width="50px" Font-Size="Small" />
                                </asp:BoundField>

                              

                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore" ItemStyle-Width="80px">
                                    <ItemStyle Width="60px" Font-Size="Small" />
                                </asp:BoundField>

                               
                               
                                <asp:TemplateField HeaderText="เอกสารตอบรับ/ยื่นจด" ShowHeader="False" ItemStyle-Width="150px">
                                <ItemStyle Width="100px" Font-Size="Small" />
                                <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload3_3" runat="server" OnClick="btnDownload_Click3">
                                            <img id="DownloadResearch" alt="" border="0" height="16" name="popcal" src="Images/Dowload.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton3_3" runat="server" Text='' >
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/viwe.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                </ItemTemplate>
                                </asp:TemplateField>
                               
                               <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditResearch3" runat="server" Text=''
                                            OnClick="btnEditResearch_Click3">
                                            <img id="editResearch3" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_edit_16x16_9821.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="2px" />
                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletResearch3" runat="server" Text=''
                                            OnClick="btnDeleteResearch_Click3">
                                            <img id="DeletResearch3" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                        <cc1:ConfirmButtonExtender  ID="btnAddResearch3_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการลบข้อมูล" Enabled="True" 
                                        TargetControlID="btnDeletResearch3" >
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
                        <asp:Button ID="Add3_3" runat="server" CssClass="btn btn-success" 
                            Text="Add" OnClick="Add3_3_Click"/>
                    </td>
                </tr>

               <tr>
                    <td colspan="6" align="center">
                        <asp:Label ID="lblRecord3" runat="server" Font-Bold="true" CssClass="gray"></asp:Label>
                        
                        <br />
                        <asp:Label ID="lbl3Error0" runat="server" Font-Bold="False" CssClass="red"></asp:Label>
                        <br />
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>    
    </div> 



<!-- ========================popup========================================================== -->
<asp:Label ID="lblPopupAddResearch3_3" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddResearch3_3" runat="server" TargetControlID="lblPopupAddResearch3_3"
        PopupControlID="panelAddResearch3_3" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddResearch3_3" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel3_3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong style="color: #593b00">ยื่นขอจดสิทธิบัตร (ปตท. / ไทย) /  ยื่นขอจดอนุสิทธิบัตร</strong></div>
                        <table align="center" width="100%" class="gray">
                            
                            <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus3" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectTopic3" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectName3Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectTopic3"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_3"></asp:RequiredFieldValidator>
                                </td>
                            </tr>      

                           <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ประเภท :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectType3" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlType3Add" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlType3Add" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-3-Type' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqType3Add" runat="server" ControlToValidate="txtProjectType3"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_3"></asp:RequiredFieldValidator>
                                    
                                </td>
                                </tr>

                          
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารตอบรับ/่ยื่นจด :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:FileUpload ID="FileUpload3_3" runat="server"  />
                                    <asp:RequiredFieldValidator ID="reqProjectFile3Add" runat="server" ErrorMessage="*" ControlToValidate="FileUpload3_3"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_3"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="vldUploadDeparture3" runat="server" style="color: #ff0000" ControlToValidate="FileUpload3_3" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_3"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError3_3" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddResearch3" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddResearch_Click3" />
                                    <cc1:ConfirmButtonExtender ID="btnAddResearch3_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddResearch3">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel3" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelResearch_Click3" />
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

    <%-- //###############################EvaluateResearch3_3 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateResearch3_4 Strat##################################################### --%>

<div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <h5 class = "h5" align="left" >4. Oral  (ตปท./ไทย) / Poster Presentation (ตปท./ไทย)</h5>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData4" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging4"
                            AllowSorting="True" OnSorting="gvData_Sorting4" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvData_RowDataBound4"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged4">
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
                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id4" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus4" runat="server" Value='<%# Bind("id") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>   
                                                             
                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic" ItemStyle-Width="150px">
                                    <ItemStyle Width="120px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="หน่วยงานที่จัด" DataField="projectAgency" ItemStyle-Width="80px">
                                    <ItemStyle Width="120px" Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ระดับการจัดงาน" DataField="projectLevel" ItemStyle-Width="80px">
                                    <ItemStyle Width="60px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="projectType" ItemStyle-Width="120px">
                                    <ItemStyle Width="120px" Font-Size="Small" />
                                </asp:BoundField>

                              

                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore" ItemStyle-Width="80px">
                                    <ItemStyle Width="50px" Font-Size="Small" />
                                </asp:BoundField>

                               
                               
                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False" ItemStyle-Width="150px">
                                <ItemStyle Width="100px" Font-Size="Small" />
                                <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload3_4" runat="server" OnClick="btnDownload_Click4">
                                            <img id="DownloadResearch" alt="" border="0" height="16" name="popcal" src="Images/Dowload.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton3_4" runat="server" Text='' >
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/viwe.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                </ItemTemplate>
                                </asp:TemplateField>
                               
                               <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditResearch4" runat="server" Text=''
                                            OnClick="btnEditResearch_Click4">
                                            <img id="editResearch4" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_edit_16x16_9821.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="2px" />
                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletResearch4" runat="server" Text=''
                                            OnClick="btnDeleteResearch_Click4">
                                            <img id="DeletResearch4" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                        <cc1:ConfirmButtonExtender  ID="btnAddResearch4_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการลบข้อมูล" Enabled="True" 
                                        TargetControlID="btnDeletResearch4" >
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
                        <asp:Button ID="Add3_4" runat="server" CssClass="btn btn-success" 
                            Text="Add" OnClick="Add3_4_Click"/>
                    </td>
                </tr>

               <tr>
                    <td colspan="6" align="center">
                        <asp:Label ID="lblRecord4" runat="server" Font-Bold="true" CssClass="gray"></asp:Label>
                        
                        <br />
                        <asp:Label ID="lbl4Error0" runat="server" Font-Bold="False" CssClass="red"></asp:Label>
                        <br />
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>    
    </div> 



<!-- ========================popup========================================================== -->
<asp:Label ID="lblPopupAddResearch3_4" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddResearch3_4" runat="server" TargetControlID="lblPopupAddResearch3_4"
        PopupControlID="panelAddResearch3_4" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddResearch3_4" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel3_4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong style="color: #593b00">Oral  (ตปท./ไทย) / Poster Presentation (ตปท./ไทย)</strong></div>
                        <table align="center" width="100%" class="gray">
                            
                            <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus4" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectTopic4" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectName4Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectTopic4"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_4"></asp:RequiredFieldValidator>
                                </td>
                            </tr>     
                            <tr>
                               
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หน่วยงานที่จัด :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectAgency4" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectAgency4Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectAgency4"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_4"></asp:RequiredFieldValidator>
                                </td>
                            </tr> 
                            <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ระดับการจัดงาน :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectLevel4" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlLevel4Add" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlLevel4Add" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-4-Level' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqLevel4Add" runat="server" ControlToValidate="txtProjectLevel4"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_4"></asp:RequiredFieldValidator>
                                    
                                </td>
                                </tr>
                              

                           <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ประเภท :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectType4" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlType4Add" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlType4Add" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Research3-4-Type' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqType4Add" runat="server" ControlToValidate="txtProjectType4"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_4"></asp:RequiredFieldValidator>
                                    
                                </td>
                                </tr>

                          
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารแนบ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:FileUpload ID="FileUpload3_4" runat="server"  />
                                    <asp:RequiredFieldValidator ID="reqProjectFile4Add" runat="server" ErrorMessage="*" ControlToValidate="FileUpload3_4"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_4"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="vldUploadDeparture4" runat="server" style="color: #ff0000" ControlToValidate="FileUpload3_4" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_4"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError3_4" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddResearch4" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddResearch_Click4" />
                                    <cc1:ConfirmButtonExtender ID="btnAddResearch4_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddResearch4">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel4" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelResearch_Click4" />
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

    <%-- //###############################EvaluateResearch3_4 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateResearch3_5 Strat##################################################### --%>
<div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <h5 class = "h5" align="left" >5. รายงานฉบับสมบูรณ์ (ภาควิชาการ ภาคอุตสาหกรรม)</h5>
                </tr>
                <tr>
                    <td colspan="6" align="Left">
                        <asp:GridView ID="gvData5" runat="server" Width="900px" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging5"
                            AllowSorting="True" OnSorting="gvData_Sorting5" AutoGenerateColumns="False" CellPadding="5" OnRowDataBound="gvData_RowDataBound5"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged5">
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
                                <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_id5" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ที่" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdf_ProjectStatus5" runat="server" Value='<%# Bind("id") %>'></asp:HiddenField>
                                        <asp:Label ID="lbl_DataItemIndex" runat="server" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small" ></asp:Label>
                                        <%--<%# Container.DataItemIndex + 1 %>--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>   
                                                             
                                <asp:BoundField HeaderText="หัวข้อ" DataField="projectTopic" ItemStyle-Width="150px">
                                    <ItemStyle Width="120px" Font-Size="Small"/>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="projectType" ItemStyle-Width="80px">
                                    <ItemStyle Width="120px" Font-Size="Small" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="%ที่ร่วม" DataField="projectJoint" ItemStyle-Width="80px">
                                    <ItemStyle Width="60px" Font-Size="Small"/>
                                </asp:BoundField>
                                                             

                                <asp:BoundField HeaderText="คะแนน" DataField="projectScore" ItemStyle-Width="80px">
                                    <ItemStyle Width="50px" Font-Size="Small" />
                                </asp:BoundField>

                               
                               
                                <asp:TemplateField HeaderText="เอกสารแนบ" ShowHeader="False" ItemStyle-Width="150px">
                                <ItemStyle Width="100px" Font-Size="Small" />
                                <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload3_5" runat="server" OnClick="btnDownload_Click5">
                                            <img id="DownloadResearch" alt="" border="0" height="16" name="popcal" src="Images/Dowload.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton3_5" runat="server" Text='' >
                                            <img id="DeletResearch" alt="" border="0" height="16" name="popcal" src="Images/viwe.gif"
                                        width="16" />
                                        </asp:LinkButton>

                                </ItemTemplate>
                                </asp:TemplateField>
                               
                               <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditResearch5" runat="server" Text=''
                                            OnClick="btnEditResearch_Click5">
                                            <img id="editResearch5" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_edit_16x16_9821.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="2px" />
                                </asp:TemplateField>

                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletResearch5" runat="server" Text=''
                                            OnClick="btnDeleteResearch_Click5">
                                            <img id="DeletResearch5" alt="" border="0" height="16" name="popcal" src="Images/iconfinder_trash_(delete)_16x16_10030.gif"
                                        width="16" />
                                        </asp:LinkButton>
                                        <cc1:ConfirmButtonExtender  ID="btnAddResearch5_ConfirmButtonExtender"
                                        runat="server" ConfirmText="ยืนยันการลบข้อมูล" Enabled="True" 
                                        TargetControlID="btnDeletResearch5" >
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
                        <asp:Button ID="Add3_5" runat="server" CssClass="btn btn-success" 
                            Text="Add" OnClick="Add3_5_Click"/>
                    </td>
                </tr>

               <tr>
                    <td colspan="6" align="center">
                        <asp:Label ID="lblRecord5" runat="server" Font-Bold="true" CssClass="gray"></asp:Label>
                        
                        <br />
                        <asp:Label ID="lbl5Error0" runat="server" Font-Bold="False" CssClass="red"></asp:Label>
                        <br />
                    </td>
                </tr>

            </table>
        </ContentTemplate>
    </asp:UpdatePanel>    
    </div> 



<!-- ========================popup========================================================== -->
<asp:Label ID="lblPopupAddResearch3_5" runat="server" Height="100%" Width="100%"></asp:Label>
    <cc1:ModalPopupExtender ID="popupAddResearch3_5" runat="server" TargetControlID="lblPopupAddResearch3_5"
        PopupControlID="panelAddResearch3_5" DropShadow="false" BackgroundCssClass="modalBackground"
        Drag="True">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="panelAddResearch3_5" runat="server" CssClass="gray">
        <%--style="display:none;"--%>
        <asp:UpdatePanel ID="UpdatePanel3_5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modalPopup" style="padding: 10px;">
                    <div class="com_address">
                        <div class="headline" style="text-align: center">
                            <strong style="color: #593b00">Technical report </strong></div>
                        <table align="center" width="100%" class="gray">
                            
                            <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus5" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">หัวข้อ :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectTopic5" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectName5Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectTopic5"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_5"></asp:RequiredFieldValidator>
                                </td>
                            </tr>     
                          
                           <tr> 
                            <td align="right" valign="top">
                                    <span style="color: Red">*</span> <strong style="color: #003359">ประเภท :</strong>
                                </td>
                                <td valign="top">
                                     <asp:DropDownList ID="txtProjectType5" runat="server" AppendDataBoundItems="True" CssClass="gray"
                                            DataSourceID="sqlType5Add" DataTextField="ddlDisplay" DataValueField="ddlDisplay"
                                            Width="180" AutoPostBack="False" >
                                            <asp:ListItem Value="" >Select</asp:ListItem>
                                        </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlType5Add" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                    SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Develop3-5-Type' ORDER BY id">
                                </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="reqType5Add" runat="server" ControlToValidate="txtProjectType5"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="AddResearch3_5"></asp:RequiredFieldValidator>
                                    
                                </td>
                                </tr>
                             <tr>
                                <asp:HiddenField ID="hdf_ResearchStatus5" runat="server" />
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">%ที่ร่วม :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:TextBox ID="txtProjectJoint5" runat="server" CssClass="gray" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqProjectJoint5Add" runat="server" ErrorMessage="*" ControlToValidate="txtProjectJoint5"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_5"></asp:RequiredFieldValidator>
                                </td>
                            </tr>     
                              
                               <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารแนบแบ่ง % :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:FileUpload ID="FileUploadShare3_5" runat="server"  />
                                    <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server" ErrorMessage="*" ControlToValidate="FileUploadShare3_5"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_5"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server" style="color: #ff0000" ControlToValidate="FileUploadShare3_5" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_5"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>
                          
                            <tr>
                                <td valign="top" align="right">
                                    <span style="color: Red">*</span> <strong style="color: #003359">เอกสารTechnical report :</strong>
                                </td>
                                <td valign="top" width="150" colspan="2">
                                    <asp:FileUpload ID="FileUpload3_5" runat="server"  />
                                    <asp:RequiredFieldValidator ID="reqProjectFile5Add" runat="server" ErrorMessage="*" ControlToValidate="FileUpload3_5"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="AddResearch3_5"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="vldUploadDeparture5" runat="server" style="color: #ff0000" ControlToValidate="FileUpload3_5" 
                                     Display="Dynamic" ErrorMessage="*ระบุได้เฉพาะไฟล์ (PDF, Excel, Word)!!" SetFocusOnError="True" 
                                     ValidationExpression="^.+\.((docx)|(odt)|(doc)|(pdf)|(xlsx)|(xls))$" ValidationGroup="AddResearch3_5"></asp:RegularExpressionValidator> 
                                </td>
                            </tr>

                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblInError3_5" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" valign="top">
                                    <asp:Button ID="btnAddResearch5" runat="server" CssClass="txt_howtonav" Text="Submit"
                                        Width="100px" ValidationGroup="AddColor" OnClick="btnAddResearch_Click5" />
                                    <cc1:ConfirmButtonExtender ID="btnAddResearch5_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="ยืนยันการบันทึกข้อมูล" Enabled="True" 
                                        TargetControlID="btnAddResearch5">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="btnCancel5" runat="server" CausesValidation="False" CssClass="txt_howtonav"
                                        Text="Cancel" Width="100px" OnClick="btnCancelResearch_Click5" />
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

    <%-- //###############################EvaluateResearch3_5 end#####################################################
###############################################################################################################
#########################################################################################################################################################
#########################################################################################################################################################
//###############################EvaluateResearch3_6 Strat##################################################### --%>











        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddResearch" />
            <asp:PostBackTrigger ControlID="btnAddResearch2" />
            <asp:PostBackTrigger ControlID="btnAddResearch3" />
            <asp:PostBackTrigger ControlID="btnAddResearch4" />
            <asp:PostBackTrigger ControlID="btnAddResearch5" />
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>
