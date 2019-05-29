<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

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
                    <h2>สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</h2>
                    <p class="lead">Synchrotron Light Research Institute (Public Organization)</p>
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
                            <tr >
                                <td>&nbsp;</td>      
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
                                                     Text="ภาระงาน" Width="150px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt2" runat="server" CssClass="btn btn-info" OnClick="report2_Click"
                                                        Text="แบบรายงานผลการปฏิบัติงาน" Width="300px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="pt3" runat="server" CssClass="btn btn-info" OnClick="report3_Click"
                                                         Text="KPI" Width="150px" />
                                                         <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                   
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

