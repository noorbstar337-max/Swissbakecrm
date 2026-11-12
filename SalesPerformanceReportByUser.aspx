<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="SalesPerformanceReportByUser.aspx.vb" Inherits="SalesPerformanceReportByUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tableftright {

  border-left: #D9416C 1px solid;
  border-right: #D9416C 1px solid;
  BORDER-TOP: #D9416C 1px solid;
  BORDER-BOTTOM: #D9416C 1px solid;
}
        .Headerfont2 {
        background-color: #352b4e;color:white;}
        .Headerfont1{  background-color: #eb6a8e;color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="hi hi-tasks" style="margin: -8px"></i>Custom Report<br>

                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Custom Report</li>

            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Custom Report</strong> Detail</h2>
                </div>

                 <div class="col-md-12" style="margin-bottom: 28px;">
                               <label class="col-md-1 control-label" for="example-hf-password">User</label>
                                <div class="col-md-3">
                                     
                                    <asp:DropDownList ID="ddusertype" runat="server" AutoPostBack="true" data-toggle="tooltip" title="User" CssClass="form-control">
                                      
                                       <%-- <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                        <asp:ListItem Value="Potential">Potential</asp:ListItem>
                                        <asp:ListItem Value="Vendor">Vendor</asp:ListItem>
                                        <asp:ListItem Value="Quote">Quote</asp:ListItem>--%>
                                    </asp:DropDownList>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddrelatedtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please enter  Task name" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                </div>
                     <label class="col-md-1 control-label" for="example-hf-password">Duration</label>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <div class="col-md-4">
                                     <div class="col-md-12" style="padding:0px;">
                                         <div class="col-md-6" style="padding:0px;"> <asp:TextBox ID="txtstartdate" runat="server" class="form-control" TextMode="Date" Text="01-03-2015"/></div>
                                         <div class="col-md-6" style="padding:0px;"><asp:TextBox ID="txtenddate" runat="server" class="form-control" TextMode="Date"/></div>
                                     </div>
                                    
                                     
                                </div>
                         </ContentTemplate>
                         <Triggers>
                             <asp:PostBackTrigger ControlID="ddusertype"/>
                              <asp:PostBackTrigger ControlID="btnreport"/>
                         </Triggers>
                     </asp:UpdatePanel>
                                
                                   <div class="col-md-3">
                                        <asp:LinkButton ID="btnreport" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                UseSubmitBehavior="false" class="btn btn-sm btn-primary" Visible="false"><i class="fa fa-share"></i>Report</asp:LinkButton>
                                        <asp:LinkButton ID="btnshow" runat="server" class="btn btn-sm btn-primary">Show All</asp:LinkButton>
                                         <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" style="margin-right:10px" Width="33px" ImageAlign ="Right" runat="server" ImageUrl="~/images/excel.gif" />
                    
                                   </div>
</div>
                <div class="col-md-12" style="margin-bottom: 22px;overflow:auto;">
                    <table  class="tableftright" cellspacing="0" cellpadding="2" border="1" bordercolor="#DDDDFF" width="100%" style="border-collapse: collapse;">
                        <tr class="tabhearerbg">
                            <td class="Headerfont2" width="100" height="21" style="TEXT-ALIGN: CENTER;word-wrap:break-word;"><p style="color:#black;">Salesperson</p></td>
                            <td class="Headerfont2" width="200" height="21" style="text-align: CENTER; word-wrap: break-word;" colspan="3">
                                <p style="color: #black;">Leads</p>
                            </td>
                            <td class="Headerfont2" width="200" height="21" style="text-align: CENTER; word-wrap: break-word; " colspan="2">
                                <p style="color: #black;">Opp</p>
                            </td>
                            <td class="Headerfont2" width="200" height="21" style="text-align: CENTER; word-wrap: break-word;" colspan="2">
                                <p style="color: #black;">Qtn</p>
                            </td>

                            <td class="Headerfont2" width="200" height="21" style="text-align: CENTER; word-wrap: break-word;" colspan="2">
                                <p style="color: #black;">Order</p>
                            </td>

                        </tr>
                        <tr class="tabhearerbg">

                            <td class="Headerfont1" width="100" height="21" style="TEXT-ALIGN: CENTER;word-wrap:break-word;"><p style="color:#black;"></p></td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word; ">
                                <p style="color: #black;">Active</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word;">
                                <p style="color: #black;">New</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word; ">
                                <p style="color: #black;">Dropped</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word; ">
                                <p style="color: #black;">No</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word;">
                                <p style="color: #black;">Value</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word;" nowrap="">
                                <p style="color: #black;">No</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="text-align: CENTER; word-wrap: break-word; " nowrap="">
                                <p style="color: #black;">Value</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="TEXT-ALIGN: CENTER;word-wrap:break-word;" nowrap="">
                                <p style="color: #black;">No</p>
                            </td>
                            <td class="Headerfont1" width="80" height="21" style="TEXT-ALIGN: CENTER;word-wrap:break-word;" nowrap="">
                                <p style="color: #black;">Value</p>
                            </td>


                        </tr>
                        <asp:Repeater ID="rplead" runat="server">
                            <ItemTemplate>
                                <tr height="1">
                                    <td class="tdbottom" height="23" nowrap="" style="text-align: center;border-right:3px solid #8EADC2;" width="80"><p> <asp:Literal ID="ltusername" Text='<%#Eval("U_FirstName")%>' runat="server"></asp:Literal></p></td>
                                    <td class="tdbottom" height="23" nowrap="" style="text-align: center" width="80">
                                        <p>&nbsp;<asp:Literal ID="ltactive" runat="server"></asp:Literal><asp:Literal ID="ltid"  Text='<%#Eval("U_ID")%>' Visible="false" runat="server"></asp:Literal></p>
                                    </td>
                                    <td class="tdbottom" height="23" nowrap="" style="text-align: center" width="80">
                                        <p>&nbsp;<asp:Literal ID="ltlnew" runat="server"></asp:Literal></p>
                                    </td>
                                    <td class="tdbottom" height="23" nowrap="" style="text-align: center; border-right: 3px solid #B6C6E6;" width="80">
                                        <p>&nbsp;<asp:Literal ID="ltclose" runat="server"></asp:Literal></p>
                                    </td>
                                    <td class="tdbottom" height="23" nowrap="" style="text-align: center" width="80">
                                        <p>&nbsp;<asp:Literal ID="ltopcount" runat="server"></asp:Literal></p>
                                    </td>

                                    <td class="tdbottom" height="23" nowrap="" align="right" width="80" style="color: #000066; text-align: right; border-right: 3px solid #B6C6E6;">&nbsp;<asp:Literal ID="ltoprevenue" runat="server"></asp:Literal></td>
                                    <td class="tdbottom" height="23" nowrap="" align="center" width="80">
                                        <asp:Literal ID="ltquocount" runat="server"></asp:Literal></td>

                                    <td class="tdbottom" height="23" nowrap="" align="right" width="80" style="color: #000066; text-align: right; border-right: 3px solid #B6C6E6;">&nbsp;<asp:Literal ID="ltquoamount" runat="server"></asp:Literal></td>
                                    <td class="tdbottom" height="23" nowrap="" align="center" width="80"><font style="font-family: verdana; font-size: 8pt;"></font>&nbsp;<asp:Literal ID="ltordercount" runat="server"></asp:Literal></td>
                                    <td class="tdbottom" height="23" nowrap="" align="right" width="80" style="color: #000066; border-right: 3px solid #B6C6E6;">&nbsp;<asp:Literal ID="ltorderamount" runat="server"></asp:Literal></td>


                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div style="clear: both"></div>
            </div>
        </ContentTemplate>
        <Triggers>
           
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

