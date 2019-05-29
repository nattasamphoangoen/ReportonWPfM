<%@ Page Title="EvaluateSummary" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Evaluate_Summary.aspx.cs" Inherits="Evaluate_Summary" Async="true" %>

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
                <div class="jumbotron" style="padding: 10px; background-color: #DCDCDC" align="center">
                    <h2>สถาบันวิจัยแสงซินโครตรอน (องค์การมหาชน)</h2>
                    <p class="lead">Synchrotron Light Research Institute (Public Organization)</p>
                    <p class="lead">แบบรายงานผลการปฏิบัติงาน (Report on Work Performance)</p>

                    <div colspan="2" align="right">
                        <tr>
                            <td>
                                <asp:LinkButton ID="reportSummary" runat="server" Text='' OnClick="reportSummary_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal"
                                        src="Images/Summary.png" width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report1" runat="server" Text='' OnClick="report1_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n1.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report2" runat="server" Text='' OnClick="report2_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n2.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report3" runat="server" Text='' OnClick="report3_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n3.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report4" runat="server" Text='' OnClick="report4_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n4.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report5" runat="server" Text='' OnClick="report5_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n5.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report6" runat="server" Text='' OnClick="report6_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n6.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:LinkButton ID="report7" runat="server" Text='' OnClick="report7_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/n7.png"
                                        width="20" />
                                </asp:LinkButton>
                            </td>
                        </tr>

                    </div>
                </div>



                <div align="center">
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">Evaluation Period : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">1/2561</strong>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">From : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">1 September 2017 </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">To : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">28 February 2018</strong>
                        </td>
                    </tr>

                    <br />
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">Name : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_FullName" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <br />
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">Position : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_Position" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td>&nbsp;</td>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">ระดับ Level : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">.........

                            </strong>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">Department : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_Department" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td align="right" valign="top">
                            <strong style="color: #000000" class="h4">ส่วนปฏิบัติการระบบลำเลียงแสง :</strong>
                        </td>
                        <td valign="top">
                            <asp:DropDownList ID="txtProjectClass3" runat="server" AppendDataBoundItems="True"
                                CssClass="gray" DataSourceID="sqlClassAdd" DataTextField="ddlDisplay"
                                DataValueField="ddlValue" Width="300" AutoPostBack="False">
                                <asp:ListItem Value="">-- Please Select --</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="sqlClassAdd" runat="server"
                                ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                                SelectCommand="SELECT id, ddlDisplay, ddlValue, ddlType  FROM MasterDDL WHERE ddlType = 'Summary-Type' ORDER BY id">
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="reqClassAdd" runat="server"
                                ControlToValidate="txtProjectClass3" Display="Dynamic" ErrorMessage=""
                                SetFocusOnError="True" ValidationGroup="AddServeice1_3"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <br />

                    <tr>
                        <td>&nbsp;</td>
                    </tr>

                </div>


                <div align="left">
                    <tr>

                        <td valign="top">
                            <strong style="color: #000000" class="h4">คะแนนส่วนบุคคล 65% : </strong>
                        </td>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                        <td valign="top">
                            <strong style="color: #2300a1" class="h4">0.00 </strong>
                        </td>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <td valign="top">
                        <strong style="color: #2300a1" class="h4">0.00 </strong>
                    </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">คะแนนกลุ่ม/ส่วนงาน 25% : </strong>
                        </td>
                        <td>&nbsp;</td>

                        <td valign="top">
                            <strong style="color: #2300a1" class="h4">0.00 </strong>
                        </td>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <td valign="top">
                        <strong style="color: #2300a1" class="h4">0.00 </strong>
                    </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">พฤติกรรมการทำงาน 10% : </strong>
                        </td>
                        <td>&nbsp;</td>
                        <td valign="top">
                            <strong style="color: #2300a1" class="h4">0.00 </strong>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">คะแนนรวมทั้งหมด : </strong>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td valign="top">
                            <strong style="color: #2300a1" class="h4">0.00 </strong>
                        </td>
                    </tr>
                    <br />
                </div>


                <div align="right">
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">Signature</strong>
                        </td>

                        <td valign="top">
                            <strong style="color: #000000" class="h4">…………………………………………………………….</strong>
                        </td>

                    </tr>
                    <br />

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">(…………………………………………………………..)</strong>
                        </td>

                    </tr>
                    <br />
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">………………./……………../………………..</strong>
                        </td>


                    </tr>
                    <br />
                </div>

                <br />
                <br />


                <table align="center" width="100%">
                    <tr>
                        <td colspan="6" align="Left">
                            <asp:GridView ID="gvData" runat="server" Width="900px" AllowPaging="True"
                                OnPageIndexChanging="gvData_PageIndexChanging" AllowSorting="True"
                                OnSorting="gvData_Sorting" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="gvData_RowDataBound" ForeColor="#333333" GridLines="None"
                                DataKeyNames="id" PageSize="50" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
                                <PagerSettings FirstPageText="&amp;lt;&amp;lt;First" LastPageText="Last&amp;gt;&amp;gt;"
                                    NextPageText="Next&amp;gt;" PreviousPageText="&amp;lt;Previous" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" CssClass="gray"
                                    HorizontalAlign="Left" />
                                <PagerStyle Wrap="True" CssClass="gray" BackColor="#DEDEFF" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#C8DCFF" Font-Bold="True" ForeColor="Navy"
                                    HorizontalAlign="Left" />
                                <HeaderStyle Font-Size="Small" BackColor="#ABCDEF" Font-Bold="True"
                                    CssClass="txt_howtonav" HorizontalAlign="Left" ForeColor="#005aa9" />
                                <AlternatingRowStyle BackColor="#DAEAFF" CssClass="gray" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" SortExpression="id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id2" runat="server" Text='<%# Bind("id") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ที่" ItemStyle-Width="5px" Visible="False">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdf_ProjectStatus" runat="server"
                                                Value='<%# Bind("id") %>'></asp:HiddenField>
                                            <asp:Label ID="lbl_DataItemIndex" runat="server"
                                                Text='<%# Container.DataItemIndex + 1 %>' Font-Size="Small">
                                            </asp:Label>
                                            <%--<%# Container.DataItemIndex + 1 %>--%>
                                        </ItemTemplate>
                                        <ItemStyle Width="1px" />
                                    </asp:TemplateField>

                                    <asp:BoundField HeaderText="งาน"
                                        DataField="E1_1" ItemStyle-Width="250px">
                                        <ItemStyle Width="250px" Font-Size="Small" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="คะแนน" DataField="score1_1" ItemStyle-Width="50px">
                                        <ItemStyle Width="50px" Font-Size="Small" />
                                    </asp:BoundField>






                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="6" align="center">
                            <asp:Label ID="lblRecord" runat="server" Font-Bold="true" CssClass="gray">
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
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent3" Runat="Server">
</asp:Content>