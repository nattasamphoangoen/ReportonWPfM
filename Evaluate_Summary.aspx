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
                                <asp:LinkButton ID="reportSummary" runat="server" Text='' title="Summary"
                                    OnClick="reportSummary_Click">
                                    <img id="report" alt="" border="0" height="20" name="popcal" src="Images/Summary.png"
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



                <div align="center">
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">Evaluation Period : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_round" runat="server" Text=''>
                                </asp:Label>
                                <asp:Label ID="lbl_and" runat="server" Text='/'>
                                </asp:Label>
                                <asp:Label ID="lbl_Year" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">From : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_Datestart" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #000000" class="h4">To : </strong>
                        </td>

                        <td valign="top" align="center">
                            <strong style="color: #2300a1" class="h4">
                                <asp:Label ID="lbl_Dateend" runat="server" Text=''>
                                </asp:Label>
                            </strong>
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


                <table align="center" width="100%" border="1">
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h4">
                                <asp:Label ID="lblWork" runat="server" Text='งาน'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h4">
                                <asp:Label ID="lblScore" runat="server" Text='คะเเนน'>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>


                    <!-- 1_1 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs1_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE1_1" runat="server"
                                    Text='1.1. งาน Local contact (Experimental setup, Sample preparation, and Measurement) งานสอบเทียบเครื่องมือและมาตรฐานการวัด'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore1_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE1_2" runat="server" Text='1.2. งานให้บริการภาคอุตสาหกรรม'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore1_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE1_3" runat="server"
                                    Text='1.3. งานเป็นที่ปรึกษาให้กับผู้ใช้บริการแสงซินโครตรอน / ภาคอุตสาหกรรม'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore1_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE1_4" runat="server" Text='1.4. Technical manual (*)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore1_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE1_5" runat="server"
                                    Text='1.5. Standard protocol (คู่มือกระบวนการดำเนินงาน)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore1_5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>


                    <!-- 1_2  -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs2_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_1" runat="server" Text='2.1. Journal publication (ISI/Scopus)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_2" runat="server" Text='2.2. Conference proceeding'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_3" runat="server"
                                    Text='2.3. ยื่นขอจดสิทธิบัตร (ปตท./ไทย) /  ยื่นขอจดอนุสิทธิบัตร'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_4" runat="server"
                                    Text='2.4. Oral  (ตปท./ไทย) / Poster Presentation (ตปท./ไทย)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_5" runat="server" Text='2.5. Technical report '>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_6" runat="server" Text='2.6. ผลงานการพัฒนาที่นำไปใช้จริง'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_6" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>

                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_6_1" runat="server"
                                    Text='2.6.1 ออกแบบระบบลำเลียงแสง / ออกแบบสถานีทดลอง /ติดตั้งและทดสอบระบบลำเลียงแสง'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_6_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_6_2" runat="server"
                                    Text='2.6.2 ออกแบบเครื่องมือตรวจวัดและอุปกรณ์ต่างๆ / ปรับปรุงระบบทัศนศาสตร์ของระบบลำเลียงแสง'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_6_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_7" runat="server"
                                    Text='2.7. วิทยานิพนธ์ (ที่เป็นอาจารย์ที่ปรึกษา/อาจารย์ที่ปรึกษาร่วม) '>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_7" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE2_8" runat="server"
                                    Text='2.8. การเข้าร่วมประชุมเชิงปฏิบัติการและฝึกอบรมทั้งในและต่างประเทศ ที่เกี่ยวข้องกับการพัฒนาและบำรุงรักษาระบบลำเลียงแสง หรือสถานีทดลอง หรือห้องปฏิบัติการต่าง ๆ (Technical training, training on the job)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore2_8" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>



                    <!-- 1_3 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs3_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_1" runat="server" Text='3.1. Journal publication (ISI/Scopus)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_2" runat="server" Text='3.2. Conference proceeding '>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_3" runat="server"
                                    Text='3.3. ยื่นขอจดสิทธิบัตร (ปตท./ไทย) /  ยื่นขอจดอนุสิทธิบัตร'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_4" runat="server"
                                    Text='3.4. Oral  (ตปท./ไทย) / Poster Presentation (ตปท./ไทย)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_5" runat="server"
                                    Text='3.5. รายงานฉบับสมบูรณ์ (ภาควิชาการ ภาคอุตสาหกรรม)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_6" runat="server" Text='3.6. ผลิตภัณฑ์ที่เกิดจากงานวิจัย'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_6" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_7" runat="server"
                                    Text='3.7. รายงานความก้าวหน้า (Progress report) ที่ระบุเนื้อหาระหว่างดำเนินงานวิจัยที่ได้รับมอบหมาย โดยระบุเนื้อหาระหว่างดำเนินงานอย่างมีรายละเอียด (เช่น รอบ 3 เดือน/6 เดือน/12 เดือน)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_7" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_8" runat="server"
                                    Text='3.8. วิทยานิพนธ์ (ที่เป็นอาจารย์ที่ปรึกษา/อาจารย์ที่ปรึกษาร่วม)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_8" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE3_9" runat="server"
                                    Text='3.9. ทุนวิจัยที่ได้รับจากหน่วยงานภายนอก (เฉพาะทุนที่เจ้าหน้าที่สถาบันฯ เป็นหัวหน้าโครงการ เช่น Talent mobility fund) รวมทุน ITAP ทุน FI (โดยเจ้าหน้าที่สถาบันฯ ให้คะแนนทุกคนจากการหารตามสัดส่วนที่รับผิดชอบโครงการ) และรายได้จากการบริการ '>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore3_9" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>


                    <!-- E4_1 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs4_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_1" runat="server"
                                    Text='4.1. การจัดการประชุมเชิงปฏิบัติการและการฝึกอบรม (Workshop, Training) การร่วมเตรียมงาน (ทั้งประธานและคณะทำงาน) / การมีส่วนร่วมในวันงาน'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_2" runat="server"
                                    Text='4.2. งานเขียนบทความ (Annual report, Research Highlight, Annual review, Poster นิทรรศการ)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_3" runat="server"
                                    Text='4.3. การเป็นวิทยากรรับเชิญ (Invited lecturer) (โดยสถาบัน / หน่วยงานในประเทศ / หน่วยงานต่างประเทศ)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_4" runat="server"
                                    Text='4.4. การให้สัมภาษณ์ผ่านสื่อต่าง ๆ เช่น รายการโทรทัศน์ วิทยุ หนังสือพิมพ์ (หากเป็นผลงานกลุ่ม ให้ทีมงานได้คะแนนด้วย)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_5" runat="server"
                                    Text='4.5. การประสานความร่วมมือเพื่อให้เกิดบันทึกความเข้าใจระหว่างสถาบันกับหน่วยงานอื่น ๆ (MOU initiation)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE4_6" runat="server"
                                    Text='4.6.  ข้อเสนอโครงการเพื่องานวิจัยภาคอุตสาหกรรม (ลงนามสัญญาจ้าง)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore4_6" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <!-- E5_1 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs5_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE5_1" runat="server"
                                    Text='5.1. คณะกรรมการงานประชุมวิชาการระดับนานาชาติ-ระดับชาติ'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore5_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE5_2" runat="server" Text='5.2. การเป็นอาจารย์ที่ปรึกษาร่วม'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore5_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE5_3" runat="server" Text='5.3. งานสอบวิทยานิพนธ์'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore5_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE5_4" runat="server"
                                    Text='5.4. ประเมินโครงการใช้แสงซินโครตรอน (BLM และ BLS)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore5_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE5_5" runat="server"
                                    Text='5.5. งานบริการวิชาการและสังคม (กรณีไม่มีค่าตอบแทน)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore5_5" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>


                    <!-- E6_1 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs6_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore6" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE6_1" runat="server" Text='6.1. งาน BLM และรับผิดชอบระบบลำเลียงแสง'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore6_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>

                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE6_1_1" runat="server"
                                    Text='6.1.1. การบำรุงรักษา ให้บริการ ดำเนินงานวิจัยและพัฒนา ณ ระบบลำเลียงแสง โดยพิจารณาจากเอกสาร % Utilization'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore6_1_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE6_1_2" runat="server"
                                    Text='6.1.2. จำนวนโครงการที่เข้ามาใช้บริการแสงซินโครตรอน และห้องปฏิบัติการสนับสนุน'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore6_1_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE6_2" runat="server"
                                    Text='6.2. การเป็นหัวหน้าโครงการและโครงการอุตสาหกรรม'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore6_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <!-- 7_1 -->
                    <tr>
                        <td valign="top">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblEs7_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #001aff" class="h5">
                                <asp:Label ID="lblsumscore7" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE7_1" runat="server"
                                    Text='7.1. การเป็นคณะกรรมการ/คณะทำงาน (สัมมนา ประเมินความสุข ปีใหม่ กีฬา พัสดุ มหกรรมวิทย์ ฯลฯ)'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore7_1" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE7_2" runat="server" Text='7.2. การต้อนรับแขกและนำเยี่ยมชมสถาบันฯ'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore7_2" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE7_3" runat="server"
                                    Text='7.3. คณะกรรมการร่าง TOR เฉพาะอุปกรณ์ที่มีความซับซ้อน ที่สถาบันฯ ไม่เคยซื้อมาก่อน'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore7_3" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblE7_4" runat="server" Text='7.4. คณะกรรมการตรวจนับพัสดุ'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #000000" class="h5">
                                <asp:Label ID="lblscore7_4" runat="server" Text=''>
                                </asp:Label>
                            </strong>
                        </td>
                    </tr>

                    <!-- sum -->

                    <tr>
                        <td valign="top" align="right">
                            <strong style="color: #ff0000" class="h5">
                                <asp:Label ID="lblALLScore" runat="server" Text='คะแนนรวมทั้งหมด'>
                                </asp:Label>
                            </strong>
                        </td>
                        <td valign="top" align="right">
                            <strong style="color: #ff0000" class="h5">
                                <asp:Label ID="lblSUMALL" runat="server" Text=''>
                                </asp:Label>
                            </strong>
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