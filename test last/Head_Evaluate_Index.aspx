<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Head_Evaluate_Index.aspx.cs" Inherits="Head_Evaluate_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table align="center" width="100%" class="gray">
                            <tr>
                                <td width="170" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="120" class="auto-style1"></td>
                                <td width="118" class="auto-style1"></td>
                            </tr>
                            <tr class="lead">
                                <td colspan="6" align="center" class="txt_title_rewards">เลือกรายงานผลการปฏิบัติงาน</td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Panel ID="PanelSearch" runat="server">
                                        <table align="center" width="100%" class="gray">
                                           
                                            
                                            <tr>
                                                <td>&nbsp;</td>                                                
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" >
                                                    <asp:Button ID="report1" runat="server" CssClass="btn btn-info" OnClick="report1_Click" 
                                                     Text="1.งานให้บริการ" Width="150px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt2" runat="server" CssClass="btn btn-info" OnClick="report2_Click"
                                                        Text="2.งานพัฒนาและบำรุงรักษา" Width="300px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt3" runat="server" CssClass="btn btn-info" OnClick="report3_Click"
                                                         Text="3.งานวิจัย" Width="150px" />
                                                         <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" valign="top">
                                                    <asp:Button ID="pt4" runat="server" CssClass="btn btn-info" OnClick="report4_Click"
                                                         Text="4.งานส่งเสริมการใช้แสง" Width="160px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt5" runat="server" CssClass="btn btn-info" OnClick="report5_Click"
                                                         Text="5.งานบริการวิชาการ" Width="160px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt6" runat="server" CssClass="btn btn-info" OnClick="report6_Click"
                                                          Text="6.งานบริหารจัดการ" Width="160px" />
                                                        <tr>
                                                                <td>&nbsp;</td>
                                                        </tr>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" valign="top">
                                                    <asp:Button ID="pt7" runat="server" CssClass="btn btn-info" OnClick="report7_Click"
                                                         Text="7.งานอื่นๆ" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                






                

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>

