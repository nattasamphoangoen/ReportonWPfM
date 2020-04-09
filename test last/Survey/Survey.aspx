<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Survey.aspx.cs" Inherits="Survey" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <style>
                body, html {
                    background: url("/Images/bg-1.png")no-repeat;
                    background-size: cover;
                }
            </style>

      
                     

            <div class="jumbotron">
                <div class="jumbotron" style="padding:10px; background-color: #DCDCDC"  >
                    <h2>แบบสอบถาม</h2>
                    <p class="lead">ข้อมูลความคิดเห็น/ข้อเสนอแนะการทบทวน/ปรับปรุงแผนยุทธศาสตร์สถาบันวิจัยแสงซินโครตรอน ปีงบประมาณ 2562</p>
                </div>

                <p class="parts">ส่วนที่ 1 ข้อมูลสถานภาพผู้ตอบแบบสอบถาม </p>
                <div>
                    <p class="questions">1.1 เพศ </p>
                    <div class="answers2">
                        <asp:RadioButtonList ID="radSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1"> &nbsp;&nbsp;&nbsp;  <img src="/Images/b_1.png" style="width:40px;height:40px;" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:ListItem>
                            <asp:ListItem Value="2"> &nbsp;&nbsp;&nbsp;  <img src="/Images/g_1.png" style="width:40px;height:40px;"/></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="reqSex" runat="server" ControlToValidate="radSex" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"><span style="color: Red">* กรุณากรอกข้อมูลเพศ</span></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div>
                    <p class="questions">1.2 ช่วงอายุ</p>
                    <div class="answers2">
                        <asp:RadioButtonList ID="radAge" runat="server" DataSourceID="sqlAge" DataTextField="DDLValue" 
                             DataValueField="DDLCode" RepeatColumns="3" RepeatDirection="Horizontal" Height="100" Width="300" >
                             </asp:RadioButtonList>
                       
                       

                        <asp:SqlDataSource ID="sqlAge" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                            SelectCommand="SELECT [DDLId], [DDLCode], [DDLType], [DDLValue], [DDLOrder], [DDLStatus]
                                                            FROM [SurveyUO].[dbo].[DDL]
                                                            WHERE [DDLStatus]= 'A'  AND [DDLType] = 'Age' 
                                                            ORDER BY [DDLOrder]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Y" Name="Status" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <%--<asp:RadioButtonList ID="radAge" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="2"> &nbsp;&nbsp;&nbsp;2. 20 – 30 ปี</asp:ListItem>
                            <asp:ListItem Value="3"> &nbsp;&nbsp;&nbsp;3. 31 – 40 ปี</asp:ListItem>
                            <asp:ListItem Value="4"> &nbsp;&nbsp;&nbsp;4. 41 - 50 ปี</asp:ListItem>
                            <asp:ListItem Value="5"> &nbsp;&nbsp;&nbsp;5. 51 – 60 ปี</asp:ListItem>
                            <asp:ListItem Value="6"> &nbsp;&nbsp;&nbsp;6. 61 ปีขึ้นไป</asp:ListItem>
                        </asp:RadioButtonList> --%>
                        <asp:RequiredFieldValidator ID="reqAge" runat="server" ControlToValidate="radAge" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"><span style="color: Red">* กรุณากรอกข้อมูลอายุ</span></asp:RequiredFieldValidator>
                    </div>



                </div>

                <div>
                    <p class="questions">1.3 Beamline </p>
                    <div class="answers2">

                        <asp:RadioButtonList ID="radPosition" runat="server" DataSourceID="sqlPosition" DataTextField="DDLValue"
                            DataValueField="DDLCode" RepeatColumns="3" RepeatDirection="Horizontal" Height="100" Width="300" >
                        </asp:RadioButtonList>
                        <asp:SqlDataSource ID="sqlPosition" runat="server" ConnectionString="<%$ ConnectionStrings:SLRIConnectionString %>"
                            SelectCommand="SELECT [DDLId], [DDLCode], [DDLType], [DDLValue], [DDLOrder], [DDLStatus]
                                                            FROM [SurveyUO].[dbo].[DDL]
                                                            WHERE [DDLStatus]= 'A'  AND [DDLType] = 'BL'
                                                            ORDER BY [DDLOrder]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Y" Name="Status" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                       <asp:RequiredFieldValidator ID="reqPosition" runat="server" ControlToValidate="radPosition" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"><span style="color: Red">* กรุณากรอกข้อมูลอายุ</span></asp:RequiredFieldValidator>
                     ​
                                
                    </div>
                </div>
                <hr width="100%" size="200" color="black" align="center">
                <p>
                <p class="parts">ส่วนที่ 2 ประเมินความถึงพอใจ</p>
                <div>
                    <p class="questions">2.1 คุณมีความพึงพอใจต่อการบริการใช้งานแสงซินโครตรอน</p>
                    <div class="answers">
                        <asp:RadioButtonList ID="radEducation" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="5"> &nbsp;&nbsp;<img src="/Images/e_1.png" style="width:40px;height:40px;" />&nbsp;&nbsp;&nbsp; </asp:ListItem>
                            <asp:ListItem Value="4"> &nbsp;&nbsp;<img src="/Images/e_2.png" style="width:40px;height:40px;" />&nbsp;&nbsp;&nbsp; </asp:ListItem>
                            <asp:ListItem Value="3"> &nbsp;&nbsp;<img src="/Images/e_3.png" style="width:40px;height:40px;" />&nbsp;&nbsp;&nbsp; </asp:ListItem>
                            <asp:ListItem Value="2"> &nbsp;&nbsp;<img src="/Images/e_4.png" style="width:40px;height:40px;" />&nbsp;&nbsp;&nbsp; </asp:ListItem>
                            <asp:ListItem Value="1"> &nbsp;&nbsp;<img src="/Images/e_5.png" style="width:40px;height:40px;" />&nbsp;&nbsp;&nbsp; </asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="reqEducation" runat="server" ControlToValidate="radEducation" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"><span style="color: Red">* กรุณาให้ความเห็นความพึงพอใจ</span></asp:RequiredFieldValidator>
                    </div>

                </div>

                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;

                
            <div class="form-group">
                <div class="col-md-offset-1">
                    <asp:Button runat="server" OnClick="Next_Click" Text="Submit" CssClass="btn btn-primary btn-lg" />
                </div>
            </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
